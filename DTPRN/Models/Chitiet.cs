using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class Chitiet
    {
        public int Id { get; set; }
        public int Hoadon { get; set; }
        public int? SanPham { get; set; }
        public int? Soluong { get; set; }
        public int? Gianhap { get; set; }
        public int? Giaban { get; set; }

        public virtual Hoadon HoadonNavigation { get; set; } = null!;
        public virtual SanPham? SanPhamNavigation { get; set; }
    }
}
