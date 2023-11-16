using DTPRN;
using DTPRN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox4.Text == String.Empty || textBox5.Text == String.Empty)
            {
                MessageBox.Show("Không được để thông tin trống!");
            }
            else
            {
                using (var context= new DTShopContext())
                {
                    Account ac = context.Accounts.FirstOrDefault(x=>x.Username== textBox1.Text );
                    if(ac== null)
                    {
                        MessageBox.Show("Tài khoản đã được đăng kí!");
                    }
                    else
                    {
                        Account ac1 = new Account();
                        ac1.Username = textBox1.Text;
                        ac1.Password = textBox2.Text;
                        ac1.Role = 2;
                        context.Accounts.Add(ac1);
                        context.SaveChanges();
                        Khachhang kh = new Khachhang();
                        kh.Name = textBox3.Text;
                        kh.Diachi = textBox4.Text;
                        kh.Sdt= textBox5.Text;
                        kh.Id = ac1.Id;
                        context.Khachhangs.Add(kh);
                        context.SaveChanges();
                        MessageBox.Show("Bạn đã tạo tài khoản thành công!");
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                }
            }
        
                    }
    }
}
