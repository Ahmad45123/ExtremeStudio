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
using System.Xml;
using Resources;

namespace ExtremeStudio.FunctionsForms
{
    public partial class ESPluginsForm : Form
    {
        public ESPluginsForm()
        {
            InitializeComponent();
        }

        List<EsPluginData> _plugins = new List<EsPluginData>();
        bool _isThereInteret = true;

        private void RefreshList()
        {
            PluginList.Items.Clear();
            foreach (var plug in _plugins)
            {
                PluginList.Items.Add(plug.PluginName);
            }
        }

        private dynamic IsPluginInstalled(EsPluginData plug)
        {
            string file = Path.GetFileName(plug.PluginPath);
            if (File.Exists(
                Application.StartupPath + "/plugins/" + file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private dynamic IsPluginDifferent(EsPluginData plug)
        {
            string file = Path.GetFileName(plug.PluginPath);
            string oldHash =
                System.Convert.ToString(ExtremeCore.Classes.GeneralFunctions.GetFileHash(Application.StartupPath + "/plugins/" + file));
            if (oldHash == plug.PluginSha)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EsPluginsForm_Load(object sender, EventArgs e)
        {
            _plugins.Clear();

            if (ExtremeCore.Classes.GeneralFunctions.IsNetAvailable()) //Download latest from internet if there is internet.
            {
                WebClient webClient = new WebClient();
                XmlDocument xmlFile = new XmlDocument();
                string fileText =
                    System.Convert.ToString(
                        webClient.DownloadString("http://ahmad45123.github.io/esfiles/esplugins.xml"));
                xmlFile.LoadXml(fileText);

                foreach (XmlNode cs in xmlFile.SelectNodes("xml/plugin"))
                {
                    EsPluginData plug = new EsPluginData();
                    plug.PluginName = System.Convert.ToString(cs["name"].InnerText.Trim());
                    plug.PluginDesc = System.Convert.ToString(cs["desc"].InnerText.Trim());
                    plug.PluginPath = System.Convert.ToString(cs["download"].InnerText.Trim());
                    plug.PluginSha = System.Convert.ToString(cs["hash"].InnerText.Trim());
                    _plugins.Add(plug);
                }
            }
            else
            {
                _isThereInteret = false;
                foreach (var file in Directory.GetFiles(Application.StartupPath + "/plugins", "*.dll"))
                {
                    _plugins.Add(new EsPluginData() {PluginName = Path.GetFileName(System.Convert.ToString(file))});
                }
            }

            RefreshList();
        }

        private void PluginList_Click(object sender, EventArgs e)
        {
            if (PluginList.SelectedIndex != -1)
            {
                if (_isThereInteret)
                {
                    foreach (var plug in _plugins)
                    {
                        if (plug.PluginName == (string)PluginList.SelectedItem)
                        {
                            PluginNameText.Text = plug.PluginName;
                            PluginDescText.Text = plug.PluginDesc;
                            if (IsPluginInstalled(plug))
                            {
                                installBtn.Text = translations.EsPluginsForm_PluginList_Click_ReInstallPlugin;
                                installBtn.Enabled = true;
                                deleteBtn.Visible = true;
                                if (IsPluginDifferent(plug))
                                {
                                    updateLabel.Visible = true;
                                }
                            }
                            else
                            {
                                installBtn.Text = translations.EsPluginsForm_PluginList_Click_InstallPlugin;
                                installBtn.Enabled = true;
                                deleteBtn.Visible = false;
                                updateLabel.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    installBtn.Text = "";
                    installBtn.Enabled = false;
                    deleteBtn.Visible = true;
                    updateLabel.Visible = false;
                }
            }
            else
            {
                installBtn.Text = "";
                installBtn.Enabled = false;
                deleteBtn.Visible = false;
                updateLabel.Visible = false;
            }

        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            if (_isThereInteret)
            {
                if (PluginList.SelectedIndex != -1)
                {
                    foreach (var plug in _plugins)
                    {
                        if (plug.PluginName == (string) PluginList.SelectedItem)
                        {
                            var plugPath = Application.StartupPath + "/plugins/" +
                                              Path.GetFileName(System.Convert.ToString(plug.PluginPath));
                            if (File.Exists(plugPath))
                            {
                                File.Delete(plugPath);
                            }

                            WebClient web = new WebClient();
                            web.DownloadFile(plug.PluginPath, plugPath);
                            EsPluginsForm_Load(this, null);
                            PluginList_Click(this, null);
                            break;
                        }
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (_isThereInteret)
            {
                if (PluginList.SelectedIndex != -1)
                {
                    string plugPath = null;
                    foreach (var plug in _plugins)
                    {
                        if (plug.PluginName == (string)PluginList.SelectedItem)
                        {
                            plugPath = Application.StartupPath + "/plugins/" +
                                       Path.GetFileName(System.Convert.ToString(plug.PluginPath));
                            if (File.Exists(plugPath))
                            {
                                File.Delete(plugPath);
                            }

                            EsPluginsForm_Load(this, null);
                            PluginList_Click(this, null);
                            break;
                        }
                    }
                }
            }
            else
            {
                File.Delete(Application.StartupPath + "/plugins/" + PluginList.SelectedItem);
                EsPluginsForm_Load(this, null);
                PluginList_Click(this, null);
            }
        }
    }

    public class EsPluginData
    {
        public string PluginName {get; set;}
        public string PluginDesc {get; set;}
        public string PluginPath {get; set;}
        public string PluginSha {get; set;}
    }
}