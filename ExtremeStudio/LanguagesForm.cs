using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ExtremeStudio
{
    public partial class LanguagesForm : Form
    {
        public LanguagesForm()
        {
            InitializeComponent();
        }

        private void LangsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LangsListBox.SelectedIndex != -1)
            {
                Acceptbtn.PerformClick();
            }
        }

        private void Done()
        {
            Close();
        }

        private void Acceptbtn_Click(object sender, EventArgs e)
        {
            if (LangsListBox.SelectedIndex != -1)
            {
                switch (LangsListBox.SelectedItem)
                {
                    case "English":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                        File.WriteAllText(
                            Application.StartupPath + "\\configs\\lang.cfg", "en");
                        break;
                    case "Hungarian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
                        File.WriteAllText(
                            Application.StartupPath + "\\configs\\lang.cfg", "hu-HU");
                        break;
                    case "Russian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                        File.WriteAllText(
                            Application.StartupPath + "\\configs\\lang.cfg", "ru-RU");
                        break;
                }

                Done();
            }
        }

        private void LanguagesForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\configs"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\configs");
            }

            if (File.Exists(Application.StartupPath + "\\configs\\lang.cfg"))
            {
                Thread.CurrentThread.CurrentUICulture =
                    new CultureInfo(File.ReadAllText(Application.StartupPath + "\\configs\\lang.cfg"));
                Done();
            }
        }
    }
}
