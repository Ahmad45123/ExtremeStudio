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
            this.PackagesList = new System.Windows.Forms.ListBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NPages = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PackageNameLabel = new System.Windows.Forms.Label();
            this.LastUpdatedLabel = new System.Windows.Forms.Label();
            this.StarsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DependsTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PackagesList
            // 
            this.PackagesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackagesList.FormattingEnabled = true;
            this.PackagesList.HorizontalScrollbar = true;
            this.PackagesList.ItemHeight = 16;
            this.PackagesList.Location = new System.Drawing.Point(12, 28);
            this.PackagesList.Name = "PackagesList";
            this.PackagesList.Size = new System.Drawing.Size(247, 372);
            this.PackagesList.TabIndex = 0;
            this.PackagesList.SelectedIndexChanged += new System.EventHandler(this.PackagesList_SelectedIndexChanged);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(184, 402);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = ">>";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(12, 402);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 2;
            this.PreviousButton.Text = "<<";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NPages
            // 
            this.NPages.AutoSize = true;
            this.NPages.Location = new System.Drawing.Point(118, 407);
            this.NPages.Name = "NPages";
            this.NPages.Size = new System.Drawing.Size(24, 13);
            this.NPages.TabIndex = 3;
            this.NPages.Text = "0/0";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(12, 2);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(247, 20);
            this.SearchTextBox.TabIndex = 4;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DependsTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StarsLabel);
            this.groupBox1.Controls.Add(this.LastUpdatedLabel);
            this.groupBox1.Controls.Add(this.PackageNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(265, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 210);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // PackageNameLabel
            // 
            this.PackageNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackageNameLabel.Location = new System.Drawing.Point(6, 21);
            this.PackageNameLabel.Name = "PackageNameLabel";
            this.PackageNameLabel.Size = new System.Drawing.Size(260, 23);
            this.PackageNameLabel.TabIndex = 0;
            this.PackageNameLabel.Text = "Name / Package";
            this.PackageNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LastUpdatedLabel
            // 
            this.LastUpdatedLabel.AutoSize = true;
            this.LastUpdatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LastUpdatedLabel.Location = new System.Drawing.Point(7, 51);
            this.LastUpdatedLabel.Name = "LastUpdatedLabel";
            this.LastUpdatedLabel.Size = new System.Drawing.Size(99, 17);
            this.LastUpdatedLabel.TabIndex = 1;
            this.LastUpdatedLabel.Text = "Last updated: ";
            // 
            // StarsLabel
            // 
            this.StarsLabel.AutoSize = true;
            this.StarsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.StarsLabel.Location = new System.Drawing.Point(7, 78);
            this.StarsLabel.Name = "StarsLabel";
            this.StarsLabel.Size = new System.Drawing.Size(57, 17);
            this.StarsLabel.TabIndex = 2;
            this.StarsLabel.Text = "Stars: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(7, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dependencies: ";
            // 
            // DependsTextBox
            // 
            this.DependsTextBox.Location = new System.Drawing.Point(19, 125);
            this.DependsTextBox.Multiline = true;
            this.DependsTextBox.Name = "DependsTextBox";
            this.DependsTextBox.ReadOnly = true;
            this.DependsTextBox.Size = new System.Drawing.Size(247, 77);
            this.DependsTextBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(281, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Install Package";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PackagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 432);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.NPages);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PackagesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PackagesForm";
            this.Text = "Packages";
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
        private System.Windows.Forms.Button button1;
    }
}