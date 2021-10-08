using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi.satis.Models
{
    public class SatisDataGridModel: SatisDbModel
    {
        public string MusteriAdiSoyadi { get; set; }
        public string UrunAdi { get; set; }
        public int BirimFiyati { get; set; }
        public int ToplamFiyat { get; set; }
    }
}
