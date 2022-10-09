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
    public partial class ND : Form
    {
        private int id;
        public ND(int id1)
        {
            id= id1;
            InitializeComponent();
        }

        private void ND_Load(object sender, EventArgs e)
        {
            using (var context = new QLContext())
            {
                List<Monhoc> mh = context.Monhocs.ToList();
                comboBox2.DisplayMember = "Subject";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = mh;

                List<Lophoc> loph = context.Lophocs.ToList();
                comboBox1.DisplayMember = "Class";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = loph;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            int lop = int.Parse(comboBox1.SelectedValue.ToString());
            int mon = int.Parse(comboBox2.SelectedValue.ToString());
            using (var context = new QLContext())
            {
                List<Diem> list = context.Diems.Where(x => x.Teacher == id && x.Class == lop && x.Subject == mon).ToList();
                foreach (Diem item in list.OrderBy(x => x.Student))
                {
                    Hocsinh h = context.Hocsinhs.Where(x => x.Id == item.Student).Single();
                    dataGridView1.Rows.Add(item.Id, h.Mssv, h.Fullname, item.Q1,item.Q2,item.Q3);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int lop = int.Parse(comboBox1.SelectedValue.ToString());
            int mon = int.Parse(comboBox2.SelectedValue.ToString());
            using (var context = new QLContext())
            {
                for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                {

                    Diem d = context.Diems.Where(x => x.Id == int.Parse(dataGridView1.Rows[rows].Cells["Column1"].Value.ToString())).SingleOrDefault();

                  
                        int q1;
                        try
                        {
                            q1 = int.Parse(dataGridView1.Rows[rows].Cells["Column4"].Value?.ToString());
                            d.Q1=q1;
                        }
                        catch {
                            d.Q1 = null;
                        }
                    
                   
                        int q2;
                        try
                        {
                            q2 = int.Parse(dataGridView1.Rows[rows].Cells["Column5"].Value?.ToString());
                            d.Q2 = q2;
                        }
                        catch {
                            d.Q2 = null;
                        }
                    
               
                   
                        int q3;
                        try
                        {
                            q3 = int.Parse(dataGridView1.Rows[rows].Cells["Column6"].Value?.ToString());
                            d.Q3 = q3;
                        }
                        catch { d.Q3 = null; }
                    



                    context.Diems.Update(d);
                    context.SaveChanges();

                    

                }
                MessageBox.Show("Update diem success");
                button1_Click(sender, e);

            }
        }
    }
}
