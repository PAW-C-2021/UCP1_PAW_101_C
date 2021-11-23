using System;
using System.Collections.Generic;

#nullable disable

namespace Pemesanan_Makanan.Models
{
    public partial class Pemilik
    {
        public Pemilik()
        {
            Pesanans = new HashSet<Pesanan>();
        }

        public int IdAdmin { get; set; }
        public string Password { get; set; }
        public string NoTelpon { get; set; }
        public string Email { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Pesanan> Pesanans { get; set; }
    }
}
