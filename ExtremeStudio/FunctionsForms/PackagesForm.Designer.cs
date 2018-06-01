namespace ExtremeStudio.FunctionsForms
{
    partial class PackagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackagesForm));
            this.PackagesList = new System.Windows.Forms.ListBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NPages = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DependsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StarsLabel = new System.Windows.Forms.Label();
            this.LastUpdatedLabel = new System.Windows.Forms.Label();
            this.PackageNameLabel = new System.Windows.Forms.Label();
            this.ActionButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PackagesList
            // 
            resources.ApplyResources(this.PackagesList, "PackagesList");
            this.PackagesList.FormattingEnabled = true;
            this.PackagesList.Name = "PackagesList";
            this.PackagesList.SelectedIndexChanged += new System.EventHandler(this.PackagesList_SelectedIndexChanged);
            // 
            // NextButton
            // 
            resources.ApplyResources(this.NextButton, "NextButton");
            this.NextButton.Name = "NextButton";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            resources.ApplyResources(this.PreviousButton, "PreviousButton");
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NPages
            // 
            resources.ApplyResources(this.NPages, "NPages");
            this.NPages.Name = "NPages";
            // 
            // SearchTextBox
            // 
            resources.ApplyResources(this.SearchTextBox, "SearchTextBox");
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DependsTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StarsLabel);
            this.groupBox1.Controls.Add(this.LastUpdatedLabel);
            this.groupBox1.Controls.Add(this.PackageNameLabel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // DependsTextBox
            // 
            resources.ApplyResources(this.DependsTextBox, "DependsTextBox");
            this.DependsTextBox.Name = "DependsTextBox";
            this.DependsTextBox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // StarsLabel
            // 
            resources.ApplyResources(this.StarsLabel, "StarsLabel");
            this.StarsLabel.Name = "StarsLabel";
            // 
            // LastUpdatedLabel
            // 
            resources.ApplyResources(this.LastUpdatedLabel, "LastUpdatedLabel");
            this.LastUpdatedLabel.Name = "LastUpdatedLabel";
            // 
            // PackageNameLabel
            // 
            resources.ApplyResources(this.PackageNameLabel, "PackageNameLabel");
            this.PackageNameLabel.Name = "PackageNameLabel";
            // 
            // ActionButton
            // 
            resources.ApplyResources(this.ActionButton, "ActionButton");
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.UseVisualStyleBackColor = true;
            this.ActionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PackagesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ActionButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.NPages);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PackagesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PackagesForm";
            this.Load += new System.EventHandler(this.PackagesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PackagesList;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Label NPages;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PackageNameLabel;
        private System.Windows.Forms.Label StarsLabel;
        private System.Windows.Forms.Label LastUpdatedLabel;
        private System.Windows.Forms.TextBox DependsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ActionButton;
    }
}