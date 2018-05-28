using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock
{
    partial class ObjectExplorerDock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectExplorerDock));
            this.treeView = new System.Windows.Forms.TreeView();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.ContextMenuStrip = this.MenuStrip;
            this.treeView.Name = "treeView";
            this.treeView.ShowNodeToolTips = true;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ToolStripSeparator1,
            this.EditItemsToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            resources.ApplyResources(this.ToolStripMenuItem1, "ToolStripMenuItem1");
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(this.ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // EditItemsToolStripMenuItem
            // 
            this.EditItemsToolStripMenuItem.Name = "EditItemsToolStripMenuItem";
            resources.ApplyResources(this.EditItemsToolStripMenuItem, "EditItemsToolStripMenuItem");
            this.EditItemsToolStripMenuItem.Click += new System.EventHandler(this.EditItemsToolStripMenuItem_Click);
            // 
            // SearchTextBox
            // 
            resources.ApplyResources(this.SearchTextBox, "SearchTextBox");
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_Changed);
            this.SearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTextBox_KeyPress);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label1.ForeColor = System.Drawing.Color.DarkGray;
            this.Label1.Name = "Label1";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ObjectExplorerDock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.treeView);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "ObjectExplorerDock";
            this.Load += new System.EventHandler(this.ObjectExplorerDock_Load);
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal TreeView treeView;
        internal ContextMenuStrip MenuStrip;
        internal ToolStripMenuItem EditItemsToolStripMenuItem;
        internal ToolStripMenuItem ToolStripMenuItem1;
        internal ToolStripSeparator ToolStripSeparator1;
        internal TextBox SearchTextBox;
        internal Label Label1;
    }
}