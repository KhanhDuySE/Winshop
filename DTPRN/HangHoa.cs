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

namespace DTPRN
{
    public partial class HangHoa : Form
    {
        public HangHoa()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            using (var context = new DTShopContext())
            {
                List<SanPham> sp = context.SanPhams.ToList();
                dataGridView1.Rows.Clear();
                foreach (SanPham item in sp)
                {
                    var loaisp = context.LoaiSps.FirstOrDefault(x => x.Id == item.LoaiSp);
                    dataGridView1.Rows.Add(item.Id, item.TenSp, item.Giatien, item.Gianhap, item.Soluong, loaisp.TenLoai);
                }
                List<LoaiSp> loai = context.LoaiSps.ToList();
                comboBox1.DisplayMember = "TenLoai";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = loai;
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            numericUpDown1.Value = 0;

        }
        private void HangHoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString());
            comboBox1.SelectedIndex = comboBox1.FindStringExact(dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new DTShopContext())
            {
                try
                {
                    SanPham sp = context.SanPhams.FirstOrDefault(x => x.Id == int.Parse(textBox1.Text));
                    if(sp != null)
                    {
                        sp.TenSp = textBox2.Text;
                        sp.Giatien = int.Parse(textBox3.Text);
                        sp.Gianhap = int.Parse(textBox4.Text);
                        sp.Soluong =(int) numericUpDown1.Value;
                        sp.LoaiSp = int.Parse(comboBox1.SelectedValue.ToString());
                        context.SanPhams.Update(sp);
                        context.SaveChanges();
                        MessageBox.Show("Cap nhat thanh cong san pham");
                        LoadData();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new DTShopContext())
            {
                try
                {
                    SanPham sp = new SanPham();
                    if (sp != null)
                    {
                        sp.TenSp = textBox2.Text;
                        sp.Giatien = int.Parse(textBox3.Text);
                        sp.Gianhap = int.Parse(textBox4.Text);
                        sp.Soluong = (int)numericUpDown1.Value;
                        sp.LoaiSp = int.Parse(comboBox1.SelectedValue.ToString());
                        context.SanPhams.Add(sp);
                        context.SaveChanges();
                        MessageBox.Show("Tao moi thanh cong san pham");
                        LoadData();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {

                }
            }
        }
    }
}
