using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtremeCore.Classes;
using Newtonsoft.Json;
using Resources;

namespace ExtremeStudio.FunctionsForms
{
    public partial class PackagesForm : Form
    {
        public PackagesForm()
        {
            InitializeComponent();
        }

        private Package[] _tmppcks;
        private Package[] _pcks;
        private int _lastIndex = 0;
        private int _page = 1;

        private const int MaxItemsPerPage = 21;

        private void PackagesForm_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string allPackages = client.DownloadString(@"https://api.sampctl.com");
            _tmppcks = JsonConvert.DeserializeObject<Package[]>(allPackages);
            _pcks = _tmppcks;

            //Only show 20
            for (int i = 0; i < Math.Min(MaxItemsPerPage, _pcks.Length); i++)
            {
                PackagesList.Items.Add($"{_pcks[i].user}/{_pcks[i].repo}");
            }
            _lastIndex = Math.Min(MaxItemsPerPage, _pcks.Length);
            PreviousButton.Enabled = false;
            NPages.Text = $@"{_page}/{Math.Ceiling(_pcks.Length/(double)MaxItemsPerPage)}";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            PackagesList.Items.Clear();
            for (int i = _lastIndex; i < Math.Min(_lastIndex+MaxItemsPerPage, _pcks.Length); i++)
            {
                PackagesList.Items.Add($"{_pcks[i].user}/{_pcks[i].repo}");
            }
            _lastIndex = Math.Min(MaxItemsPerPage+_lastIndex, _pcks.Length);
            PreviousButton.Enabled = true;
            if(_lastIndex == _pcks.Length)
                NextButton.Enabled = false;
            NPages.Text = $@"{++_page}/{Math.Ceiling(_pcks.Length/(double)MaxItemsPerPage)}";
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            PackagesList.Items.Clear();
            for (int i = Math.Max(_lastIndex-(MaxItemsPerPage*2), 0); i < Math.Max(_lastIndex-MaxItemsPerPage, 0); i++)
            {
                PackagesList.Items.Add($"{_pcks[i].user}/{_pcks[i].repo}");
            }
            _lastIndex = Math.Max(_lastIndex-MaxItemsPerPage, 0);
            NextButton.Enabled = true;
            if(_lastIndex <= MaxItemsPerPage)
                PreviousButton.Enabled = false;
            NPages.Text = $@"{--_page}/{Math.Ceiling(_pcks.Length/(double)MaxItemsPerPage)}";
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text != "")
                _pcks = _tmppcks.Where(x => (x.user + "/" + x.repo).ToLower().Contains(SearchTextBox.Text.ToLower()))
                    .ToArray();
            else
                _pcks = _tmppcks;

            PackagesList.Items.Clear();
            NextButton.Enabled = true;
            _page = 1;
            for (int i = 0; i < Math.Min(MaxItemsPerPage, _pcks.Length); i++)
            {
                PackagesList.Items.Add($"{_pcks[i].user}/{_pcks[i].repo}");
            }
            _lastIndex = Math.Min(MaxItemsPerPage, _pcks.Length);
            PreviousButton.Enabled = false;
            NPages.Text = $@"{_page}/{Math.Ceiling(_pcks.Length/(double)MaxItemsPerPage)}";
            if(Math.Ceiling(_pcks.Length/(double)MaxItemsPerPage) == 1)
                NextButton.Enabled = false;
            else if (Math.Ceiling(_pcks.Length / (double) MaxItemsPerPage) == 0)
            {
                NextButton.Enabled = false;
                NPages.Text = @"0/0";
            }
        }

        private void PackagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionButton.Enabled = false;
            if (PackagesList.SelectedIndex != -1)
            {
                string[] data = PackagesList.SelectedItem.ToString().Split('/');
                Package itm = _pcks.First(x => x.user == data[0] && x.repo == data[1]);
                PackageNameLabel.Text = itm.user + " / " + itm.repo;
                LastUpdatedLabel.Text = translations.PackagesForm_PackagesList_SelectedIndexChanged_LastUpdated + itm.updated.ToString("D");
                StarsLabel.Text = translations.PackagesForm_PackagesList_SelectedIndexChanged_Stars + itm.stars;
                DependsTextBox.Text = "";
                if (itm.dependencies != null)
                {
                    foreach (var d in itm.dependencies)
                    {
                        DependsTextBox.Text += d + '\r' + '\n';
                    }
                }

                ActionButton.Text = Program.MainForm.CurrentProject.SampCtlData.dependencies.Contains(PackagesList.SelectedItem) ? translations.PackagesForm_button1_Click_UninstallPackage : translations.PackagesForm_button1_Click_InstallPackage;
                ActionButton.Enabled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (Program.MainForm.CurrentProject.SampCtlData.dependencies.Contains(PackagesList.SelectedItem.ToString()))
            {
                ActionButton.Enabled = false;
                ActionButton.Text = translations.PackagesForm_button1_Click_Uninstalling;
                PackagesList.Enabled = false;
                ControlBox = false;

                await SampCtl.SendCommand(Application.StartupPath + "/sampctl.exe",
                    Program.MainForm.CurrentProject.ProjectPath, "p uninstall " + PackagesList.SelectedItem);
                Program.MainForm.CurrentProject.LoadSampCtlData();

                ActionButton.Text = translations.PackagesForm_button1_Click_InstallPackage;
                ActionButton.Enabled = true;
                PackagesList.Enabled = true;
                ControlBox = true;
            }
            else
            {
                ActionButton.Enabled = false;
                ActionButton.Text = translations.PackagesForm_button1_Click_Installing;
                PackagesList.Enabled = false;
                ControlBox = false;

                await SampCtl.SendCommand(Application.StartupPath + "/sampctl.exe",
                    Program.MainForm.CurrentProject.ProjectPath, "p install " + PackagesList.SelectedItem);
                Program.MainForm.CurrentProject.LoadSampCtlData();
                
                ActionButton.Text = translations.PackagesForm_button1_Click_UninstallPackage;
                ActionButton.Enabled = true;
                PackagesList.Enabled = true;
                ControlBox = true;
            }
        }
    }

    class Package
    {
        public string user { get; set; }
        public string repo { get; set; }
        public string stars { get; set; }
        public DateTime updated { get; set; }
        public string[] dependencies { get; set; }
    }
}
