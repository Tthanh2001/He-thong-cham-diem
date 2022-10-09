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
    public partial class HS : Form
    {
        public HS()
        {
            InitializeComponent();
        }

        private void HS_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context  = new QLContext())
            {
                List<Hocsinh> list= context.Hocsinhs.ToList();
                foreach (Hocsinh h in list)
                {
                    dataGridView1.Rows.Add(h.Id, h.Mssv, h.Fullname);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new QLContext())
            {
                List<Hocsinh> list = context.Hocsinhs.ToList();
                Hocsinh h = new Hocsinh();
                h.Mssv = "SV" + (list.Count + 1);
                h.Fullname = textBox3.Text;
                context.Hocsinhs.Add(h);
                context.SaveChanges();
                MessageBox.Show("Add Sinh vien success");
                HS_Load(sender, e);
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

                    Hocsinh h = context.Hocsinhs.Where(x => x.Id == id).SingleOrDefault();
                    if(h != null)
                    {
                        h.Fullname = textBox3.Text;
                        context.Hocsinhs.Update(h);
                        context.SaveChanges();
                        MessageBox.Show("Update sinh vien success");
                        HS_Load(sender, e);

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
