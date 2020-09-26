using ShirtSwimmersData.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace ShirtSwimmersData.BusinessLogicLayer
{
    public static class SQL
    {
        public static long GetHighestMatchId()
        {
            long result = 0;
            string query = "SELECT MAX(match_id) FROM dbo.Matches";

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShirtSwimmers"].ToString())) {
                var command = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        result = reader.GetInt64(0);
                    }
                }

                reader.Close();
            }

            return result;
        }

        public static void AddMatch(Match match)
        {
            string query = "INSERT INTO [Shirtswimmers].[dbo].[Matches] VALUES (";
            query += match.match_id.ToString() + ",";
            query += FormatNullableInt(match.dire_score) + ",";
            query += FormatNullableInt(match.radiant_score) + ",";
            query += FormatNullableInt(match.duration) + ",";
            query += FormatNullableInt(match.game_mode) + ",";
            query += FormatNullableInt(match.lobby_type) + ",";
            query += FormatNullableInt(match.skill) + ",";
            query += FormatNullableInt(match.start_time) + ",";
            query += FormatNullableInt(match.tower_status_dire) + ",";
            query += FormatNullableInt(match.tower_status_radiant) + ",";
            query += (match.radiant_win == null ? "NULL" : "1") + ",";
            query += FormatNullableInt(match.patch) + ",";
            query += FormatNullableInt(match.region) + ")";

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShirtSwimmers"].ToString()))
            {
                conn.Open();
                var command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public static void AddPlayer(Player player)
        {
            string query = "INSERT INTO [Shirtswimmers].[dbo].[Players] VALUES (";
            query += player.match_id.ToString() + ",";
            query += FormatNullableInt(player.player_slot) + ",";
            query += (player.account_id == null ? "NULL" : player.account_id.ToString()) + ",";
            query += FormatNullableInt(player.kills) + ",";
            query += FormatNullableInt(player.deaths) + ",";
            query += FormatNullableInt(player.assists) + ",";
            query += FormatNullableInt(player.last_hits) + ",";
            query += FormatNullableInt(player.denies) + ",";
            query += FormatNullableInt(player.gold) + ",";
            query += FormatNullableInt(player.gold_per_min) + ",";
            query += FormatNullableInt(player.gold_spent) + ",";
            query += FormatNullableInt(player.hero_damage) + ",";
            query += FormatNullableInt(player.hero_healing) + ",";
            query += FormatNullableInt(player.tower_damage) + ",";
            query += FormatNullableInt(player.xp_per_min) + ",";
            query += "'" + (player.personaname == null ? "" : player.personaname.Replace("'", "''")) + "',";
            query += FormatNullableBool(player.isRadiant) + ",";
            query += FormatNullableInt(player.win) + ",";
            query += FormatNullableInt(player.lose) + ",";
            query += FormatNullableInt(player.total_gold) + ",";
            query += FormatNullableInt(player.total_xp) + ",";
            query += FormatNullableInt(player.kda) + ",";
            query += FormatNullableInt(player.abandons) + ",";
            query += FormatNullableInt(player.hero_id) + ",";
            query += FormatNullableInt(player.item_0) + ",";
            query += FormatNullableInt(player.item_1) + ",";
            query += FormatNullableInt(player.item_2) + ",";
            query += FormatNullableInt(player.item_3) + ",";
            query += FormatNullableInt(player.item_4) + ",";
            query += FormatNullableInt(player.item_5) + ",";
            query += FormatNullableInt(player.item_neutral) + ",";
            query += FormatNullableInt(player.backpack_0) + ",";
            query += FormatNullableInt(player.backpack_1) + ",";
            query += FormatNullableInt(player.backpack_2) + ",";
            query += FormatNullableInt(player.party_size) + ")";

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShirtSwimmers"].ToString()))
            {
                conn.Open();
                var command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public static string FormatNullableInt(int? intValue)
        {
            return intValue == null ? "NULL" : intValue.ToString();
        }

        public static string FormatNullableBool(bool? boolValue)
        {
            if (boolValue == null)
            {
                return "NULL";
            }

            return (bool)boolValue ? "1" : "0";
        }
    }
}
