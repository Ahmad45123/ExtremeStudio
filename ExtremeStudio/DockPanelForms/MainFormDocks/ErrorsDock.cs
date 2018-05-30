using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ExtremeStudio.DockPanelForms.MainFormDocks
{
    public partial class ErrorsDock : DockContent
    {
        public class ScriptErrorInfo
        {

            public enum ErrorTypes
            {
                Error,
                Warning
            }

            public string FileName { get; set; }
            public string LineNumber { get; set; }
            public ErrorTypes ErrorType { get; set; }
            public string ErrorMessage { get; set; }
        }

        public ErrorsDock()
        {
            InitializeComponent();
        }

        public List<ScriptErrorInfo> ErrorWarningList = new List<ScriptErrorInfo>();

        public void RefreshErrorWarnings()
        {
            errorsWarnsGrid.Rows.Clear();

            foreach (ScriptErrorInfo err in ErrorWarningList)
            {
                if (err.ErrorType == ScriptErrorInfo.ErrorTypes.Error & showErrorsCheck.Checked == false)
                {
                    continue;
                }

                if (err.ErrorType == ScriptErrorInfo.ErrorTypes.Warning
                    & showWarnsCheck.Checked == false)
                {
                    continue;
                }

                errorsWarnsGrid.Rows.Add((err.ErrorType == ScriptErrorInfo.ErrorTypes.Error
                    ? Properties.Resources.ribbon_errors
                    : Properties.Resources.warning_icon), err.FileName, err.LineNumber, err.ErrorMessage);
            }
        }

        private void showWarnsCheck_CheckedChanged(object sender, EventArgs e)
        {
            RefreshErrorWarnings();
        }

        private void errorsWarnsGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            Program.MainForm.CurrentScintilla?.Lines[(int)(errorsWarnsGrid.Rows[e.RowIndex].Cells[2].Value) - 1].Goto();
            Program.MainForm.CurrentScintilla?.Select();
        }
    }
}