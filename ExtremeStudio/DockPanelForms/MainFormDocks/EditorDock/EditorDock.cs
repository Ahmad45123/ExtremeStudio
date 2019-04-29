using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutocompleteMenuNS;
using ExtremeCore.Classes;
using ExtremeParser;
using ExtremeParser.Exceptions;
using ExtremeParser.Global;
using ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.AutoComplete;
using ExtremeStudio.FunctionsForms;
using Resources;
using ScintillaNET;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock
{
    public partial class EditorDock
    {
        public EditorDock()
        {
            Scintilla.SetDestroyHandleBehavior(true);
            InitializeComponent();

            Editor.BeforeDelete += BeforeTextChangedDelayed_Timer;
            Editor.BeforeDelete += OnRemove;
            Editor.BeforeInsert += BeforeTextChangedDelayed_Timer;
            Editor.BeforeInsert += OnAdd;
            Editor.CharAdded += CallTip_Editor_CharAdded;
            Editor.CharAdded += ColorPicker_CharAdded;
            Editor.UpdateUI += Editor_UpdateStyle;
        }

        //Global Vars
        public enum IndicatorIDs
        {
            IndicatorParserError = 50, //Start from 50
            IndicatorPawndocError,
            IndicatorSearchItem
        }

        public CodeParts CodeParts = new CodeParts();

        List<AutoCompleteItemEx> _autoCompleteList = new List<AutoCompleteItemEx>();

        public bool IsFirstParse = true;

        //UnRelated events here.
        private void EditorDock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Editor.Modified)
            {
                var res = MessageBox.Show(translations.EditorDock_EditorDock_FormClosing_FileContainsUnSavedContent, "", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    Program.MainForm.SaveFile(Editor);
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            _idleTimer.Stop();

            if (RefreshWorker.IsBusy)
            {
                Program.MainForm.statusLabel.Text = translations.EditorDock_RefreshWorker_RunWorkerCompleted_Idle;
            }
        }

        #region Key Handling

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Program.SettingsForm.SaveHotkey.Hotkey | Program.SettingsForm.SaveHotkey.HotkeyModifiers))
            {
                Program.MainForm.SaveFile(Editor);
                Editor.SetSavePoint();
                return true;

            }

            if (keyData == (Program.SettingsForm.SaveAllHotkey.Hotkey | Program.SettingsForm.SaveAllHotkey.HotkeyModifiers))
            {
                Program.MainForm.SaveFile(Editor);
                Editor.SetSavePoint();
                Program.MainForm.SaveAllFiles(this, EventArgs.Empty);
                return true;

            }

            if (keyData == (Program.SettingsForm.GotoHotkey.Hotkey | Program.SettingsForm.GotoHotkey.HotkeyModifiers))
            {
                Program.GotoForm.Show();
                return true;

            }

            if (keyData == (Program.SettingsForm.SearchHotkey.Hotkey | Program.SettingsForm.SearchHotkey.HotkeyModifiers))
            {
                if (!Program.SearchReplaceForm.Visible)
                {
                    Program.SearchReplaceForm.Show();
                }

                Program.SearchReplaceForm.TabControl1.SelectTab(0); //Search Tab.
                Program.SearchReplaceForm.searchFindText.Select();
                return true;

            }

            if (keyData == (Program.SettingsForm.ReplaceHotkey.Hotkey | Program.SettingsForm.ReplaceHotkey.HotkeyModifiers))
            {
                Program.SearchReplaceForm.Show();
                Program.SearchReplaceForm.TabControl1.SelectTab(1); //Replace Tab.
                return true;

            }

            if (keyData == (Program.SettingsForm.GotoNextHotkey.Hotkey | Program.SettingsForm.GotoNextHotkey.HotkeyModifiers))
            {
                //If SearchReplaceForm.travelList.Count > 1 Then
                //    Dim nearestNext As Long = 999999999999999999
                //    Dim nearestID As Integer = 0
                //    For i As Integer = 0 To SearchReplaceForm.travelList.Count - 1
                //        If SearchReplaceForm.travelList(i).Key > Editor.CurrentPosition And SearchReplaceForm.travelList(i).Key < nearestNext Then
                //            nearestNext = SearchReplaceForm.travelList(i).Key
                //            nearestID = i
                //        End If
                //    Next
                //    Editor.SetSelection(SearchReplaceForm.travelList(nearestID).Key, SearchReplaceForm.travelList(nearestID).Value)
                //    Editor.ScrollCaret()
                //End If
                Program.SearchReplaceForm.SearchAndMark(Program.SearchReplaceForm.searchFindText.Text);
                return true;

            }

            if (keyData == (Program.SettingsForm.GotoBeforeHotkey.Hotkey | Program.SettingsForm.GotoBeforeHotkey.HotkeyModifiers))
            {
                //If SearchReplaceForm.travelList.Count > 1 Then
                //    Dim nearestNext As Long = 0
                //    Dim nearestID As Integer = 0
                //    For i As Integer = 0 To SearchReplaceForm.travelList.Count - 1
                //        If SearchReplaceForm.travelList(i).Key < Editor.CurrentPosition And SearchReplaceForm.travelList(i).Key > nearestNext Then
                //            nearestNext = SearchReplaceForm.travelList(i).Key
                //            nearestID = i
                //        End If
                //    Next
                //    Editor.SetSelection(SearchReplaceForm.travelList(nearestID).Key, SearchReplaceForm.travelList(nearestID).Value)
                //    Editor.ScrollCaret()
                //End If
                Program.SearchReplaceForm.SearchAndMark(Program.SearchReplaceForm.searchFindText.Text, true);
                return true;

            }

            if (keyData == (Program.SettingsForm.BuildHotkey.Hotkey | Program.SettingsForm.BuildHotkey.HotkeyModifiers))
            {
                Program.MainForm.compileScriptBtn.PerformClick();
                return true;

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        //All modules are here.

        #region Styles Handlers

        private void SetBackColor(Color clr)
        {
            foreach (Style stle in Editor.Styles)
            {
                stle.BackColor = clr;
            }

            Editor.SetFoldMarginColor(true, clr);
            Editor.SetFoldMarginHighlightColor(true, clr);
        }

        private void DoStyle(int style, StyleItem clr)
        {
            if(clr.ForeColor != Color.Transparent)
                Editor.Styles[style].ForeColor = clr.ForeColor;
            if(clr.BackColor != Color.Transparent)
                Editor.Styles[style].BackColor = clr.BackColor;

            if (clr.Font != null)
            {
                Editor.Styles[style].Font = clr.Font.FontFamily.Name;
                Editor.Styles[style].Size = (int)clr.Font.Size;
                Editor.Styles[style].Bold = clr.Font.Bold;
                Editor.Styles[style].Underline = clr.Font.Underline;
                Editor.Styles[style].Italic = clr.Font.Italic;
                Editor.Styles[style].Underline = clr.Font.Underline;
            }
        }

        [Localizable(false)]
        public void OnSetsChange()
        {

            //Exit if the control is disposed
            if (Editor.IsDisposed)
            {
                return;
            }

            //Setup font.
            Editor.StyleResetDefault();
            DoStyle(Convert.ToInt32(Style.Default), Program.SettingsForm.ColorsInfo.SDefault);
            Editor.StyleClearAll();

            //Setup Default CPP similar Colors:
            DoStyle(Convert.ToInt32(Style.Cpp.Number), Program.SettingsForm.ColorsInfo.SInteger);
            DoStyle(Convert.ToInt32(Style.Cpp.String), Program.SettingsForm.ColorsInfo.SString);
            DoStyle(Convert.ToInt32(Style.Cpp.Character), Program.SettingsForm.ColorsInfo.SString);
            DoStyle(Convert.ToInt32(Style.Cpp.Operator), Program.SettingsForm.ColorsInfo.SSymbols);
            DoStyle(Convert.ToInt32(Style.Cpp.CommentLine), Program.SettingsForm.ColorsInfo.SSlComments);
            DoStyle(Convert.ToInt32(Style.Cpp.Comment), Program.SettingsForm.ColorsInfo.SMlComments);
            DoStyle(Convert.ToInt32(Style.Cpp.CommentDoc), Program.SettingsForm.ColorsInfo.SPawnDoc);
            DoStyle(Convert.ToInt32(Style.Cpp.Preprocessor), Program.SettingsForm.ColorsInfo.SPawnPre);
            DoStyle(Convert.ToInt32(Style.Cpp.Word), Program.SettingsForm.ColorsInfo.SPawnKeys);
            Editor.SetKeywords(0,
                "static break case enum continue do else false for goto public stock if is new null return sizeof switch true while forward native const default");

            DoStyle((Int32) Styles.Functions, Program.SettingsForm.ColorsInfo.SFunctions);
            DoStyle((Int32) Styles.Publics, Program.SettingsForm.ColorsInfo.SPublics);
            DoStyle((Int32) Styles.Stocks, Program.SettingsForm.ColorsInfo.SStocks);
            DoStyle((Int32) Styles.Natives, Program.SettingsForm.ColorsInfo.SNatives);
            DoStyle((Int32) Styles.Defines, Program.SettingsForm.ColorsInfo.SDefines);
            DoStyle((Int32) Styles.Macros, Program.SettingsForm.ColorsInfo.SMacros);
            DoStyle((Int32) Styles.Enums, Program.SettingsForm.ColorsInfo.SEnums);
            DoStyle((Int32) Styles.PublicVars, Program.SettingsForm.ColorsInfo.SGlobalVars);
            DoStyle((Int32) Styles.Tags, Program.SettingsForm.ColorsInfo.Tags);

            Editor.IndentationGuides = IndentView.LookBoth;

            //Setup Hotspot Stuff
            Editor.Styles[(int)Styles.Hotspot].Hotspot = true;
            Editor.Styles[(int)Styles.Hotspot].Underline = true;
            Editor.Styles[(int)Styles.Hotspot].ForeColor = Color.DarkBlue;

            // Configure a margin to display folding symbols.
            Editor.Margins[2].Type = MarginType.Symbol;
            Editor.Margins[2].Mask = Marker.MaskFolders;
            Editor.Margins[2].Sensitive = true;
            Editor.Margins[2].Width = 20;

            // Set colors for all folding markers.
            for (int i = 25; i <= 31; i++)
            {
                Editor.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                Editor.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            //Brace Styling
            Editor.Styles[Style.BraceBad].ForeColor = Color.Red;
            Editor.Styles[Style.BraceLight].BackColor = Color.Gray;

            // Instruct the lexer to calculate folding
            Editor.SetProperty("fold", "1");
            Editor.SetProperty("fold.compact", "1");

            // Configure folding markers with respective symbols.
            Editor.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            Editor.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            Editor.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            Editor.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            Editor.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            Editor.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            Editor.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding.
            Editor.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            //Set the CallTip color.
            Editor.CallTipSetForeHlt(Color.Black);

            //Setup the indicators
            Editor.Indicators[(int)IndicatorIDs.IndicatorParserError].Style = IndicatorStyle.Squiggle;
            Editor.Indicators[(int)IndicatorIDs.IndicatorParserError].ForeColor = Color.DarkGreen;
            Editor.Indicators[(int)IndicatorIDs.IndicatorParserError].Under = true;
            Editor.Indicators[(int)IndicatorIDs.IndicatorSearchItem].Style = IndicatorStyle.FullBox;
            Editor.Indicators[(int)IndicatorIDs.IndicatorSearchItem].ForeColor = Color.Green;

            //Set up auto-complete.
            AutoCompleteMenu.TargetControlWrapper = new ScintillaWrapper(Editor);
        }

        private void EditorDock_Load(object sender, EventArgs e)
        {
            //Add handler.
            Program.SettingsForm.OnColorsSettingsChange += OnSetsChange;

            //ReLoad data.
            Program.SettingsForm.IsGlobal = false;
            Program.SettingsForm.ReloadInfoAll();

            //Call the function.
            OnSetsChange();

            //Timers
            _idleTimer.Enabled = true;
            _idleTimer.Interval = 1000;
            _idleTimer.Tick += idleTimer_Tick;
        }

        #endregion

        #region TextChangedDelayed WITH VISIBLE Setup Code

        //Variables to save parsing offsets.
        //Will be -1 if done.
        private int _offsetStart = -1;
        private int _offsetLength = -1;

        private Timer _idleTimer = new Timer();
        private string _oldVisible = ""; //This is just a key that I am going to use as empty!..

        [Localizable(false)]
        private void CheckIfDefines(ref string code, int line)
        {
            //Get all the visible If's and ends.
            int allIfs = Convert.ToInt32(Regex.Matches(code, "#if\\s+defined").Cast<object>().Count());
            int allEnds = Convert.ToInt32(Regex.Matches(code, "#endif").Cast<object>().Count());

            //Check if the ifs are more then the ends.
            if (allIfs > allEnds)
            {
                //Aslong as they're not equal, Keep going!
                while (allIfs != allEnds && Editor.Lines.Count > line)
                {
                    line++;

                    string newLine = Convert.ToString(Editor.Lines[line].Text);
                    code += newLine;

                    if (Regex.IsMatch(newLine, "#endif"))
                    {
                        allEnds++;
                    }
                }
            }
            else if (allEnds > allIfs)
            {
                //Aslong as they're not equal, Keep going!
                while (allIfs != allEnds && Editor.Lines.Count > line)
                {
                    line++;

                    string newLine = Convert.ToString(Editor.Lines[line].Text);
                    code += newLine;

                    if (Regex.IsMatch(newLine, "#if\\s+defined"))
                    {
                        allIfs++;
                    }
                }
            }
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            _idleTimer.Stop();
            string newCode = Convert.ToString(Editor.GetTextRange(_offsetStart, _offsetLength));

            //Make sure the current code is valid from if defines.
            CheckIfDefines(ref newCode, Editor.LineFromPosition(_offsetStart + _offsetLength));

            //Get the new visible text and call the func.
            scintilla_TextChangedDelayed(_oldVisible, newCode);

            //Reset:
            _oldVisible = "";
            _offsetStart = -1;
            _offsetLength = -1;
        }

        //This for on first time.
        private void BeforeTextChangedDelayed_Timer(object sender, BeforeModificationEventArgs e)
        {
            if (e.Text != null)
            {
                if (_offsetStart == -1 & _offsetLength == -1)
                {
                    //Get positions of visible text and store them.
                    _offsetStart = Convert.ToInt32(Editor.Lines[Editor.FirstVisibleLine].Position);
                    _offsetLength = Convert.ToInt32(
                        (Editor.Lines[Editor.FirstVisibleLine + Editor.LinesOnScreen].EndPosition) - _offsetStart);

                    //Store the text.
                    _oldVisible = Convert.ToString(Editor.GetTextRange(_offsetStart, _offsetLength));

                    //Make sure its valid.
                    CheckIfDefines(ref _oldVisible, Editor.LineFromPosition(_offsetStart + _offsetLength));
                }
            }
        }

        //Adding and minusing to length.
        private void OnAdd(object sender, BeforeModificationEventArgs e)
        {
            if (e.Text != null)
            {
                if (_offsetLength != -1 & _offsetStart != -1)
                {
                    int len = Convert.ToInt32(e.Text.Length);
                    //Dim newEndPos As Integer = e.Position + len
                    //Dim OffsetEnd As Integer = OffsetStart + OffsetLength

                    //If e.Position < OffsetStart Then
                    //    OffsetStart += len : OffsetLength += len
                    //ElseIf e.Position > OffsetStart Then
                    _offsetLength += len;
                    //End If
                }
            }
        }

        private void OnRemove(object sender, BeforeModificationEventArgs e)
        {
            if (e.Text != null)
            {
                if (_offsetLength != -1 & _offsetStart != -1)
                {
                    int len = Convert.ToInt32(e.Text.Length);
                    //Dim newEndPos As Integer = e.Position + len
                    //Dim oldEndPos As Integer = OffsetStart + OffsetLength

                    //If e.Position < OffsetStart Then
                    //    OffsetStart -= len : OffsetLength -= len
                    //ElseIf e.Position > OffsetStart Then
                    _offsetLength -= len;
                    //End If

                    //TO MAKE SURE THIS IS GOING TO BE REMOVED:
                    _oldVisible += Convert.ToString("\r\n" + "\r\n" + e.Text + "\r\n" + "\r\n");
                }
            }
        }

        #endregion

        #region LineNumbers Calculation

        private int _maxLineNumberCharLength;

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            //DELAYED AC
            _idleTimer.Stop();
            _idleTimer.Start();

            var maxLineNumberCharLength = Editor.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == _maxLineNumberCharLength)
            {
                return;
            }

            const int padding = 2;
            Editor.Margins[0].Width = Editor.TextWidth(Style.LineNumber,
                                          new string('9', Convert.ToInt32(maxLineNumberCharLength + 1))) +
                                      padding;
            _maxLineNumberCharLength = Convert.ToInt32(maxLineNumberCharLength);
        }

        #endregion

        #region Refresh Worker Codes

        public void scintilla_TextChangedDelayed(string oldcode, string newcode)
        {
            if (RefreshWorker.IsBusy == false && Program.MainForm.CompilerWorker.IsBusy == false)
            {
                RefreshWorker.RunWorkerAsync(new[] {oldcode, newcode, Editor.Tag, Program.MainForm.CurrentProject.ProjectPath});
                Program.MainForm.statusLabel.Text = translations.EditorDock_scintilla_TextChangedDelayed_ParsingCode;
            }
        }

        private void RefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Editor.IsHandleCreated)
            {
                object[] arr = (object[]) e.Argument;
                //Parse old.
                var @null = new Parser(CodeParts, (string)arr[0], (string)arr[2], (string)arr[3], false);

                //Save the new to the result.
                e.Result = new Parser(CodeParts, (string)arr[1], (string)arr[2], (string)arr[3], true);
            }
        }

        [Localizable(false)]
        private void ParseCodeParts(List<AutoCompleteItemEx> autoList)
        {
            foreach (var part in CodeParts.FlattenIncludes())
            {
                foreach (var stock in part.Stocks)
                {
                    AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock);
                    autoList.Add(newitm);
                }

                foreach (var publicFunc in part.Publics)
                {
                    AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc);
                    autoList.Add(newitm);
                }

                foreach (var func in part.Functions)
                {
                    AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, func);
                    autoList.Add(newitm);
                }

                foreach (var native in part.Natives)
                {
                    AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native);
                    autoList.Add(newitm);
                }

                foreach (var def in part.Defines)
                {
                    AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeDefine, def.DefineName,
                        def.DefineValue);
                    autoList.Add(newitm);
                }

                foreach (var parentEnm in part.Enums)
                {
                    foreach (var enm in parentEnm.EnumContents)
                    {
                        string type = "";

                        if (enm.Type == FunctionParameters.VarTypes.TypeArray)
                        {
                            type = "array/string";
                        }
                        else if (enm.Type == FunctionParameters.VarTypes.TypeFloat)
                        {
                            type = "float";
                        }
                        else if (enm.Type == FunctionParameters.VarTypes.TypeInteger)
                        {
                            type = "integer";
                        }
                        else if (enm.Type == FunctionParameters.VarTypes.TypeTagged)
                        {
                            type = "tagged";
                        }

                        AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeDefine, enm.Content,
                            "This is an enum item with the type: `" + type + "` that is in the enum: `" +
                            parentEnm.EnumName + "`");
                        autoList.Add(newitm);
                    }
                }

                foreach (var var in part.PublicVariables)
                {
                    AutoCompleteItemEx newitm = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeDefine, var.VarName,
                        "This is a global variable declared in one of the includes.");
                    autoList.Add(newitm);
                }
            }
        }

        private void RefreshWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            Program.MainForm.statusLabel.Text = translations.EditorDock_RefreshWorker_RunWorkerCompleted_Idle;
            Program.ErrorsDock.parserErrors.Rows.Clear();

            #region Error Showing

            ExceptionsList errors = ((Parser) e.Result).Errors;
            foreach (var obj in errors.ExceptionsList_Renamed)
            {
                if ((obj) is IncludeNotFoundException)
                {
                    var tmpObj = (IncludeNotFoundException) obj;
                    string msg =
                        string.Format(
                            Convert.ToString(translations
                                .EditorDock_RefreshWorker_RunWorkerCompleted_IncludeNotFoundError), tmpObj.IncludeName);
                    Program.ErrorsDock.parserErrors.Rows.Add(msg, tmpObj.IncludeName);
                }
                else if ((obj) is ParserException tmpObj)
                {
                    Program.ErrorsDock.parserErrors.Rows.Add(tmpObj.Message, tmpObj.Iden);
                }
            }

            #endregion

            #region AutoComplete Refresh.

            _autoCompleteList.Clear();

            ParseCodeParts(_autoCompleteList);

            AutoCompleteMenu.SetAutocompleteItems(_autoCompleteList);

            #endregion

            //Update Visible Style:
            Editor_UpdateStyle(this, new UpdateUIEventArgs(new UpdateChange()));

            if (Program.ObjectExplorerDock.Visible)
            {
                Program.ObjectExplorerDock.RefreshTreeView(CodeParts);
            }
        }

        #endregion

        #region Brace Highlighting

        private static bool IsBrace(int c)
        {
            return c == '[' || c == ']' || c == '{' || c == '}' || c == '(' || c == ')';
        }

        private int _lastCaretPos;

        private void Editor_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            // Has the caret changed position
            var caretPos = Editor.CurrentPosition;
            if (_lastCaretPos != caretPos)
            {
                _lastCaretPos = Convert.ToInt32(caretPos);
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right
                if (caretPos > 0 && IsBrace(Convert.ToInt32(Editor.GetCharAt(caretPos - 1))))
                {
                    bracePos1 = Convert.ToInt32(caretPos - 1);
                }
                else if (IsBrace(Convert.ToInt32(Editor.GetCharAt(caretPos))))
                {
                    bracePos1 = Convert.ToInt32(caretPos);
                }

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = Convert.ToInt32(Editor.BraceMatch(bracePos1));
                    if (bracePos2 == Scintilla.InvalidPosition)
                    {
                        Editor.BraceBadLight(bracePos1);
                        Editor.HighlightGuide = 0;
                    }
                    else
                    {
                        Editor.BraceHighlight(bracePos1, bracePos2);
                        Editor.HighlightGuide = Editor.GetColumn(bracePos1);
                    }
                }
                else
                {
                    // Turn off brace matching
                    Editor.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                    Editor.HighlightGuide = 0;
                }
            }
        }

        #endregion

        #region AutoIndent of new lines

        [Localizable(false)]
        private void Editor_InsertCheck(object sender, InsertCheckEventArgs e)
        {
            if (e.Text.EndsWith("" + '\r') || e.Text.EndsWith("" + '\n'))
            {
                int startPos =
                    Convert.ToInt32(Editor.Lines[Editor.LineFromPosition(Editor.CurrentPosition)].Position);
                int endPos = Convert.ToInt32(e.Position);
                string curLineText =
                    Convert.ToString(Editor.GetTextRange(startPos, endPos - startPos)); //Text until the caret.
                Match indent = Regex.Match(curLineText, "^[ \\t]*");
                e.Text = e.Text + indent.Value;
                if (Regex.IsMatch(curLineText, "{\\s*$"))
                {
                    e.Text = e.Text + "    ";
                }
            }
        }

        [Localizable(false)]
        private void Editor_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (e.Char == 125) //The '}' char.
            {
                int curLine = Convert.ToInt32(Editor.LineFromPosition(Editor.CurrentPosition));
                if (Editor.Lines[curLine].Text.Trim() == "}"
                ) //Check whether the bracket is the only thing on the line.. For cases like "if() { }".
                {
                    Editor.Lines[curLine].Indentation -= Editor.TabWidth;
                }
            }
        }

        #endregion

        #region SavePoints

        private void Editor_SavePointReached(object sender, EventArgs e)
        {
            TabText = Text;
        }

        [Localizable(false)]
        private void Editor_SavePointLeft(object sender, EventArgs e)
        {
            if (Text == "")
            {
                return;
            }

            TabText = "* " + Text;
        }

        #endregion

        #region CallTip Codes

        bool _isCallTipShown;
        AutoCompleteItemEx _currentCallTipItm;

        [Localizable(false)]
        private void CallTipMarkCurrentPar(AutoCompleteItemEx itm)
        {
            string currentLineText = Convert.ToString(Editor.Lines[Editor.CurrentLine].Text);
            Match funcOnly = Regex.Match(currentLineText, itm.Text + "\\(([^\\n\\r\\);]*)");
            string currentWrite = "";
            if (funcOnly.Success)
            {
                currentWrite = Convert.ToString(funcOnly.Captures[0].Value);
            }
            else
            {
                currentWrite = currentLineText;
            }

            int extraCount = Convert.ToInt32(itm.Text.Length + 1); //1 for the ( and )
            string wholeFunc = Convert.ToString(itm.Parameters.ParamsText);

            int currentCommas = Convert.ToInt32(GeneralFunctions.CountChar(currentWrite, ','));
            int allCommads = Convert.ToInt32(GeneralFunctions.CountChar(wholeFunc, ','));

            if (currentCommas > allCommads)
            {
                return;
            }

            string[] allPars = wholeFunc.Split(",".ToCharArray());

            int startPos = extraCount;
            for (int i = 0; i <= allPars.Count() - 1; i++)
            {
                if (i == currentCommas)
                {
                    break;
                }

                startPos += Convert.ToInt32(allPars[i].Length + 1); //1 for the comma.
            }

            int endPos = startPos + allPars[currentCommas].Length;

            Editor.CallTipSetHlt(startPos, endPos);
        }

        [Localizable(false)]
        private void AutoCompleteMenu_Selected(object sender, SelectedEventArgs e)
        {
            AutoCompleteItemEx itm = (AutoCompleteItemEx) e.Item;

            if (itm.Type == AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction)
            {
                Editor.CallTipShow(Editor.CurrentPosition, itm.Text + "(" + itm.Parameters.ParamsText + ")");
                _isCallTipShown = true;
                _currentCallTipItm = itm;

                CallTipMarkCurrentPar(_currentCallTipItm);
            }
        }

        private void CallTip_Editor_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (e.Char == 44) //The ',' char.
            {
                if (_isCallTipShown && (_currentCallTipItm) is AutoCompleteItemEx)
                {
                    CallTipMarkCurrentPar(_currentCallTipItm);
                }
            }
            else if (e.Char == 13) //If he presses enter, Hide the calltip.
            {
                if (_isCallTipShown)
                {
                    _isCallTipShown = false;
                    _currentCallTipItm = null;
                }
            }
        }

        [Localizable(false)]
        private void CallTip_Editor_BeforeDelete(object sender, ModificationEventArgs e)
        {
            if (_isCallTipShown && (_currentCallTipItm) is AutoCompleteItemEx)
            {
                if (e.Text.Contains(","))
                {
                    CallTipMarkCurrentPar(_currentCallTipItm);
                }
            }
        }

        [Localizable(false)]
        private void CallTip_Editor_Insert(object sender, ModificationEventArgs e)
        {
            if (e.Text == "(") //Which will be used to show the calltip.
            {
                //First of all get the funcName.
                string funcText = "";
                int pos = Convert.ToInt32(e.Position);

                while (pos > 0)
                {
                    pos--;

                    string txt = Convert.ToString(Editor.GetTextRange(pos, 1));
                    if (txt == " " || txt == "\n" || txt == "(" || txt == ")" || txt == "{" || txt == "}" ||
                        txt == ";")
                    {
                        break;
                    }

                    funcText = funcText.Insert(0, txt);
                }

                //Now check if there is an AutoCompleteItem matching that.
                foreach (AutoCompleteItemEx itm in _autoCompleteList)
                {
                    if (itm.Text == funcText)
                    {
                        //Found one.. Now if its a function.. Show it. :)
                        if (itm.Type == AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction)
                        {
                            Editor.CallTipShow(Editor.CurrentPosition,
                                itm.Text + "(" + itm.Parameters.ParamsText + ")");
                            _isCallTipShown = true;
                            _currentCallTipItm = itm;

                            CallTipMarkCurrentPar(_currentCallTipItm);
                        }
                    }
                }
            }
        }

        #endregion

        #region WordSet Colorizer

        private enum Styles
        {
            Hotspot = 100,
            Functions,
            Publics,
            Stocks,
            Natives,
            Defines,
            Macros,
            Enums,
            PublicVars,
            Tags
        }

        private void DoColor(int startPos, string code, string rgx, Styles reqstyle, bool isMultiLine = false)
        {
            foreach (Match mtch in Regex.Matches(code, rgx, isMultiLine ? RegexOptions.Multiline : RegexOptions.None))
            {

                //Make sure target isn't comment or anything...
                var targetStartStyle = Editor.GetStyleAt(mtch.Index + startPos);
                var targetEndStyle = Editor.GetStyleAt(mtch.Index + startPos + mtch.Length - 1);

                if (targetStartStyle == Style.Cpp.Identifier && targetEndStyle == Style.Cpp.Identifier)
                {
                    Editor.StartStyling(mtch.Index + startPos);
                    Editor.SetStyling(mtch.Length, (int)reqstyle);
                }
            }
        }

        [Localizable(false)]
        private void ReColorize(CodeParts parts, int startPos, int endPos)
        {
            //Setup vars:
            string code = Convert.ToString(Editor.GetTextRange(startPos, endPos - startPos));

            //Tags.
            List<string> tags = new List<string>();

            StringBuilder rgx = new StringBuilder();
            //Functions:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Functions.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.Functions[i].FuncName));
                if (i < parts.Functions.Count - 1)
                {
                    rgx.Append("|");
                }

                if(!tags.Contains(parts.Functions[i].ReturnTag))
                    tags.Add(parts.Functions[i].ReturnTag);
            }

            if (parts.Functions.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Functions);
            }

            //Publics:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Publics.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.Publics[i].FuncName));
                if (i < parts.Publics.Count - 1)
                {
                    rgx.Append("|");
                }

                if(!tags.Contains(parts.Publics[i].ReturnTag))
                    tags.Add(parts.Publics[i].ReturnTag);
            }
            
            if (parts.Publics.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Publics);
            }

            //Stocks:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Stocks.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.Stocks[i].FuncName));
                if (i < parts.Stocks.Count - 1)
                {
                    rgx.Append("|");
                }

                if(!tags.Contains(parts.Stocks[i].ReturnTag))
                    tags.Add(parts.Stocks[i].ReturnTag);
            }

            if (parts.Stocks.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Stocks);
            }

            //Natives:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Natives.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.Natives[i].FuncName));
                if (i < parts.Natives.Count - 1)
                {
                    rgx.Append("|");
                }

                if(!tags.Contains(parts.Natives[i].ReturnTag))
                    tags.Add(parts.Natives[i].ReturnTag);
            }

            if (parts.Natives.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Natives);
            }

            //Defines:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Defines.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.Defines[i].DefineName));
                if (i < parts.Defines.Count - 1)
                {
                    rgx.Append("|");
                }
            }

            if (parts.Defines.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Defines);
            }

            //Macros:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Macros.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.Macros[i].DefineName));
                if (i < parts.Macros.Count - 1)
                {
                    rgx.Append("|");
                }
            }

            if (parts.Macros.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Macros);
            }

            //Enums:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.Enums.Count - 1; i++)
            {
                foreach (var cntn in parts.Enums[i].EnumContents)
                {
                    rgx.Append(Regex.Escape(cntn.Content));
                    if (i < parts.Enums.Count - 1)
                    {
                        rgx.Append("|");
                    }
                }
            }

            if (parts.Enums.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Enums);
            }

            //Public Variables:
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= parts.PublicVariables.Count - 1; i++)
            {
                rgx.Append(Regex.Escape(parts.PublicVariables[i].VarName));
                if (i < parts.PublicVariables.Count - 1)
                {
                    rgx.Append("|");
                }

                if(!tags.Contains(parts.PublicVariables[i].VarTag))
                    tags.Add(parts.PublicVariables[i].VarTag);
            }

            if (parts.PublicVariables.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.PublicVars);
            }

            //tags colorize
            rgx.Clear();
            rgx.Append("\\b(?:");
            for (int i = 0; i <= tags.Count - 1; i++)
            {
                if(tags[i] == "")
                    continue;
                rgx.Append(Regex.Escape(tags[i].Remove(tags[i].Length-1, 1)));
                if (i < tags.Count - 1)
                {
                    rgx.Append("|");
                }
            }
            if (tags.Any())
            {
                rgx.Append(")\\b");
                DoColor(startPos, code, rgx.ToString(), Styles.Tags);
            }
        }

        private void Editor_UpdateStyle(object sender, UpdateUIEventArgs e)
        {
            var startPos = Editor.Lines[Editor.FirstVisibleLine].Position;
            var endPos = Editor.Lines[Editor.FirstVisibleLine + Editor.LinesOnScreen].EndPosition;
            foreach (var inc in CodeParts.FlattenIncludes().ToList())
            {
                ReColorize(inc, Convert.ToInt32(startPos), Convert.ToInt32(endPos));
            }
        }

        #endregion

        #region DragDrop

        [Localizable(false)]
        private void MainDock_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                if (Path.GetExtension(file) != ".pwn" || Path.GetExtension(file) != ".inc")
                {
                    e.Effect = DragDropEffects.None;
                }
            }

            e.Effect = DragDropEffects.Copy;
        }

        [Localizable(false)]
        private void MainDock_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var file in files)
            {
                if (Path.GetExtension(file) == ".pwn" || Path.GetExtension(file) == ".inc")
                {
                    Program.MainForm.OpenFile(file, true);
                }
            }
        }

        #endregion

        #region CTRL+CLICK

        KeyValuePair<int, int> _foundItem;
        string _foundItemFile = "";

        [Localizable(false)]
        private void LoadPart(CodeParts part, string fileContent, string item, bool current = false)
        {
            _foundItemFile = Convert.ToString(current ? "current" : part.FilePath);

            //Do enums first.
            foreach (var Enm in part.Enums)
            {
                foreach (var cntn in Enm.EnumContents)
                {
                    if (cntn.Content == item)
                    {
                        string allText = fileContent;
                        var mtch = Regex.Match(allText,
                            "enum\\s+" + Regex.Escape(Enm.EnumName) + "\\s+(?:(?:[{])([^}]+)(?:[}]))",
                            RegexOptions.Multiline);
                        if (mtch.Length != 0)
                        {
                            _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                        }

                        return;
                    }
                }
            }

            if (part.Defines.FindAll(x => x.DefineName == item).Any())
            {
                string allText = fileContent;
                var mtch = Regex.Match(allText,
                    "^[ \\t]*[#]define[ \\t]+" + Regex.Escape(item) +
                    "[ \\t]*(?:\\\\\\s+)?(?>(?<value>[^\\\\\\n\\r]+)[ \\t]*(?:\\\\\\s+)?)*", RegexOptions.Multiline);
                if (mtch.Length != 0)
                {
                    _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                }

            }
            else if (part.Functions.FindAll(x => x.FuncName == item).Any())
            {
                string allText = fileContent;
                var mtch = Regex.Match(allText,
                    "^[ \\t]*(?:\\sstatic\\s+stock\\s+|\\sstock\\s+static\\s+|\\sstatic\\s+)?" + Regex.Escape(item) +
                    "\\((.*)\\)(?!;)\\s*{", RegexOptions.Multiline);
                if (mtch.Length != 0)
                {
                    _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                }

            }
            else if (part.Natives.FindAll(x => x.FuncName == item).Any())
            {
                string allText = fileContent;
                var mtch = Regex.Match(allText, "native.+" + Regex.Escape(item) + "[ \\t]*?\\((.*)\\);",
                    RegexOptions.Multiline);
                if (mtch.Length != 0)
                {
                    _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                }

            }
            else if (part.PublicVariables.FindAll(x => x.VarName == item).Any())
            {
                string allText = fileContent;
                var mtch = Regex.Match(allText,
                    "(?:\\s?stock\\s+static|\\s?static\\s+stock|\\s?new\\s+stock|\\s?new|\\s?static|\\s?stock)\\s*" +
                    Regex.Escape(item) + ";", RegexOptions.Multiline);
                if (mtch.Length != 0)
                {
                    _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                }

            }
            else if (part.Publics.FindAll(x => x.FuncName == item).Any())
            {
                string allText = fileContent;
                var mtch = Regex.Match(allText, "public[ \\t]+" + Regex.Escape(item) + "[ \\t]*\\((.*)\\)\\s*{",
                    RegexOptions.Multiline);
                if (mtch.Length != 0)
                {
                    _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                }

            }
            else if (part.Stocks.FindAll(x => x.FuncName == item).Any())
            {
                string allText = fileContent;
                var mtch = Regex.Match(allText, "stock[ \\t]+" + Regex.Escape(item) + "[ \\t]*\\((.*)\\)\\s*{",
                    RegexOptions.Multiline);
                if (mtch.Length != 0)
                {
                    _foundItem = new KeyValuePair<int, int>(mtch.Index, mtch.Index + mtch.Length);
                }

            }
            else
            {
                _foundItem = new KeyValuePair<int, int>(0, 0);
                _foundItemFile = "";
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Program.SettingsForm.GotoDefHotkey.Hotkey && e.Modifiers == Program.SettingsForm.GotoDefHotkey.HotkeyModifiers)
            {
                //The pos.
                var pos = Editor.CurrentPosition;

                //Get what is there.
                string item = Convert.ToString(Editor.GetWordFromPosition(pos));

                //Loop in all for it.
                LoadPart(CodeParts, Convert.ToString(Editor.GetTextRange(0, Editor.TextLength)), item, true);
                if (_foundItem.Key == _foundItem.Value)
                {
                    var allIncs = CodeParts.FlattenIncludes();
                    var codePartses = allIncs as CodeParts[] ?? allIncs.ToArray();
                    for (var i = 1; i < codePartses.Count(); i++)
                    {
                        if (_foundItem.Key == _foundItem.Value)
                        {
                            LoadPart(codePartses.ElementAt(i), File.ReadAllText(Convert.ToString(codePartses[i].FilePath)), item);
                        }
                    }
                }

                //Now if found, Make the mouse cursor a click.
                if (_foundItem.Key != _foundItem.Value)
                {
                    //Make sure that certain file is opened.
                    if (_foundItemFile != "current")
                    {
                        Program.MainForm.OpenFile(_foundItemFile);
                    }

                    //Goto
                    Program.MainForm.CurrentScintilla.SetSelection(_foundItem.Key, _foundItem.Value);
                    Program.MainForm.CurrentScintilla.ScrollCaret();
                    //Clear
                    _foundItemFile = "";
                    _foundItem = new KeyValuePair<int, int>(0, 0);
                }
                else
                {
                    Program.MainForm.ShowStatus(translations.EditorDock_Editor_KeyDown_DefNotFound, 2000, true);
                }
            }
        }

        #endregion

        #region ColorPicker

        ThemeColorPickerWindow _clrPicker;

        [Localizable(false)]
        private void ColorPicker_CharAdded(object sender, CharAddedEventArgs e)
        {
            string line = Convert.ToString(Editor.Lines[Editor.CurrentLine].Text.Replace("\r\n", ""));
            if (Regex.IsMatch(line, "#define\\s+(?:COLOR|COLOUR)_(?:[^\\s]+)\\s+$"))
            {
                Point loc = Editor.PointToScreen(new Point(Editor.PointXFromPosition(Editor.CurrentPosition),
                    Editor.PointYFromPosition(Editor.CurrentPosition) + Editor.Font.Height));
                _clrPicker = new ThemeColorPickerWindow(loc, FormBorderStyle.None,
                    ThemeColorPickerWindow.Action.CloseWindow, ThemeColorPickerWindow.Action.CloseWindow);
                _clrPicker.ColorSelected += _clrPickerChosen;
                _clrPicker.Show();
            }
        }

        [Localizable(false)]
        private void _clrPickerChosen(object sender, ColorSelectedArg e)
        {
            Editor.InsertText(Editor.CurrentPosition, GeneralFunctions.ColorToHex(e.Color));
            Editor.CurrentPosition += GeneralFunctions.ColorToHex(e.Color).Length;
            Editor.AnchorPosition += GeneralFunctions.ColorToHex(e.Color).Length;
        }

        #endregion
    }
}