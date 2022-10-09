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
    public partial class MH : Form
    {
        public MH()
        {
            InitializeComponent();
        }

        private void MH_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
             using (var context = new QLContext())
            {
               List<Monhoc> list = context.Monhocs.ToList();
                foreach (Monhoc h in list)
                {
                    dataGridView1.Rows.Add(h.Id, h.Code, h.Subject);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new QLContext())
            {
                List<Monhoc> list = context.Monhocs.ToList();
                Monhoc h = new Monhoc();
                h.Code = "MH" + (list.Count + 1);
                h.Subject = textBox3.Text;
                context.Monhocs.Add(h);
                context.SaveChanges();
                MessageBox.Show("Add mon hoc success");
                MH_Load(sender, e);
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

                    Monhoc h = context.Monhocs.Where(x => x.Id == id).SingleOrDefault();
                    if (h != null)
                    {
                        h.Subject = textBox3.Text;
                        context.Monhocs.Update(h);
                        context.SaveChanges();
                        MessageBox.Show("Update mon hoc success");
                        MH_Load(sender, e);

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
