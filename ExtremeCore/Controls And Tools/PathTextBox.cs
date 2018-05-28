using System;
using System.Windows.Forms;

namespace ExtremeCore.Controls_And_Tools
{
    public partial class PathTextBox : UserControl
    {
        public PathTextBox()
        {
            InitializeComponent();
        }

        public enum PathTypes
        {
            Folder,
            FileSave,
            FileOpen
        }
        public PathTypes PathType {get; set;}
	
        /// <summary>
        /// Will be used for .Description in folders and as .Title for Files.
        /// </summary>
        /// <returns></returns>
        public string Description {get; set;}
	
        /// <summary>
        /// Only useable if PathType is set to FileSave or FileOpen
        /// </summary>
        /// <returns></returns>
        public string Filter {get; set;}
	
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (PathType == PathTypes.Folder)
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog
                {
                    Description = Description
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PathText.Text = dlg.SelectedPath;
                }
			
            }
            else if (PathType == PathTypes.FileOpen)
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    Title = Description,
                    Filter = Filter
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PathText.Text = dlg.FileName;
                }
			
            }
            else if (PathType == PathTypes.FileSave)
            {
                SaveFileDialog dlg = new SaveFileDialog
                {
                    Title = Description,
                    Filter = Filter
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PathText.Text = dlg.FileName;
                }
			
            }
        }
	
        private void PathText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BrowseBtn.PerformClick();
        }
    }
}
