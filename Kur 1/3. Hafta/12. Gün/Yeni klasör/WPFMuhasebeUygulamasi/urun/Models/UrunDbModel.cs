using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi.urun.Models
{
    public class UrunDbModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int BirimFiyati { get; set; }
        public int DepoAdet { get; set; }
    }
}
