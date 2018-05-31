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
            Program.StartupForm.Show();
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
                            Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg", "en");
                        break;
                    case "Portuguese, Brazillian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        File.WriteAllText(
                            Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg", "pt-BR");
                        break;
                    case "Croatian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                        File.WriteAllText(
                            Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg", "hr");
                        break;
                    case "Spanish":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                        File.WriteAllText(
                            Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg", "es");
                        break;
                    case "Hungarian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu");
                        File.WriteAllText(
                            Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg", "hu");
                        break;
                }

                Done();
            }
        }

        private void LanguagesForm_Load(object sender, EventArgs e)
        {
            //We will want to set/know the settings folder first.
            //CHANGED: it now just saved in the same folder as app
            Program.MainForm.ApplicationFiles = Application.StartupPath;

            if (!Directory.Exists(Program.MainForm.ApplicationFiles + "\\configs"))
            {
                Directory.CreateDirectory(Program.MainForm.ApplicationFiles + "\\configs");
            }

            if (File.Exists(Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg"))
            {
                Thread.CurrentThread.CurrentUICulture =
                    new CultureInfo(File.ReadAllText(Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg"));
                Done();
            }
        }
    }
}