using System;
using System.Collections.Generic;

#nullable disable

namespace Pemesanan_Makanan.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Pesanans = new HashSet<Pesanan>();
        }

        public int IdCustumer { get; set; }
        public string Telpon { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public string PasswordCustumer { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Pesanan> Pesanans { get; set; }
    }
}
