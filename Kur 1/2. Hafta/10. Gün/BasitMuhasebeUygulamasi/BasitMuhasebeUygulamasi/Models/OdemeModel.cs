using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Models
{
    public class OdemeModel
    {
        public int Id { get; set; }
        public int SatisId { get; set; }
        public int OdemeTutari { get; set; }
        public DateTime Tarih { get; set; }
    }
}
