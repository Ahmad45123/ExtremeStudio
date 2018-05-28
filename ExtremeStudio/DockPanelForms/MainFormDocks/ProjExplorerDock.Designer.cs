using System.ComponentModel;
using System.Windows.Forms;
using ExtremeCore.Controls_And_Tools;

namespace ExtremeStudio.DockPanelForms.MainFormDocks
{
    partial class ProjExplorerDock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjExplorerDock));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.mouseRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.NewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesList = new ExtremeCore.Controls_And_Tools.FilesListBox();
            this.mouseRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "dirs_projexplorer.png");
            this.ImageList.Images.SetKeyName(1, "file_projexplorer.png");
            this.ImageList.Images.SetKeyName(2, "correct_projexplorer.png");
            // 
            // mouseRightClick
            // 
            this.mouseRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripMenuItem,
            this.ToolStripSeparator1,
            this.RenameToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.NewFileToolStripMenuItem,
            this.NewDirectoryToolStripMenuItem});
            this.mouseRightClick.Name = "mouseRightClick";
            resources.ApplyResources(this.mouseRightClick, "mouseRightClick");
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            resources.ApplyResources(this.RefreshToolStripMenuItem, "RefreshToolStripMenuItem");
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(this.ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            resources.ApplyResources(this.RenameToolStripMenuItem, "RenameToolStripMenuItem");
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            resources.ApplyResources(this.DeleteToolStripMenuItem, "DeleteToolStripMenuItem");
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            resources.ApplyResources(this.ToolStripMenuItem1, "ToolStripMenuItem1");
            // 
            // NewFileToolStripMenuItem
            // 
            this.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem";
            resources.ApplyResources(this.NewFileToolStripMenuItem, "NewFileToolStripMenuItem");
            this.NewFileToolStripMenuItem.Click += new System.EventHandler(this.NewFileToolStripMenuItem_Click);
            // 
            // NewDirectoryToolStripMenuItem
            // 
            this.NewDirectoryToolStripMenuItem.Name = "NewDirectoryToolStripMenuItem";
            resources.ApplyResources(this.NewDirectoryToolStripMenuItem, "NewDirectoryToolStripMenuItem");
            this.NewDirectoryToolStripMenuItem.Click += new System.EventHandler(this.NewDirectoryToolStripMenuItem_Click);
            // 
            // filesList
            // 
            resources.ApplyResources(this.filesList, "filesList");
            this.filesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filesList.FileIconSize = ExtremeCore.Controls_And_Tools.IconSize.Small;
            this.filesList.FormattingEnabled = true;
            this.filesList.MainDir = "C:/";
            this.filesList.Name = "filesList";
            this.filesList.FileSelected += new ExtremeCore.Controls_And_Tools.FileSelectedEventHandler(this.filesList_FileSelected);
            this.filesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filesList_KeyDown);
            this.filesList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filesList_MouseDown);
            // 
            // ProjExplorerDock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filesList);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "ProjExplorerDock";
            this.Load += new System.EventHandler(this.ProjExplorerDock_Load);
            this.mouseRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal ImageList ImageList;
        internal ContextMenuStrip mouseRightClick;
        internal ToolStripMenuItem RenameToolStripMenuItem;
        internal ToolStripMenuItem DeleteToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem NewFileToolStripMenuItem;
        internal ToolStripMenuItem NewDirectoryToolStripMenuItem;
        internal ToolStripMenuItem RefreshToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator1;
        internal FilesListBox filesList;
    }
}