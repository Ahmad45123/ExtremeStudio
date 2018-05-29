using System.Windows.Forms;

namespace ExtremeStudio.FunctionsForms
{
    partial class ESPluginsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ESPluginsForm));
            this.Label1 = new System.Windows.Forms.Label();
            this.PluginList = new System.Windows.Forms.ListBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PluginDescText = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.PluginNameText = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.installBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateLabel = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // PluginList
            // 
            resources.ApplyResources(this.PluginList, "PluginList");
            this.PluginList.FormattingEnabled = true;
            this.PluginList.Name = "PluginList";
            this.PluginList.Click += new System.EventHandler(this.PluginList_Click);
            // 
            // GroupBox1
            // 
            resources.ApplyResources(this.GroupBox1, "GroupBox1");
            this.GroupBox1.Controls.Add(this.PluginDescText);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.PluginNameText);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.TabStop = false;
            // 
            // PluginDescText
            // 
            resources.ApplyResources(this.PluginDescText, "PluginDescText");
            this.PluginDescText.Name = "PluginDescText";
            this.PluginDescText.ReadOnly = true;
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // PluginNameText
            // 
            resources.ApplyResources(this.PluginNameText, "PluginNameText");
            this.PluginNameText.Name = "PluginNameText";
            this.PluginNameText.ReadOnly = true;
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // installBtn
            // 
            resources.ApplyResources(this.installBtn, "installBtn");
            this.installBtn.Name = "installBtn";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // deleteBtn
            // 
            resources.ApplyResources(this.deleteBtn, "deleteBtn");
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateLabel
            // 
            resources.ApplyResources(this.updateLabel, "updateLabel");
            this.updateLabel.Name = "updateLabel";
            // 
            // Label4
            // 
            resources.ApplyResources(this.Label4, "Label4");
            this.Label4.Name = "Label4";
            // 
            // ESPluginsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.PluginList);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ESPluginsForm";
            this.Load += new System.EventHandler(this.EsPluginsForm_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Label Label1;
        internal ListBox PluginList;
        internal GroupBox GroupBox1;
        internal TextBox PluginDescText;
        internal Label Label3;
        internal TextBox PluginNameText;
        internal Label Label2;
        internal Button installBtn;
        internal Button deleteBtn;
        internal Label updateLabel;
        internal Label Label4;
    }
}