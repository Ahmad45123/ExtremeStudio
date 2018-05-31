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
            string allPackages = client.DownloadString(@"https://list.packages.sampctl.com");
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
            _page = 1;
            for (int i = 0; i < Math.Min(MaxItemsPerPage, _pcks.Length); i++)
            {
                PackagesList.Items.Add($"{_pcks[i].user}/{_pcks[i].repo}");
            }
            _lastIndex = Math.Min(MaxItemsPerPage, _pcks.Length);
            PreviousButton.Enabled = false;
            NPages.Text = $@"{_page}/{Math.Ceiling(_pcks.Length/(double)MaxItemsPerPage)}";
        }

        private void PackagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionButton.Enabled = false;
            if (PackagesList.SelectedIndex != -1)
            {
                string[] data = PackagesList.SelectedItem.ToString().Split('/');
                Package itm = _pcks.First(x => x.user == data[0] && x.repo == data[1]);
                PackageNameLabel.Text = itm.user + " / " + itm.repo;
                LastUpdatedLabel.Text = "Last updated: " + itm.updated.ToString("D");
                StarsLabel.Text = "Stars: " + itm.stars;
                DependsTextBox.Text = "";
                if (itm.dependencies != null)
                {
                    foreach (var d in itm.dependencies)
                    {
                        DependsTextBox.Text += d + '\r' + '\n';
                    }
                }

                ActionButton.Text = Program.MainForm.CurrentProject.SampCtlData.dependencies.Contains(PackagesList.SelectedItem) ? "Uninstall Package" : "Install Package";
                ActionButton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.MainForm.CurrentProject.SampCtlData.dependencies.Contains(PackagesList.SelectedItem.ToString()))
            {
                //Uninstall action: 
                Program.MainForm.CurrentProject.SampCtlData.dependencies.Remove(PackagesList.SelectedItem.ToString());
                Directory.Delete(Program.MainForm.CurrentProject.ProjectPath + "/dependencies/" + PackagesList.SelectedItem.ToString().Split('/')[1], true);
                Program.MainForm.CurrentProject.SaveSampCtlData();
                ActionButton.Text = "Install Package";
            }
            else
            {
                SampCtl.SendCommand(Application.StartupPath + "/sampctl.exe",
                    Program.MainForm.CurrentProject.ProjectPath, "p install " + PackagesList.SelectedItem);
                Program.MainForm.CurrentProject.LoadSampCtlData();
                ActionButton.Text = "Uninstall Package";
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
