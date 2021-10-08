using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi.odeme.Models
{
    public class OdemeDataGridModel: OdemeDbModel
    {
        public string MusteriAdiSoyadi { get; set; }
        public string UrunAdi { get; set; }
        public string OdemeDurum { get; set; }
    }
}
