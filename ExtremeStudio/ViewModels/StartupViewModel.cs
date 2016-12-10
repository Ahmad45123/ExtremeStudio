using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using Metro.Dialogs;
using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Interactivity;
using ExtremeStudio.Classes;
using ExtremeStudio.Properties;

namespace ExtremeStudio.ViewModels
{
    public class StartupViewModel : Screen
    {
        /// <summary>
        /// To know whether to extract the SQL files or not.
        /// </summary>
        public bool IsFirst = true;
        private bool _isClosedProgram = false;

        private readonly IWindowManager _windowManager;
        private readonly IWindowsDialogs _dialogManager;
        private readonly IDialogCoordinator _dialogCoordinator;
        private readonly CurrentProjectClass _currentProject;
        public StartupViewModel(IWindowManager windowManager, IWindowsDialogs windowsDialogs, IDialogCoordinator dialogcord, CurrentProjectClass currentProject)
        {
            _windowManager = windowManager;
            _dialogManager = windowsDialogs;
            _dialogCoordinator = dialogcord;
            _currentProject = currentProject;

            if (IsFirst & (!File.Exists(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/x64/SQLite.Interop.dll") | !File.Exists(CurrentProjectClass.ApplicationFiles + "/x86/SQLite.Interop.dll")))
            {
                //Remove old.
                if (File.Exists(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/x64/SQLite.Interop.dll"))
                    File.Delete(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/x64/SQLite.Interop.dll");
                if (File.Exists(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/x86/SQLite.Interop.dll"))
                    File.Delete(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/x86/SQLite.Interop.dll");

                //Extract New
                File.WriteAllBytes(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/interop.zip", Resources.SQLite_Interop);
                //Write the file.
                Core.Modules.GeneralFunctions.FastZipUnpack(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/interop.zip", Core.Modules.GeneralFunctions.GetExecutionFolder());
                //Extract it.
                File.Delete(Core.Modules.GeneralFunctions.GetExecutionFolder() + "/interop.zip");
                //Delete the temp file.
            }

            //Create needed folders and files.
            if (!Directory.Exists(CurrentProjectClass.ApplicationFiles + "/cache"))
            {
                Directory.CreateDirectory(CurrentProjectClass.ApplicationFiles + "/cache");
            }
            if (!Directory.Exists(CurrentProjectClass.ApplicationFiles + "/cache/serverPackages"))
            {
                Directory.CreateDirectory(CurrentProjectClass.ApplicationFiles + "/cache/serverPackages");
            }
            if (!Directory.Exists(CurrentProjectClass.ApplicationFiles + "/cache/includes"))
            {
                Directory.CreateDirectory(CurrentProjectClass.ApplicationFiles + "/cache/includes");
            }

            if (!Directory.Exists(CurrentProjectClass.ApplicationFiles + "/configs"))
            {
                Directory.CreateDirectory(CurrentProjectClass.ApplicationFiles + "/configs");
                File.WriteAllText(CurrentProjectClass.ApplicationFiles + "/configs/recent.json", "", Encoding.UTF8);
            }

            //Setting the IsGlobal in Settings will make sure the settings are in place and correct.
            //TODO: SettingsForm.IsGlobal = true;

            //Load all the recent.
            if (File.Exists(CurrentProjectClass.ApplicationFiles + "/configs/recent.json"))
            {
                try
                {
                    Recent = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(CurrentProjectClass.ApplicationFiles + "/configs/recent.json")) ??
                             new List<string>();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        #region Create Project
        
        //Property Bindings.
        private string _NewProjectProjectNameTextBox;
        public string NewProjectProjectNameTextBox
        {
            get { return _NewProjectProjectNameTextBox; }
            set { _NewProjectProjectNameTextBox = value; NotifyOfPropertyChange(() => NewProjectProjectNameTextBox); }
        }

        private ObservableCollection<string> _NewProjectSampVersionListBox;
        public ObservableCollection<string> NewProjectSampVersionListBox
        {
            get { return _NewProjectSampVersionListBox; }
            set { _NewProjectSampVersionListBox = value; NotifyOfPropertyChange(() => NewProjectSampVersionListBox); }
        }

        private bool _NewProjectCreateFromPreExisting;
        public bool NewProjectCreateFromPreExisting
        {
            get { return _NewProjectCreateFromPreExisting; }
            set { _NewProjectCreateFromPreExisting = value; NotifyOfPropertyChange(() => NewProjectCreateFromPreExisting); }
        }

        private string _NewProjectPathTextBox;
        public string NewProjectPathTextBox
        {
            get { return _NewProjectPathTextBox; }
            set { _NewProjectPathTextBox = value; NotifyOfPropertyChange(() => NewProjectPathTextBox); }
        }

        private int _VersionsListBoxSelectedItem;
        public int VersionsListBoxSelectedItem
        {
            get { return _VersionsListBoxSelectedItem; }
            set { _VersionsListBoxSelectedItem = value; NotifyOfPropertyChange(() => VersionsListBoxSelectedItem); }
        }
        private int _VersionsListBoxSelectedIndex;
        public int VersionsListBoxSelectedIndex
        {
            get { return _VersionsListBoxSelectedIndex; }
            set { _VersionsListBoxSelectedIndex = value; NotifyOfPropertyChange(() => VersionsListBoxSelectedIndex); }
        }

        //Actions
        private List<string> _versionListBoxDownloads = new List<string>();
        public void OnOpenNewProjectTab()
        {
            NewProjectSampVersionListBox = new ObservableCollection<string>();
            _versionListBoxDownloads = new List<string>();

            //Download latest from internet if there is internet.
            if (Core.Modules.GeneralFunctions.IsNetAvailable())
            {
                WebClient webClient = new WebClient();
                XmlDocument xmlFile = new XmlDocument();
                string fileText = webClient.DownloadString("http://johnymac.github.io/esfiles/serverPackages.xml");
                xmlFile.LoadXml(fileText);

                foreach (XmlNode cs in xmlFile.SelectNodes("serverPackages/samp"))
                {
                    NewProjectSampVersionListBox.Add(cs["name"]?.InnerText);
                    _versionListBoxDownloads.Add(cs["download"]?.InnerText);
                }
            }
            else
            {
                //Load existing from folder.
                foreach (string pth in Directory.GetFiles(CurrentProjectClass.ApplicationFiles + "/cache/serverPackages"))
                {
                    NewProjectSampVersionListBox.Add(Path.GetFileNameWithoutExtension(pth));
                    _versionListBoxDownloads.Add(pth);
                }
            }
        }

        public void NewProjectBrowseButton()
        {
            NewProjectPathTextBox = _dialogManager.ShowSelectFolderDialog("Select Project Folder");
        }

        public void NewProjectCreateProject()
        {
            string newPath = NewProjectPathTextBox;
            if (NewProjectCreateFromPreExisting)
            {
                if (!Directory.Exists(newPath) | Core.Modules.GeneralFunctions.IsValidExtremeProject(newPath) | !Core.Modules.GeneralFunctions.IsValidSAMPFolder(newPath))
                {
                    _dialogCoordinator.ShowMessageAsync(this, "ERROR", "Invalid SAMP Folder Selected.");
                    return;
                }
            }
            else
            {
                //Add to the path folder name.
                if (Core.Modules.GeneralFunctions.FilenameIsOk(NewProjectProjectNameTextBox, false, 0) == false)
                {
                    _dialogCoordinator.ShowMessageAsync(this, "ERROR", "Invalid Name.");
                    return;
                }
                newPath = Path.Combine(NewProjectPathTextBox, NewProjectProjectNameTextBox);
                if (!string.IsNullOrEmpty(newPath) & Directory.Exists(newPath) == false)
                    Directory.CreateDirectory(newPath);

                //Check if entered path exist.
                if (Directory.Exists(newPath) & File.Exists(newPath + "/extremeStudio.config") == false)
                {
                    if (VersionsListBoxSelectedIndex != -1)
                    {
                        //check if that version is existing
                        if (File.Exists(CurrentProjectClass.ApplicationFiles + "/cache/serverPackages/" + VersionsListBoxSelectedItem + ".zip"))
                        {
                            Core.Modules.GeneralFunctions.FastZipUnpack(CurrentProjectClass.ApplicationFiles + "/cache/serverPackages/" + VersionsListBoxSelectedItem + ".zip", newPath);
                            //Extract the zip to project folder.
                            //Download from net if not exist.
                        }
                        else
                        {
                            WebClient client = new WebClient();
                            //For downloading the selected file.
                            client.DownloadFile(_versionListBoxDownloads[VersionsListBoxSelectedIndex], Path.GetTempPath() + "/" + NewProjectProjectNameTextBox + ".zip");
                            //Download the zip file.
                            Core.Modules.GeneralFunctions.FastZipUnpack(Path.GetTempPath() + "/" + NewProjectProjectNameTextBox + ".zip", newPath);
                            //Extract the zip.
                            File.Copy(Path.GetTempPath() + "/" + NewProjectProjectNameTextBox + ".zip", CurrentProjectClass.ApplicationFiles + "/cache/serverPackages/" + VersionsListBoxSelectedItem + ".zip");
                            //Copy the file to be used instead of downloading
                            File.Delete(Path.GetTempPath() + "/" + NewProjectProjectNameTextBox + ".zip");
                            //Delete the file from temp.
                        }
                        File.WriteAllText(newPath + "/gamemodes/" + NewProjectProjectNameTextBox + ".pwn", Resources.newfileTemplate, Encoding.UTF8);
                    }
                    else
                    {
                        _dialogCoordinator.ShowMessageAsync(this, "ERROR", "No SAMP version was selected.");
                        return;
                    }
                }
                else
                {
                    _dialogCoordinator.ShowMessageAsync(this, "ERROR", "The directory specified is invalid.");
                    return;
                }
            }

            _currentProject.ProjectName = NewProjectProjectNameTextBox;
            _currentProject.ProjectPath = newPath;
            _currentProject.ProjectVersion = VersionHandler.CurrentVersion;
            _currentProject.CreateTables();
            //Create the tables of the db.
            _currentProject.SaveInfo();
            //Write the default extremeStudio config.
            _currentProject.CopyGlobalConfig();
            AddNewRecent(_currentProject.ProjectPath);
            //Add it to the recent list.
            _windowManager.ShowWindow(new MainViewModel());
            _isClosedProgram = true;
            TryClose();
        }

        public void OnNameTextBoxChange()
        {
            if (string.IsNullOrEmpty(NewProjectProjectNameTextBox))
                return;

            if (Core.Modules.GeneralFunctions.FilenameIsOk(NewProjectProjectNameTextBox, false, 0)) return;
            //Replace invalid chars.
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("\\", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("/", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace(":", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("*", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("?", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("\"", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("<", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace(">", "");
            NewProjectProjectNameTextBox = NewProjectProjectNameTextBox.Replace("|", "");
        }

        #endregion

        #region Load Project
        //Property Bindings: 
        private string _LoadProjectProjectNameLabel;
        public string LoadProjectProjectNameLabel
        {
            get { return _LoadProjectProjectNameLabel; }
            set { _LoadProjectProjectNameLabel = value; NotifyOfPropertyChange(() => LoadProjectProjectNameLabel); }
        }

        private string _LoadProjectProjectVersionLabel;
        public string LoadProjectProjectVersionLabel
        {
            get { return _LoadProjectProjectVersionLabel; }
            set { _LoadProjectProjectVersionLabel = value; NotifyOfPropertyChange(() => LoadProjectProjectVersionLabel); }
        }

        private string _LoadProjectProjectPathTextBox;
        public string LoadProjectProjectPathTextBox
        {
            get { return _LoadProjectProjectPathTextBox; }
            set { _LoadProjectProjectPathTextBox = value; NotifyOfPropertyChange(() => LoadProjectProjectPathTextBox); }
        }

        //Actions: 

        #endregion


        #region Recent
        #region RECENT STUFF: 
        public List<string> Recent = new List<string>();

        const int MaxListItems = 30;
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
            //Insert it at the very start
            //Remove the new added stuff
            if (Recent.Count - 1 == MaxListItems)
            {
                Recent.RemoveAt(MaxListItems);
            }
            File.WriteAllText(CurrentProjectClass.ApplicationFiles + "/configs/recent.json", JsonConvert.SerializeObject(Recent), Encoding.UTF8);
        }

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
            File.WriteAllText(CurrentProjectClass.ApplicationFiles + "/configs/recent.json", JsonConvert.SerializeObject(Recent), Encoding.UTF8);
        }
        #endregion

        //Properties: 
        private ObservableCollection<string> _RecentListBox;
        public ObservableCollection<string> RecentListBox
        {
            get { return _RecentListBox; }
            set { _RecentListBox = value; NotifyOfPropertyChange(() => RecentListBox); }
        }

        //Actions
        public void OnRecentLoaded()
        {
            RecentListBox = new ObservableCollection<string>();
            //Get recent list.
            if (Recent != null)
            {
                foreach (string str in Recent)
                {
                    if (str == null)
                        continue;
                    RecentListBox.Add(str);
                }
            }
        }
        #endregion
    }
}
