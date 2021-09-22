using System;

namespace StringFonksiyonlari
{
    class Program
    {
        static void Main(string[] args)
        {
            string ad = "Ahmet Ali";
            string ad2 = "";
            string soyad = " Kaya ";

            var kayaBosluk = soyad.Trim();

            string adSoyad1 = ad + " " + soyad;
            string adsoyad2 = string.Concat(ad, " ", soyad);

            int adSoyadUzunluk = adsoyad2.Length;
            var metNerede = adsoyad2.IndexOf("met");
            var metNeredeTers = adsoyad2.LastIndexOf("met");

            var bastaVarmi = adsoyad2.StartsWith("Ahmet");
            var bastaVarmi2 = adsoyad2.StartsWith("Ahmet1");

            var sondaVarmi = adsoyad2.EndsWith("Kaya");

            var adSoyadBuyuk = adsoyad2.ToUpper();
            var adSoyadKucuk = adsoyad2.ToLower();

            var adDegisti = ad.Replace("Ali","Mehmet");

            var adBirkismi = ad.Substring(3,3);

            var adYazilmismi = string.IsNullOrEmpty(ad2);

            if (ad2==null || ad2=="")
            {
                var mesaj = "Adınızı giriniz";
            }

            var kacKelime = ad.Split(' ');

            var isimler = "Ahmet, Ali, Mehmet, Kerim";

            var kacIsimVar = isimler.Split(' ');

            for (int i = 0; i < kacIsimVar.Length; i++)
            {
                kacIsimVar[i] = kacIsimVar[i].Replace(",", "");
            }

            var adDevam = ad.Insert(5, " Mehmet ");

            var temizle = adDevam.Remove(5, 3);

            var sayi1 = 5.3;

            var sayiMutlak = Math.Abs(sayi1);

            var celling = Math.Ceiling(sayi1);
            var celling2 = Math.Ceiling(5.9);

            var floor = Math.Floor(sayi1);
            var floor2 = Math.Floor(5.9);

            var round = Math.Round(sayi1);
            var round2 = Math.Round(5.6);
            var round3 = Math.Round(5.6561,2);

            var sqrtSayi = Math.Sqrt(3);
            var powSayi = Math.Pow(3,2);

            var maxSayi = Math.Max(15, 9);
            var minSayi = Math.Min(15, 9);

            Console.WriteLine("Hello World!");
        }
    }
}
