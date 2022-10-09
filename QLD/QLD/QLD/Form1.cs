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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new QLContext())
            {
                Account a = context.Accounts.Where(x => x.Username == textBox1.Text && x.Password == textBox2.Text).SingleOrDefault();
                
                if (a == null)
                {
                    MessageBox.Show("Login that bai");
                    textBox1.Focus();   

                }
                else
                {
                   // MessageBox.Show("Login thanh cong");
                    TC form = new TC(a.Id);
                    form.Show();
                    this.Hide();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
