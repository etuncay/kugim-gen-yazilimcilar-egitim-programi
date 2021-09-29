using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek
{
    public class PersonelModel : UniversiteModel
    {
        
        public int PersonelId { get; set; }
        public string Unvan { get; set; }
        public string PersonelTipi { get; set; }
        public string SicilNo { get; set; }
        public bool Durum { get; set; }
    }
}
