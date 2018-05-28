using System;
using System.Windows.Forms;
using Resources;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock
{
    public partial class ObjectExplorerDockItems : Form
    {
        public ObjectExplorerDockItems()
        {
            InitializeComponent();
        }

        private void Ref()
        {
            itemsList.Items.Clear();

            foreach (var itm in Program.MainForm.CurrentProject.ObjectExplorerItems)
            {
                itemsList.Items.Add(itm.Name);
            }
        }

        private dynamic GetId(string nme)
        {
            for (int i = 0; i <= Program.MainForm.CurrentProject.ObjectExplorerItems.Count - 1; i++)
            {
                if (Program.MainForm.CurrentProject.ObjectExplorerItems[i].Name == nme)
                {
                    return i;
                }
            }

            return -1;
        }

        private void ObjectExplorerDockItems_Load(object sender, EventArgs e)
        {
            Ref();
        }

        private void itemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsList.SelectedIndex == -1)
            {
                return;
            }

            infoName.Text = (string)itemsList.SelectedItem;
            infoIden.Text = Program.MainForm.CurrentProject
                .ObjectExplorerItems[GetId(Convert.ToString(itemsList.SelectedItem))].Identifier;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(translations.ObjectExplorerDockItems_deleteBtn_Click_YouWantDelete, "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                Program.MainForm.CurrentProject.ObjectExplorerItems.RemoveAt(GetId(Convert.ToString(infoName.Text)));
                Ref();
            }
            catch (Exception)
            {
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (addName.Text == "" || addIden.Text == "")
            {
                MessageBox.Show(
                    Convert.ToString(translations.ObjectExplorerDockItems_addBtn_Click_PleaseEnterDetials));
            }
            else
            {
                Program.MainForm.CurrentProject.ObjectExplorerItems.Add(
                    new ObjectExplorerItem(Convert.ToString(addName.Text),
                        Convert.ToString(addIden.Text)));
                Ref();
            }
        }
    }

    public class ObjectExplorerItem
    {
        public ObjectExplorerItem(string name, string iden)
        {
            Name = name;
            Identifier = iden;
        }

        public string Name { get; set; }
        public string Identifier { get; set; }
    }
}