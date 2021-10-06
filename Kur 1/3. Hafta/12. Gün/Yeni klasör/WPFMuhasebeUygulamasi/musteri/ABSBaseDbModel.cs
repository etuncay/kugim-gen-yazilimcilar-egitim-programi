using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi.musteri
{
    public abstract class ABSBaseDbModel
    {
        public  void DosyaKontrolEt(string dosyaYolu)
        {
            if (!File.Exists(dosyaYolu))
            {
                File.Create(dosyaYolu);
            }
        }
    }
}
