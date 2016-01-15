Imports System.Data.SQLite

Public Class CurrentProjectClass
    Public Property ProjectName As String
    Public Property ProjectVersion As String

    Private _projectPathB As String
    Public Property ProjectPath As String
        Set(value As String)
            _sqlCon = New SQLiteDatabase(value + "/extremeStudio.config")
            _projectPathB = value
        End Set
        Get
            Return _projectPathB
        End Get
    End Property

    Public Property ObjectExplorerItems As New List(Of objectExplorerItem)

#Region "SQL Funcs"
    Dim _sqlCon As SQLiteDatabase
    Public Sub CreateTables()
        _sqlCon.ExecuteNonQuery("CREATE TABLE MainConfig(`name` STRING(50), `value` STRING(50));")
        _sqlCon.ExecuteNonQuery("CREATE TABLE ObjectExplorerItems(`name` STRING(50), `identifier` STRING(50));")
        _sqlCon.ExecuteNonQuery("CREATE TABLE Includes(`incName` STRING(50));")
        _sqlCon.ExecuteNonQuery("CREATE TABLE Plugins(`plugName` STRING(50));")
    End Sub
#End Region

    Public Sub SaveInfo() 'Will only work if the projectPath is set to valid ExtremeStudio project.
        Dim dic As New Dictionary(Of String, String)

        'Instead of doing a huge logic for updating and inserting on first time and this stuff.. I just will
        'Delete the whole data in each table before writing.

#Region "MainConfig"
        'Save projects name.
        dic.Clear() : _sqlCon.ClearTable("MainConfig")
        dic.Add("name", "ProjectName")
        dic.Add("value", projectName)
        _sqlCon.Insert("MainConfig", dic)

        'Save projects version.
        dic.Clear()  'Table already cleared once. :P
        dic.Add("name", "ProjectVersion")
        dic.Add("value", projectVersion)
        _sqlCon.Insert("MainConfig", dic)
#End Region

        'Save the objectexporleritems.
        _sqlCon.ClearTable("ObjectExplorerItems")
        For Each itm In objectExplorerItems
            dic.Clear()
            dic.Add("name", itm.Name)
            dic.Add("identifier", itm.Identifier)
            _sqlCon.Insert("ObjectExplorerItems", dic)
        Next
    End Sub

    Public Sub ReadInfo() 'Will only work if the projectPath is set to valid ExtremeStudio project.
        'Read main info like project name and version.
        projectName = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectName'")
        projectVersion = _sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectVersion'")

        'Get all the objectexpolreritems.
        Dim dt As DataTable = _sqlCon.GetDataTable("SELECT * FROM `ObjectExplorerItems`")
        For Each row As DataRow In dt.Rows
            objectExplorerItems.Add(New objectExplorerItem(row(0), row(1)))
        Next
    End Sub

#Region "Includes Codes"
    Public Sub AddInclude(inc As String)
        Dim dt = _sqlCon.GetDataTable("SELECT * FROM `Includes` WHERE `incName` = '" + inc + "'")
        If dt.Rows.Count > 0 Then _sqlCon.ExecuteNonQuery("DELETE FROM `Includes` WHERE `incName` = '" + inc + "'")
        _sqlCon.ExecuteNonQuery("INSERT INTO `Includes` VALUES('" + inc + "');")
    End Sub
    Public Sub RemoveInclude(inc As String)
        _sqlCon.ExecuteNonQuery("DELETE FROM `Includes` WHERE `incName` = '" + inc + "'")
    End Sub
    Public Function IncludeExists(inc As String) As Boolean
        Dim dt = _sqlCon.GetDataTable("SELECT * FROM `Includes` WHERE `incName` = '" + inc + "'")
        If dt.Rows.Count > 0 Then Return True
        Return False
    End Function
#End Region

#Region "server.cfg"
    Public Sub EditSampConfig(key As String, value As String)
        'Variables
        Dim allInfo As New List(Of String)

        'Reading
        Dim textLine As String
        If System.IO.File.Exists(projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                allInfo.Add(TextLine)
            Loop

            objReader.Close()
        End If

        'Editing
        Dim allText As String = Nothing 'To short the loops :P
        Dim done As Boolean = False 'This is to know if it was edited or not.
        For Each str As String In allInfo
            Dim values() As String = str.Split(" ", 2, StringSplitOptions.None)
            If values(0) = key Then
                str = values(0) + " " + value
                allText += str + vbCrLf
                done = True
            Else
                allText += str + vbCrLf
            End If
        Next

        'If it wasn't edited, We add it.
        If done = False Then allText += key + " " + value

        'Writing
        My.Computer.FileSystem.WriteAllText(projectPath + "/server.cfg", allText, False)
    End Sub
    Public Function GetSampConfig(key As String) As String
        Dim textLine As String
        If IO.File.Exists(projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                Dim values() As String = TextLine.Split(" ", 2, StringSplitOptions.None)
                If values(0) = key And values.Length = 2 Then
                    objReader.Close()
                    Return values(1)
                End If
            Loop

            objReader.Close()
        End If

        Return -1
    End Function
#End Region

#Region "PluginsHandler"
    Public Sub AddPlugin(inc As String)
        Dim dt = _sqlCon.GetDataTable("SELECT * FROM `Plugins` WHERE `plugName` = '" + inc + "'")
        If dt.Rows.Count > 0 Then _sqlCon.ExecuteNonQuery("DELETE FROM `Plugins` WHERE `plugName` = '" + inc + "'")
        _sqlCon.ExecuteNonQuery("INSERT INTO `Plugins` VALUES('" + inc + "');")
    End Sub
    Public Sub RemovePlugin(inc As String)
        _sqlCon.ExecuteNonQuery("DELETE FROM `Plugins` WHERE `plugName` = '" + inc + "'")
    End Sub
    Public Function PluginExists(inc As String) As Boolean
        Dim dt = _sqlCon.GetDataTable("SELECT * FROM `Plugins` WHERE `plugName` = '" + inc + "'")
        If dt.Rows.Count > 0 Then Return True
        Return False
    End Function

    'Server.cfg stuff for plugins.
    Private Function GetPluginsListInServerCfg() As List(Of String)
        getPluginsListInServerCFG = New List(Of String)

        Dim st As String = GetSAMPConfig("plugins")
        If st = "-1" Then
            st = ""
        Else
            Dim bla As String() = st.Split(" ")

            For Each bl As String In bla
                If Not bl = "" Or Not bl = " " Then
                    getPluginsListInServerCFG.Add(bl)
                End If
            Next
        End If

        Return getPluginsListInServerCFG
    End Function
    Private Sub SavePluginsInServerCfg(plugs As List(Of String))
        Dim str As String = Nothing
        For Each plug As String In plugs
            str += " " + plug
        Next
        If str IsNot Nothing Then str = str.Remove(0, 1)

        EditSAMPConfig("plugins", str)
    End Sub

    Public Function IsPluginInServerCfg(pluginName As String)
        Dim lst As List(Of String) = getPluginsListInServerCFG()
        For Each str As String In lst
            If str = pluginName Then
                Return True
            End If
        Next

        Return False
    End Function
    Public Sub TogglePluginInServerCfg(pluginName As String)
        Dim lst As List(Of String) = getPluginsListInServerCFG()
        For Each str As String In lst
            If str = pluginName Then
                lst.Remove(str) 'Remove it then exit sub and don't continue adding it.
                savePluginsInServerCFG(lst) 'Save it
                Exit Sub
            End If
        Next

        'If code reaches here, Then it wasn't found so add it.
        lst.Add(pluginName)
        savePluginsInServerCFG(lst)
    End Sub

#End Region

End Class


Class SqLiteDatabase
    Private _dbConnection As [String]

    ''' <summary>
    '''     Default Constructor for SQLiteDatabase Class.
    ''' </summary>
    Public Sub New()
        _dbConnection = "Data Source=recipes.s3db"
    End Sub

    ''' <summary>
    '''     Single Param Constructor for specifying the DB file.
    ''' </summary>
    ''' <param name="inputFile">The File containing the DB</param>
    Public Sub New(inputFile As [String])
        _dbConnection = [String].Format("Data Source={0}", inputFile)
    End Sub

    ''' <summary>
    '''     Single Param Constructor for specifying advanced connection options.
    ''' </summary>
    ''' <param name="connectionOpts">A dictionary containing all desired options and their values</param>
    Public Sub New(connectionOpts As Dictionary(Of [String], [String]))
        Dim str As [String] = ""
        For Each row As KeyValuePair(Of [String], [String]) In connectionOpts
            str += [String].Format("{0}={1}; ", row.Key, row.Value)
        Next
        str = str.Trim().Substring(0, str.Length - 1)
        _dbConnection = str
    End Sub

    ''' <summary>
    '''     Allows the programmer to run a query against the Database.
    ''' </summary>
    ''' <param name="sql">The SQL to run</param>
    ''' <returns>A DataTable containing the result set.</returns>
    Public Function GetDataTable(sql As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim cnn As New SQLiteConnection(_dbConnection)
            cnn.Open()
            Dim mycommand As New SQLiteCommand(cnn)
            mycommand.CommandText = sql
            Dim reader As SQLiteDataReader = mycommand.ExecuteReader()
            dt.Load(reader)
            reader.Close()
            cnn.Close()
        Catch e As Exception
            Throw New Exception(e.Message)
        End Try
        Return dt
    End Function

    ''' <summary>
    '''     Allows the programmer to interact with the database for purposes other than a query.
    ''' </summary>
    ''' <param name="sql">The SQL to be run.</param>
    ''' <returns>An Integer containing the number of rows updated.</returns>
    Public Function ExecuteNonQuery(sql As String) As Integer
        Dim cnn As New SQLiteConnection(_dbConnection)
        cnn.Open()
        Dim mycommand As New SQLiteCommand(cnn)
        mycommand.CommandText = sql
        Dim rowsUpdated As Integer = mycommand.ExecuteNonQuery()
        cnn.Close()
        Return rowsUpdated
    End Function

    ''' <summary>
    '''     Allows the programmer to retrieve single items from the DB.
    ''' </summary>
    ''' <param name="sql">The query to run.</param>
    ''' <returns>A string.</returns>
    Public Function ExecuteScalar(sql As String) As String
        Dim cnn As New SQLiteConnection(_dbConnection)
        cnn.Open()
        Dim mycommand As New SQLiteCommand(cnn)
        mycommand.CommandText = sql
        Dim value As Object = mycommand.ExecuteScalar()
        cnn.Close()
        If value IsNot Nothing Then
            Return value.ToString()
        End If
        Return ""
    End Function

    ''' <summary>
    '''     Allows the programmer to easily update rows in the DB.
    ''' </summary>
    ''' <param name="tableName">The table to update.</param>
    ''' <param name="data">A dictionary containing Column names and their new values.</param>
    ''' <param name="where">The where clause for the update statement.</param>
    ''' <returns>A boolean true or false to signify success or failure.</returns>
    Public Function Update(tableName As [String], data As Dictionary(Of [String], [String]), where As [String]) As Boolean
        Dim vals As [String] = ""
        Dim returnCode As [Boolean] = True
        If data.Count >= 1 Then
            For Each val As KeyValuePair(Of [String], [String]) In data
                vals += [String].Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString())
            Next
            vals = vals.Substring(0, vals.Length - 1)
        End If
        Try
            Me.ExecuteNonQuery([String].Format("update {0} set {1} where {2};", tableName, vals, where))
        Catch
            returnCode = False
        End Try
        Return returnCode
    End Function

    ''' <summary>
    '''     Allows the programmer to easily delete rows from the DB.
    ''' </summary>
    ''' <param name="tableName">The table from which to delete.</param>
    ''' <param name="where">The where clause for the delete.</param>
    ''' <returns>A boolean true or false to signify success or failure.</returns>
    Public Function Delete(tableName As [String], where As [String]) As Boolean
        Dim returnCode As [Boolean] = True
        Try
            Me.ExecuteNonQuery([String].Format("delete from {0} where {1};", tableName, where))
        Catch fail As Exception
            MessageBox.Show(fail.Message)
            returnCode = False
        End Try
        Return returnCode
    End Function

    ''' <summary>
    '''     Allows the programmer to easily insert into the DB
    ''' </summary>
    ''' <param name="tableName">The table into which we insert the data.</param>
    ''' <param name="data">A dictionary containing the column names and data for the insert.</param>
    ''' <returns>A boolean true or false to signify success or failure.</returns>
    Public Function Insert(tableName As [String], data As Dictionary(Of [String], [String])) As Boolean
        Dim columns As [String] = ""
        Dim values As [String] = ""
        Dim returnCode As [Boolean] = True
        For Each val As KeyValuePair(Of [String], [String]) In data
            columns += [String].Format(" {0},", val.Key.ToString())
            values += [String].Format(" '{0}',", val.Value)
        Next
        columns = columns.Substring(0, columns.Length - 1)
        values = values.Substring(0, values.Length - 1)
        Try
            Me.ExecuteNonQuery([String].Format("insert into {0}({1}) values({2});", tableName, columns, values))
        Catch fail As Exception
            MessageBox.Show(fail.Message)
            returnCode = False
        End Try
        Return returnCode
    End Function

    ''' <summary>
    '''     Allows the programmer to easily delete all data from the DB.
    ''' </summary>
    ''' <returns>A boolean true or false to signify success or failure.</returns>
    Public Function ClearDb() As Boolean
        Dim tables As DataTable
        Try
            tables = Me.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;")
            For Each table As DataRow In tables.Rows
                Me.ClearTable(table("NAME").ToString())
            Next
            Return True
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    '''     Allows the user to easily clear all data from a specific table.
    ''' </summary>
    ''' <param name="table">The name of the table to clear.</param>
    ''' <returns>A boolean true or false to signify success or failure.</returns>
    Public Function ClearTable(table As [String]) As Boolean
        Try

            Me.ExecuteNonQuery([String].Format("delete from {0};", table))
            Return True
        Catch
            Return False
        End Try
    End Function
End Class