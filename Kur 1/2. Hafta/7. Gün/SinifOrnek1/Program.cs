using System;
using System.Collections.Generic;

namespace SinifOrnek1
{
    class Program
    {
        static void Main(string[] args)
        {
            var _hesapMakinesi = new HesapMakinesi();
            var _gunluk = new List<Gunluk>();
            var _uygulama = new Uygulama();


            var IslemSureci = true;
            var sayi = 0;
            var sonuc = 0;
            var girilenSayilar = new List<int>();
            var gunSonu = new Gunluk();
            var sayi1 = 0;
            var sayi2 = 0;
            while (IslemSureci)
            {
                _uygulama.Menu();
                Console.Write("Lütfen Menü seçimi yapınız");
                var menuSecimiString = Console.ReadLine();
                var menuSecimiInt = int.Parse(menuSecimiString);

                try
                {
                    switch (menuSecimiInt)
                    {
                        case 1:
                            //Toplama
                            var toplamIslem = true;
                            sonuc = 0;
                            girilenSayilar = new List<int>();
                            while (toplamIslem)
                            {
                                try
                                {
                                    sayi = _hesapMakinesi.EkrandanSayiAl();
                                    
                                    sonuc = sonuc + sayi;

                                    girilenSayilar.Add(sayi);
                                    Console.WriteLine("Toplama sonucu = " + sonuc);
                                }
                                catch
                                {
                                    toplamIslem = false;
                                }

                            }
                            gunSonu = new Gunluk()
                            {
                                YapilanIslem = "Toplama",
                                Sonuc = sonuc,
                                Sayilar = girilenSayilar
                            };
                            _gunluk.Add(gunSonu);

                            _hesapMakinesi.SonucuEkranaBas(gunSonu.YapilanIslem, gunSonu.Sonuc);

                            _uygulama.Bekleme();
                            _uygulama.EkraniTemizle();
                            break;
                        case 2:
                            //Çıkarma
                            sonuc = 0;
                            girilenSayilar = new List<int>();

                            sayi1 = _hesapMakinesi.EkrandanSayiAl();
                            sayi2 = _hesapMakinesi.EkrandanSayiAl();

                            sonuc = sayi1 - sayi2;
                            girilenSayilar.Add(sayi1);
                            girilenSayilar.Add(sayi2);
                            gunSonu = new Gunluk()
                            {
                                YapilanIslem = "Çıkarma",
                                Sonuc = sonuc,
                                Sayilar = girilenSayilar
                            };
                            _gunluk.Add(gunSonu);
                            _hesapMakinesi.SonucuEkranaBas(gunSonu.YapilanIslem, gunSonu.Sonuc);

                            _uygulama.Bekleme();
                            _uygulama.EkraniTemizle();
                            break;
                        case 3:
                            //Çarpma
                            var carpmaIslem = true;
                            sonuc = 1;
                            girilenSayilar = new List<int>();
                            while (carpmaIslem)
                            {
                                try
                                {
                                    sayi = _hesapMakinesi.EkrandanSayiAl();

                                    sonuc = sonuc * sayi;

                                    girilenSayilar.Add(sayi);
                                    Console.WriteLine("Çarpma sonucu = " + sonuc);
                                }
                                catch
                                {
                                    carpmaIslem = false;
                                }

                            }
                            gunSonu = new Gunluk()
                            {
                                YapilanIslem = "Çarpma",
                                Sonuc = sonuc,
                                Sayilar = girilenSayilar
                            };
                            _gunluk.Add(gunSonu);

                            _hesapMakinesi.SonucuEkranaBas(gunSonu.YapilanIslem, gunSonu.Sonuc);

                            _uygulama.Bekleme();
                            _uygulama.EkraniTemizle();
                            break;
                        case 4:
                            //Bölme
                            sonuc = 0;
                            girilenSayilar = new List<int>();

                            sayi1 = _hesapMakinesi.EkrandanSayiAl();
                            sayi2 = _hesapMakinesi.EkrandanSayiAl();

                            sonuc = sayi1 / sayi2;
                            girilenSayilar.Add(sayi1);
                            girilenSayilar.Add(sayi2);
                            gunSonu = new Gunluk()
                            {
                                YapilanIslem = "Bölme",
                                Sonuc = sonuc,
                                Sayilar = girilenSayilar
                            };
                            _gunluk.Add(gunSonu);
                            _hesapMakinesi.SonucuEkranaBas(gunSonu.YapilanIslem, gunSonu.Sonuc);

                            _uygulama.Bekleme();
                            _uygulama.EkraniTemizle();
                            break;
                        case 5:
                            //Günlük Göster
                            foreach (var item in _gunluk)
                            {
                                Console.WriteLine("#############################");
                                Console.WriteLine("Yapılan İşlem :" + item.YapilanIslem);
                                Console.WriteLine("İşlem Sonucu :" + item.Sonuc);
                                var sayilar = "";
                                foreach (var sayim in item.Sayilar)
                                {
                                    sayilar = sayilar+ sayim + ",";

                                }

                                Console.WriteLine("Girilen Sayilar :" + sayilar);
                                Console.WriteLine("#############################");
                            }
                            _uygulama.Bekleme();
                            _uygulama.EkraniTemizle();
                            break;
                        case 6:
                            //Çıkış
                            IslemSureci = false;
                            break;
                    }
                }
                catch
                {
                    _uygulama.MenuRakamKontrolEt();
                }

            }


        }
    }
}
