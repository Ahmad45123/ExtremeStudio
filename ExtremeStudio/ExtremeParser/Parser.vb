Imports System.IO
Imports System.Text.RegularExpressions

Public Class Parser

    'PUBLICS: 
    Public Defines As New List(Of DefinesStruct)
    Public Macros As New List(Of DefinesStruct)
    Public Functions As New List(Of FunctionsStruct)
    Public Stocks As New List(Of FunctionsStruct)
    Public Publics As New List(Of FunctionsStruct)
    Public Natives As New List(Of FunctionsStruct)
    Public Enums As New List(Of EnumsStruct)
    Public Includes As New Dictionary(Of String, Parser)
    Public publicVariables As New List(Of VarStruct)

    'PRIVATES: 
    Private pawnDocs As New List(Of PawnDoc)

    ''' <summary>
    ''' This is a list of the PAWN language keywords that look like functions.
    ''' Keywords must be seperated with a `|`
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property funcLikeKeywords As String = "do|for|switch|while|if|foreach|else"

    Public errors As New ExceptionsList

    Private isValid As Boolean = True
    Public Sub New(code As String, filePath As String, projectPath As String, Optional parsed As List(Of String) = Nothing)
        If code Is Nothing Then Exit Sub

        'Set as already parsed.
        If filePath IsNot Nothing Then

            If parsed Is Nothing Then
                parsed = New List(Of String)
            End If

            'Check if already parsed and if so, Skip.
            For Each str As String In parsed
                If str = Path.GetFileName(filePath) Then
                    isValid = False
                    Exit Sub
                End If
            Next

            parsed.Add(Path.GetFileName(filePath))
        End If

        'Remove singleline comments from code.
        code = Regex.Replace(code, "//.*", "")

        'PawnDoc -- Placed before multiline comments removel because pawndoc is basically a comment.
        For Each Match As Match In Regex.Matches(code, "/\*\*([\s\S]*?)\*/")
            Dim val As String = Match.Groups(1).Value 'Group 0 which contains only the internal text without the start and the end.

            If Not val.Contains("<summary>") Or Not val.Contains("</summary>") Then Continue For

            Try
                pawnDocs.Add(New PawnDoc(val))
            Catch ex As ParserException
                Throw New ParserException(ex.Message, "")
            End Try
        Next

        'Remove multiline comments.
        code = Regex.Replace(code, "\/\*[\s\S]*?\*\/", "", RegexOptions.Multiline)

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
            Enums.Add(New EnumsStruct(Match.Groups(1).Value, enumStuff))
        Next

        'Remove all curly brackets and its contents to remove all child codes.
        code = Regex.Replace(code, "(?<=\{)(?>[^{}]+|\{(?<DEPTH>)|\}(?<-DEPTH>))*(?(DEPTH)(?!))(?=\})", "")

        'Includes
        For Each Match As Match In Regex.Matches(code, "\#include[ \t]+([^\s]+)", RegexOptions.Multiline)
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

                fullPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(filePath)), text)
                If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
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

                Dim prs As New Parser(My.Computer.FileSystem.ReadAllText(fullPath), fullPath, projectPath, parsed)
                If prs.isValid Then Includes.Add(text, prs)

                'Exceptions.
            Catch ex As DirectoryNotFoundException
                errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
            Catch ex As FileNotFoundException
                errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
            End Try
        Next

        'Remove all strings.
        code = Regex.Replace(code, "'[^'\\]*(?:\\[^\n\r\x85\u2028\u2029][^'\\]*)*'", "")
        code = Regex.Replace(code, Chr(34) + "[^" + Chr(34) + "\\]*(?:\\[^\n\r\x85\u2028\u2029][^" + Chr(34) + "\\]*)*" + Chr(34), "")

        'Defines & Macros: 
        Dim tmpDefines As New List(Of DefinesStruct)
        For Each Match As Match In Regex.Matches(code, "^[ \t]*[#]define[ \t]+(?<name>[^\s\\;]+)[ \t]*(?:\\\s+)?(?>(?<value>[^\\\n\r]+)[ \t]*(?:\\\s+)?)*", RegexOptions.Multiline)
            Dim defineName As String = Match.Groups(1).Value
            Dim defineValue As String = ""

            For Each capt As Capture In Match.Groups(2).Captures
                defineValue += capt.Value.Trim + vbCrLf
            Next

            Try
                tmpDefines.Add(New DefinesStruct(defineName.Trim, defineValue.Trim, Match))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The define `" + defineName + "` already exists somewhere in the file.", defineName))
            End Try
        Next
        'Flip the defines upside down cuz the compiler goes from down to top, I guess.
        For i As Integer = tmpDefines.Count - 1 To 0 Step -1
            If tmpDefines(i).DefineName.Contains("%") Then
                Macros.Add(tmpDefines(i))
            Else
                Defines.Add(tmpDefines(i))
            End If
        Next

        'Now loop though all defines in includes And such And then replace em.
        For Each inc In Includes.Keys
            For i As Integer = 0 To Includes(inc).Defines.Count - 1
                defineReplacer.Replace(code, Includes(inc).Defines(i).DefineName, Includes(inc).Defines(i).DefineValue)
            Next
            For i As Integer = 0 To Includes(inc).Macros.Count - 1
                defineReplacer.Replace(code, Includes(inc).Macros(i).DefineName, Includes(inc).Macros(i).DefineValue)
            Next
        Next
        For i As Integer = 0 To Defines.Count - 1
            defineReplacer.Replace(code, Defines(i).DefineName, Defines(i).DefineValue)
        Next
        For i As Integer = 0 To Macros.Count - 1
            defineReplacer.Replace(code, Macros(i).DefineName, Macros(i).DefineValue)
        Next

        'Publics.
        For Each Match As Match In Regex.Matches(code, "public[ \t]+([a-zA-Z1-3_@: \t]+)[ \t]*\((.*)\)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Publics.Add(New FunctionsStruct(funcName, funcParams, Match, tag, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The public `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Stocks
        For Each Match As Match In Regex.Matches(code, "stock[ \t]+([a-zA-Z1-3_@: \t]+)[ \t]*\((.*)\)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Stocks.Add(New FunctionsStruct(funcName, funcParams, Match, tag, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The stock `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Functions in General.
        For Each Match As Match In Regex.Matches(code, "^[ \t]*(?!" + funcLikeKeywords + ")(?:\sstatic\s+stock\s+|\sstock\s+static\s+|\sstatic\s+)?([^ \t\n\r]+)\((.*)\)(?!;)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Functions.Add(New FunctionsStruct(funcName, funcParams, Match, tag, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The function `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Natives
        For Each Match As Match In Regex.Matches(code, "native[ \t]+([a-zA-Z1-3_@: \t]+)[ \t]*?\((.*)\);", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDoc = Nothing
                If pawnDocs IsNot Nothing Then
                    For Each doc As PawnDoc In pawnDocs
                        If doc.Summary = funcName Then pwndoc = doc : Exit For
                    Next
                End If

                Natives.Add(New FunctionsStruct(funcName, funcParams, Match, tag, pwndoc))
            Catch ex As Exception
                errors.exceptionsList.Add(New ParserException("The native `" + funcName + "` already exists somewhere in the file.", funcName))
            End Try
        Next

        'Now parse for all global variables.
        For Each match As Match In Regex.Matches(code, "(?:\s?stock\s+static|\s?static\s+stock|\s?new\s+stock|\s?new|\s?static|\s?stock)\s*([\s\S]*?);", RegexOptions.Multiline)
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
                'Get tag and remove.
                Dim tag As String = ""
                If str.Contains(":") Then
                    tag = str.Substring(0, str.IndexOf(":") + 1)
                    str = str.Remove(0, str.IndexOf(":") + 1)
                End If

                'Get and Remove all arrays.
                Dim arrays As New List(Of String)
                For Each mtch As Match In Regex.Matches(str, "(?<=\[)(?>[^\[\]]+|\[(?<DEPTH>)|\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\])")
                    arrays.Add(mtch.Value)
                Next
                str = Regex.Replace(str, "\[(?<=\[)(?>[^\[\]]+|\[(?<DEPTH>)|\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\])\]", "")

                'Get then Remove default
                Dim def As String = ""
                If str.Contains("=") Then
                    def = str.Substring(str.IndexOf("="), str.Length - str.IndexOf("="))
                    str = str.Remove(str.IndexOf("="), str.Length - str.IndexOf("="))
                End If

                'Add
                publicVariables.Add(New VarStruct(str, tag, def, arrays))
            Next
        Next

        My.Computer.FileSystem.WriteAllText("D:/test.pwn", code, False)

        'Now to checks for if defined stuff And remove as needed.
        For Each match As Match In Regex.Matches(code, "\#if[ \t]+(!)?defined[ \t]+(.+)([\s\S]*?)\#endif", RegexOptions.Multiline)
            Dim isNt As Boolean = IIf(match.Groups(1).Value = "", False, True)
            Dim condition As String = ""
            Dim mainCode As String = ""
            Dim elseClode As String = " "

            'Start filling the vars.
            condition = match.Groups(2).Value.Trim

            If match.Groups(3).Value.Contains("#else") Then
                Dim s As String() = Split(match.Groups(3).Value, "#else")
                mainCode = s(0).Trim : elseClode = s(1).Trim
            Else
                mainCode = match.Groups(3).Value.Trim
            End If

            'The result of the parse will be saved here for deletion.
            Dim result As Parser = Nothing

            'Now check which part needs to be parsed by seeing isNt and the else.
            If isNt = False Then
                'Here the thing should NOT be defined
                If isDefined(condition) = False Then
                    'Parse the main.
                    result = New Parser(mainCode, Nothing, Nothing)
                Else
                    'Parse the else.
                    result = New Parser(elseClode, Nothing, Nothing)
                End If
            Else
                'It SHOULD be defined.
                If isDefined(condition) = True Then
                    'Parse the main.
                    result = New Parser(mainCode, Nothing, Nothing)
                Else
                    'Parse the else.
                    result = New Parser(elseClode, Nothing, Nothing)
                End If
            End If

            'After we have got the stuff that needs to be removed,
            'Start looping through all of them and removing as necessery.
            For i As Integer = 0 To result.Defines.Count - 1
                For a As Integer = 0 To Defines.Count - 1
                    If result.Defines(i) = Defines(a) Then
                        Defines.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To result.Stocks.Count - 1
                For a As Integer = 0 To Stocks.Count - 1
                    If result.Stocks(i) = Stocks(a) Then
                        Stocks.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To result.Publics.Count - 1
                For a As Integer = 0 To Publics.Count - 1
                    If result.Publics(i) = Publics(a) Then
                        Publics.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To result.Functions.Count - 1
                For a As Integer = 0 To Functions.Count - 1
                    If result.Functions(i) = Functions(a) Then
                        Functions.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To result.Natives.Count - 1
                For a As Integer = 0 To Natives.Count - 1
                    If result.Natives(i) = Natives(a) Then
                        Natives.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To result.Enums.Count - 1
                For a As Integer = 0 To Enums.Count - 1
                    If result.Enums(i) = Enums(a) Then
                        Enums.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            For i As Integer = 0 To result.publicVariables.Count - 1
                For a As Integer = 0 To publicVariables.Count - 1
                    If result.publicVariables(i) = publicVariables(a) Then
                        publicVariables.RemoveAt(a)
                        Exit For
                    End If
                Next
            Next
            'And thats it :D
        Next
    End Sub

    Private Function isDefined(str As String)
        For i As Integer = 0 To Defines.Count - 1
            If Defines(i).DefineName = str Then Return True
        Next
        For i As Integer = 0 To Stocks.Count - 1
            If Stocks(i).FuncName = str Then Return True
        Next
        For i As Integer = 0 To Publics.Count - 1
            If Publics(i).FuncName = str Then Return True
        Next
        For i As Integer = 0 To Functions.Count - 1
            If Functions(i).FuncName = str Then Return True
        Next
        For i As Integer = 0 To Natives.Count - 1
            If Natives(i).FuncName = str Then Return True
        Next
        For i As Integer = 0 To Enums.Count - 1
            If Enums(i).EnumName = str Then Return True
        Next
        For i As Integer = 0 To publicVariables.Count - 1
            If publicVariables(i).VarName = str Then Return True
        Next

        Return False
    End Function

    Public Shared Operator -(first As Parser, second As Parser)
        For i As Integer = 0 To first.Defines.Count - 1
            For a As Integer = 0 To second.Defines.Count - 1
                If first.Defines(i).DefineName = second.Defines(a).DefineName Then first.Defines.RemoveAt(i)
            Next
        Next
        For i As Integer = 0 To first.Stocks.Count - 1
            For a As Integer = 0 To second.Stocks.Count - 1
                If first.Stocks(i).FuncName = second.Stocks(a).FuncName Then first.Stocks.RemoveAt(i)
            Next
        Next
        For i As Integer = 0 To first.Publics.Count - 1
            For a As Integer = 0 To second.Publics.Count - 1
                If first.Publics(i).FuncName = second.Publics(a).FuncName Then first.Publics.RemoveAt(i)
            Next
        Next
        For i As Integer = 0 To first.Functions.Count - 1
            For a As Integer = 0 To second.Functions.Count - 1
                If first.Functions(i).FuncName = second.Functions(a).FuncName Then first.Functions.RemoveAt(i)
            Next
        Next
        For i As Integer = 0 To first.Natives.Count - 1
            For a As Integer = 0 To second.Natives.Count - 1
                If first.Natives(i).FuncName = second.Natives(a).FuncName Then first.Natives.RemoveAt(i)
            Next
        Next
        For i As Integer = 0 To first.Enums.Count - 1
            For a As Integer = 0 To second.Enums.Count - 1
                If first.Enums(i).EnumName = second.Enums(a).EnumName Then first.Enums.RemoveAt(i)
            Next
        Next
        For i As Integer = 0 To first.publicVariables.Count - 1
            For a As Integer = 0 To second.publicVariables.Count - 1
                If first.publicVariables(i).VarName = second.publicVariables(a).VarName Then first.publicVariables.RemoveAt(i)
            Next
        Next

        Return first
    End Operator

    Public Shared Operator +(first As Parser, second As Parser)
        For a As Integer = 0 To second.Defines.Count - 1
            first.Defines.Add(second.Defines(a))
        Next
        For a As Integer = 0 To second.Stocks.Count - 1
            first.Stocks.Add(second.Stocks(a))
        Next
        For a As Integer = 0 To second.Publics.Count - 1
            first.Publics.Add(second.Publics(a))
        Next
        For a As Integer = 0 To second.Functions.Count - 1
            first.Functions.Add(second.Functions(a))
        Next
        For a As Integer = 0 To second.Natives.Count - 1
            first.Natives.Add(second.Natives(a))
        Next
        For a As Integer = 0 To second.Enums.Count - 1
            first.Enums.Add(second.Enums(a))
        Next
        For a As Integer = 0 To second.publicVariables.Count - 1
            first.publicVariables.Add(second.publicVariables(a))
        Next

        Return first
    End Operator
End Class
