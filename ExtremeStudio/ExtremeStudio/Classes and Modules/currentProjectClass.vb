Imports System.Data.SQLite

Public Class currentProjectClass
    Public Property projectName As String
    Public Property projectVersion As Integer

    Private projectPathB As String
    Public Property projectPath As String
        Set(value As String)
            sqlCon = New SQLiteDatabase(value + "/extremeStudio.config")
            projectPathB = value
        End Set
        Get
            Return projectPathB
        End Get
    End Property

    Public Property objectExplorerItems As New List(Of objectExplorerItem)

#Region "SQL Funcs"
    Dim sqlCon As SQLiteDatabase
    Public Sub CreateTables()
        sqlCon.ExecuteNonQuery("CREATE TABLE MainConfig(`name` STRING(50), `value` STRING(50));")
        sqlCon.ExecuteNonQuery("CREATE TABLE ObjectExplorerItems(`name` STRING(50), `identifier` STRING(50));")
    End Sub
#End Region

    Public Sub SaveInfo() 'Will only work if the projectPath is set to valid ExtremeStudio project.
        Dim dic As New Dictionary(Of String, String)

        'Instead of doing a huge logic for updating and inserting on first time and this stuff.. I just will
        'Delete the whole data in each table before writing.

#Region "MainConfig"
        'Save projects name.
        dic.Clear() : sqlCon.ClearTable("MainConfig")
        dic.Add("name", "ProjectName")
        dic.Add("value", projectName)
        sqlCon.Insert("MainConfig", dic)

        'Save projects version.
        dic.Clear()  'Table already cleared once. :P
        dic.Add("name", "ProjectVersion")
        dic.Add("value", projectVersion)
        sqlCon.Insert("MainConfig", dic)
#End Region

        'Save the objectexporleritems.
        sqlCon.ClearTable("ObjectExplorerItems")
        For Each itm In objectExplorerItems
            dic.Clear()
            dic.Add("name", itm.Name)
            dic.Add("identifier", itm.Identifier)
            sqlCon.Insert("ObjectExplorerItems", dic)
        Next
    End Sub

    Public Sub ReadInfo() 'Will only work if the projectPath is set to valid ExtremeStudio project.
        'Read main info like project name and version.
        projectName = sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectName'")
        projectVersion = Convert.ToInt16(sqlCon.ExecuteScalar("SELECT value FROM MainConfig WHERE name='ProjectVersion'"))

        'Get all the objectexpolreritems.
        Dim dt As DataTable = sqlCon.GetDataTable("SELECT * FROM `ObjectExplorerItems`")
        For Each row As DataRow In dt.Rows
            objectExplorerItems.Add(New objectExplorerItem(row(0), row(1)))
        Next
    End Sub

#Region "server.cfg"
    Public Sub EditSAMPConfig(key As String, value As String)
        'Variables
        Dim allInfo As New List(Of String)

        'Reading
        Dim TextLine As String
        If System.IO.File.Exists(projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                allInfo.Add(TextLine)
            Loop
        End If

        'Editing
        Dim allText As String = Nothing 'To short the loops :P
        For Each Str As String In allInfo
            Dim values() As String = Str.Split(" ", 2, StringSplitOptions.None)
            If values(0) = key Then
                values(1) = value
                Str = values(0) + " " + values(1)
                allText = Str + vbCrLf
                Exit For
            End If
            allText = Str + vbCrLf
        Next

        'Writing
        My.Computer.FileSystem.WriteAllText(projectPath + "/server.cfg", allText, False)
    End Sub
    Public Function GetSAMPConfig(key As String)
        Dim TextLine As String
        If System.IO.File.Exists(projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                Dim values() As String = TextLine.Split(" ", 2, StringSplitOptions.None)
                If values(0) = key Then
                    Return values(1)
                End If
            Loop
        End If
        Return -1
    End Function
#End Region

End Class


Class SQLiteDatabase
    Private dbConnection As [String]

    ''' <summary>
    '''     Default Constructor for SQLiteDatabase Class.
    ''' </summary>
    Public Sub New()
        dbConnection = "Data Source=recipes.s3db"
    End Sub

    ''' <summary>
    '''     Single Param Constructor for specifying the DB file.
    ''' </summary>
    ''' <param name="inputFile">The File containing the DB</param>
    Public Sub New(inputFile As [String])
        dbConnection = [String].Format("Data Source={0}", inputFile)
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
        dbConnection = str
    End Sub

    ''' <summary>
    '''     Allows the programmer to run a query against the Database.
    ''' </summary>
    ''' <param name="sql">The SQL to run</param>
    ''' <returns>A DataTable containing the result set.</returns>
    Public Function GetDataTable(sql As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim cnn As New SQLiteConnection(dbConnection)
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
        Dim cnn As New SQLiteConnection(dbConnection)
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
        Dim cnn As New SQLiteConnection(dbConnection)
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
    Public Function ClearDB() As Boolean
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