using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"formulaOne.mdf;Integrated Security=True";
        private static string[] tableNames = { "Country", "Driver", "Team", "Circuits", "Scores", "Races", "RacesPoints" };

        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - CONSOLE ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Circuits");
                Console.WriteLine("5 - Create Scores");
                Console.WriteLine("6 - Create Races");
                Console.WriteLine("7 - Create RacesPoints");
                Console.WriteLine("--------------------------");
                Console.WriteLine("R - RESET DB");
                Console.WriteLine("--------------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        ExecuteSqlScript("Drivers.sql");
                        break;
                    case '4':
                        ExecuteSqlScript("Circuits.sql");
                        break;
                    case '5':
                        ExecuteSqlScript("Scores.sql");
                        break;
                    case '6':
                        ExecuteSqlScript("Races.sql");
                        break;
                    case '7':
                        ExecuteSqlScript("RacesPoints.sql");
                        break;
                    case 'R':
                        ResetDB();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        public static void ResetDB()
        {
            bool OK;
            BackupDb();
            OK = DropTable("Country");
            if (OK) OK = DropTable("Driver");
            if (OK) OK = DropTable("Team");
            Console.WriteLine();
            if (OK) OK = ExecuteSqlScript("Countries.sql");
            if (OK) OK = ExecuteSqlScript("Drivers.sql");
            if (OK) OK = ExecuteSqlScript("Teams.sql");
            if (OK)
            {
                Console.WriteLine("\nRESET AVVENUTO CON SUCCESSO");
            }
            else
            {
                RestoreDb();
            }
        }

        public static void BackupDb()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + WORKINGPATH + "formulaone.mdf" + "] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + WORKINGPATH + "formulaone.mdf" + "] TO DISK='" + WORKINGPATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RestoreDb()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    string sqlStmt = "";
                    foreach (string table in tableNames)
                    {
                        sqlStmt += "TRUNCATE TABLE " + table + ";";
                        sqlStmt += "SELECT * INTO " + table + "_bck FROM " + table + ";";
                    }
                    sqlStmt = string.Format("RESTORE database FormulaOne.mdf FROM disk='{0}'", WORKINGPATH + "FormulaOneBackup.mdf");
                    using (SqlCommand bu2 = new SqlCommand(sqlStmt, conn))
                    {
                        conn.Open();
                        bu2.ExecuteNonQuery();
                        conn.Close();
                        Console.WriteLine("\nRESTORE AVVENUTO CON SUCCESSO");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nRESTORE AVVENUTO CON SUCCESSO");
            }
        }

        static bool ExecuteSqlScript(string scriptName)
        {
            try
            {
                var fileContent = File.ReadAllText(WORKINGPATH + scriptName);
                fileContent = fileContent.Replace("\r\n", "");
                fileContent = fileContent.Replace("\r", "");
                fileContent = fileContent.Replace("\n", "");
                fileContent = fileContent.Replace("\t", "");
                var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                var con = new SqlConnection(CONNECTION_STRING);
                var cmd = new SqlCommand("query", con);
                con.Open(); int i = 0;
                foreach (var query in sqlqueries)
                {
                    cmd.CommandText = query; i++;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        Console.WriteLine("Errore in esecuzione della query numero: " + i);
                        Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    }
                }
                con.Close();
                Console.WriteLine("CREAZIONE TABELLA " + scriptName + " - AVVENUTO");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CREAZIONE TABELLA " + scriptName + " - ERRORE: " + ex.Message + "\n");
                return false;
            }
        }

        static bool DropTable(string tableName)
        {
            try
            {
                var con = new SqlConnection(CONNECTION_STRING);
                var cmd = new SqlCommand("Drop Table " + tableName + ";", con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                }
                con.Close();
                Console.WriteLine("ELIMINAZIONE TABELLA " + tableName + " - AVVENUTO");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ELIMINAZIONE TABELLA" + tableName + " - ERRORE: " + ex.Message + "");
                return false;
            }
        }
    }
}