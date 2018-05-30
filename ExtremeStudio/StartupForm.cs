using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Net;
using System.Windows.Forms;
using System.Xml;
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
        private void StartupForm_Load(object sender, EventArgs e)
        {
            //Download SAMPCTL
            SampCtl.EnsureLatestInstalled(Application.StartupPath);

            //Add event.
            pathTextBox.PathText.TextChanged += pathTextBox_TextChanged;

            //If the interop files don't exist, Extract the files.
            if (IsFirst &&
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
            }

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

            //Load samp versions into list.
            List<string> str = new List<string>();
            if (GeneralFunctions.IsNetAvailable()) //Download latest from internet if there is internet.
            {
                WebClient webClient = new WebClient();
                XmlDocument xmlFile = new XmlDocument();
                string fileText =
                    Convert.ToString(
                        webClient.DownloadString("https://ahmad45123.github.io/esfiles/serverPackages.xml"));
                xmlFile.LoadXml(fileText);

                foreach (XmlNode cs in xmlFile.SelectNodes("serverPackages/samp"))
                {
                    int newList = Convert.ToInt32(verListBox.Items.Add(cs["name"].InnerText));
                    str.Add(cs["download"].InnerText);
                }
            }
            else //Load existing from folder.
            {
                foreach (string pth in Directory.GetFiles(Program.MainForm.ApplicationFiles + "/cache/serverPackages"))
                {
                    int newList = Convert.ToInt32(verListBox.Items.Add(Path.GetFileNameWithoutExtension(pth)));
                    str.Add(pth);
                }
            }

            verListBox.Tag = str;
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

        private void CreateProjectBtn_Click(object sender, EventArgs e)
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
                        if (File.Exists(
                            Program.MainForm.ApplicationFiles + "/cache/serverPackages/" + verListBox.SelectedItem +
                            ".zip")
                        ) //check if that version is existing
                        {
                            GeneralFunctions.FastZipUnpack(
                                Program.MainForm.ApplicationFiles + "/cache/serverPackages/" + verListBox.SelectedItem +
                                ".zip",
                                newPath); //Extract the zip to project folder.
                        }
                        else //Download from net if not exist.
                        {
                            WebClient client = new WebClient(); //For downloading the selected file.
                            client.DownloadFile(((List<string>) verListBox.Tag)[verListBox.SelectedIndex],
                                Path.GetTempPath() + "/" + nameTextBox.Text + ".zip"); //Download the zip file.
                            GeneralFunctions.FastZipUnpack(
                                Path.GetTempPath()
                                + "/" + nameTextBox.Text + ".zip", newPath); //Extract the zip.
                            File.Copy(
                                Path.GetTempPath()
                                + "/" + nameTextBox.Text + ".zip",
                                Program.MainForm.ApplicationFiles + "/cache/serverPackages/" + verListBox.SelectedItem +
                                ".zip"); //Copy the file to be used instead of downloading
                            File.Delete(
                                Path.GetTempPath()
                                + "/" + nameTextBox.Text + ".zip"); //Delete the file from temp.
                        }

                        File.WriteAllText(
                            newPath + "/gamemodes/" + nameTextBox.Text + ".pwn",
                            Convert.ToString(Properties.Resources.newfileTemplate));
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

            //Delete the pawno folder, useless.
            Directory.Delete(Path.Combine(newPath, "pawno"));
            //Create the pawn.json file for SAMPCtl
            File.WriteAllText(Path.Combine(newPath, "pawn.json"), string.Format(Properties.Resources.pawn, Environment.UserName, nameTextBox.Text, nameTextBox.Text + ".pwn", nameTextBox.Text + ".amx"));
            

            Program.MainForm.CurrentProject.ProjectName = nameTextBox.Text;
            Program.MainForm.CurrentProject.ProjectPath = newPath;
            Program.MainForm.CurrentProject.ProjectVersion = _versionHandler.CurrentVersion;
            Program.MainForm.CurrentProject.CreateTables(); //Create the tables of the db.
            Program.MainForm.CurrentProject.SaveInfo(); //Write the default extremeStudio config.
            Program.MainForm.CurrentProject.CopyGlobalConfig();
            AddNewRecent(
                Convert.ToString(Program.MainForm.CurrentProject.ProjectPath)); //Add it to the recent list.
            Program.MainForm.Show();
            _isClosedProgram = true;
            Close();
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