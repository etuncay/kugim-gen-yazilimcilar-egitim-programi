using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek
{
    public class OgrenciModel : UniversiteModel
    {
        public int OgrenciId { get; set; }
        public string OgrenciNo { get; set; }
        public List<string> Ders { get; set; }
        public bool Durum { get; set; }
    }
}
