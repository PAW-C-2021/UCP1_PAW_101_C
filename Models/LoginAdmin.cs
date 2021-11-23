using System;
using System.Collections.Generic;

#nullable disable

namespace Pemesanan_Makanan.Models
{
    public partial class LoginAdmin
    {
        public int IdLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
