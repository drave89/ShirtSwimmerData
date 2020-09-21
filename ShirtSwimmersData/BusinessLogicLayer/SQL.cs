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
                    result = reader.GetInt64(0);
                }

                reader.Close();
            }

            return result;
        }
    }
}
