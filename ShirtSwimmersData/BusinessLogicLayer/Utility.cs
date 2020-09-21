using Flurl.Http;
using log4net;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirtSwimmersData.BusinessLogicLayer
{
    public static class Utility
    {
        public static List<string> ErrorList = new List<string>();
        private static readonly ILog Log = LogManager.GetLogger("ShirtSwimmers");

        public static void InitializeComponents()
        {
            // Initialize logger
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void LogInfo(string msg, bool line_break = false)
        {
            // Write to console and the file log
            Console.WriteLine(msg);
            Log.Info(msg);

            if (line_break)
            {
                Console.WriteLine("");
                Log.Info("");
            }
        }

        public static void LogDebug(string msg, bool line_break = false)
        {
            // Add to file log with Debug level
            Log.Debug(msg);
            if (line_break)
            {
                Log.Debug("");
            }
        }

        public static void LogError(string msg, bool line_break = false)
        {
            // Write to console and the file log, store the error
            ErrorList.Add(msg);
            Console.WriteLine(msg);
            Log.Error(msg);

            if (line_break)
            {
                Console.WriteLine("");
                Log.Error("");
            }
        }
    }
}
