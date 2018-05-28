using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock
{
    partial class ObjectExplorerDockItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectExplorerDockItems));
            this.itemsList = new System.Windows.Forms.ListBox();
            this.selinfo = new System.Windows.Forms.GroupBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.infoIden = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.infoName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.addIden = new System.Windows.Forms.TextBox();
            this.addName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.selinfo.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsList
            // 
            resources.ApplyResources(this.itemsList, "itemsList");
            this.itemsList.FormattingEnabled = true;
            this.itemsList.Name = "itemsList";
            this.itemsList.SelectedIndexChanged += new System.EventHandler(this.itemsList_SelectedIndexChanged);
            // 
            // selinfo
            // 
            resources.ApplyResources(this.selinfo, "selinfo");
            this.selinfo.Controls.Add(this.deleteBtn);
            this.selinfo.Controls.Add(this.infoIden);
            this.selinfo.Controls.Add(this.Label3);
            this.selinfo.Controls.Add(this.infoName);
            this.selinfo.Controls.Add(this.Label1);
            this.selinfo.Name = "selinfo";
            this.selinfo.TabStop = false;
            // 
            // deleteBtn
            // 
            resources.ApplyResources(this.deleteBtn, "deleteBtn");
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // infoIden
            // 
            resources.ApplyResources(this.infoIden, "infoIden");
            this.infoIden.Name = "infoIden";
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // infoName
            // 
            resources.ApplyResources(this.infoName, "infoName");
            this.infoName.Name = "infoName";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // GroupBox1
            // 
            resources.ApplyResources(this.GroupBox1, "GroupBox1");
            this.GroupBox1.Controls.Add(this.addBtn);
            this.GroupBox1.Controls.Add(this.addIden);
            this.GroupBox1.Controls.Add(this.addName);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.TabStop = false;
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // addIden
            // 
            resources.ApplyResources(this.addIden, "addIden");
            this.addIden.Name = "addIden";
            // 
            // addName
            // 
            resources.ApplyResources(this.addName, "addName");
            this.addName.Name = "addName";
            // 
            // Label6
            // 
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.Name = "Label6";
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // ObjectExplorerDockItems
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.selinfo);
            this.Controls.Add(this.itemsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ObjectExplorerDockItems";
            this.Load += new System.EventHandler(this.ObjectExplorerDockItems_Load);
            this.selinfo.ResumeLayout(false);
            this.selinfo.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal ListBox itemsList;
        internal GroupBox selinfo;
        internal Label infoName;
        internal Label Label1;
        internal Label infoIden;
        internal Label Label3;
        internal GroupBox GroupBox1;
        internal Button deleteBtn;
        internal Label Label6;
        internal Label Label5;
        internal TextBox addIden;
        internal TextBox addName;
        internal Button addBtn;
    }
}