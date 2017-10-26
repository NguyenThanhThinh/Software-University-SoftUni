namespace _03.Get_Minion_Names
{
    using System.IO;
    using System;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            string path = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(path);
            connection.Open();

            int requestedId = int.Parse(Console.ReadLine());

            using (connection)
            {
                string getVillainQuery = File.ReadAllText(@"../../GetVillain.sql");
                SqlCommand getVillainCmd = new SqlCommand(getVillainQuery, connection);

                using (getVillainCmd)
                {
                    SqlParameter villainParamId = new SqlParameter("@GivenId", requestedId);
                    getVillainCmd.Parameters.Add(villainParamId);

                    SqlDataReader villainReader = getVillainCmd.ExecuteReader();

                    if (villainReader.Read())
                    {
                        Console.WriteLine($"Villain: {villainReader["Name"]}");
                        villainReader.Close();

                        string findMinnionsQuery = File.ReadAllText(@"../../FindMinnions.sql");
                        SqlCommand findMinnionsCmd = new SqlCommand(findMinnionsQuery, connection);

                        using (findMinnionsCmd)
                        {
                            findMinnionsCmd.Parameters.AddWithValue("@GivenId", requestedId);
                            SqlDataReader minnionsReader = findMinnionsCmd.ExecuteReader();
                            int index = 1;

                            while (minnionsReader.Read())
                            {
                                string minnionName = (string)minnionsReader["Name"];
                                int minnionAge = int.Parse(minnionsReader["Age"].ToString());

                                Console.WriteLine($"{index}. {minnionName} {minnionAge}");
                                index++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {requestedId} exists in the database.");
                    }
                }
            }
        }
    }
}