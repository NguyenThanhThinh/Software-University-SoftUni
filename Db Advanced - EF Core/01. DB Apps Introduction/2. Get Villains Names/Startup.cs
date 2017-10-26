namespace _2.Get_Villains_Names
{
    using System.Data.SqlClient;
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string path = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(path);
            connection.Open();

            using (connection)
            {
                string query = File.ReadAllText(@"../../Query.sql");
                SqlCommand sqlCmd = new SqlCommand(query, connection);

                using (sqlCmd)
                {
                    SqlDataReader queryData = sqlCmd.ExecuteReader();

                    while (queryData.Read())
                    {
                        for (int i = 0; i < queryData.FieldCount; i++)
                        {
                            string value = queryData.GetValue(i).ToString();
                            Console.Write($"{value} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}