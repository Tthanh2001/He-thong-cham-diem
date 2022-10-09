using QLD.Models;
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
    public partial class LH : Form
    {
        public LH()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LH_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new QLContext())
            {
                List<Lophoc> list = context.Lophocs.ToList();
                foreach (Lophoc h in list)
                {
                    dataGridView1.Rows.Add(h.Id, h.Code, h.Class);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new QLContext())
            {
                List<Lophoc> list = context.Lophocs.ToList();
                Lophoc h = new Lophoc();
                h.Code = "LH" + (list.Count + 1);
                h.Class = textBox3.Text;
                context.Lophocs.Add(h);
                context.SaveChanges();
                MessageBox.Show("Add lop hoc success");
                LH_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = int.Parse(textBox1.Text);
                using (var context = new QLContext())
                {

                    Lophoc h = context.Lophocs.Where(x => x.Id == id).SingleOrDefault();
                    if (h != null)
                    {
                        h.Class = textBox3.Text;
                        context.Lophocs.Update(h);
                        context.SaveChanges();
                        MessageBox.Show("Update lop hoc success");
                        LH_Load(sender, e);
                    }
                }
            }
            catch
            {
                textBox1.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
        }
    }
}
