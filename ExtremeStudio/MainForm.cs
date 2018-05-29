using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExtremeCore.Classes;
using ExtremeStudio.Classes;
using ExtremeStudio.DockPanelForms.MainFormDocks;
using ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock;
using ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock;
using ExtremeStudio.FunctionsForms;
using Resources;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace ExtremeStudio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;
            Load += DockSavingLoading_Mainform_Load;
            Load += OnFormLoadPlugin;
        }

        //This is set in LanguageForm by users needing.
        public string ApplicationFiles;

        #region Properties

        public Scintilla CurrentScintilla
        {
            get
            {
                if (ReferenceEquals(MainDock.ActiveDocument, null))
                {
                    return null;
                }

                return ((Scintilla) (MainDock.ActiveDocument.DockHandler.Form.Controls["Editor"]));
            }
        }

        public EditorDock CurrentEditor => (EditorDock) CurrentScintilla?.Parent;

        #endregion

        #region Functions

        [Localizable(false)]
        public void OpenFile(string targetPath, bool isExternal = false)
        {
            //We gotta make sure there is no file opened with that path first.
            foreach (var doc in MainDock.Documents)
            {
                if ((string) doc.DockHandler.Form.Controls["Editor"].Tag == targetPath)
                {
                    doc.DockHandler.Activate();
                    return;
                }
            }

            EditorDock newEditor = new EditorDock
            {
                Text = Path.GetFileName(targetPath) + (isExternal ? " [EXTERNAL]" : "")
            };
            newEditor.Editor.Tag = targetPath;
            newEditor.Editor.Text = File.ReadAllText(targetPath, Encoding.Default);
            newEditor.Show(MainDock);
            newEditor.Editor.SetSavePoint(); //Set that all data has been saved.
        }

        public void SaveFile(Scintilla editor)
        {
            File.WriteAllText(Convert.ToString(editor.Tag), Convert.ToString(editor.Text),
                Encoding.Default);
            editor.SetSavePoint(); //Set as un-modified.
        }

        #endregion

        #region DocksSavingLoading

        DeserializeDockContent _mDeserlise;

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(ProjExplorerDock).ToString())
            {
                return Program.ProjExplorerDock;
            }
            if (persistString == typeof(ObjectExplorerDock).ToString())
            {
                return Program.ObjectExplorerDock;
            }
            if (persistString == typeof(ErrorsDock).ToString())
            {
                return Program.ErrorsDock;
            }

            return null;
        }

        private void DockSavingLoading_Mainform_Load(object sendr, EventArgs e)
        {
            //Setup DockPanelSuite theme.
            //Has to be here so its applied before anything.
            VS2015LightTheme theme = new VS2015LightTheme();
            MainDock.Theme = theme;

            try
            {
                _mDeserlise = GetContentFromPersistString;
                try
                {
                    if (File.Exists(ApplicationFiles + "/configs/docksInfo.xml") == false)
                    {
                        File.WriteAllText(ApplicationFiles + "/configs/docksInfo.xml",
                            Convert.ToString(Properties.Resources.docksInfo), Encoding.Unicode);
                    }

                    MainDock.LoadFromXml(ApplicationFiles + "/configs/docksInfo.xml", _mDeserlise);
                }
                catch (Exception)
                {
                    //None.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString("Error Loading Docks: " + "\r\n" + ex.Message));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainDock.SaveAsXml(ApplicationFiles + "/configs/docksInfo.xml");
        }

        #endregion

        #region StatusStripStuff

        public void ShowStatus(string textToShow, int msInterval, bool isBeep)
        {
            statusLabel.Text = textToShow;
            if (isBeep)
            {
                //BUG: no beep
            }

            if (msInterval == -1) return;
            statusStripTimer.Interval = msInterval;
            statusStripTimer.Stop();
            statusStripTimer.Start();
        }

        private void statusStripTimer_Tick(object sender, EventArgs e)
        {
            statusStripTimer.Stop();
            statusLabel.Text = "Idle";
        }

        #endregion

        //Global variables that are used through the whole program:
        public CurrentProjectClass CurrentProject = new CurrentProjectClass();

        [Localizable(false)]
        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "ExtremeStudio - " + CurrentProject.ProjectName;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Save all info.
            CurrentProject.SaveInfo();

            if (_isClosedProgrammitcly == false)
            {
                Application.Exit();
            }
        }

        #region View Codes

        private void ProjectExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.ProjExplorerDock.Visible == false)
            {
                if(Program.ProjExplorerDock.IsDisposed)
                    Program.ProjExplorerDock = new ProjExplorerDock();
                Program.ProjExplorerDock.Visible = true;
                Program.ProjExplorerDock.Show(MainDock);
            }
            else
            {
                Program.ProjExplorerDock.Close();
                Program.ProjExplorerDock.Visible = false;
            }
        }

        private void ObjectExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.ObjectExplorerDock.Visible == false)
            {
                if(Program.ObjectExplorerDock.IsDisposed)
                    Program.ObjectExplorerDock = new ObjectExplorerDock();
                Program.ObjectExplorerDock.Visible = true;
                Program.ObjectExplorerDock.Show(MainDock);
            }
            else
            {
                Program.ObjectExplorerDock.Close();
                Program.ObjectExplorerDock.Visible = false;
            }
        }

        private void ErrorsAndWarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.ErrorsDock.Visible == false)
            {
                if(Program.ErrorsDock.IsDisposed)
                    Program.ErrorsDock = new ErrorsDock();
                Program.ErrorsDock.Visible = true;
                Program.ErrorsDock.Show(MainDock);
            }
            else
            {
                Program.ErrorsDock.Close();
                Program.ErrorsDock.Visible = false;
            }
        }

        #endregion

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(CurrentScintilla, null))
            {
                return;
            }

            SaveFile(CurrentScintilla);
        }

        [Localizable(false)]
        public void SaveAllFiles(object sender, EventArgs e)
        {
            foreach (DockContent Dock in MainDock.Documents)
            {
                SaveFile((Scintilla)Dock.Controls["Editor"]);
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            /*IncludesForm frm = new IncludesForm();
            frm.Show();*/
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            /*PluginsForm frm = new PluginsForm();
            frm.Show();*/
        }

        private void MainDock_ActiveDocumentChanged(object sender, EventArgs e)
        {
            //Update.
            if (Program.ObjectExplorerDock.Visible && CurrentEditor != null)
            {
                Program.ObjectExplorerDock.RefreshTreeView(CurrentEditor.CodeParts);
            }
        }

        private bool _isClosedProgrammitcly;

        private void closeProjectButton_Click(object sender, EventArgs e)
        {
            //Save
            CurrentProject.SaveInfo();

            //Then close ourself.
            _isClosedProgrammitcly = true;
            Close();

            //Open the form
            StartupForm str = new StartupForm
            {
                IsFirst = false
            };
            str.Show();
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            CurrentScintilla.Cut();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            CurrentScintilla.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            CurrentScintilla.Paste();
        }

        private void gotoButton_Click(object sender, EventArgs e)
        {
            Program.GotoForm.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Program.SearchReplaceForm.Show();
            Program.SearchReplaceForm.TabControl1.SelectTab(0); //Search Tab.
            Program.SearchReplaceForm.searchFindText.Select();
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            Program.SearchReplaceForm.Show();
            Program.SearchReplaceForm.TabControl1.SelectTab(1); //Replace Tab.
        }

        private void RibbonButton1_Click(object sender, EventArgs e)
        {
            Program.SettingsForm.IsGlobal = false;
            Program.SettingsForm.ShowDialog();
        }

        private void compileScriptBtn_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(CurrentEditor, null))
            {
                return;
            }

            if (CompilerWorker.IsBusy || CurrentEditor.RefreshWorker.IsBusy)
            {
                MessageBox.Show(Convert.ToString(translations.MainForm_compileScriptBtn_Click_WaitForCompile));
            }
            else
            {
                CompilerWorker.RunWorkerAsync(new[]
                    {CurrentScintilla.Tag, Program.SettingsForm.GetCompilerArgs()}); //The file path is the parameter.
            }
        }

        #region Compiler Stuff

        private void CompilerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //First of all, Try and save all docs.
            if (CurrentScintilla.Modified)
            {
                var msgRslt = MessageBox.Show(translations.MainForm_CompilerWorker_DoWork_WouldYouLikeToSaveFiles, "", MessageBoxButtons.YesNoCancel);
                if (msgRslt == DialogResult.Cancel)
                {
                    return;
                }

                if (msgRslt == DialogResult.Yes)
                {
                    CompilerWorker.ReportProgress(1); //Save all files.
                }
            }
            else
            {
                CompilerWorker.ReportProgress(1); //Save all files.
            }

            //Next, Create the compiler process.
            if (File.Exists(CurrentProject.ProjectPath + "/pawno/pawncc.exe"))
            {
                //Start compilation process and wait till exit.
                Process compiler = new Process
                {
                    StartInfo =
                    {
                        FileName = CurrentProject.ProjectPath + "/pawno/pawncc.exe",
                        WorkingDirectory = Path.GetDirectoryName(((object[]) e.Argument)[0].ToString().Replace("/", "\\")),
                        Arguments = "\"" + ((object[]) e.Argument)[0].ToString().Replace("/", "\\") + "\"" +
                                    " " + ((object[]) e.Argument)[1],
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        UseShellExecute = false
                    }
                };
                CompilerWorker.ReportProgress(2); //Compiling
                compiler.Start();
                compiler.WaitForExit();

                //Now, Get the errors/warning then parse them and return.
                string errs = Convert.ToString(compiler.StandardError.ReadToEnd());
                if (string.IsNullOrEmpty(errs))
                {
                    CompilerWorker.ReportProgress(5); //Done sucessfully.
                    e.Result = new List<ErrorsDock.ScriptErrorInfo>();
                }
                else
                {
                    //Parse the list for the errors and warnings first.
                    var errorLevel = 0;
                    List<ErrorsDock.ScriptErrorInfo> errorList = new List<ErrorsDock.ScriptErrorInfo>();
                    foreach (Match match in Regex.Matches(errs,
                        "(.*)\\(([0-9]+)\\)\\s:\\s(error|warning)\\s([0-9]+):\\s(.*)"))
                    {
                        ErrorsDock.ScriptErrorInfo err = new ErrorsDock.ScriptErrorInfo
                        {
                            FileName = Path.GetFileName(Convert.ToString(match.Groups[1].Value)),
                            LineNumber = match.Groups[2].Value
                        };
                        if (match.Groups[3].Value == "error")
                        {
                            err.ErrorType = ErrorsDock.ScriptErrorInfo.ErrorTypes.Error;
                            errorLevel = 2;
                        }
                        else
                        {
                            err.ErrorType = ErrorsDock.ScriptErrorInfo.ErrorTypes.Warning;
                            if (errorLevel < 2)
                            {
                                errorLevel = 1;
                            }
                        }

                        err.ErrorNumber = match.Groups[4].Value;
                        err.ErrorMessage = match.Groups[5].Value;

                        errorList.Add(err);
                    }

                    //Set result as the list.
                    e.Result = errorList;

                    //Report status.
                    if (errorLevel == 2)
                    {
                        CompilerWorker.ReportProgress(3); //Failed with errors and possible warnings.
                    }
                    else if (errorLevel == 1)
                    {
                        CompilerWorker.ReportProgress(4); //Sucess but warnings..
                    }
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(translations.MainForm_CompilerWorker_DoWork_PawnccNotFound +
                                                        " \"" + CurrentProject.ProjectPath + "/pawno/pawncc.exe" +
                                                        "\"" + "\r\n" +
                                                        translations
                                                            .MainForm_CompilerWorker_DoWork_VerifyPawnccIsThere));
            }
        }

        private void CompilerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //We will use the progress event to do stuff in the UI.

            //1 = Save
            if (e.ProgressPercentage == 1)
            {
                SaveAllFiles(this, null);
            }

            //2 = Started Compiling
            if (e.ProgressPercentage == 2)
            {
                ShowStatus(Convert.ToString(translations.MainForm_CompilerWorker_ProgressChanged_Compiling), -1,
                    false);

                //3 = Failed Compiling With Errors/Warnings.
            }
            else if (e.ProgressPercentage == 3)
            {
                ShowStatus(
                    Convert.ToString(translations
                        .MainForm_CompilerWorker_ProgressChanged_CompilingFailedWithErrors), 5000, true);

                //4 = Finished Compiling With Warnings.
            }
            else if (e.ProgressPercentage == 4)
            {
                ShowStatus(
                    Convert.ToString(translations
                        .MainForm_CompilerWorker_ProgressChanged_CompilingDoneWithWarnings), 5000, true);

                Program.ProjExplorerDock.RefreshList();
                //5 = Finished Compiling.
            }
            else if (e.ProgressPercentage == 5)
            {
                ShowStatus(
                    Convert.ToString(translations
                        .MainForm_CompilerWorker_ProgressChanged_CompilingDoneWithNoErrorsWarnings), 5000, true);

                Program.ProjExplorerDock.RefreshList();
            }
        }

        private void CompilerWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            //Once done, Report result to ErrorsDock.
            Program.ErrorsDock.ErrorWarningList = (List<ErrorsDock.ScriptErrorInfo>)e.Result;
            Program.ErrorsDock.RefreshErrorWarnings();
        }

        #endregion

        #region Plugin System

        PluginBootstrapper _allPlugins = new PluginBootstrapper();

        [Localizable(false)]
        private void OnFormLoadPlugin(object sender, EventArgs e)
        {
            //I've made a thing of my own that is just like shadow copying to make sure the DLL's are accessed easily while app is running.
            var tempPlugPath = Path.GetTempPath() + "esplugins";
            if (Directory.Exists(tempPlugPath))
            {
                Directory.Delete(tempPlugPath, true);
            }

            if (Directory.Exists(ApplicationFiles + "/plugins") == false)
            {
                    Directory.CreateDirectory(ApplicationFiles + "/plugins");
            }

            GeneralFunctions.DirectoryCopy(ApplicationFiles + "/plugins",
                tempPlugPath, true);

            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(tempPlugPath));

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(_allPlugins);
            }
            catch (CompositionException CompositionException)
            {
                Debug.WriteLine(CompositionException.ToString());
            }

            //Intialize plugins.
            foreach (var plugin in _allPlugins.Plugins)
            {
                plugin.ExtremeStudioFuncs = new FuncsHandler();
                plugin.OnPluginInit();
                foreach (var btn in plugin.ToolStripButtons)
                {
                    installedPlugins.Items.Add(btn);
                }
            }
        }

        #endregion

        private void addIndentButton_Click(object sender, EventArgs e)
        {
            if (CurrentScintilla != null)
            {
                if (CurrentScintilla.SelectionStart == CurrentScintilla.SelectionEnd)
                {
                    CurrentScintilla.Lines[CurrentScintilla.CurrentLine].Indentation += 4;
                }
                else
                {
                    foreach (var line in GeneralFunctions.GetLinesFromRange(CurrentScintilla, CurrentScintilla.SelectionStart,
                        CurrentScintilla.SelectionEnd))
                    {
                        CurrentScintilla.Lines[line].Indentation += 4;
                    }
                }
            }
        }

        private void removeIndentButton_Click(object sender, EventArgs e)
        {
            if (CurrentScintilla != null)
            {
                if (CurrentScintilla.SelectionStart == CurrentScintilla.SelectionEnd)
                {
                    if (CurrentScintilla.Lines[CurrentScintilla.CurrentLine].Indentation >= 4)
                    {
                        CurrentScintilla.Lines[CurrentScintilla.CurrentLine].Indentation -= 4;
                    }
                }
                else
                {
                    foreach (var line in GeneralFunctions.GetLinesFromRange(CurrentScintilla, CurrentScintilla.SelectionStart,
                        CurrentScintilla.SelectionEnd))
                    {
                        if (CurrentScintilla.Lines[line].Indentation >= 4)
                        {
                            CurrentScintilla.Lines[line].Indentation -= 4;
                        }
                    }
                }
            }
        }

        private void esPluginsManage_Click(object sender, EventArgs e)
        {
            ESPluginsForm dlg = new ESPluginsForm();
            dlg.ShowDialog();
        }
    }
}