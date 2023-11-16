using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiets = new HashSet<Chitiet>();
        }

        public int Id { get; set; }
        public int Nguoimua { get; set; }
        public int? Tongtien { get; set; }
        public DateTime? Ngaymua { get; set; }

        public virtual Khachhang NguoimuaNavigation { get; set; } = null!;
        public virtual ICollection<Chitiet> Chitiets { get; set; }
    }
}
