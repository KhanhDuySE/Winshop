using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            Chitiets = new HashSet<Chitiet>();
        }

        public int Id { get; set; }
        public string? TenSp { get; set; }
        public int? Giatien { get; set; }
        public int? Gianhap { get; set; }
        public int? Soluong { get; set; }
        public int? LoaiSp { get; set; }

        public virtual LoaiSp? LoaiSpNavigation { get; set; }
        public virtual ICollection<Chitiet> Chitiets { get; set; }
    }
}
