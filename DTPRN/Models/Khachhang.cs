using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Diachi { get; set; }
        public string? Sdt { get; set; }

        public virtual Account IdNavigation { get; set; } = null!;
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
