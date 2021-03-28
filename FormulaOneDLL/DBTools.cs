using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class DBTools
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"formulaOne.mdf;Integrated Security=True";

        public DataTable getTableData(string tablename)
        {
            DataTable dTable = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                String sql = $"SELECT * FROM " + tablename;
                dbConn.ConnectionString = CONNECTION_STRING;
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter dAdapter = new SqlDataAdapter(command))
                    {
                        dAdapter.Fill(dTable);
                    }
                }
            }
            return dTable;
        }

        public List<string> getTableName()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection(CONNECTION_STRING))
            {
                String sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return retVal;
        }

        // Countries

        public List<string> GetCountries()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", countryCode, countryName);
                            retVal.Add(countryCode + " - " + countryName);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Country> GetCountriesObj()
        {
            List<Country> retVal = new List<Country>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", countryCode, countryName);
                            retVal.Add(new Country(countryCode, countryName));
                        }
                    }
                }
            }
            return retVal;
        }

        public Country GetCountryById(string isoCode)
        {
            Country retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM country WHERE countryCode='" + isoCode + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", countryCode, countryName);
                            retVal = new Country(countryCode, countryName);
                        }
                    }
                }
            }
            return retVal;
        }

        // Drivers

        public List<string> GetDrivers()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = "SELECT * FROM driver";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int Number = reader.GetInt32(1);
                            string Name = reader.GetString(2);
                            DateTime DOB = reader.GetDateTime(3);
                            byte[] HelmetImage = reader["HelmetImage"] as byte[];
                            byte[] Image = reader["Image"] as byte[];
                            int TeamID = reader.GetInt32(6);
                            int Podiums = reader.GetInt32(7);
                            string CountryCode = reader.GetString(8);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode);
                            retVal.Add(ID + " - " + Number + " - " + Name + " - " + DOB + " - " + HelmetImage + " - " + Image + " - " + TeamID + " - " + Podiums + " - " + CountryCode);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Driver> GetDriversObj()
        {
            List<Driver> retVal = new List<Driver>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM driver";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int Number = reader.GetInt32(1);
                            string Name = reader.GetString(2);
                            DateTime DOB = reader.GetDateTime(3);
                            byte[] HelmetImage = reader["HelmetImage"] as byte[];
                            byte[] Image = reader["Image"] as byte[];
                            int TeamID = reader.GetInt32(6);
                            int Podiums = reader.GetInt32(7);
                            string CountryCode = reader.GetString(8);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode);
                            retVal.Add(new Driver(ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode));
                        }
                    }
                }
            }
            return retVal;
        }

        public Driver GetDriverById(int id)
        {
            Driver retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM driver WHERE ID='" + id + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int Number = reader.GetInt32(1);
                            string Name = reader.GetString(2);
                            DateTime DOB = reader.GetDateTime(3);
                            byte[] HelmetImage = reader["HelmetImage"] as byte[];
                            byte[] Image = reader["Image"] as byte[];
                            int TeamID = reader.GetInt32(6);
                            int Podiums = reader.GetInt32(7);
                            string CountryCode = reader.GetString(8);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode);
                            retVal = new Driver(ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode);
                        }
                    }
                }
            }
            return retVal;
        }

        public Driver GetDriverByName(string name)
        {
            Driver retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM driver WHERE name='" + name + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int Number = reader.GetInt32(1);
                            string Name = reader.GetString(2);
                            DateTime DOB = reader.GetDateTime(3);
                            byte[] HelmetImage = reader["HelmetImage"] as byte[];
                            byte[] Image = reader["Image"] as byte[];
                            int TeamID = reader.GetInt32(6);
                            int Podiums = reader.GetInt32(7);
                            string CountryCode = reader.GetString(8);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode);
                            retVal = new Driver(ID, Number, Name, DOB, HelmetImage, Image, TeamID, Podiums, CountryCode);
                        }
                    }
                }
            }
            return retVal;
        }

        // Teams

        public List<string> GetTeams()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = "SELECT * FROM team";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string teamName = reader.GetString(1);
                            byte[] teamLogo = reader["teamLogo"] as byte[];
                            string baseT = reader.GetString(3);
                            string teamChief = reader.GetString(4);
                            string technicalChief = reader.GetString(5);
                            string powerUnit = reader.GetString(6);
                            byte[] carImage = reader["carImage"] as byte[];
                            string countryID = reader.GetString(8);
                            int worldChampionships = reader.GetInt32(9);
                            int polePositions = reader.GetInt32(10);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", id, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions);
                            retVal.Add(id + " - " + teamName + " - " + teamLogo + " - " + baseT + " - " + teamChief + " - " + technicalChief + " - " + powerUnit + " - " + countryID + " - " + worldChampionships + " - " + polePositions);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Team> GetTeamsObj()
        {
            List<Team> retVal = new List<Team>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM team";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string teamName = reader.GetString(1);
                            byte[] teamLogo = reader["teamLogo"] as byte[];
                            string baseT = reader.GetString(3);
                            string teamChief = reader.GetString(4);
                            string technicalChief = reader.GetString(5);
                            string powerUnit = reader.GetString(6);
                            byte[] carImage = reader["carImage"] as byte[];
                            string countryID = reader.GetString(8);
                            int worldChampionships = reader.GetInt32(9);
                            int polePositions = reader.GetInt32(10);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", id, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions);
                            retVal.Add(new Team(id, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions));
                        }
                    }
                }
            }
            return retVal;
        }

        public Team GetTeamById(int id)
        {
            Team retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM team WHERE ID='" + id + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string teamName = reader.GetString(1);
                            byte[] teamLogo = reader["teamLogo"] as byte[];
                            string baseT = reader.GetString(3);
                            string teamChief = reader.GetString(4);
                            string technicalChief = reader.GetString(5);
                            string powerUnit = reader.GetString(6);
                            byte[] carImage = reader["carImage"] as byte[];
                            string countryID = reader.GetString(8);
                            int worldChampionships = reader.GetInt32(9);
                            int polePositions = reader.GetInt32(10);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", ID, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions);  
                            retVal = new Team(ID, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions);
                        }
                    }
                }
            }
            return retVal;
        }

        public Team GetTeamByName(string name)
        {
            Team retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM team WHERE TeamName='" + name + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string teamName = reader.GetString(1);
                            byte[] teamLogo = reader["teamLogo"] as byte[];
                            string baseT = reader.GetString(3);
                            string teamChief = reader.GetString(4);
                            string technicalChief = reader.GetString(5);
                            string powerUnit = reader.GetString(6);
                            byte[] carImage = reader["carImage"] as byte[];
                            string countryID = reader.GetString(8);
                            int worldChampionships = reader.GetInt32(9);
                            int polePositions = reader.GetInt32(10);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", ID, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions);
                            retVal = new Team(ID, teamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, carImage, countryID, worldChampionships, polePositions);
                        }
                    }
                }
            }
            return retVal;
        }

        // Driver DTO

        public List<DriverPageDTO> getDriversList()
        {
            List<DriverPageDTO> retVal = new List<DriverPageDTO>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                string sql = "SELECT d.Number,d.Name,d.Image,t.TeamName,c.countryCode FROM driver d,team t,country c WHERE d.TeamID=t.ID AND d.CountryCode=c.countryCode;";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Number = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            byte[] Image = reader["Image"] as byte[];
                            string Team = reader.GetString(3);
                            string CountryCode = reader.GetString(4);
                            retVal.Add(new DriverPageDTO(Number, Name, Image, Team, CountryCode));
                        }
                    }
                }
            }
            return retVal;
        }

        public DriverDetailsDTO getDriversDetails(int number)
        {
            DriverDetailsDTO retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                string sql = "SELECT d.Number,d.Name,d.Image,t.TeamName,c.countryCode,d.Podiums,d.DOB FROM driver d,team t,country c WHERE d.TeamID=t.ID AND d.CountryCode=c.countryCode AND d.Number='" + number + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Number = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            byte[] Image = reader["Image"] as byte[];
                            string Team = reader.GetString(3);
                            string countryCode = reader.GetString(4);
                            int Podiums = reader.GetInt32(5);
                            DateTime DOB = reader.GetDateTime(6);
                            retVal = new DriverDetailsDTO(Number, Name, Image, Team, countryCode, Podiums, DOB);
                        }
                    }
                }
            }
            return retVal;
        }

        // Team DTO

        public List<TeamPageDTO> getTeamsList()
        {
            List<TeamPageDTO> retVal = new List<TeamPageDTO>();
            string tName = "";
            byte[] tLogo = new byte[0];
            string[] dNames = new string[2];
            List<byte[]> dImages = new List<byte[]>();
            byte[] carImage = new byte[0];
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT t.TeamName, t.TeamLogo, d.Name, d.Image, t.CarImage FROM Team t, Driver d WHERE d.TeamID = t.ID ORDER BY t.TeamName";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    if (i % 2 == 0)
                    {
                        tName = reader.GetString(0);
                        tLogo = reader["TeamLogo"] as byte[];
                        dNames = new string[2];
                        dNames[0] = reader.GetString(2);
                        dImages = new List<byte[]>();
                        dImages.Add(reader["Image"] as byte[]);
                        carImage = reader["CarImage"] as byte[];
                    }
                    else
                    {
                        dNames[1] = reader.GetString(2);
                        dImages.Add(reader["Image"] as byte[]);
                        TeamPageDTO team = new TeamPageDTO(tName, tLogo, dNames, dImages, carImage);
                        retVal.Add(team);
                    }
                    i++;
                }
            }
            return retVal;
        }

        public TeamDetailsDTO getTeamsDetails(int id)
        {
            TeamDetailsDTO retVal = null;
            int id_team = 0;
            string TeamName = string.Empty;
            byte[] teamLogo = null;
            string baseT = string.Empty;
            string teamChief = string.Empty;
            string technicalChief = string.Empty;
            string powerUnit = string.Empty;
            byte[] CarImage = null;
            string countryID = string.Empty;
            int worldChampionships = 0;
            int polePositions = 0;
            int[] numbers = new int[2];
            string[] dNames = new string[2];
            List<byte[]> dImages = new List<byte[]>();
            int i = 0;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT t.id,t.TeamName,t.TeamLogo,t.Base,t.TeamChief,t.TechnicalChief,t.PowerUnit,t.CarImage,t.countryID,t.worldChampionships,t.polePositions,d.number,d.Name,d.Image FROM driver d, team t WHERE d.TeamID = t.ID AND t.ID ='" + id + "';";
                SqlCommand cmd = new SqlCommand(sql, dbConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (i % 2 == 0)
                    {
                        id_team = reader.GetInt32(0);
                        TeamName = reader.GetString(1); ;
                        teamLogo = reader["TeamLogo"] as byte[]; ;
                        baseT = reader.GetString(3); ;
                        teamChief = reader.GetString(4); ;
                        technicalChief = reader.GetString(5); ;
                        powerUnit = reader.GetString(6); ;
                        CarImage = reader["CarImage"] as byte[]; ;
                        countryID = reader.GetString(8); ;
                        worldChampionships = reader.GetInt32(9);
                        polePositions = reader.GetInt32(10);
                        numbers[0] = reader.GetInt32(11);
                        dNames[0] = reader.GetString(12);
                        dImages.Add(reader["Image"] as byte[]);
                    }
                    else
                    {
                        numbers[1] = reader.GetInt32(11);
                        dNames[1] = reader.GetString(12);
                        dImages.Add(reader["Image"] as byte[]);
                        retVal = new TeamDetailsDTO(id_team, TeamName, teamLogo, baseT, teamChief, technicalChief, powerUnit, CarImage, countryID, worldChampionships, polePositions, numbers, dNames, dImages);
                    }
                    i++;
                }
            }
            return retVal;
        }
    }
}