using System;
using System.Windows.Forms;

namespace ExtremeCore.Controls_And_Tools
{
    public partial class AdvancedInputBox : Form
    {
        public enum ReturnValue
        {
            InputResultOk,
            InputResultCancel
        }

        public ReturnValue ResResult;
        public string ResText;

        public AdvancedInputBox(string title, string message, string cancelButton = "&Cancel", string okButton = "&Ok", string defaultText = "")
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            Text = title;
            label1.Text = message;
            button1.Text = cancelButton;
            button2.Text = okButton;
            textBox1.Text = defaultText;
            ShowDialog();
            ResText = textBox1.Text;
            if (ResText == "")
                ResResult = ReturnValue.InputResultCancel;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ResResult = ReturnValue.InputResultOk;
            Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ResResult = ReturnValue.InputResultCancel;
            Close();
        }
    }
}
