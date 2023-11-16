using System;
using System.Collections.Generic;

namespace DTPRN.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }

        public virtual Khachhang? Khachhang { get; set; }
        public virtual Nhanvien? Nhanvien { get; set; }
    }
}
