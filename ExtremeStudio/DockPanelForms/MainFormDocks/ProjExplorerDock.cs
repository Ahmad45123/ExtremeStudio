using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ExtremeCore.Classes;
using ExtremeCore.Controls_And_Tools;
using Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace ExtremeStudio.DockPanelForms.MainFormDocks
{
    public partial class ProjExplorerDock : DockContent
    {
        public ProjExplorerDock()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            if(Visible)
                filesList.SelectedPath = filesList.SelectedPath;
        }

        private void ProjExplorerDock_Load(object sender, EventArgs e)
        {
            //Wont be called multiple times:
            filesList.MainDir = Program.MainForm.CurrentProject.ProjectPath;
            filesList.SelectedPath = Program.MainForm.CurrentProject.ProjectPath;
            filesList.IgnoredNames = new List<string>()
            {
                "configs",
                "dependencies",
                "extremeStudio.config",
                "pawn.json",
            };
            RefreshList();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void filesList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                filesList.SelectedIndex = filesList.IndexFromPoint(e.Location);
                if (filesList.SelectedItem != null)
                {
                    DeleteToolStripMenuItem.Enabled = false;
                    RenameToolStripMenuItem.Enabled = false;
                }
                else
                {
                    DeleteToolStripMenuItem.Enabled = true;
                    RenameToolStripMenuItem.Enabled = true;
                }

                mouseRightClick.Show(MousePosition);
            }
        }

        private void filesList_FileSelected(object sender, FileSelectEventArgs fse)
        {
            var ext = Path.GetExtension(Convert.ToString(fse.FileName));

            //Do different stuff depending on file type.
            if (ext == ".inc" || ext == ".pwn")
            {
                Program.MainForm.OpenFile(fse.FileName);
            }
            else
            {
                Program.MainForm.ShowStatus(translations.ProjExplorerDock_filesList_FileSelected_FileNotSupported, 5000, false);
                Process.Start(new ProcessStartInfo
                {
                    WorkingDirectory = Path.GetDirectoryName(Convert.ToString(fse.FileName)),
                    FileName = fse.FileName
                });
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Convert.ToString(filesList.SelectedFile)))
            {
                ResetFolder:
                AdvancedInputBox input = new AdvancedInputBox(
                    translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle,
                    translations.ProjExplorerDock_RenameToolStripMenuItem_Click_PleaseEnterNewDirName);
                if (input.ResResult == AdvancedInputBox.ReturnValue.InputResultOk)
                {
                    if (input.ResText.IsValidFileName())
                    {
                        try
                        {
                            Directory.Move(
                                Convert.ToString(filesList.SelectedFile), Path.Combine(Path.GetDirectoryName(filesList.SelectedFile), input.ResText)); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                        }

                        RefreshList();
                    }
                    else
                    {
                        goto ResetFolder;
                    }
                }

            }
            else if (File.Exists(Convert.ToString(filesList.SelectedFile)))
            {
                ResetFile:
                AdvancedInputBox input = new AdvancedInputBox(
                    translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle,
                    translations.ProjExplorerDock_RenameToolStripMenuItem_Click_PleaseEnterNameForFile,
                    Path.GetFileName(Convert.ToString(filesList.SelectedFile)));
                if (input.ResResult == AdvancedInputBox.ReturnValue.InputResultOk)
                {
                    if (input.ResText.IsValidFileName())
                    {
                        try
                        {
                            File.Move(
                                Convert.ToString(filesList.SelectedFile), Path.Combine(Path.GetDirectoryName(filesList.SelectedFile), input.ResText));

                            //If done, change path in openend documents
                            foreach (var doc in Program.MainForm.MainDock.Documents)
                            {
                                var oy = (EditorDock.EditorDock)doc.DockHandler.Form;
                                if ((string) oy.Editor.Tag == filesList.SelectedFile)
                                {
                                    oy.Editor.Tag = Path.Combine(Path.GetDirectoryName(filesList.SelectedFile),
                                        input.ResText);
                                    oy.TabText = input.ResText;
                                    oy.Text = input.ResText;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        RefreshList();
                    }
                    else
                    {
                        goto ResetFile;
                    }
                }

            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(translations.ProjExplorerDock_DeleteToolStripMenuItem_Click_AreYouSure, "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (Directory.Exists(Convert.ToString(filesList.SelectedFile)))
            {
                Directory.Delete(Convert.ToString(filesList.SelectedFile));
                RefreshList();

            }
            else if (File.Exists(Convert.ToString(filesList.SelectedFile)))
            {
                File.Delete(Convert.ToString(filesList.SelectedFile));
                RefreshList();

            }
        }

        private void NewDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Convert.ToString(filesList.SelectedFile)))
            {
                //Go inside the dir.
                filesList.SelectedPath = Path.Combine(Convert.ToString(filesList.SelectedPath),
                    Convert.ToString(filesList.SelectedItem.ToString()));
            }

            ResetChoose:
            AdvancedInputBox input = new AdvancedInputBox(
                translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle,
                translations.ProjExplorerDock_NewDirectoryToolStripMenuItem_Click_PleaseEnterNameForDir);
            if (input.ResResult == AdvancedInputBox.ReturnValue.InputResultOk)
            {
                if (GeneralFunctions.IsValidFileName(input.ResText))
                {
                    try
                    {
                        Directory.CreateDirectory(
                            Path.Combine(Convert.ToString(filesList.SelectedPath),
                                Convert.ToString(input.ResText)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    RefreshList();
                }
                else
                {
                    goto ResetChoose;
                }
            }
        }

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Convert.ToString(filesList.SelectedFile)))
            {
                //Go inside the dir.
                filesList.SelectedPath = Path.Combine(Convert.ToString(filesList.SelectedPath),
                    Convert.ToString(filesList.SelectedItem.ToString()));
            }

            ResetChoose:
            AdvancedInputBox input = new AdvancedInputBox(
                translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle,
                translations.ProjExplorerDock_NewFileToolStripMenuItem_Click_PleaseEnterNameForFile, "example.pwn");
            if (input.ResResult == AdvancedInputBox.ReturnValue.InputResultOk)
            {
                if (GeneralFunctions.IsValidFileName(input.ResText))
                {
                    try
                    {
                        File.WriteAllText(
                            Path.Combine(Convert.ToString(filesList.SelectedPath),
                                Convert.ToString(input.ResText)), "");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    RefreshList();
                }
                else
                {
                    goto ResetChoose;
                }
            }
        }

        private void filesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteToolStripMenuItem_Click(this, null);
            }
        }
    }
}