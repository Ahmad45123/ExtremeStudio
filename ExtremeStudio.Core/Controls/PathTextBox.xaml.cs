using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace ExtremeStudio.Core.Controls
{
    /// <summary>
    /// Interaction logic for PathTextBox.xaml
    /// </summary>
    public partial class PathTextBox : UserControl
    {
        public PathTextBox()
        {
            InitializeComponent();
        }

        public bool IsDirectory { get; set; } = false;
        public string TheDesc { get; set; }
        public string TheFilter { get; set; }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsDirectory)
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog()
                {
                    Description = TheDesc
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TheTextBox.Text = dlg.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog()
                {
                    Title = TheDesc,
                    Filter = TheFilter
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TheTextBox.Text = dlg.FileName;
                }
            }
            e.Handled = true;
        }
    }
}
