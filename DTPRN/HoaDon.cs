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
    public partial class HoaDon : Form
    {
        public int id;
        public HoaDon(int id1)
        {
            id = id1;
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            using (var context = new DTShopContext())
            {
                List<Hoadon> list = context.Hoadons.Where(x => x.Nguoimua == id).OrderByDescending(x => x.Ngaymua).ToList();
                int? tongtien = 0;
                foreach (Hoadon item in list)
                {
                    dataGridView1.Rows.Add(item.Id, item.Tongtien, item.Ngaymua.Value.ToString("dd-MM-yyyy"));
                    tongtien += item.Tongtien;
                }
                label5.Text = "Tổng tiền : " + tongtien;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
            using (var context = new DTShopContext())
            {
                dataGridView2.Rows.Clear();
                List<Chitiet> ct = context.Chitiets.Where(x => x.Hoadon == id).ToList();
                foreach (Chitiet item in ct)
                {
                    var sp = context.SanPhams.FirstOrDefault(x => x.Id == item.SanPham);
                    dataGridView2.Rows.Add(item.Id, sp.TenSp, item.Soluong, item.Giaban * item.Soluong);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new DTShopContext())
            {
                dataGridView1.Rows.Clear();
                int? tongtien = 0;
                List<Hoadon> list = context.Hoadons.Where(x => x.Nguoimua == id && x.Ngaymua >= dateTimePicker1.Value && x.Ngaymua <= dateTimePicker2.Value).OrderByDescending(x => x.Ngaymua).ToList();
                foreach (Hoadon item in list)
                {
                    dataGridView1.Rows.Add(item.Id, item.Tongtien, item.Ngaymua.Value.ToString("dd-MM-yyyy"));
                    tongtien += item.Tongtien;
                }
                label5.Text = "Tổng tiền : " + tongtien;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
