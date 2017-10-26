namespace _01.Initial_Setup
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            CreateDatabase();

            CreateTables();

            CreateDifferentQueriesAndAddData();
        }

        private static void CreateDatabase()
        {
            string serverPath = @"Server=.;Database=SoftUni;Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(serverPath);
            sqlConnection.Open();

            using (sqlConnection)
            {
                string queryCreateMinionsdb = @"CREATE DATABASE MinionsDB";
                SqlCommand sqlCommand = new SqlCommand(queryCreateMinionsdb, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.ExecuteScalar();
                    Console.WriteLine("MinionsDB Created");
                }
            }
        }

        public static void CreateTables()
        {
            var sqlConnection = CreateNewSqlConnection();

            // this string is made just for exercise and should never be like that!
            string query = @"CREATE TABLE Countries
                             (
	                             Id int PRIMARY KEY IDENTITY,
	                             Name varchar(30) NOT NULL
                             )

                             CREATE TABLE Towns
                             (
	                             Id int PRIMARY KEY IDENTITY,
	                             Name varchar(30) NOT NULL,
	                             CountryId int NOT NULL,
	                             CONSTRAINT FK_Towns_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
                             )

                             CREATE TABLE Minnions
                             (
	                             Id int PRIMARY KEY IDENTITY,
	                             Name varchar(30) NOT NULL,
	                             Age int NOT NULL,
	                             TownId int NOT NULL,
	                             CONSTRAINT FK_Minnions_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)
                             )

                             CREATE TABLE Villains
                             (
	                             Id int PRIMARY KEY IDENTITY,
	                             Name varchar(30) NOT NULL,
	                             EvilnessFactor varchar(10) CHECK (EvilnessFactor IN ('good', 'bad', 'evil', 'super evil')) NOT NULL
                             )

                             CREATE TABLE MinnionsVillains
                             (
	                             MinnionId int,
	                             VillainId int,
	                             CONSTRAINT PK_MinnionIdVillainId PRIMARY KEY(MinnionId, VillainId),
	                             CONSTRAINT FK_MinnionsVillains_Minnions FOREIGN KEY (MinnionId) REFERENCES Minnions(Id),
	                             CONSTRAINT FK_MinnionsVillains_Villains FOREIGN KEY (VillainId) REFERENCES Villains(Id)
                             )";

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteScalar();
                Console.WriteLine("Tables Created");
            }
        }

        //This method should never looks so bad, but this is just exercise
        public static void CreateDifferentQueriesAndAddData()
        {

            string countryQuery = @"INSERT INTO Countries (Name)
                                    VALUES (@CountryName), (@CountryNameTwo), (@CountryNameThree), (@CountryNameFour), (@CountryNameFive)";

            string townsQuery = @"INSERT INTO Towns (Name, CountryId)
                                  VALUES (@NameOne, @CountryIdOne), (@NameTwo, @CountryIdTwo), 
                                         (@NameThree, @CountryIdThree), (@NameFour, @CountryIdFour), (@NameFive, @CountryIdFive)";

            string minnionsQuery = @"INSERT INTO Minnions (Name, Age, TownId)
                                     VALUES (@NameOne, @AgeOne, @TownIdOne), (@NameTwo,  @AgeTwo, @TownIdTwo), (@NameThree,  @AgeThree, @TownIdThree), 
                                            (@NameFour,  @AgeFour, @TownIdFour), (@NameFive,  @AgeFive, @TownIdFive)";

            string villainsQuery = @"INSERT INTO Villains (Name, EvilnessFactor)
                                     VALUES (@NameOne, @EvilnessFactorOne), (@NameTwo, @EvilnessFactorTwo), 
                                         (@NameThree, @EvilnessFactorThree), (@NameFour, @EvilnessFactorFour), (@NameFive, @EvilnessFactorFive)";

            string minnionsVillainsQuerry = @"INSERT INTO MinnionsVillains (MinnionId, VillainId)
                                               VALUES (@MinnionIdOne, @VillainIdOne), (@MinnionIdTwo, @VillainIdTwo), (@MinnionIdThree, @VillainIdThree), 
                                                        (@MinnionIdFour, @VillainIdFour), (@MinnionIdFive, @VillainIdFive)";


            List<SqlParameter> countryPrms = new List<SqlParameter>()
            {
                new SqlParameter("@CountryName", SqlDbType.VarChar) {Value = "Bulgaria"},
                new SqlParameter("@CountryNameTwo", SqlDbType.VarChar) {Value = "Romania"},
                new SqlParameter("@CountryNameThree", SqlDbType.VarChar) {Value = "Belgium"},
                new SqlParameter("@CountryNameFour", SqlDbType.VarChar) {Value = "Germany"},
                new SqlParameter("@CountryNameFive", SqlDbType.VarChar) {Value = "Greec"}
            };

            List<SqlParameter> townsPrms = new List<SqlParameter>()
            {
                new SqlParameter("@NameOne", SqlDbType.VarChar) {Value = "Varna"},
                new SqlParameter("@CountryIdOne", SqlDbType.Int) {Value = 1},
                new SqlParameter("@NameTwo", SqlDbType.VarChar) {Value = "Burgas"},
                new SqlParameter("@CountryIdTwo", SqlDbType.Int) {Value = 2},
                new SqlParameter("@NameThree", SqlDbType.VarChar) {Value = "V.Tyrnovo"},
                new SqlParameter("@CountryIdThree", SqlDbType.Int) {Value = 3},
                new SqlParameter("@NameFour", SqlDbType.VarChar) {Value = "Sofia"},
                new SqlParameter("@CountryIdFour", SqlDbType.Int) {Value = 4},
                new SqlParameter("@NameFive", SqlDbType.VarChar) {Value = "Stz"},
                new SqlParameter("@CountryIdFive", SqlDbType.Int) {Value = 5}
            };

            List<SqlParameter> minnionsPrms = new List<SqlParameter>()
            {
                new SqlParameter("@NameOne", SqlDbType.VarChar) {Value = "Gosho"},
                new SqlParameter("@AgeOne", SqlDbType.Int) {Value = 16},
                new SqlParameter("@TownIdOne", SqlDbType.Int) {Value = 1},
                new SqlParameter("@NameTwo", SqlDbType.VarChar) {Value = "Ivan"},
                new SqlParameter("@AgeTwo", SqlDbType.Int) {Value = 18},
                new SqlParameter("@TownIdTwo", SqlDbType.Int) {Value = 2},
                new SqlParameter("@NameThree", SqlDbType.VarChar) {Value = "Petar"},
                new SqlParameter("@AgeThree", SqlDbType.Int) {Value = 20},
                new SqlParameter("@TownIdThree", SqlDbType.Int) {Value = 3},
                new SqlParameter("@NameFour", SqlDbType.VarChar) {Value = "Sev"},
                new SqlParameter("@AgeFour", SqlDbType.Int) {Value = 22},
                new SqlParameter("@TownIdFour", SqlDbType.Int) {Value = 4},
                new SqlParameter("@NameFive", SqlDbType.VarChar) {Value = "Miro"},
                new SqlParameter("@AgeFive", SqlDbType.Int) {Value = 27},
                new SqlParameter("@TownIdFive", SqlDbType.Int) {Value = 5}
            };

            List<SqlParameter> villainsPrms = new List<SqlParameter>()
            {
                new SqlParameter("@NameOne", SqlDbType.VarChar) {Value = "Zurla"},
                new SqlParameter("@EvilnessFactorOne", SqlDbType.VarChar) {Value = "good"},
                new SqlParameter("@NameTwo", SqlDbType.VarChar) {Value = "Pucana"},
                new SqlParameter("@EvilnessFactorTwo", SqlDbType.VarChar) {Value = "bad"},
                new SqlParameter("@NameThree", SqlDbType.VarChar) {Value = "Kirka"},
                new SqlParameter("@EvilnessFactorThree", SqlDbType.VarChar) {Value = "evil"},
                new SqlParameter("@NameFour", SqlDbType.VarChar) {Value = "Mucka"},
                new SqlParameter("@EvilnessFactorFour", SqlDbType.VarChar) {Value = "super evil"},
                new SqlParameter("@NameFive", SqlDbType.VarChar) {Value = "Lili"},
                new SqlParameter("@EvilnessFactorFive", SqlDbType.VarChar) {Value = "bad"}
            };

            List<SqlParameter> minnionsVillainsPrms = new List<SqlParameter>()
            {
                new SqlParameter("@MinnionIdOne", SqlDbType.Int) {Value = 1},
                new SqlParameter("@VillainIdOne", SqlDbType.Int) {Value = 2},
                new SqlParameter("@MinnionIdTwo", SqlDbType.Int) {Value = 2},
                new SqlParameter("@VillainIdTwo", SqlDbType.Int) {Value = 3},
                new SqlParameter("@MinnionIdThree", SqlDbType.Int) {Value = 4},
                new SqlParameter("@VillainIdThree", SqlDbType.Int) {Value = 5},
                new SqlParameter("@MinnionIdFour", SqlDbType.Int) {Value = 5},
                new SqlParameter("@VillainIdFour", SqlDbType.Int) {Value = 3},
                new SqlParameter("@MinnionIdFive", SqlDbType.Int) {Value = 2},
                new SqlParameter("@VillainIdFive", SqlDbType.Int) {Value = 2}
            };

            string countryPrefix = "Country";
            string townPrefix = "Town";
            string minnionsPrefix = "Minnions";
            string villainsPrefix = "Villains";
            string minnionsVillainsPrefix = "MinnionsVillains";

            AddGivenData(countryQuery, countryPrms, countryPrefix);

            AddGivenData(townsQuery, townsPrms, townPrefix);

            AddGivenData(minnionsQuery, minnionsPrms, minnionsPrefix);

            AddGivenData(villainsQuery, villainsPrms, villainsPrefix);

            AddGivenData(minnionsVillainsQuerry, minnionsVillainsPrms, minnionsVillainsPrefix);
        }

        private static void AddGivenData(string dataQuery, List<SqlParameter> prm, string typeOfData)
        {
            var sqlConnection = CreateNewSqlConnection();
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand(dataQuery, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddRange(prm.ToArray());
                    int count = sqlCommand.ExecuteNonQuery();

                    Console.WriteLine($"{count} records were added in table - {typeOfData}");
                }
            }
        }

        private static SqlConnection CreateNewSqlConnection()
        {
            string serverPath = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(serverPath);
            return sqlConnection;
        }
    }
}