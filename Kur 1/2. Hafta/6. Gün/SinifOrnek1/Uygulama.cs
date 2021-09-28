using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinifOrnek1
{
    class Uygulama
    {
        public void Menu()
        {
            Console.WriteLine("1 - Toplama");
            Console.WriteLine("2 - Çıkarma");
            Console.WriteLine("3 - Çarpma");
            Console.WriteLine("4 - Bölme");
            Console.WriteLine("5 - Son Yapılan İşlemler");
            Console.WriteLine("6 - Çıkış");
        }

        public void Bekleme()
        {
            Console.WriteLine("Menüye geçmek için herhangi bir tuşa basınız");
            Console.ReadLine();
        }

        public void MenuRakamKontrolEt()
        {
            Console.Clear();
            Console.WriteLine("Lütfen 1 ile 6 arası bir seçim yapınız. Menüye geçmek için herhangi bir tuşa basınız.");
            Console.ReadLine();
            Console.Clear();
        }

        public void EkraniTemizle()
        {
            Console.Clear();
        }
    }
}
