namespace _06.Remove_Villain
{
    using System;
    using System.IO;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            string connectionPath = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionPath);
            connection.Open();

            int villainIdToRemove = int.Parse(Console.ReadLine());

            using (connection)
            {
                string removeVillainQuery = File.ReadAllText("../../RemoveVellain.sql");
                SqlCommand removeVillainCmd = new SqlCommand(removeVillainQuery, connection);
                removeVillainCmd.Parameters.AddWithValue("@GivenId", villainIdToRemove);

                using (removeVillainCmd)
                {
                    SqlDataReader reader = removeVillainCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} was deleted");
                        Console.WriteLine($"{reader["RowEffected"]} minions released");
                    }
                    else
                    {
                        Console.WriteLine("No such villain was found");
                    }
                }
            }
        }
    }
}