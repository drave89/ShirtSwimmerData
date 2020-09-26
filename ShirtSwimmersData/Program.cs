using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

using Flurl;
using Polly;
using Flurl.Http;

using ShirtSwimmersData.Common;
using ShirtSwimmersData.BusinessLogicLayer;
using System.Linq;

namespace ShirtSwimmersData
{
    class Program
    {
        static void Main(string[] args)
        {
            RunScript().Wait();
        }

        static async Task RunScript()
        {
            var start_time = DateTime.Now;

            Utility.InitializeComponents();
            Utility.LogInfo("".PadRight(60, '='), true);
            Utility.LogInfo("Start time: " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), true);
            Utility.LogInfo("".PadRight(60, '='), true);

            try
            {
                var match_ids = await GetPlayerMatches();
                var highest_match_id = SQL.GetHighestMatchId();

                // Only need to insert the ones we haven't seen before.
                match_ids = match_ids.Where(m => m > highest_match_id).ToList();

                ParseMatches(match_ids.OrderBy(z => z).ToList()).Wait();

                Utility.LogInfo("");
                Utility.LogInfo(match_ids.Count() + " games parsed.", true);
            } 
            catch (Exception ex)
            {
                Utility.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    Utility.LogError(ex.InnerException.Message);
                }
            }

            TimeSpan ts = DateTime.Now - start_time;
            int hourDiff = ts.Hours;
            int minDiff = ts.Minutes;
            int secDiff = ts.Seconds;

            Utility.LogInfo("ShirtSwimmers program completed in " + hourDiff.ToString().PadLeft(2, '0') + ":" + minDiff.ToString().PadLeft(2, '0') + ":" + secDiff.ToString().PadLeft(2, '0'), true);
            Console.ReadLine();
        }

        static async Task<List<long>> GetPlayerMatches()
        {
            List<long> match_ids = new List<long>();
            List<string> the_boyz = new List<string>()
            {
                ConfigurationManager.AppSettings["ScottId"],
                ConfigurationManager.AppSettings["DominicId"],
                ConfigurationManager.AppSettings["BlairId"],
                ConfigurationManager.AppSettings["GeorgeId"],
                ConfigurationManager.AppSettings["KieferId"],
                ConfigurationManager.AppSettings["NickId"],
                ConfigurationManager.AppSettings["BenId"]
            };

            foreach (var boy in the_boyz)
            {
                string url = Url.Combine(
                    ConfigurationManager.AppSettings["OpenDotaBaseUrl"],
                    "players",
                    boy,
                    "matches"
                );

                var result = await ExecuteAsnycGet<List<PlayerMatches>>(url);
                foreach (var match in result) {
                    if (!match_ids.Contains(match.match_id))
                    {
                        match_ids.Add(match.match_id);
                    }
                }
            }

            return match_ids;
        }

        static async Task ParseMatches(List<long> match_ids)
        {
            foreach (var match_id in match_ids)
            {
                // API only allows a certain number of requests
                string url = Url.Combine(
                    ConfigurationManager.AppSettings["OpenDotaBaseUrl"],
                    "matches",
                    match_id.ToString()
                );

                var match = await ExecuteAsnycGet<Match>(url);

                SQL.AddMatch(match);
                foreach (var player in match.players)
                {
                    SQL.AddPlayer(player);
                }
            }
        }

        static async Task<T> ExecuteAsnycGet<T>(string url)
        {
            // API is throttled at 60 queries per minute, so we add a retry with wait
            Utility.LogInfo(url);
            return await Policy
                .Handle<FlurlHttpException>(IsWorthRetrying)
                .WaitAndRetryAsync(new[] {
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(30),
                },
                (result, timeSpan, retryCount, context) =>
                {
                    Utility.LogDebug($"Request failed with {result.Message}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                })
                .ExecuteAsync(() => url
                .WithTimeout(60)
                .SetQueryParam("significant", 0)
                .GetJsonAsync<T>());
        }

        /// <summary>
        /// this function works with Polly to retry requests that match these StatusCodes
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        static bool IsWorthRetrying(FlurlHttpException ex)
        {
            if (ex.Call.Response == null)
            {
                // Likely server unavailable exception, worth retrying
                return true;
            }

            switch ((int)ex.Call.Response.StatusCode)
            {
                case 401:
                case 404:
                case 408:
                case 429:
                case 500:
                case 502:
                case 503:
                case 504:
                    return true;
                default:
                    return false;
            }
        }
    }
}
