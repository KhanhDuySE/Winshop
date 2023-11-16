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
using System.Windows.Forms.Design.Behavior;

namespace DTPRN
{
    public partial class Muahang : Form
    {
        public int id;
        public Muahang(int id1)
        {
            id = id1;
            InitializeComponent();
        }
        public void LoadData()
        {
            using (var context = new DTShopContext())
            {
                List<SanPham> list = context.SanPhams.Where(x => x.Soluong > 0).ToList();
                dataGridView1.Rows.Clear();
                foreach (SanPham item in list)
                {
                    dataGridView1.Rows.Add(item.Id, item.TenSp, item.Giatien, item.Soluong, context.LoaiSps.FirstOrDefault(x => x.Id == item.LoaiSp).TenLoai);
                }
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            numericUpDown1.Value = 0;
            label3.Text = "0";
            listgh = new List<SanPham>();
            dataGridView2.Rows.Clear();

        }
        private void Muahang_Load(object sender, EventArgs e)
        {
            LoadData();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = textBox4.Text;
            using (var context = new DTShopContext())
            {
                List<SanPham> list = context.SanPhams.Where(x => x.Soluong > 0 && x.TenSp.Contains(text)).ToList();
                dataGridView1.Rows.Clear();
                foreach (SanPham item in list)
                {
                    dataGridView1.Rows.Add(item.Id, item.TenSp, item.Giatien, item.Soluong, context.LoaiSps.FirstOrDefault(x => x.Id == item.LoaiSp).TenLoai);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            numericUpDown1.Maximum = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
            numericUpDown1.Value = 1;

        }
        

        public List<SanPham> listgh = new List<SanPham>();  
        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.Id = int.Parse(textBox1.Text);
            sp.TenSp = textBox2.Text;
            sp.Giatien = int.Parse(textBox3.Text);
            sp.Soluong = int.Parse(numericUpDown1.Value.ToString());
            if (sp.Soluong > 0)
            {
                var check = listgh.FirstOrDefault(x => x.Id == sp.Id);
                if(check != null)
                {
                    check.Soluong = sp.Soluong;
                }
                else
                {
                    listgh.Add(sp);
                }
              
                dataGridView2.Rows.Clear();
                foreach(SanPham item in listgh.OrderBy(x=>x.Id))
                {
                    dataGridView2.Rows.Add(item.Id, item.TenSp, item.Giatien, item.Soluong);
                }
            
            }
            else
            {
                var check = listgh.FirstOrDefault(x => x.Id == sp.Id);
                if(check != null)
                {
                    listgh.Remove(check);

                    dataGridView2.Rows.Clear();
                    foreach (SanPham item in listgh.OrderBy(x => x.Id))
                    {
                        dataGridView2.Rows.Add(item.Id, item.TenSp, item.Giatien, item.Soluong);
                    }

                }
            }
            int sum = 0;
            foreach(SanPham item in listgh)
            {
                sum+=(int)( item.Giatien*item.Soluong);
            }
            label3.Text = sum.ToString() ;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Ban muon thanh toan?", "Thong bao", MessageBoxButtons.OKCancel);
            if(r== DialogResult.OK)
            {
                using (var context =new DTShopContext())
                {
                    decimal discount = numericUpDown2.Value;

                    Hoadon hd = new Hoadon();
                    hd.Ngaymua = DateTime.Now;
                    int totaldis = int.Parse(label3.Text);
                    hd.Tongtien = discount==0? int.Parse(label3.Text): totaldis;
                    hd.Nguoimua = id;
                    context.Hoadons.Add(hd);
                    context.SaveChanges();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        Chitiet ct = new Chitiet();
                        ct.SanPham = int.Parse(row.Cells["Column6"].Value.ToString());
                        ct.Soluong = int.Parse(row.Cells["Column9"].Value.ToString());
                        ct.Hoadon = hd.Id;
                        SanPham sp = context.SanPhams.FirstOrDefault(x => x.Id == ct.SanPham);
                        ct.Giaban = discount == 0 ? sp.Giatien: (sp.Giatien*(100-(int)discount))/100;
                        ct.Gianhap = sp.Gianhap;
                        context.Chitiets.Add(ct);

                        
                        sp.Soluong -= ct.Soluong;
                        context.SanPhams.Update(sp);
                    }
                    context.SaveChanges();
                }
                LoadData();
                MessageBox.Show("Thanh toan thanh cong");
            }
            else
            {

            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != 0)
            {
                int sum = 0;
                foreach (SanPham item in listgh)
                {
                    sum += (int)(item.Giatien * item.Soluong);
                }
                label3.Text = sum.ToString();
                try
                {
                    string s = label3.Text;
                    label3.Text = ((double.Parse(s) * (100 - (int)numericUpDown2.Value))/100).ToString();
                }
                catch { }
            }
            else
            {
                int sum = 0;
                foreach (SanPham item in listgh)
                {
                    sum += (int)(item.Giatien * item.Soluong);
                }
                label3.Text = sum.ToString();
            }
        }
    }
}
