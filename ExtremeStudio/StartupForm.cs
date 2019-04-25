using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using AutoUpdaterDotNET;
using ExtremeCore.Classes;
using ExtremeStudio.Classes;
using Newtonsoft.Json;
using Resources;

namespace ExtremeStudio
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To know whether to extract the SQL files or not.
        /// </summary>
        public bool IsFirst = true;

        private bool _isClosedProgram;

        public string ProjectToOpen = "";

        #region RecentCode

        public List<string> Recent = new List<string>();
        const int MaxListItems = 30;

        [Localizable(false)]
        public void AddNewRecent(string path)
        {
            foreach (string str in Recent)
            {
                if (str == path)
                {
                    Recent.Remove(str);
                    break;
                }
            }

            Recent.Insert(0, path); //Inset it at the very start
            if (Recent.Count - 1 == MaxListItems) //Remove the new added stuff
            {
                Recent.RemoveAt(MaxListItems);
            }

            File.WriteAllText(
                Program.MainForm.ApplicationFiles + "/configs/recent.json",
                Convert.ToString(JsonConvert.SerializeObject(Recent)));
        }

        [Localizable(false)]
        public void RemoveRecent(string path)
        {
            foreach (string str in Recent)
            {
                if (str == path)
                {
                    Recent.Remove(str);
                    break;
                }
            }

            File.WriteAllText(
                Program.MainForm.ApplicationFiles + "/configs/recent.json",
                Convert.ToString(JsonConvert.SerializeObject(Recent)));
        }

        #endregion

        VersionHandler _versionHandler = new VersionHandler();

        [Localizable(false)]
        private async void StartupForm_Load(object sender, EventArgs e)
        {
            //Download SAMPCTL
            this.Enabled = false;
            this.Text = "Updating sampctl...";
            await SampCtl.EnsureLatestInstalled(Application.StartupPath);
            this.Text = "ExtremeStudio";
            this.Enabled = true;

            //Add event.
            pathTextBox.PathText.TextChanged += pathTextBox_TextChanged;

            //Check for updates
            AutoUpdater.ParseUpdateInfoEvent += AutoUpdater_ParseUpdateInfoEvent;
            WebClient client = new WebClient {Headers = {["User-Agent"] = "ExtremeStudio"}};
            client.DownloadFile("https://api.github.com/repos/Ahmad45123/ExtremeStudio/releases/latest", Application.StartupPath + "/latest.txt");
            AutoUpdater.Start(Application.StartupPath + "/latest.txt");

            //If the interop files don't exist, Extract the files.
            /*if (IsFirst &&
                (!File.Exists(
                     Application.StartupPath + "/x64/SQLite.Interop.dll") ||
                 !File.Exists(
                     Program.MainForm.ApplicationFiles + "/x86/SQLite.Interop.dll")))
            {
                //Remove old.
                if (File.Exists(
                    Application.StartupPath + "/x64/SQLite.Interop.dll"))
                {
                    File.Delete(
                        Application.StartupPath + "/x64/SQLite.Interop.dll");
                }

                if (File.Exists(
                    Application.StartupPath + "/x86/SQLite.Interop.dll"))
                {
                    File.Delete(
                        Application.StartupPath + "/x86/SQLite.Interop.dll");
                }

                //Extract New
                File.WriteAllBytes(
                    Application.StartupPath + "/interop.zip", Properties.Resources.SQLite_Interop); //Write the file.
                GeneralFunctions.FastZipUnpack(Application.StartupPath + "/interop.zip",
                    Application.StartupPath); //Extract it.
                File.Delete(
                    Application.StartupPath + "/interop.zip"); //Delete the temp file.
            }*/

            //Create needed folders and files.
            if (!Directory.Exists(
                Program.MainForm.ApplicationFiles + "/cache"))
            {
                Directory.CreateDirectory(
                    Program.MainForm.ApplicationFiles + "/cache");
            }

            if (!Directory.Exists(
                Program.MainForm.ApplicationFiles + "/cache/serverPackages"))
            {
                Directory.CreateDirectory(
                    Program.MainForm.ApplicationFiles + "/cache/serverPackages");
            }

            if (!Directory.Exists(
                Program.MainForm.ApplicationFiles + "/cache/includes"))
            {
                Directory.CreateDirectory(
                    Program.MainForm.ApplicationFiles + "/cache/includes");
            }

            if (!Directory.Exists(
                Program.MainForm.ApplicationFiles + "/configs"))
            {
                Directory.CreateDirectory(
                    Program.MainForm.ApplicationFiles + "/configs");
                File.WriteAllText(
                    Program.MainForm.ApplicationFiles + "/configs/recent.json", "");
            }

            //Setting the IsGlobal in Settings will make sure the settings are in place and correct.
            Program.SettingsForm.IsGlobal = true;

            //Load all the recent.
            if (File.Exists(
                Program.MainForm.ApplicationFiles + "/configs/recent.json"))
            {
                try
                {
                    Recent = JsonConvert.DeserializeObject<List<string>>(
                        File.ReadAllText(
                            Program.MainForm.ApplicationFiles + "/configs/recent.json"));
                    if (ReferenceEquals(Recent, null))
                    {
                        Recent = new List<string>();
                    }
                }
                catch (Exception)
                {
                }
            }

            if (ProjectToOpen != "")
            {
                if (GeneralFunctions.IsValidExtremeProject(ProjectToOpen))
                {
                    Program.MainForm.CurrentProject.ProjectPath = ProjectToOpen;
                    Program.MainForm.CurrentProject.ReadInfo();
                    projectName.Text = Program.MainForm.CurrentProject.ProjectName;

                    string projVersion = Convert.ToString(Program.MainForm.CurrentProject.ProjectVersion);
                    string progVersion = Convert.ToString(_versionHandler.CurrentVersion);

                    VersionReader.CompareVersionResult versionCompare =
                        VersionReader.CompareVersions(projVersion, progVersion);
                    if (versionCompare == VersionReader.CompareVersionResult.VersionSame)
                    {
                        loadProjectBtn_Click(null, EventArgs.Empty);
                    }
                    else if (versionCompare == VersionReader.CompareVersionResult.VersionNew)
                    {
                        loadProjectBtn_Click(null, EventArgs.Empty);
                    }
                    else if (versionCompare == VersionReader.CompareVersionResult.VersionOld)
                    {
                        MessageBox.Show(translations.StartupForm_pathTextBox_TextChanged_ProjectVersionNewer);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show(Convert.ToString(translations.StartupForm_pathTextBox_TextChanged_InvalidESPrj));
                    Application.Exit();
                }
            }
        }

        private void AutoUpdater_ParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic json = JsonConvert.DeserializeObject(args.RemoteData);
            string version = json.tag_name;
            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = Version.Parse(version),
                DownloadURL = $"https://github.com/Ahmad45123/ExtremeStudio/releases/download/{version}/ExtremeStudio.Setup_{version}.exe"
            };
        }

        [Localizable(false)]
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                return;
            }

            if (nameTextBox.Text.IsValidFileName())
            {
            }
            else
            {
                SystemSounds.Beep.Play();

                //Replace invalid chars.
                nameTextBox.Text = nameTextBox.Text.Replace("\\", "");
                nameTextBox.Text = nameTextBox.Text.Replace("/", "");
                nameTextBox.Text = nameTextBox.Text.Replace(":", "");
                nameTextBox.Text = nameTextBox.Text.Replace("*", "");
                nameTextBox.Text = nameTextBox.Text.Replace("?", "");
                nameTextBox.Text = nameTextBox.Text.Replace("\"", "");
                nameTextBox.Text = nameTextBox.Text.Replace("<", "");
                nameTextBox.Text = nameTextBox.Text.Replace(">", "");
                nameTextBox.Text = nameTextBox.Text.Replace("|", "");
            }
        }

        private async void CreateProjectBtn_Click(object sender, EventArgs e)
        {
            string newPath = Convert.ToString(locTextBox.PathText.Text);
            if (preExistCheck.Checked)
            {
                if (!Directory.Exists(newPath) ||
                    GeneralFunctions.IsValidExtremeProject(newPath) || !GeneralFunctions.IsValidSAMPFolder(newPath))
                {
                    MessageBox.Show(
                        Convert.ToString(translations.StartupForm_CreateProjectBtn_Click_InvalidSampFolder));
                    return;
                }
                else
                {
                    //Create the default file
                    if(!File.Exists(newPath + "/gamemodes/" + nameTextBox.Text + ".pwn"))
                        File.WriteAllText(
                            newPath + "/gamemodes/" + nameTextBox.Text + ".pwn",
                            Convert.ToString(Properties.Resources.newfileTemplate));

                    //Fill pawnctl data
                    Program.MainForm.CurrentProject.SampCtlData = new PawnJson()
                    {
                        entry = "gamemodes\\" + nameTextBox.Text + ".pwn",
                        output = "gamemodes\\" + nameTextBox.Text + ".amx",
                        user = Environment.UserName,
                        repo = nameTextBox.Text,
                        dependencies = new List<string>() {"sampctl/samp-stdlib"},
                        builds = new List<BuildInfo>()
                        {
                            new BuildInfo()
                            {
                                name = "main",
                                args = Program.SettingsForm.GetCompilerArgs().Split(' ').ToList()
                            }
                        },
                        runtime = new RuntimeInfo() {version = verListBox.SelectedItem?.ToString() ?? "latest"},
                    };
                    Program.MainForm.CurrentProject.ProjectName = nameTextBox.Text;
                    Program.MainForm.CurrentProject.ProjectPath = newPath;
                    Program.MainForm.CurrentProject.ProjectVersion = _versionHandler.CurrentVersion;
                    Program.MainForm.CurrentProject.CreateTables(); //Create the tables of the db.
                    Program.MainForm.CurrentProject.SaveInfo(); //Write the default extremeStudio config.
                    Program.MainForm.CurrentProject.CopyGlobalConfig();
                    Program.MainForm.CurrentProject.LoadSampCtlData(); //to ensure pawno/includes is there.

                    //Ensure the packages are ready
                    this.Enabled = false;
                    this.Text = "Ensuring Packages...";
                    await SampCtl.SendCommand(Path.Combine(Application.StartupPath, "sampctl.exe"), newPath, "p ensure");
                    this.Enabled = true;

                    AddNewRecent(
                        Convert.ToString(Program.MainForm.CurrentProject.ProjectPath)); //Add it to the recent list.
                    Program.MainForm.Show();
                    _isClosedProgram = true;
                    Close();
                }
            }
            else
            {
                //Add to the path folder name.
                if (nameTextBox.Text.IsValidFileName() == false)
                {
                    MessageBox.Show(
                        Convert.ToString(translations.StartupForm_CreateProjectBtn_Click_InvalidName));
                    return;
                }

                newPath = Path.Combine(Convert.ToString(locTextBox.PathText.Text),
                    Convert.ToString(nameTextBox.Text));
                if (!string.IsNullOrEmpty(newPath) &&
                    Directory.Exists(newPath) == false)
                {
                    Directory.CreateDirectory(newPath);
                }

                //Check if entered path exist.
                if (Directory.Exists(newPath) &&
                    File.Exists(
                        newPath + "/extremeStudio.config") == false)
                {
                    if (verListBox.SelectedIndex != -1)
                    {
                        //Create directories.
                        Directory.CreateDirectory(newPath + "/gamemodes");
                        Directory.CreateDirectory(newPath + "/plugins");
                        Directory.CreateDirectory(newPath + "/scriptfiles");

                        //Create the default file
                        File.WriteAllText(
                            newPath + "/gamemodes/" + nameTextBox.Text + ".pwn",
                            Convert.ToString(Properties.Resources.newfileTemplate));

                        //Fill pawnctl data
                        Program.MainForm.CurrentProject.SampCtlData = new PawnJson()
                        {
                            entry = "gamemodes\\" + nameTextBox.Text + ".pwn",
                            output = "gamemodes\\" + nameTextBox.Text + ".amx",
                            user = Environment.UserName,
                            repo = nameTextBox.Text,
                            dependencies = new List<string>() {"sampctl/samp-stdlib"},
                            builds = new List<BuildInfo>() {new BuildInfo(){name = "main", args = Program.SettingsForm.GetCompilerArgs().Split(' ').ToList()}},
                            runtime = new RuntimeInfo() {version = verListBox.SelectedItem.ToString()},
                        };
                        Program.MainForm.CurrentProject.ProjectName = nameTextBox.Text;
                        Program.MainForm.CurrentProject.ProjectPath = newPath;
                        Program.MainForm.CurrentProject.ProjectVersion = _versionHandler.CurrentVersion;
                        Program.MainForm.CurrentProject.CreateTables(); //Create the tables of the db.
                        Program.MainForm.CurrentProject.SaveInfo(); //Write the default extremeStudio config.
                        Program.MainForm.CurrentProject.CopyGlobalConfig();

                        //Ensure the packages are ready
                        this.Enabled = false;
                        this.Text = "Ensuring Packages...";
                        await SampCtl.SendCommand(Path.Combine(Application.StartupPath, "sampctl.exe"), newPath, "p ensure");
                        Enabled = true;

                        AddNewRecent(
                            Convert.ToString(Program.MainForm.CurrentProject.ProjectPath)); //Add it to the recent list.
                        Program.MainForm.Show();
                        _isClosedProgram = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            Convert.ToString(translations.StartupForm_CreateProjectBtn_Click_NoSampSelected));
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Convert.ToString(translations.StartupForm_CreateProjectBtn_Click_DirError));
                    return;
                }
            }
        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            loadProjectBtn.Enabled = false;
            projectName.Text = translations.StartupForm_pathTextBox_TextChanged_None;
            projectVersion.Text = translations.StartupForm_pathTextBox_TextChanged_None;

            if (GeneralFunctions.IsValidExtremeProject(pathTextBox.PathText.Text))
            {
                Program.MainForm.CurrentProject.ProjectPath = pathTextBox.PathText.Text;
                Program.MainForm.CurrentProject.ReadInfo();
                projectName.Text = Program.MainForm.CurrentProject.ProjectName;

                string projVersion = Convert.ToString(Program.MainForm.CurrentProject.ProjectVersion);
                string progVersion = Convert.ToString(_versionHandler.CurrentVersion);

                VersionReader.CompareVersionResult versionCompare =
                    VersionReader.CompareVersions(projVersion, progVersion);
                if (versionCompare == VersionReader.CompareVersionResult.VersionSame)
                {
                    projectVersion.Text = translations.StartupForm_pathTextBox_TextChanged_ProjectVersionSame;
                    loadProjectBtn.Enabled = true;
                }
                else if (versionCompare == VersionReader.CompareVersionResult.VersionNew)
                {
                    projectVersion.Text = translations.StartupForm_pathTextBox_TextChanged_ProjectVersionOlder;
                    loadProjectBtn.Enabled = true;
                }
                else if (versionCompare == VersionReader.CompareVersionResult.VersionOld)
                {
                    projectVersion.Text = translations.StartupForm_pathTextBox_TextChanged_ProjectVersionNewer;
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(translations.StartupForm_pathTextBox_TextChanged_InvalidESPrj));
            }
        }

        private void loadProjectBtn_Click(object sender, EventArgs e)
        {
            AddNewRecent(
                Convert.ToString(Program.MainForm.CurrentProject.ProjectPath)); //Add it to the recent list.
            _versionHandler.DoIfUpdateNeeded(Program.MainForm.CurrentProject);
            Program.MainForm.Show();
            _isClosedProgram = true;
            Close();
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 2)
            {
                recentListBox.Items.Clear();

                //Get recent list.
                if (Recent != null)
                {
                    foreach (string str in Recent)
                    {
                        if (ReferenceEquals(str, null))
                        {
                            continue;
                        }

                        recentListBox.Items.Add(str);
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (recentListBox.SelectedIndex == -1)
            {
                return;
            }

            pathTextBox.PathText.Text = (string) recentListBox.SelectedItem;
            if (loadProjectBtn.Enabled)
            {
                if (projectVersion.Text != translations.StartupForm_pathTextBox_TextChanged_ProjectVersionSame)
                {
                    if (MessageBox.Show(
                            projectVersion.Text + "\r\n" + "\r\n" +
                            translations.StartupForm_Button1_Click_WouldYouLikeToContinue, "",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        loadProjectBtn_Click(loadProjectBtn, EventArgs.Empty); //Click `Load Project` button.
                    }
                }
                else
                {
                    loadProjectBtn_Click(loadProjectBtn, EventArgs.Empty); //Click `Load Project` button.
                }
            }
            else
            {
                if (projectVersion.Text != translations.StartupForm_pathTextBox_TextChanged_ProjectVersionSame)
                {
                    MessageBox.Show(Convert.ToString(projectVersion.Text));
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (recentListBox.SelectedIndex == -1)
            {
                return;
            }

            RemoveRecent(Convert.ToString(recentListBox.SelectedItem));
            TabControl1_Selected(TabControl1,
                new TabControlEventArgs(TabPage3, 2,
                    TabControlAction.Selected)); //Fire the selected event to refresh the list.
        }

        private void recentListBox_DoubleClick(object sender, EventArgs e)
        {
            Button1.PerformClick(); //Press the load button.
        }

        private void StartupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isClosedProgram == false)
            {
                Application.Exit();
            }
        }

        private void OpenGlobalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.SettingsForm.IsGlobal = true;
            Program.SettingsForm.ShowDialog();
        }

        private void preExistCheck_CheckedChanged(object sender, EventArgs e)
        {
            verListBox.Enabled = !preExistCheck.Checked;
        }
    }
}