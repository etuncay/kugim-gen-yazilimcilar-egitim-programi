using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinifOrnek1
{
    class HesapMakinesi
    {
        public int EkrandanSayiAl()
        {
            Console.Write("Sayi giriniz = ");
            var sayiString = Console.ReadLine();
            return int.Parse(sayiString);
        }

        public void SonucuEkranaBas(string YapilanIslem, int Sonuc)
        {
            Console.WriteLine("Yapılan işlem = " + YapilanIslem);
            Console.WriteLine("İşlem Sonucu = "+ Sonuc);
        }
    }
}
