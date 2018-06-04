using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock;
using Newtonsoft.Json;

namespace ExtremeStudio.Classes
{
    public class CurrentProjectClass
    {
        public CurrentProjectClass()
        {
            // VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
            ObjectExplorerItems = new List<ObjectExplorerItem>();

        }

        public string ProjectName { get; set; }
        public string ProjectVersion { get; set; }
        public string LastOpenFiles { get; set; }
        public PawnJson SampCtlData { get; set; }

        private string _projectPathB;

        public string ProjectPath
        {
            set
            {
                _sqlCon = new SqLiteDatabase(value + "/extremeStudio.config");
                _projectPathB = value;
            }
            get => _projectPathB;
        }

        public List<ObjectExplorerItem> ObjectExplorerItems { get; set; } = new List<ObjectExplorerItem>();

        #region SQL Funcs

        SqLiteDatabase _sqlCon;

        public void CreateTables()
        {
            _sqlCon.ExecuteNonQuery("CREATE TABLE MainConfig(`name` STRING(50), `value` STRING(50));");
            _sqlCon.ExecuteNonQuery("CREATE TABLE ObjectExplorerItems(`name` STRING(50), `identifier` STRING(50));");
        }

        #endregion

        public void SaveSampCtlData()
        {
            File.WriteAllText(ProjectPath + "/pawn.json", JsonConvert.SerializeObject(SampCtlData, Formatting.Indented));
        }

        public void LoadSampCtlData()
        {
            if (File.Exists(ProjectPath + "/pawn.json"))
            {
                SampCtlData = JsonConvert.DeserializeObject<PawnJson>(File.ReadAllText(ProjectPath + "/pawn.json"));
                if ((SampCtlData.builds[0].includes == null || !SampCtlData.builds[0].includes.Contains("./pawno/include/")) && Directory.Exists(Path.Combine(ProjectPath, "pawno/include/")))
                {
                    SampCtlData.builds[0].includes = new List<string>() {"./pawno/include/"};
                    foreach (var inc in Directory.GetFiles(Path.Combine(ProjectPath, "pawno/include/")))
                    {
                        bool isit = false;
                        switch (Path.GetFileName(inc))
                        {
                            case "a_actor.inc":
                            case "a_http.inc":
                            case "a_npc.inc":
                            case "a_objects.inc":
                            case "a_players.inc":
                            case "a_samp.inc":
                            case "a_sampdb.inc":
                            case "a_vehicles.inc":
                            case "core.inc":
                            case "datagram.inc":
                            case "file.inc":
                            case "float.inc":
                            case "string.inc":
                            case "time.inc":
                                isit = true;
                                break;
                        }

                        if (isit)
                        {
                            string newPath = Path.Combine(Path.GetDirectoryName(inc),
                                Path.GetFileNameWithoutExtension(inc));
                            File.Move(inc, newPath + "_disabled.inc");
                        }
                    }

                    SaveSampCtlData();
                }
                else if(SampCtlData.builds[0].includes.Contains("./pawno/include/") && !Directory.Exists(Path.Combine(ProjectPath, "pawno/include/")))

                {
                    SampCtlData.builds[0].includes.Remove("./pawno/include/");
                    SaveSampCtlData();
                }
            }
        }

        public void SaveInfo() //Will only work if the projectPath is set to valid ExtremeStudio project.
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            //Instead of doing a huge logic for updating and inserting on first time and this stuff.. I just will
            //Delete the whole data in each table before writing.

            #region MainConfig

            //Save projects name.
            dic.Clear();
            _sqlCon.ClearTable("MainConfig");
            dic.Add("name", "ProjectName");
            dic.Add("value", ProjectName);
            _sqlCon.Insert("MainConfig", dic);

            //Save projects version.
            dic.Clear(); //Table already cleared once. :P
            dic.Add("name", "ProjectVersion");
            dic.Add("value", ProjectVersion);
            _sqlCon.Insert("MainConfig", dic);

            //Last opened files.
            dic.Clear(); //Table already cleared once. :P
            dic.Add("name", "LastOpenFiles");
            dic.Add("value", LastOpenFiles);
            _sqlCon.Insert("MainConfig", dic);
            #endregion

            //Save the objectexporleritems.
            _sqlCon.ClearTable("ObjectExplorerItems");
            foreach (var itm in ObjectExplorerItems)
            {
                dic.Clear();
                dic.Add("name", itm.Name);
                dic.Add("identifier", itm.Identifier);
                _sqlCon.Insert("ObjectExplorerItems", dic);
            }

            //Save the PAWNCTL json
            SaveSampCtlData();
        }

        public void ReadInfo() //Will only work if the projectPath is set to valid ExtremeStudio project.
        {
            //Read main info like project name and version.
            ProjectName = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectName'");
            ProjectVersion = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectVersion'");
            LastOpenFiles = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='LastOpenFiles'");

            //Get all the objectexpolreritems.
            DataTable dt = _sqlCon.GetDataTable("SELECT * FROM `ObjectExplorerItems`");
            foreach (DataRow row in dt.Rows)
            {
                ObjectExplorerItems.Add(new ObjectExplorerItem((string)row[0], (string)row[1]));
            }

            LoadSampCtlData();
        }

        public void CopyGlobalConfig()
        {
            //Make dir.
            if (Directory.Exists(ProjectPath + "/configs") == false)
            {
                Directory.CreateDirectory(ProjectPath + "/configs");
            }

            //We will only copy the files that is project specific and not all.
            File.Copy(Program.MainForm.ApplicationFiles + "/configs/themeInfo.json", ProjectPath + "/configs/themeInfo.json", true);
            File.Copy(Program.MainForm.ApplicationFiles + "/configs/compiler.json", ProjectPath + "/configs/compiler.json", true);
        }
    }

    public class PawnJson
    {
        public string user { get; set; }
        public string repo { get; set; }
        public string entry { get; set; }
        public string output { get; set; }
        public List<string> dependencies { get; set; }
        public List<BuildInfo> builds { get; set; }
        public RuntimeInfo runtime { get; set; }
    }

    public class BuildInfo
    {
        public string name { get; set; }
        public List<string> includes { get; set; }
        public List<string> args { get; set; }
    }

    public class RuntimeInfo
    {
        public string version { get; set; } = "latest";
        public bool lanmode { get; set; } = false;
        public string rcon_password { get; set; } = "12345678";
        public int maxplayers { get; set; } = 50;
        public int port { get; set; } = 7777;
        public string hostname { get; set; } = "SA-MP 0.3 Server";
        public bool announce { get; set; } = false;
        public bool chatlogging { get; set; } = false;
        public string weburl { get; set; } = "www.sa-mp.com";
        public int onfoot_rate { get; set; } = 40;
        public int incar_rate { get; set; } = 40;
        public int weapon_rate { get; set; } = 40;
        public float stream_distance { get; set; } = 300.0f;
        public int stream_rate { get; set; } = 1000;
        public int maxnpc { get; set; } = 0;
        public string logtimeformat { get; set; } = "[%H:%M:%S]";
        public string language { get; set; } = "English";
    }

    public class SqLiteDatabase
    {
        private string _dbConnection;

        /// <summary>
        ///     Default Constructor for SQLiteDatabase Class.
        /// </summary>
        public SqLiteDatabase()
        {
            _dbConnection = "Data Source=recipes.s3db";
        }

        /// <summary>
        ///     Single Param Constructor for specifying the DB file.
        /// </summary>
        /// <param name="inputFile">The File containing the DB</param>
        public SqLiteDatabase(string inputFile)
        {
            _dbConnection = string.Format("Data Source={0}", inputFile);
        }

        /// <summary>
        ///     Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SqLiteDatabase(Dictionary<string, string> connectionOpts)
        {
            string str = connectionOpts.Aggregate("",
                (current, row) => current + string.Format("{0}={1}; ", row.Key, row.Value));
            str = Convert.ToString(str.Trim().Substring(0, str.Length - 1));
            _dbConnection = str;
        }

        /// <summary>
        ///     Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(_dbConnection);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = sql};
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw (new Exception(e.Message));
            }

            return dt;
        }

        /// <summary>
        ///     Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn)
            {
                CommandText = sql
            };
            int rowsUpdated = Convert.ToInt32(mycommand.ExecuteNonQuery());
            cnn.Close();
            return rowsUpdated;
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn)
            {
                CommandText = sql
            };
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }

            return "";
        }

        /// <summary>
        ///     Allows the programmer to easily update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing Column names and their new values.</param>
        /// <param name="where">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Update(string tableName, Dictionary<string, string> data, string where)
        {
            string vals = "";
            bool returnCode = true;
            if (data.Count >= 1)
            {
                vals = data.Aggregate(vals,
                    (current, val) =>
                        current + string.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString()));
                vals = vals.Substring(0, vals.Length - 1);
            }

            try
            {
                ExecuteNonQuery(string.Format("update {0} set {1} where {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }

            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Delete(string tableName, string where)
        {
            bool returnCode = true;
            try
            {
                ExecuteNonQuery(string.Format("delete from {0} where {1};", tableName, where));
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                returnCode = false;
            }

            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Insert(string tableName, Dictionary<string, string> data)
        {
            string columns = "";
            string values = "";
            bool returnCode = true;
            foreach (KeyValuePair<string, string> val in data)
            {
                columns += string.Format(" {0},", val.Key);
                values += string.Format(" '{0}',", val.Value);
            }

            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                ExecuteNonQuery(string.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                returnCode = false;
            }

            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily delete all data from the DB.
        /// </summary>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearDb()
        {
            DataTable tables = default(DataTable);
            try
            {
                tables = GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
                foreach (DataRow table in tables.Rows)
                {
                    ClearTable(Convert.ToString(table["NAME"].ToString()));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Allows the user to easily clear all data from a specific table.
        /// </summary>
        /// <param name="table">The name of the table to clear.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearTable(string table)
        {
            try
            {

                ExecuteNonQuery(string.Format("delete from {0};", table));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}