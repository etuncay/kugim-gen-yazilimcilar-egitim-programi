using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek.Islem
{
    public class BirimIslem
    {
        protected List<string> Birimler = new List<string>() { 
            "Rektörlük", "Mühendislik","Fen Edebiyat"
        };

        public virtual bool BirimKontrol(string birimAdi)
        {
            if(Birimler.FirstOrDefault(q=>q == birimAdi) != null)
            {
                return true;
            }

            return false;
        }

    }
}
