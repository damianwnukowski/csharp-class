using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damian_Wnukowski_zadanie1
{
    public partial class MenuForm : Form
    {
        Form currentForm = null;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void setCurrentForm(Form objForm)
        {
            if (currentForm != null)
            {
                this.Controls.Remove(currentForm);
            }

            objForm.TopLevel = false;
            this.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
            this.currentForm = objForm;
        }

        private void zadanie1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form1());
        }

        private void zadanie2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form2());
        }

        private void zadanie3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form3());
        }

        private void zadanie4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form4());
        }

        private void zadanie5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form5());
        }

        private void zadanie67ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form6());
        }

        private void zadanie7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form7());
        }

        private void zadanie8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentForm(new Form8());
        }
    }
}
