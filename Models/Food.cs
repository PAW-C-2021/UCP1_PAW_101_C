using System;
using System.Collections.Generic;

#nullable disable

namespace Pemesanan_Makanan.Models
{
    public partial class Food
    {
        public Food()
        {
            Pesanans = new HashSet<Pesanan>();
        }

        public int IdMakanan { get; set; }
        public string NamaMakanan { get; set; }
        public string Harga { get; set; }
        public string Keterangan { get; set; }

        public virtual ICollection<Pesanan> Pesanans { get; set; }
    }
}
