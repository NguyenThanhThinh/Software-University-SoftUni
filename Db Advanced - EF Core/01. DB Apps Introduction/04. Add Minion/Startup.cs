
using System.Data.SqlClient;
using System.IO;

namespace _04.Add_Minion
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            string path = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(path);
            connection.Open();

            string minnion = Console.ReadLine();
            using (connection)
            {
                string query = File.ReadAllText(@"../../AddMinion.sql");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@GivenMinion", minnion);

                SqlDataReader reader = cmd.ExecuteReader();

            }
        }
    }
}