using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeStudio.DockPanelForms.MainFormDocks
{
    partial class ErrorsDock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorsDock));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.showWarnsCheck = new System.Windows.Forms.CheckBox();
            this.showErrorsCheck = new System.Windows.Forms.CheckBox();
            this.errorsWarnsGrid = new System.Windows.Forms.DataGridView();
            this.typeColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.fileColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errortextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.parserErrors = new System.Windows.Forms.DataGridView();
            this.ErrorMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsWarnsGrid)).BeginInit();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parserErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            // 
            // TabPage1
            // 
            resources.ApplyResources(this.TabPage1, "TabPage1");
            this.TabPage1.Controls.Add(this.showWarnsCheck);
            this.TabPage1.Controls.Add(this.showErrorsCheck);
            this.TabPage1.Controls.Add(this.errorsWarnsGrid);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // showWarnsCheck
            // 
            resources.ApplyResources(this.showWarnsCheck, "showWarnsCheck");
            this.showWarnsCheck.Checked = true;
            this.showWarnsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showWarnsCheck.Name = "showWarnsCheck";
            this.showWarnsCheck.UseVisualStyleBackColor = true;
            this.showWarnsCheck.CheckedChanged += new System.EventHandler(this.showWarnsCheck_CheckedChanged);
            // 
            // showErrorsCheck
            // 
            resources.ApplyResources(this.showErrorsCheck, "showErrorsCheck");
            this.showErrorsCheck.Checked = true;
            this.showErrorsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showErrorsCheck.Name = "showErrorsCheck";
            this.showErrorsCheck.UseVisualStyleBackColor = true;
            // 
            // errorsWarnsGrid
            // 
            resources.ApplyResources(this.errorsWarnsGrid, "errorsWarnsGrid");
            this.errorsWarnsGrid.AllowUserToAddRows = false;
            this.errorsWarnsGrid.AllowUserToDeleteRows = false;
            this.errorsWarnsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.errorsWarnsGrid.BackgroundColor = System.Drawing.Color.White;
            this.errorsWarnsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.errorsWarnsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorsWarnsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeColumn,
            this.fileColumn,
            this.lineColumn,
            this.errortextColumn});
            this.errorsWarnsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.errorsWarnsGrid.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.errorsWarnsGrid.MultiSelect = false;
            this.errorsWarnsGrid.Name = "errorsWarnsGrid";
            this.errorsWarnsGrid.ReadOnly = true;
            this.errorsWarnsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.errorsWarnsGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.errorsWarnsGrid_CellMouseDoubleClick);
            // 
            // typeColumn
            // 
            resources.ApplyResources(this.typeColumn, "typeColumn");
            this.typeColumn.Name = "typeColumn";
            this.typeColumn.ReadOnly = true;
            // 
            // fileColumn
            // 
            resources.ApplyResources(this.fileColumn, "fileColumn");
            this.fileColumn.Name = "fileColumn";
            this.fileColumn.ReadOnly = true;
            // 
            // lineColumn
            // 
            resources.ApplyResources(this.lineColumn, "lineColumn");
            this.lineColumn.Name = "lineColumn";
            this.lineColumn.ReadOnly = true;
            // 
            // errortextColumn
            // 
            resources.ApplyResources(this.errortextColumn, "errortextColumn");
            this.errortextColumn.Name = "errortextColumn";
            this.errortextColumn.ReadOnly = true;
            // 
            // TabPage3
            // 
            resources.ApplyResources(this.TabPage3, "TabPage3");
            this.TabPage3.Controls.Add(this.parserErrors);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // parserErrors
            // 
            resources.ApplyResources(this.parserErrors, "parserErrors");
            this.parserErrors.AllowUserToAddRows = false;
            this.parserErrors.AllowUserToDeleteRows = false;
            this.parserErrors.BackgroundColor = System.Drawing.Color.White;
            this.parserErrors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.parserErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parserErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ErrorMsg,
            this.Column1});
            this.parserErrors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.parserErrors.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.parserErrors.MultiSelect = false;
            this.parserErrors.Name = "parserErrors";
            this.parserErrors.ReadOnly = true;
            this.parserErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ErrorMsg
            // 
            resources.ApplyResources(this.ErrorMsg, "ErrorMsg");
            this.ErrorMsg.Name = "ErrorMsg";
            this.ErrorMsg.ReadOnly = true;
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ErrorsDock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "ErrorsDock";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsWarnsGrid)).EndInit();
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parserErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal TabControl TabControl1;
        internal TabPage TabPage1;
        internal TabPage TabPage3;
        internal DataGridView parserErrors;
        internal DataGridViewTextBoxColumn ErrorMsg;
        internal DataGridViewTextBoxColumn Column1;
        internal DataGridView errorsWarnsGrid;
        internal CheckBox showWarnsCheck;
        internal CheckBox showErrorsCheck;
        private DataGridViewImageColumn typeColumn;
        private DataGridViewTextBoxColumn fileColumn;
        private DataGridViewTextBoxColumn lineColumn;
        private DataGridViewTextBoxColumn errortextColumn;
    }
}