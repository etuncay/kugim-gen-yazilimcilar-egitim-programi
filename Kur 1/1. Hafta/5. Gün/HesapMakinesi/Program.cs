using System;
using System.Collections.Generic;

namespace HesapMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
            var islemdefteri = new List<string>();
            var cikis = true;
            var islem = "";
            while (cikis)
            {
                Menu();
                Console.WriteLine("İşlem yapmak için rakam giriniz");
                var menuRakamiString = Console.ReadLine();
                try
                {
                    var menuRakamInt = int.Parse(menuRakamiString);
                    switch (menuRakamInt)
                    {
                        case 1:
                            var toplamIslemi = true;
                            var toplam = 0;
                            var sayiSira = 1;
                            var islemSayi = "";
                            while (toplamIslemi)
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen bir sayı giriniz");
                                var sayiString = Console.ReadLine();

                                if (int.TryParse(sayiString , out int sayiInt))
                                {
                                    toplam = toplam + sayiInt;
                                    islemSayi = islemSayi+ " sayi " + sayiSira + " =" + sayiInt+" ,";
                                    sayiSira++;
                                }
                                else
                                {
                                    toplamIslemi = false;
                                }
                            }
                            islem = "Yapılan işlem toplama " + islemSayi +" toplamı = "+ toplam;

                            Console.WriteLine("Toplam = " + toplam);

                            //Console.Write("1. sayıyı giriniz = ");
                            //var sayi1String1 = Console.ReadLine();
                            //Console.Write("2. sayıyı giriniz = ");
                            //var sayi2String1 = Console.ReadLine();

                            //var sayi1Int1 = int.Parse(sayi1String1);
                            //var sayi2Int1 = int.Parse(sayi2String1);

                            //var toplam = sayi1Int1 + sayi2Int1;
                            //Console.WriteLine("2 sayının toplamı =" + toplam);
                            //islem = "Yapılan işlem toplama sayi 1=" + sayi1Int1+", sayi 2 = " + sayi2Int1+ " toplamı = "+ toplam;


                            islemdefteri.Add(islem);
                            Bekleme();
                            Console.Clear();
                            break;
                        case 2:



                            Console.Write("1. sayıyı giriniz = ");
                            var sayi1String2 = Console.ReadLine();
                            Console.Write("2. sayıyı giriniz = ");
                            var sayi2String2 = Console.ReadLine();

                            var sayi1Int2 = int.Parse(sayi1String2);
                            var sayi2Int2 = int.Parse(sayi2String2);
                            var cikan = sayi1Int2 - sayi2Int2;
                            Console.WriteLine("2 sayının çıkmarması =" + cikan);
                            islem = "Yapılan işlem çıkmarma sayi 1=" + sayi1Int2 + ", sayi 2 = " + sayi2Int2 + " cıkan = " + cikan;
                            islemdefteri.Add(islem);

                            Bekleme();
                            Console.Clear();
                            break;
                        case 3:
                            //Console.Write("1. sayıyı giriniz = ");
                            //var sayi1String3 = Console.ReadLine();
                            //Console.Write("2. sayıyı giriniz = ");
                            //var sayi2String3 = Console.ReadLine();

                            //var sayi1Int3 = int.Parse(sayi1String3);
                            //var sayi2Int3 = int.Parse(sayi2String3);
                            //var carpma = sayi1Int3 * sayi2Int3;
                            //Console.WriteLine("2 sayının çarpımı = "+ carpma);
                            //islem = "Yapılan işlem çarpma sayi 1=" + sayi1Int3 + ", sayi 2 = " + sayi2Int3 + " çarpım = " + carpma;

                            var carpmaIslem = true;
                            var carpim = 1;
                            var islemSira = 2;
                            var islemSayi1 = "";
                            while (carpmaIslem)
                            {
                                Console.Write("Lütfen sayı giriniz");
                                var sayiString = Console.ReadLine();
                                try
                                {
                                    var sayiInt = int.Parse(sayiString);
                                    carpim = carpim * sayiInt;
                                    islemSayi1 = islemSayi1 + " sayi " + islemSira + " =" + sayiInt + " ,";
                                }
                                catch (Exception e)
                                {
                                    carpmaIslem = false;
                                }
                            }
                            islem = "Yapılan işlem çarpma " + islemSayi1 + " toplamı = " + carpim;

                            Console.WriteLine("Çarpma = " + carpim);

                            islemdefteri.Add(islem);

                            Bekleme();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Write("1. sayıyı giriniz = ");
                            var sayi1String4 = Console.ReadLine();
                            Console.Write("2. sayıyı giriniz = ");
                            var sayi2String4 = Console.ReadLine();

                            var sayi1Int4 = int.Parse(sayi1String4);
                            var sayi2Int4 = int.Parse(sayi2String4);

                            var bolmesi = sayi1Int4 / sayi2Int4;
                            Console.WriteLine("2 sayının bölümü = " + bolmesi);
                            islem = "Yapılan işlem bölme sayi 1=" + sayi1Int4 + ", sayi 2 = " + sayi2Int4 + " bölüm = " + bolmesi;
                            islemdefteri.Add(islem);
                            Bekleme();
                            Console.Clear();
                            break;
                        case 5:
                            var x = 0;
                            foreach (var kayit in islemdefteri)
                            {
                                x++;
                                Console.WriteLine(x + " : " + kayit);
                            }  

                            Bekleme();
                            Console.Clear();
                            break;
                        case 6: break;
                        default:
                            MenuRakamKontrol();
                            break;
                    }
                }
                catch
                {
                    MenuRakamKontrol();
                }
            }

        }

        public static void Menu()
        {
            Console.WriteLine("1 - Toplama");
            Console.WriteLine("2 - Çıkarma");
            Console.WriteLine("3 - Çarpma");
            Console.WriteLine("4 - Bölme");
            Console.WriteLine("5 - Son Yapılan İşlemler");
            Console.WriteLine("6 - Çıkış");
        }

        public static void Bekleme()
        {
            Console.WriteLine("Menüye geçmek için herhangi bir tuşa basınız");
            Console.ReadLine();
        }

        public static void MenuRakamKontrol()
        {
            Console.Clear();
            Console.WriteLine("Lütfen 1 ile 6 arası bir seçim yapınız. Menüye geçmek için herhangi bir tuşa basınız.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
