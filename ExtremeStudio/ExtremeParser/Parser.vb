Imports System.IO
Imports System.Text.RegularExpressions

Public Class Parser

    'PUBLICS: 
    Public Defines As New List(Of DefinesClass)
    Public Functions As New List(Of FunctionsClass)
    Public Stocks As New List(Of FunctionsClass)
    Public Publics As New List(Of FunctionsClass)
    Public Natives As New List(Of FunctionsClass)
    Public Enums As New List(Of EnumsClass)
    Public Includes As New Dictionary(Of String, Parser)
    Public publicVariables As New List(Of String)

    'PRIVATES: 
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

    Public Sub New(code As String, projectPath As String, Optional isInclude As Boolean = False)
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

        'Includes
        For Each Match As Match In Regex.Matches(code, "#include[ \t]+([^\s]+)")
            Dim text As String = Match.Groups(1).Value
            Dim fullPath As String = ""

            Dim type = text.Substring(0, 1)

            If type = Chr(34) Then
                'Remove the quotes.
                Try
                    text = text.Remove(text.IndexOf(Chr(34)), 1)
                    text = text.Remove(text.IndexOf(Chr(34)), 1)
                Catch ex As Exception
                    Continue For
                End Try

                fullPath = projectPath + "/gamemodes/" + text
            ElseIf type = "<"
                'Remove the brackets.
                Try
                    text = text.Remove(text.IndexOf("<"), 1)
                    text = text.Remove(text.IndexOf(">"), 1)
                Catch ex As Exception
                    Continue For
                End Try

                fullPath = projectPath + "\pawno\include\" + text
                If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
            Else
                fullPath = projectPath + "\pawno\include\" + text
                If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
            End If
            Try

                Dim prs As New Parser(My.Computer.FileSystem.ReadAllText(fullPath), projectPath, True)
                Includes.Add(text, prs)

                'Exceptions.
            Catch ex As DirectoryNotFoundException
                errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
            Catch ex As FileNotFoundException
                errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
            End Try
        Next

        'Defines & Macros: 
        Dim tmpDefines As New List(Of DefinesClass)
        For Each Match As Match In Regex.Matches(code, "#define[ \t]+([^\n\r\s\\;]+)[ \t]*([^\n\r\s;]+)")
            Dim defineName As String = Match.Groups(1).Value
            Dim defineValue As String = Match.Groups(2).Value

#Region "Check if its multiline or not, And if yes.. Start processing to get the lines."
            If defineValue = "\" Then
                defineValue = ""

                Dim pos As Integer = Match.Index + Match.Length + 1 ' 1 for Skip the coming vbLf.
                Dim neededLines As Integer = 1

                'Infinite loop.
                Dim finished As Boolean = False
                While (finished = False)
                    pos += 1

                    If code.Length <= pos Then finished = True : Exit While

                    If code(pos) = "\" Then
                        neededLines += 1
                    ElseIf code(pos) = vbCr Then
                        neededLines -= 1
                    Else
                        defineValue += code(pos)
                    End If

                    If neededLines <= 0 Then
                        finished = True
                    End If
                End While
            End If
#End Region

            Try
                tmpDefines.Add(new DefinesClass(defineName, defineValue, Match))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The define `" + defineName + "` already exists somewhere in the file.", defineName))
            End Try
        Next
        'Flip the defines upside down cuz the compiler goes from down to top, I guess.
        For i As Integer = tmpDefines.Count - 1 To 0 Step -1
            Defines.Add(tmpDefines(i))
        Next


        'Now loop though all defines in includes and such and then replace em.
        For Each inc In Includes.Keys
            For Each define In Includes(inc).Defines
                defineReplacer.Replace(code, define.DefineName, define.DefineValue)
            Next
        Next

        'Publics.
        For Each Match As Match In Regex.Matches(code, "public[ \t]+(.+)[ \t]*\((.*)\)", RegexOptions.Multiline)
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                'Remove the tag if exists.
                If funcName.Contains(":") Then
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Publics.Add(New FunctionsClass(funcName, funcParams, Match, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The public `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Stocks
        For Each Match As Match In Regex.Matches(code, "stock[ \t]+(.+)[ \t]*\((.*)\)", RegexOptions.Multiline)
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                'Remove the tag if exists.
                If funcName.Contains(":") Then
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Stocks.Add(New FunctionsClass(funcName, funcParams, Match, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The stock `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Functions in General -- Removed all strings because some strings which contains a { bugs the below regex.
        code = Regex.Replace(code, "'[^'\\]*(?:\\[^\n\r\x85\u2028\u2029][^'\\]*)*'", "")
        code = Regex.Replace(code, Chr(34) + "[^" + Chr(34) + "\\]*(?:\\[^\n\r\x85\u2028\u2029][^" + Chr(34) + "\\]*)*" + Chr(34), "")

        For Each Match As Match In Regex.Matches(code, "^[ \t]*(.+)(?<!" + funcLikeKeywords + ")\((.*)\)[ \t]*{", RegexOptions.Multiline)
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                'Remove the tag if exists.
                If funcName.Contains(":") Then
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Functions.Add(New FunctionsClass(funcName, funcParams, Match, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The function `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Natives
        For Each Match As Match In Regex.Matches(code, "native[ \t]+(.+)[ \t]*?\((.*)\)", RegexOptions.Multiline)
            Dim funcName As String = Match.Groups(1).Value
            Dim funcParams As String = Match.Groups(2).Value
            Try
                'Remove the tag if exists.
                If funcName.Contains(":") Then
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Natives.Add(New FunctionsClass(funcName, funcParams, Match, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The native `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Enums
        For Each Match As Match In Regex.Matches(code, "enum\s+([^\n;\(\)\{\}\s]*)\s+(?:(?:[{])([^}]+)(?:[}]))")
            Dim enumds As String() = Match.Groups(2).Value.Split(",")

            'Variable to store the enums contents.
            Dim enumStuff As New List(Of EnumsContentsClass)

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
                    enumStuff.Add(New EnumsContentsClass(enuma, type))
                Catch ex As Exception
                    errors.exceptionsList.Add(New ParserException("The enum `" + enuma + "` already exists somewhere in the file.", enuma))
                End Try
            Next

            'Now add it to the actual list.
            Enums.Add(New EnumsClass(Match.Captures(1).Value, enumStuff)))
        Next

        'Remove all curly brackets and its contents to remove all child codes.
        'To be able to get global variables.
        Dim finish As Boolean = False
        While (finish = False)
            If Regex.IsMatch(code, "\{(?:[^{}]*?)\}") Then
                code = Regex.Replace(code, "\{(?:[^{}]*?)\}", "")
            Else
                finish = True
            End If
        End While

        'Now parse for all global variables.
        For Each match As Match In Regex.Matches(code, "new[ \t]+(.*);")
            Dim varName As String = match.Groups(1).Value

            'Remove all whitespace.
            varName = varName.Replace(" ", "")
            varName = varName.Replace(vbTab, "")

            'Now if there is multiple variables in one.. Split it.
            Dim allVars As String()

            If varName.Contains(",") Then
                allVars = varName.Split(",")
            Else
                allVars = {varName}
            End If

            'Loop through all.
            For Each str As String In allVars
                'Remove tags.
                If str.Contains(":") Then
                    str = str.Remove(0, str.IndexOf(":") + 1)
                End If

                'Remove all arrays.
                Dim done As Boolean = False
                While done = False
                    If str.Contains("[") And str.Contains("]") Then
                        str = str.Remove(str.IndexOf("["), (str.IndexOf("]") - str.IndexOf("[")) + 1)
                    Else
                        done = True
                    End If
                End While

                'Remove default
                If str.Contains("=") Then
                    str = str.Remove(str.IndexOf("="), str.Length - str.IndexOf("="))
                End If

                'Add
                publicVariables.Add(str)
            Next
        Next
    End Sub
End Class
