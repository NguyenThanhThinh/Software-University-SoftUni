namespace _05.Change_Town_Names_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string connectionPath = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionPath);
            connection.Open();

            string country = Console.ReadLine();
            int townsAffected = 0;
            List<string> towns = new List<string>();

            using (connection)
            {
                towns = GetLowerCaseTownNames(connection, country);

                townsAffected = MakeTownNamesByGivenCountryAllCapital(connection, country, townsAffected);
            }

            if (townsAffected != 0)
            {
                Console.WriteLine($"{townsAffected} town names were affected.");
                Console.WriteLine("[" + string.Join(", ", towns) + "]");
            }
            else
            {
                Console.WriteLine("No town names were affected.");
            }
        }

        private static int MakeTownNamesByGivenCountryAllCapital(SqlConnection connection, string country, int townsAffected)
        {
            string makeLowerCaseToUpperCaseQuery = File.ReadAllText("../../ChangeTownNameCasingToUpper.sql");
            SqlCommand changeLowerToUpperCaseNamesCmd = new SqlCommand(makeLowerCaseToUpperCaseQuery, connection);

            using (changeLowerToUpperCaseNamesCmd)
            {
                changeLowerToUpperCaseNamesCmd.Parameters.AddWithValue("@GivenCountryName", country);
                townsAffected = changeLowerToUpperCaseNamesCmd.ExecuteNonQuery();
            }
            return townsAffected;
        }

        private static List<string> GetLowerCaseTownNames(SqlConnection connection, string country)
        {
            string getLowerCaseTownNamesQuery = File.ReadAllText("../../GetTownsWithLowerCaseNames.sql");
            SqlCommand getLowerCaseNamesCmd = new SqlCommand(getLowerCaseTownNamesQuery, connection);
            getLowerCaseNamesCmd.Parameters.AddWithValue("@GivenCountryName", country);

            List<string> towns = new List<string>();

            using (getLowerCaseNamesCmd)
            {
                SqlDataReader getLowerCaseTowns = getLowerCaseNamesCmd.ExecuteReader();

                while (getLowerCaseTowns.Read())
                {
                    string currentTownName = getLowerCaseTowns["Name"].ToString().ToUpper();
                    towns.Add(currentTownName);
                }

                getLowerCaseTowns.Close();
            }
            return towns;
        }
    }
}