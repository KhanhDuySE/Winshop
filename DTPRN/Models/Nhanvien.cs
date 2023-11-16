using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class Nhanvien
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }

        public virtual Account IdNavigation { get; set; } = null!;
    }
}
