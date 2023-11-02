using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Form currentChildForm = null;

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelmain.Controls.Add(childForm);
            panelmain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bài1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bai1());
        }

        private void bài2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bai2());
        }

        private void bài3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bai3());
        }

        private void bài4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bai4());
        }

    }
}
