using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }
        public string? TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
