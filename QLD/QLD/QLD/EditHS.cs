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
    public partial class EditHS : Form
    {
        private int id;
        public EditHS(int id1)
        {
            id = id1;
            InitializeComponent();
        }

        private void EditHS_Load(object sender, EventArgs e)
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
            dataGridView2.Rows.Clear(); 
            int lop = int.Parse(comboBox1.SelectedValue.ToString());
            int mon = int.Parse(comboBox2.SelectedValue.ToString());
            using (var context = new QLContext())
            {
                List<Diem> list = context.Diems.Where(x => x.Teacher == id && x.Class == lop && x.Subject == mon).ToList();
                foreach (Diem item in list.OrderBy(x=>x.Student))
                {
                    Hocsinh h = context.Hocsinhs.Where(x => x.Id == item.Student).Single();
                    dataGridView1.Rows.Add(item.Id, h.Mssv, h.Fullname, "Xoa");
                }
                List<Hocsinh> list1 = context.Hocsinhs.ToList();
                foreach (Hocsinh item in list1)
                {
                    bool check= false;
                    var kq = list.Find(x => x.Student == item.Id);
                    if(kq!= null)
                    {
                        check = true;
                    }
                    if(check== false)
                    {
                        dataGridView2.Rows.Add(false,item.Id, item.Mssv, item.Fullname);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int lop = int.Parse(comboBox1.SelectedValue.ToString());
            int mon = int.Parse(comboBox2.SelectedValue.ToString());
            using (var context = new QLContext())
            {
                    for (int rows = 0; rows < dataGridView2.Rows.Count; rows++)
                    {
                        bool check = bool.Parse(dataGridView2.Rows[rows].Cells["Column7"].Value.ToString());
                        if (check == true)
                        {
                            Diem d = new Diem();
                            d.Teacher = id;
                            d.Class = lop;
                            d.Subject = mon;
                            d.Student = int.Parse(dataGridView2.Rows[rows].Cells["Column4"].Value.ToString());
                            context.Diems.Add(d);
                            context.SaveChanges();

                        }

                    }
                    MessageBox.Show("Update sinh vien thanhh cong");
                  
                
            }
            button1_Click(sender, e);
        }
    }
}
