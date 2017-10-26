namespace _08.Increase_Minions_Age
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string connectionPath = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionPath);
            connection.Open();

            int[] minnions = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            using (connection)
            {
                string makeChangesQuery = File.ReadAllText("../../IncreaseMinnionsAgeAndChangeName.sql");

                for (int i = 0; i < minnions.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand(makeChangesQuery, connection);

                    using (cmd)
                    {
                        cmd.Parameters.AddWithValue(@"GivenId", minnions[i]);
                        SqlDataReader changerReader = cmd.ExecuteReader();
                        changerReader.Close();
                    }
                }

                string getMinnionsQuery = File.ReadAllText("../../GetAllMinnions.sql");
                SqlCommand getMinnionsCmd = new SqlCommand(getMinnionsQuery, connection);

                using (getMinnionsCmd)
                {
                    SqlDataReader getMinnionsReader = getMinnionsCmd.ExecuteReader();

                    while (getMinnionsReader.Read())
                    {
                        string name = getMinnionsReader["Name"].ToString();
                        int age = int.Parse(getMinnionsReader["Age"].ToString());

                        Console.WriteLine($"{name} {age}");
                    }
                    getMinnionsReader.Close();
                }
            }
        }
    }
}