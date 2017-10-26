using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace _09.Increase_Age_Stored_Proc
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string connectionPath = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionPath);
            connection.Open();

            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_GetOlder", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@GivenId", id);
                    int idsEffected = cmd.ExecuteNonQuery();

                    if (idsEffected > 0)
                    {
                        string getMinnionsQuery = File.ReadAllText("../../getMinnions.sql");

                        cmd.CommandText = getMinnionsQuery;
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader minnionsReader = cmd.ExecuteReader();
                        minnionsReader.Read();

                        string name = minnionsReader["Name"].ToString();
                        string age = minnionsReader["Age"].ToString();
                        Console.WriteLine($"{name} {age}");
                    }
                    else
                    {
                        Console.WriteLine($"No minnion with ID: {id} have been found");
                    }
                }
            }
        }
    }
}