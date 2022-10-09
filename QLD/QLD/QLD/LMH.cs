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
    public partial class LMH : Form
    {
        private static int id;
        public LMH(int id1)
        {
            id = id1;
            InitializeComponent();
        }

        private void LMH_Load(object sender, EventArgs e)
        {
            using (var context = new QLContext())
            {
                List<Monhoc> mh= context.Monhocs.ToList();
                comboBox2.DisplayMember = "Subject";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = mh;

                List<Lophoc> loph= context.Lophocs.ToList();
                comboBox1.DisplayMember = "Class";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = loph;

                dataGridView1.Rows.Clear();
                List<Hocsinh> list= context.Hocsinhs.ToList();  
                foreach(Hocsinh item in list)
                {
                    dataGridView1.Rows.Add(false, item.Id, item.Mssv, item.Fullname);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lop = int.Parse(comboBox1.SelectedValue.ToString());
            int mon= int.Parse(comboBox2.SelectedValue.ToString());
            using (var context = new QLContext())
            {
                List<Diem> list = context.Diems.Where(x => x.Class == lop && x.Subject == mon).ToList();

                if (list.Count >= 1)
                {
                    MessageBox.Show("Lop da hoc mon nay khong the tao moi");
                }
                else
                {
                    for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                    {
                        bool check = bool.Parse(dataGridView1.Rows[rows].Cells["Column1"].Value.ToString());
                        if(check== true)
                        {
                            Diem d = new Diem();
                            d.Teacher= id;
                            d.Class= lop;
                            d.Subject= mon;

                            d.Student = int.Parse(dataGridView1.Rows[rows].Cells["Column2"].Value.ToString());
                            context.Diems.Add(d);
                            context.SaveChanges();
                            
                        }
                      
                        

                    }
                    MessageBox.Show("Tao lop hoc moi thanh cong");
                    LMH_Load(sender, e);
                }
            }


          
        }
    }
}
