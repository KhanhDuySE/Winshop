using DTPRN.Models;
using WinApp;

namespace DTPRN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass= textBox2.Text;
            using (var context = new DTShopContext())
            {
                Account ac = context.Accounts.FirstOrDefault(x => x.Username == user && x.Password == pass);
                if (ac == null)
                {
                    MessageBox.Show("Dang nhap that bai");
                }
                else
                {
                    if (ac.Role == 2)
                    {
                        FormKH form = new FormKH(ac.Id);
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        FormNV form = new FormNV(ac.Id);
                        form.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}