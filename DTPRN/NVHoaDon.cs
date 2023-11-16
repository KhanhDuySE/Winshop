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
    public partial class NVHoaDon : Form
    {
        public NVHoaDon()
        {
            InitializeComponent();
        }

        private void NVHoaDon_Load(object sender, EventArgs e)
        {
            using (var context = new DTShopContext())
            {
                List<Hoadon> hd = context.Hoadons.OrderByDescending(x=>x.Ngaymua).ToList();
                dataGridView1.Rows.Clear();
                int? tongtien = 0;
                foreach(Hoadon item in hd)
                {
                    var kh = context.Khachhangs.FirstOrDefault(x => x.Id == item.Nguoimua);
                    dataGridView1.Rows.Add(item.Id, kh.Name, item.Ngaymua.Value.ToString("dd-MM-yyyy"), item.Tongtien);
                    tongtien+= item.Tongtien;
                }
                label5.Text = "Tong tien : " + tongtien;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new DTShopContext())
            {
                List<Hoadon> hd = context.Hoadons.Where(x => x.Ngaymua >= dateTimePicker1.Value && x.Ngaymua <= dateTimePicker2.Value).OrderByDescending(x => x.Ngaymua).ToList();
                dataGridView1.Rows.Clear();
                int? tongtien = 0;
                foreach (Hoadon item in hd)
                {
                    var kh = context.Khachhangs.FirstOrDefault(x => x.Id == item.Nguoimua);
                    dataGridView1.Rows.Add(item.Id, kh.Name, item.Ngaymua.Value.ToString("dd-MM-yyyy"), item.Tongtien);
                    tongtien += item.Tongtien;
                }
                label5.Text = "Tong tien : " + tongtien;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id =int.Parse( dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                using (var context = new DTShopContext())
                {
                    List<Chitiet> ct = context.Chitiets.Where(x => x.Hoadon == id).ToList();
                    dataGridView2.Rows.Clear();
                    foreach(Chitiet item in ct)
                    {
                        var sp = context.SanPhams.FirstOrDefault(x => x.Id == item.SanPham);
                        dataGridView2.Rows.Add(item.Id, sp.TenSp, item.Soluong, item.Giaban, item.Gianhap,(item.Giaban - item.Gianhap) * item.Soluong);
                    }
                }
            }
        }
    }
}
