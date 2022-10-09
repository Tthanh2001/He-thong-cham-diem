using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLD
{
    public partial class TC : Form
    {
        private int id;
        public TC(int id1)
        {
            id = id1;
            InitializeComponent();
        }

        private void qLDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new ND(id));
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Ban co chac muon thoat khong","Thoat",MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();

            }
        }
        private Form FormChild;
        private void OpenForm(Form child)
        {
            if (FormChild != null)
            {
                FormChild.Close();
            }
            FormChild = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel1.Controls.Add(child);
            panel1.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void qLHocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new HS());
           
        }

        private void quanLopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new LH());
        }

        private void qLMonHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new MH());
        }

        private void addHocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new LMH(id));
        }

        private void suaHocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new EditHS(id));
        }

        private void xoaHocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new XoaHS(id));
        }
    }
}
