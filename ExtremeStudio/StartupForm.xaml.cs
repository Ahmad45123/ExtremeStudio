using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Xml;
using ExtremeStudio.Core.Modules;
using ExtremeStudio.translations;
using MahApps.Metro.Controls;
using Newtonsoft.Json;

namespace ExtremeStudio
{
    /// <summary>
    /// Interaction logic for StartupForm.xaml
    /// </summary>
    public partial class StartupForm : MetroWindow
    {
        /// <summary>
        /// To know whether to extract the SQL files or not.
        /// </summary>
        public bool IsFirst = true;

        public static readonly string StartupPath =
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        private bool _isClosedProgram = false;

        #region "RecentCode"

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
            Recent.Insert(0, path);
            //Inset it at the very start
            //Remove the new added stuff
            if (Recent.Count - 1 == MaxListItems)
            {
                Recent.RemoveAt(MaxListItems);
            }
            File.WriteAllText(MainForm.ApplicationFiles + "/configs/recent.json", JsonConvert.SerializeObject(Recent));
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
            File.WriteAllText(MainForm.ApplicationFiles + "/configs/recent.json", JsonConvert.SerializeObject(Recent));
        }

        #endregion

        VersionHandler _versionHandler = new VersionHandler();

        [Localizable(false)]
        private void StartupForm_Loaded(object sender, RoutedEventArgs e)
        {
            //Add event.
            LoadProjectProjectDirTextBox.TheTextBox.TextChanged += LoadProjectProjectDirTextBox_TextChanged;

            //If the interop files don't exist, Extract the files.
            if (IsFirst &
                (!File.Exists(StartupPath + "/x64/SQLite.Interop.dll") ||
                 !File.Exists(MainForm.ApplicationFiles + "/x86/SQLite.Interop.dll")))
            {
                //Remove old.
                if (File.Exists(StartupPath + "/x64/SQLite.Interop.dll"))
                    File.Delete(StartupPath + "/x64/SQLite.Interop.dll");
                if (File.Exists(StartupPath + "/x86/SQLite.Interop.dll"))
                    File.Delete(StartupPath + "/x86/SQLite.Interop.dll");

                //Extract New
                File.WriteAllBytes(StartupPath + "/interop.zip", My.Resources.SQLite_Interop);
                //Write the file.
                GeneralFunctions.FastZipUnpack(StartupPath + "/interop.zip", StartupPath);
                //Extract it.
                File.Delete(StartupPath + "/interop.zip");
                //Delete the temp file.
            }

            //Create needed folders and files.
            if (!Directory.Exists(MainForm.ApplicationFiles + "/cache"))
            {
                Directory.CreateDirectory(MainForm.ApplicationFiles + "/cache");
            }
            if (!Directory.Exists(MainForm.ApplicationFiles + "/cache/serverPackages"))
            {
                Directory.CreateDirectory(MainForm.ApplicationFiles + "/cache/serverPackages");
            }
            if (!Directory.Exists(MainForm.ApplicationFiles + "/cache/includes"))
            {
                Directory.CreateDirectory(MainForm.ApplicationFiles + "/cache/includes");
            }
            if (!Directory.Exists(MainForm.ApplicationFiles + "/configs"))
            {
                Directory.CreateDirectory(MainForm.ApplicationFiles + "/configs");
                File.WriteAllText(MainForm.ApplicationFiles + "/configs/recent.json", "");
            }

            //Setting the IsGlobal in Settings will make sure the settings are in place and correct.
            SettingsForm.IsGlobal = true;

            //Load all the recent.
            if (File.Exists(MainForm.ApplicationFiles + "/configs/recent.json"))
            {
                try
                {
                    Recent =
                        JsonConvert.DeserializeObject<List<string>>(
                            File.ReadAllText(MainForm.ApplicationFiles + "/configs/recent.json"));
                    if (Recent == null)
                        Recent = new List<string>();
                }
                catch (Exception ex)
                {
                }
            }

            //Load samp versions into list.
            List<string> str = new List<string>();
            SampVersionListBox.Tag = str;
            //Download latest from internet if there is internet.
            if (GeneralFunctions.IsNetAvailable())
            {
                WebClient webClient = new WebClient();
                XmlDocument xmlFile = new XmlDocument();
                string fileText = webClient.DownloadString("http://johnymac.github.io/esfiles/serverPackages.xml");
                xmlFile.LoadXml(fileText);

                foreach (XmlNode cs in xmlFile.SelectNodes("serverPackages/samp"))
                {
                    int newList = SampVersionListBox.Items.Add(cs["name"].InnerText);
                    ((List<string>) SampVersionListBox.Tag).Add(cs["download"].InnerText);
                }
                //Load existing from folder.
            }
            else
            {
                foreach (string pth in Directory.GetFiles(MainForm.ApplicationFiles + "/cache/serverPackages"))
                {
                    int newList = SampVersionListBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(pth));
                    ((List<string>) SampVersionListBox.Tag).Add(pth);
                }
            }
        }

        [Localizable(false)]
        private void ProjectNameTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectNameTextBox.Text))
                return;

            if (!GeneralFunctions.FilenameIsOk(ProjectNameTextBox.Text, false, 0))
            {
                Console.Beep();

                //Replace invalid chars.
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("\\", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("/", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace(":", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("*", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("?", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("\"", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("<", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace(">", "");
                ProjectNameTextBox.Text = ProjectNameTextBox.Text.Replace("|", "");
            }
        }

        private void CreateProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            string newPath = ProjectLocationTextBox.TheTextBox.Text;
            if (PreExistFilesCheckBox.IsChecked == true)
            {
                if (!Directory.Exists(newPath) | Core.Modules.GeneralFunctions.IsValidExtremeProject(newPath) | !Core.Modules.GeneralFunctions.IsValidSAMPFolder(newPath))
                {
                    MessageBox.Show(strings.StartupForm_CreateProjectBtn_Click_InvalidSampFolder);
                    return;
                }
            }
            else
            {
                //Add to the path folder name.
                if (GeneralFunctions.FilenameIsOk(ProjectNameTextBox.Text, false, 0) == false)
                {
                    MessageBox.Show(strings.StartupForm_CreateProjectBtn_Click_InvalidName);
                    return;
                }
                newPath = System.IO.Path.Combine(ProjectLocationTextBox.TheTextBox.Text, ProjectNameTextBox.Text);
                if (!string.IsNullOrEmpty(newPath) & Directory.Exists(newPath) == false)
                    Directory.CreateDirectory(newPath);

                //Check if entered path exist.
                if (Directory.Exists(newPath) & File.Exists(newPath + "/extremeStudio.config") == false)
                {
                    if (SampVersionListBox.SelectedIndex != -1)
                    {
                        //check if that version is existing
                        if (File.Exists(MainForm.ApplicationFiles + "/cache/serverPackages/" + SampVersionListBox.SelectedItem + ".zip"))
                        {
                            GeneralFunctions.FastZipUnpack(MainForm.ApplicationFiles + "/cache/serverPackages/" + SampVersionListBox.SelectedItem + ".zip", newPath);
                            //Extract the zip to project folder.
                            //Download from net if not exist.
                        }
                        else
                        {
                            WebClient client = new WebClient();
                            //For downloading the selected file.
                            var stuff = (List<string>)SampVersionListBox.Tag;
                            client.DownloadFile(stuff[SampVersionListBox.SelectedIndex], System.IO.Path.GetTempPath() + "/" + ProjectNameTextBox.Text + ".zip");
                            //Download the zip file.
                            GeneralFunctions.FastZipUnpack(System.IO.Path.GetTempPath() + "/" + ProjectNameTextBox.Text + ".zip", newPath);
                            //Extract the zip.
                            File.Copy(System.IO.Path.GetTempPath() + "/" + ProjectNameTextBox.Text + ".zip", MainForm.ApplicationFiles + "/cache/serverPackages/" + SampVersionListBox.SelectedItem + ".zip");
                            //Copy the file to be used instead of downloading
                            File.Delete(System.IO.Path.GetTempPath() + "/" + ProjectNameTextBox.Text + ".zip");
                            //Delete the file from temp.
                        }
                        File.WriteAllText(newPath + "/gamemodes/" + ProjectNameTextBox.Text + ".pwn", My.Resources.newfileTemplate, false);
                    }
                    else
                    {
                        MessageBox.Show(strings.StartupForm_CreateProjectBtn_Click_NoSampSelected);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(strings.StartupForm_CreateProjectBtn_Click_DirError);
                    return;
                }
            }

            MainForm.CurrentProject.ProjectName = ProjectNameTextBox.Text;
            MainForm.CurrentProject.ProjectPath = newPath;
            MainForm.CurrentProject.ProjectVersion = _versionHandler.CurrentVersion;
            MainForm.CurrentProject.CreateTables();
            //Create the tables of the db.
            MainForm.CurrentProject.SaveInfo();
            //Write the default extremeStudio config.
            MainForm.CurrentProject.CopyGlobalConfig();
            AddNewRecent(MainForm.CurrentProject.ProjectPath);
            //Add it to the recent list.
            MainForm.Show();
            _isClosedProgram = true;
            Close();
        }

        private void LoadProjectProjectDirTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadProjectButton.IsEnabled = false;
            ProjectNameTextBlock.Text = strings.StartupForm_pathTextBox_TextChanged_None;
            ProjectVersionTextBlock.Text = strings.StartupForm_pathTextBox_TextChanged_None;

            if (GeneralFunctions.IsValidExtremeProject(LoadProjectProjectDirTextBox.TheTextBox.Text))
            {
                MainForm.CurrentProject.ProjectPath = LoadProjectProjectDirTextBox.TheTextBox.Text;
                MainForm.CurrentProject.ReadInfo();
                ProjectNameTextBlock.Text = MainForm.CurrentProject.ProjectName;

                string projVersion = MainForm.CurrentProject.ProjectVersion;
                string progVersion = _versionHandler.CurrentVersion;

                VersionReader.CompareVersionResult versionCompare = VersionReader.CompareVersions(projVersion, progVersion);
                if (versionCompare == VersionReader.CompareVersionResult.VersionSame)
                {
                    ProjectVersionTextBlock.Text = strings.StartupForm_pathTextBox_TextChanged_ProjectVersionSame;
                    LoadProjectButton.IsEnabled = true;
                }
                else if (versionCompare == VersionReader.CompareVersionResult.VersionNew)
                {
                    ProjectVersionTextBlock.Text = strings.StartupForm_pathTextBox_TextChanged_ProjectVersionOlder;
                    LoadProjectButton.IsEnabled = true;
                }
                else if (versionCompare == VersionReader.CompareVersionResult.VersionOld)
                {
                    ProjectVersionTextBlock.Text = strings.StartupForm_pathTextBox_TextChanged_ProjectVersionNewer;
                }
            }
            else
            {
                MessageBox.Show(strings.StartupForm_pathTextBox_TextChanged_InvalidESPrj);
            }
        }

        private void loadProjectBtn_Click(object sender, EventArgs e)
        {
            AddNewRecent(MainForm.CurrentProject.ProjectPath);
            //Add it to the recent list.
            _versionHandler.DoIfUpdateNeeded(MainForm.CurrentProject);
            MainForm.Show();
            _isClosedProgram = true;
            Close();
        }

        private void MainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecentTabItem.IsSelected == true)
            {
                RecentListBox.Items.Clear();

                //Get recent list.
                if (Recent != null)
                {
                    foreach (string str in Recent)
                    {
                        if (str == null)
                            continue;
                        RecentListBox.Items.Add(str);
                    }
                }
            }
        }

        private void LoadRecentProjectButton_Click(object sender, EventArgs e)
        {
            if (RecentListBox.SelectedIndex == -1)
                return;
            LoadProjectProjectDirTextBox.TheTextBox.Text = (string)RecentListBox.SelectedItem;
            if (LoadProjectButton.IsEnabled == true)
            {
                if (ProjectVersionTextBlock.Text != strings.StartupForm_pathTextBox_TextChanged_ProjectVersionSame)
                {
                    if (MessageBox.Show(ProjectVersionTextBlock.Text + '\n' + '\n' + strings.StartupForm_Button1_Click_WouldYouLikeToContinue, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        loadProjectBtn_Click(LoadProjectButton, EventArgs.Empty);
                        //Click `Load Project` button.
                    }
                }
                else
                {
                    loadProjectBtn_Click(LoadProjectButton, EventArgs.Empty);
                    //Click `Load Project` button.
                }
            }
            else
            {
                if (ProjectVersionTextBlock.Text != strings.StartupForm_pathTextBox_TextChanged_ProjectVersionSame)
                {
                    MessageBox.Show(ProjectVersionTextBlock.Text);
                }
            }
        }

        private void DeleteRecentProject_Click(object sender, EventArgs e)
        {
            if (RecentListBox.SelectedIndex == -1)
                return;
            RemoveRecent((string)RecentListBox.SelectedItem);
            MainTabControl_SelectionChanged(MainTabControl, null);
            //Fire the selected event to refresh the list.
        }

        private void recentListBox_DoubleClick(object sender, EventArgs e)
        {
            LoadRecentProjectButton_Click(null, null);
            //Press the load button.
        }

        private void StartupForm_FormClosed(object sender, EventArgs e)
        {
            if (_isClosedProgram == false)
            {
                Application.Current.Shutdown();
            }
        }

        private void OpenGlobalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.IsGlobal = true;
            SettingsForm.ShowDialog();
        }

        private void preExistCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PreExistFilesCheckBox.IsChecked == true)
            {
                SampVersionListBox.IsEnabled = false;
            }
            else
            {
                SampVersionListBox.IsEnabled = true;
            }
        }
    }
}
