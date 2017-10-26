namespace _07.Print_All_Minion_Names
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string connectionPath = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionPath);
            connection.Open();

            List<string> allMinnions = new List<string>();

            using (connection)
            {
                string query = File.ReadAllText(@"../../GetAllMinnions.sql");
                SqlCommand getMinnionsCmd = new SqlCommand(query, connection);

                using (getMinnionsCmd)
                {
                    SqlDataReader minnionsReader = getMinnionsCmd.ExecuteReader();

                    while (minnionsReader.Read())
                    {
                        string currentMinnion = minnionsReader["Name"].ToString();
                        allMinnions.Add(currentMinnion);
                    }

                    minnionsReader.Close();
                }
            }

            int index = 1;

            for (int i = 0; i < allMinnions.Count / 2; i++)
            {

                Console.WriteLine($"{index}. {allMinnions[i]}");
                index++;
                int lenght = allMinnions.Count - 1;

                Console.WriteLine($"{index}. {allMinnions[lenght - i]}");
                index++;
            }
        }
    }
}