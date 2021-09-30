using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek.Islem
{
    public abstract class AbstBirimIslem
    {
        protected List<string> Birimler = new List<string>() {
            "Rektörlük", "Mühendislik","Fen Edebiyat"
        };

        public abstract bool BirimKontrol(string birimAdi);

        public string BirimGetir(int id)
        {
            var birim = Birimler.ToArray()[id];

            return birim;
        }
        
    }
}
