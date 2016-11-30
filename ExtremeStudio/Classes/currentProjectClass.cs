using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExtremeStudio.Classes
{
    public class CurrentProjectClass
    {
        public string ProjectName { get; set; }
        public string ProjectVersion { get; set; }

        private string _projectPathB;

        public string ProjectPath
        {
            get { return _projectPathB; }
            set
            {
                _sqlCon = new SqLiteDatabase(value + "/extremeStudio.config");
                _projectPathB = value;
            }
        }

        public List<objectExplorerItem> ObjectExplorerItems { get; set; }

        #region "SQL Funcs"

        SqLiteDatabase _sqlCon;

        public void CreateTables()
        {
            _sqlCon.ExecuteNonQuery("CREATE TABLE MainConfig(`name` STRING(50), `value` STRING(50));");
            _sqlCon.ExecuteNonQuery("CREATE TABLE ObjectExplorerItems(`name` STRING(50), `identifier` STRING(50));");
            _sqlCon.ExecuteNonQuery("CREATE TABLE Includes(`incName` STRING(50), `incVer` STRING(50));");
            _sqlCon.ExecuteNonQuery("CREATE TABLE Plugins(`plugName` STRING(50), `plugVer` STRING(50));");
        }

        #endregion

        //Will only work if the projectPath is set to valid ExtremeStudio project.
        public void SaveInfo()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            //Instead of doing a huge logic for updating and inserting on first time and this stuff.. I just will
            //Delete the whole data in each table before writing.

            #region "MainConfig"

            //Save projects name.
            dic.Clear();
            _sqlCon.ClearTable("MainConfig");
            dic.Add("name", "ProjectName");
            dic.Add("value", ProjectName);
            _sqlCon.Insert("MainConfig", dic);

            //Save projects version.
            dic.Clear();
            //Table already cleared once. :P
            dic.Add("name", "ProjectVersion");
            dic.Add("value", ProjectVersion);
            _sqlCon.Insert("MainConfig", dic);

            #endregion

            //Save the objectexporleritems.
            _sqlCon.ClearTable("ObjectExplorerItems");
            foreach (var itmLoopVariable in ObjectExplorerItems)
            {
                var itm = itmLoopVariable;
                dic.Clear();
                dic.Add("name", itm.Name);
                dic.Add("identifier", itm.Identifier);
                _sqlCon.Insert("ObjectExplorerItems", dic);
            }
        }

        //Will only work if the projectPath is set to valid ExtremeStudio project.
        public void ReadInfo()
        {
            //Read main info like project name and version.
            ProjectName = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectName'");
            ProjectVersion = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectVersion'");

            //Get all the objectexpolreritems.
            DataTable dt = _sqlCon.GetDataTable("SELECT * FROM `ObjectExplorerItems`");
            foreach (DataRow row in dt.Rows)
            {
                ObjectExplorerItems.Add(new objectExplorerItem(row[0], row[1]));
            }
        }

        public void CopyGlobalConfig()
        {
            //Make dir.
            if (Directory.Exists(ProjectPath + "/configs") == false)
                Directory.CreateDirectory(ProjectPath + "/configs");

            //We will only copy the files that is project specific and not all.
            File.Copy(MainForm.ApplicationFiles + "/configs/themeInfo.json", ProjectPath + "/configs/themeInfo.json", true);
            File.Copy(MainForm.ApplicationFiles + "/configs/compiler.json", ProjectPath + "/configs/compiler.json", true);
        }

        #region "Includes Codes"

        public void AddInclude(string inc, string ver)
        {
            dynamic dt = _sqlCon.GetDataTable("SELECT * FROM `Includes` WHERE `incName` = '" + inc + "'");
            if (dt.Rows.Count > 0)
                _sqlCon.ExecuteNonQuery("DELETE FROM `Includes` WHERE `incName` = '" + inc + "'");
            _sqlCon.ExecuteNonQuery("INSERT INTO `Includes` VALUES('" + inc + "', '" + ver + "');");
        }

        public void RemoveInclude(string inc)
        {
            _sqlCon.ExecuteNonQuery("DELETE FROM `Includes` WHERE `incName` = '" + inc + "'");
        }

        public bool IncludeExists(string inc)
        {
            dynamic dt = _sqlCon.GetDataTable("SELECT * FROM `Includes` WHERE `incName` = '" + inc + "'");
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public string IncludeVersion(string inc)
        {
            dynamic dt = _sqlCon.GetDataTable("SELECT `incVer` FROM `Includes` WHERE `incName` = '" + inc + "'");
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows(0).Item(0);
        }

        #endregion

        #region "server.cfg"

        public void EditSampConfig(string key, string value)
        {
            //Variables
            List<string> allInfo = new List<string>();

            //Reading
            string textLine = null;
            if (System.IO.File.Exists(ProjectPath + "/server.cfg") == true)
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(ProjectPath + "/server.cfg");
                while (objReader.Peek() != -1)
                {
                    textLine = objReader.ReadLine();
                    allInfo.Add(textLine);
                }

                objReader.Close();
            }

            //Editing
            string allText = null;
            //To short the loops :P
            bool done = false;
            //This is to know if it was edited or not.
            foreach (string str in allInfo)
            {
                string[] values = str.Split(new[] { ' ' }, 2, StringSplitOptions.None);
                if (values[0] == key)
                {
                    var newstr = values[0] + ' ' + value;
                    allText += newstr + '\n';
                    done = true;
                }
                else
                {
                    allText += str + '\n';
                }
            }

            //If it wasn't edited, We add it.
            if (done == false)
                allText += key + ' ' + value;

            //Writing
            File.WriteAllText(ProjectPath + "/server.cfg", allText);
        }

        public string GetSampConfig(string key)
        {
            string textLine = null;
            if (File.Exists(ProjectPath + "/server.cfg") == true)
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(ProjectPath + "/server.cfg");
                while (objReader.Peek() != -1)
                {
                    textLine = objReader.ReadLine();
                    string[] values = textLine.Split(new[] {' '}, 2, StringSplitOptions.None);
                    if (values[0] == key & values.Length == 2)
                    {
                        objReader.Close();
                        return values[1];
                    }
                }

                objReader.Close();
            }

            return null;
        }

        #endregion

        #region "PluginsHandler"

        public void AddPlugin(string inc, string ver)
        {
            dynamic dt = _sqlCon.GetDataTable("SELECT * FROM `Plugins` WHERE `plugName` = '" + inc + "'");
            if (dt.Rows.Count > 0)
                _sqlCon.ExecuteNonQuery("DELETE FROM `Plugins` WHERE `plugName` = '" + inc + "'");
            _sqlCon.ExecuteNonQuery("INSERT INTO `Plugins` VALUES('" + inc + "', '" + ver + "');");
        }

        public void RemovePlugin(string inc)
        {
            _sqlCon.ExecuteNonQuery("DELETE FROM `Plugins` WHERE `plugName` = '" + inc + "'");
        }

        public bool PluginExists(string inc)
        {
            dynamic dt = _sqlCon.GetDataTable("SELECT * FROM `Plugins` WHERE `plugName` = '" + inc + "'");
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public string PluginVersion(string inc)
        {
            dynamic dt = _sqlCon.GetDataTable("SELECT `plugVer` FROM `Plugins` WHERE `plugName` = '" + inc + "'");
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows(0).Item(0);
        }

        //Server.cfg stuff for plugins.
        private List<string> GetPluginsListInServerCfg()
        {
            List<string> functionReturnValue = default(List<string>);
            functionReturnValue = new List<string>();

            string st = GetSampConfig("plugins");
            if (st == "-1")
            {
                st = "";
            }
            else
            {
                string[] bla = st.Split(' ');

                foreach (string bl in bla)
                {
                    if (!string.IsNullOrEmpty(bl) | !(bl == " "))
                    {
                        functionReturnValue.Add(bl);
                    }
                }
            }

            return functionReturnValue;
        }

        private void SavePluginsInServerCfg(List<string> plugs)
        {
            string str = plugs.Aggregate<string>((current, plug) => current + (' ' + plug));
            if (str != null)
                str = str.Remove(0, 1);

            EditSampConfig("plugins", str);
        }

        public object IsPluginInServerCfg(string pluginName)
        {
            List<string> lst = GetPluginsListInServerCfg();
            return lst.Any(str => str == pluginName);
        }

        public void TogglePluginInServerCfg(string pluginName)
        {
            List<string> lst = GetPluginsListInServerCfg();
            foreach (string str in lst)
            {
                if (str == pluginName)
                {
                    lst.Remove(str);
                    //Remove it then exit sub and don't continue adding it.
                    SavePluginsInServerCfg(lst);
                    //Save it
                    return;
                }
            }

            //If code reaches here, Then it wasn't found so add it.
            lst.Add(pluginName);
            SavePluginsInServerCfg(lst);
        }

        #endregion

    }


    class SqLiteDatabase
    {

        private String _dbConnection;

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
        public SqLiteDatabase(String inputFile)
        {
            _dbConnection = $"Data Source={inputFile}";
        }

        /// <summary>
        ///     Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SqLiteDatabase(Dictionary<String, String> connectionOpts)
        {
            String str = connectionOpts.Aggregate("",
                (current, row) => current + $"{row.Key}={row.Value}; ");
            str = str.Trim().Substring(0, str.Length - 1);
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
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = sql;
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = sql};
            int rowsUpdated = mycommand.ExecuteNonQuery();
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
            SQLiteCommand mycommand = new SQLiteCommand(cnn) {CommandText = sql};
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
        public bool Update(String tableName, Dictionary<String, String> data, String @where)
        {
            String vals = "";
            Boolean returnCode = true;
            if (data.Count >= 1)
            {
                vals = data.Aggregate(vals,
                    (current, val) => current + $" {val.Key.ToString()} = '{val.Value.ToString()}',");
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery($"update {tableName} set {vals} where {@where};");
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
        public bool Delete(String tableName, String @where)
        {
            Boolean returnCode = true;
            try
            {
                this.ExecuteNonQuery($"delete from {tableName} where {@where};");
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
        public bool Insert(String tableName, Dictionary<String, String> data)
        {
            String columns = "";
            String values = "";
            Boolean returnCode = true;
            foreach (KeyValuePair<String, String> val in data)
            {
                columns += $" {val.Key.ToString()},";
                values += $" '{val.Value}',";
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery($"insert into {tableName}({columns}) values({values});");
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
                tables = this.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
                foreach (DataRow table in tables.Rows)
                {
                    this.ClearTable(table["NAME"].ToString());
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
        public bool ClearTable(String table)
        {

            try
            {
                this.ExecuteNonQuery($"delete from {table};");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}