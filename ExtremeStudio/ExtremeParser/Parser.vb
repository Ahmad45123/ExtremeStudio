Imports System.IO
Imports System.Text.RegularExpressions

Public Class Parser

    Public Defines As New DictionaryEx(Of String, String) 'name, value.
    Public Functions As New DictionaryEx(Of String, FunctionParameters) 'func name, func params class
    Public Stocks As New DictionaryEx(Of String, FunctionParameters) 'func name, func params class
    Public Publics As New DictionaryEx(Of String, FunctionParameters) 'func name, func params class
    Public Natives As New DictionaryEx(Of String, FunctionParameters) 'func name, fiunc params class
    Public Enums As New DictionaryEx(Of String, FunctionParameters.varTypes) 'enum name, the enum type
    Public Includes As New Dictionary(Of String, Parser) 'Include path|name, The include parse.

    Private pawnDocs As New List(Of PawnDoc)

    ''' <summary>
    ''' This is a list of the PAWN language keywords that look like functions.
    ''' Keywords must be seperated with a `|`
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property funcLikeKeywords As String = "do|for|switch|while|if|foreach"

    Public errors As New ExceptionsList

    Public Sub New(filePath As String, projectPath As String, Optional isInclude As Boolean = False)
        'Code
        Dim code As String = ""
        Try
            code = My.Computer.FileSystem.ReadAllText(filePath)
        Catch ex As DirectoryNotFoundException
            If isInclude Then
                Throw New IncludeNotFoundException(Path.GetFileNameWithoutExtension(filePath))
                Exit Sub
            Else
                Throw ex
            End If
        Catch ex As FileNotFoundException
            If isInclude Then
                Throw New IncludeNotFoundException(Path.GetFileNameWithoutExtension(filePath))
                Exit Sub
            Else
                Throw ex
            End If
        End Try

        'PawnDoc -- Placed before comments removel because pawndoc is basically a comment.
        For Each Match As Match In Regex.Matches(code, "(?:\/\*\/{1,}\*\/(?:\r\n|\r|\n))((?:\/\/\/.*(?:\r\n|\r|\n))+)(?:\/\*\\{1,}\*\/)") 'Longest RegEx in the world ? :P
            Dim val As String = Match.Groups(0).Value 'Group 0 which contains only the internal text without the start and the end.
            Try
                pawnDocs.Add(New PawnDoc(val))
            Catch ex As ParserException
                Throw New ParserException(ex.Message, "")
            End Try
        Next

        'Remove all comments from code.
        code = Regex.Replace(code, "//.*", "")
        code = Regex.Replace(code, "\/\*[\s\S]*?\*\/", "", RegexOptions.Multiline)

        'Defines & Macros: 
        For Each Match As Match In Regex.Matches(code, "#define\s+([^\n; ]+)\s+(.+)")
            Dim defineName As String = Match.Groups(1).Value
            Dim defineValue As String = Match.Groups(2).Value

            Try
                Defines.Add(defineName, defineValue)
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The define `" + defineName + "` already exists somewhere in the file.", defineName))
            End Try
        Next

        'Publics.
        For Each Match As Match In Regex.Matches(code, "public\s+([^\n;\(\)\{\} ]+)\s*?\((.*)\)")
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                Publics.Add(funcName, New FunctionParameters(funcParams))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The public `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
            If pawnDocs IsNot Nothing Then
                For Each doc As PawnDoc In pawnDocs
                    If doc.Summary = funcName Then Publics(funcName).pawnDoc = doc : Exit For
                Next
            End If
        Next

        'Stocks
        For Each Match As Match In Regex.Matches(code, "stock\s+([^\n;\(\)\{\} ]+)\s*?\((.*)\)")
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                Stocks.Add(funcName, New FunctionParameters(funcParams))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The stock `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
            If pawnDocs IsNot Nothing Then
                For Each doc As PawnDoc In pawnDocs
                    If doc.Summary = funcName Then Stocks(funcName).pawnDoc = doc : Exit For
                Next
            End If
        Next

        'Includes
        If isInclude = False Then
            For Each Match As Match In Regex.Matches(code, "#include\s+(" + Chr(34) + "|<)(.+)(?:" + Chr(34) + "|>)")
                Dim type As String = Match.Groups(1).Value
                Dim text As String = Match.Groups(2).Value
                Dim fullPath As String = ""

                If type = Chr(34) Then
                    fullPath = projectPath + "/gamemodes/" + text
                ElseIf type = "<"
                    fullPath = projectPath + "\pawno\include\" + text
                    If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
                End If
                Try
                    Dim prs As New Parser(fullPath, projectPath, True)
                    Includes.Add(text, prs)
                Catch ex As IncludeNotFoundException
                    errors.exceptionsList.Add(ex)
                End Try
            Next
        End If

        'Functions in General -- Removed all strings because some strings which contains a { bugs the below regex.
        code = Regex.Replace(code, "'[^'\\]*(?:\\[^\n\r\x85\u2028\u2029][^'\\]*)*'", "")
        code = Regex.Replace(code, Chr(34) + "[^" + Chr(34) + "\\]*(?:\\[^\n\r\x85\u2028\u2029][^" + Chr(34) + "\\]*)*" + Chr(34), "")

        For Each Match As Match In Regex.Matches(code, "^\s*([^\n;\(\)\{\} ]+)(?<!" + funcLikeKeywords + ")\((.*)\)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                Functions.Add(funcName, New FunctionParameters(funcParams))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The function `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
            If pawnDocs IsNot Nothing Then
                For Each doc As PawnDoc In pawnDocs
                    If doc.Summary = funcName Then Functions(funcName).pawnDoc = doc : Exit For
                Next
            End If
        Next

        'Natives
        For Each Match As Match In Regex.Matches(code, "native\s+([^\n;\(\)\{\} ]+)\s*?\((.*)\)")
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                Natives.Add(funcName, New FunctionParameters(funcParams))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The native `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
            If pawnDocs IsNot Nothing Then
                For Each doc As PawnDoc In pawnDocs
                    If doc.Summary = funcName Then Natives(funcName).pawnDoc = doc : Exit For
                Next
            End If
        Next

        'Enums
        For Each Match As Match In Regex.Matches(code, "enum\s+([^\n;\(\)\{\} ]*)\s+(?:(?:[{])([^}]+)(?:[}]))")
            Dim enumds As String() = Match.Groups(2).Value.Split(",")

            For Each enuma As String In enumds
                'Check if empty
                If enuma Is Nothing Or enuma.Trim = "" Then Continue For

                Dim length As Integer = enuma.Length + 1
                enuma = enuma.Trim
                Dim type = FunctionParameters.getVarType(enuma)

                'Do what needs to be changed
                If type = FunctionParameters.varTypes.TYPE_FLOAT Then
                    enuma = enuma.Remove(0, 6)
                ElseIf type = FunctionParameters.varTypes.TYPE_ARRAY Then
                    enuma = enuma.Remove(enuma.IndexOf("["), (enuma.IndexOf("]") - enuma.IndexOf("[")) + 1)
                ElseIf type = FunctionParameters.varTypes.TYPE_TAGGED Then
                    enuma = enuma.Remove(0, enuma.IndexOf(":") + 1)
                End If

                Try
                    Enums.Add(enuma, type)
                Catch ex As Exception
                    errors.exceptionsList.Add(New ParserException("The enum `" + enuma + "` already exists somewhere in the file.", enuma))
                End Try
            Next
        Next
    End Sub
End Class
