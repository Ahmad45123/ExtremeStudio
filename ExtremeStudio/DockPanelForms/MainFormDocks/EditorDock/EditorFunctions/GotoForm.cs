using System;
using System.Windows.Forms;
using Resources;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.EditorFunctions
{
    public partial class GotoForm : Form
    {
        public GotoForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void linenumberRadio_CheckedChanged(object sender, EventArgs e)
        {
            theLabel.Text = translations.GotoForm_linenumberRadio_CheckedChanged_LineNumberLabel;
            maxLabel.Text = translations.GotoForm_linenumberRadio_CheckedChanged_MaximumLabel +
                            Program.MainForm.CurrentScintilla?.Lines.Count;
            curLabel.Text = translations.GotoForm_linenumberRadio_CheckedChanged_CurrentLabel +
                            (Program.MainForm.CurrentScintilla?.CurrentLine + 1);
            valueTextBox.Select();
        }

        private void positionRadio_CheckedChanged(object sender, EventArgs e)
        {
            theLabel.Text = translations.GotoForm_positionRadio_CheckedChanged_PositionLabel;
            maxLabel.Text = translations.GotoForm_linenumberRadio_CheckedChanged_MaximumLabel + Program.MainForm
                                .CurrentScintilla?.Lines[Program.MainForm.CurrentScintilla.Lines.Count - 1].EndPosition;
            curLabel.Text = translations.GotoForm_linenumberRadio_CheckedChanged_CurrentLabel +
                            (Program.MainForm.CurrentScintilla?.CurrentPosition + 1);
            valueTextBox.Select();
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            if (valueTextBox.Text == "" || int.TryParse(valueTextBox.Text, out int n) == false)
            {
                return;
            }

            if (linenumberRadio.Checked)
            {
                if (Convert.ToInt32(valueTextBox.Text) > 0 &&
                    Convert.ToInt32(valueTextBox.Text) <= Program.MainForm.CurrentScintilla.Lines.Count)
                {
                    Program.MainForm.CurrentScintilla.Lines[Convert.ToInt32(valueTextBox.Text) - 1].Goto();
                    Visible = false;

                }
                else
                {
                    MessageBox.Show(Convert.ToString(translations.GotoForm_GoBtn_Click_CheckYourValues));
                }

            }
            else if (positionRadio.Checked)
            {
                if (Convert.ToInt32(valueTextBox.Text) > 0 && Convert.ToInt32(valueTextBox.Text) <=
                    Program.MainForm.CurrentScintilla.Lines[Program.MainForm.CurrentScintilla.Lines.Count - 1].EndPosition)
                {
                    Program.MainForm.CurrentScintilla.GotoPosition(Convert.ToInt32(valueTextBox.Text) - 1);
                    Visible = false;

                }
                else
                {
                    MessageBox.Show(Convert.ToString(translations.GotoForm_GoBtn_Click_CheckYourValues));
                }

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Visible = false;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GotoForm_Load(object sender, EventArgs e)
        {
            linenumberRadio_CheckedChanged(this, null);
        }

        private void GotoForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1.00;
        }

        private void GotoForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.50;
        }

        private void GotoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }
    }
}