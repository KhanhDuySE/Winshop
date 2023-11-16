using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTPRN
{
    public partial class FormNV : Form
    {
        public int id;
        public FormNV(int id1)
        {
            id=id1;
            InitializeComponent();
        }
        private Form FormChild;
        private void OpenForm(Form child)
        {
            if (FormChild != null)
            {
                FormChild.Close();
            }
            FormChild = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel1.Controls.Add(child);
            panel1.Tag = child;
            child.BringToFront();
            child.Show();
        }
        private void FormNV_Load(object sender, EventArgs e)
        {
            OpenForm(new HangHoa());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new NVHoaDon());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm(new HangHoa());
        }
    }
}
