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
    public partial class XoaHS : Form
    {
        private int id;
        public XoaHS(int id1)
        {
            id = id1;
            InitializeComponent();
        }

        private void XoaHS_Load(object sender, EventArgs e)
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
                foreach(Diem item in list.OrderBy(x=>x.Student))
                {
                    Hocsinh h = context.Hocsinhs.Where(x => x.Id == item.Student).Single();
                    dataGridView1.Rows.Add(item.Id, h.Mssv, h.Fullname, "Xoa");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Column4"].Index)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                using (var context = new QLContext())
                {
                    Diem d = context.Diems.Where(x => x.Id == id).SingleOrDefault();
                    context.Diems.Remove(d);    
                    context.SaveChanges();
                    MessageBox.Show("Xoa sinh vien ra khoi lop success");
                    button1_Click(sender, e);
                }
            }
        }
    }
}
