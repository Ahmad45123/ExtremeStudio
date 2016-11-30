using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExtremeStudio
{
    /// <summary>
    /// Interaction logic for LanguagesForm.xaml
    /// </summary>
    public partial class LanguagesForm
    {
        public LanguagesForm()
        {
            InitializeComponent();
        }

        //StartupForm: 
        public static StartupForm StartForm = new StartupForm();

        private void LangsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LangsListBox.SelectedIndex != -1)
            {
                ChooseLangBtn_Click(sender, null);
            }
        }

        private void Done()
        {
            StartForm.Show();
            Close();
        }

        private string _applicationFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ExtremeStudio";
        private void ChooseLangBtn_Click(object sender, EventArgs e)
        {
            if (LangsListBox.SelectedIndex != -1)
            {
                ListBoxItem item = (ListBoxItem)LangsListBox.SelectedItem;
                switch ((string)item.Content)
                {
                    case "English":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                        File.WriteAllText(_applicationFiles + "\\configs\\lang.cfg", "en");
                        break;
                    case "Portuguese, Brazillian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        File.WriteAllText(_applicationFiles + "\\configs\\lang.cfg", "pt-BR");
                        break;
                    case "Croatian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                        File.WriteAllText(_applicationFiles + "\\configs\\lang.cfg", "hr");
                        break;
                    case "Spanish":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                        File.WriteAllText(_applicationFiles + "\\configs\\lang.cfg", "es");
                        break;
                    case "Hungarian":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu");
                        File.WriteAllText(_applicationFiles + "\\configs\\lang.cfg", "hu");
                        break;
                }
                Done();
            }
        }

        private void LanguagesForm_Loaded(object sender, EventArgs e)
        {
            if (!Directory.Exists(_applicationFiles + "\\configs"))
            {
                Directory.CreateDirectory(_applicationFiles + "\\configs");
            }

            if (File.Exists(_applicationFiles + "\\configs\\lang.cfg"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(File.ReadAllText(_applicationFiles + "\\configs\\lang.cfg"));
                Done();
            }
        }
    }
}
