using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Models
{
    public class UrunModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int BirimFiyati { get; set; }
        public int Adet { get; set; }
    }
}
