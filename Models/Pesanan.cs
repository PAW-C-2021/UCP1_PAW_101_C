using System;
using System.Collections.Generic;

#nullable disable

namespace Pemesanan_Makanan.Models
{
    public partial class Pesanan
    {
        public int IdPesanan { get; set; }
        public string NamaMakanan { get; set; }
        public string Harga { get; set; }
        public string Keterangan { get; set; }
        public string Total { get; set; }
        public int? IdCustumer { get; set; }
        public int? IdAdmin { get; set; }
        public DateTime Tanggal { get; set; }
        public int? IdMakanan { get; set; }

        public virtual Pemilik IdAdminNavigation { get; set; }
        public virtual Pembeli IdCustumerNavigation { get; set; }
        public virtual Food IdMakananNavigation { get; set; }
    }
}
