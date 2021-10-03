using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Models
{
    public class SatisModel
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime? IptalTarihi { get; set; }
    }
}
