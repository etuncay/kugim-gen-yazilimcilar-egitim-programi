using System;

namespace TelefonDefteri
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kişi
            //Telefon
            var kisiIslem = new Kisi();
            var telefonIslem = new Telefon();

            var islem = true;
            var diziSira = 0;
            while (islem)
            {
                Menu();
                try
                {
                    Console.WriteLine("Menü Seçimi Yapınız");
                    var menuString = Console.ReadLine();
                    var menuInt = int.Parse(menuString);
                    switch (menuInt)
                    {
                        case 1:
                            //Kişileri Listesi
                            Console.Clear();
                            diziSira = 0;
                            foreach (var item in kisiIslem.TumListe())
                            {
                                if (item != null)
                                {
                                    Console.WriteLine("Sira ="+diziSira + " Ad =" + item.Ad + " Soyad = " + item.Soyad);
                                }
                                diziSira++;
                                
                            }
                            
                            BeklemeYap();
                            Console.Clear();
                            break;
                        case 2:
                            //Kişi Ekle
                            Console.Clear();
                            Console.Write("Ad Giriniz = ");
                            var ad = Console.ReadLine();
                            Console.Write("Soyad Giriniz =");
                            var soyAd = Console.ReadLine();
                            kisiIslem.Kaydet(new KisiModel {
                            Ad = ad,
                            Soyad = soyAd
                            });
                            
                            BeklemeYap();
                            Console.Clear();
                            break;
                        case 3:
                            //Telefon Ekle
                            Console.Clear();
                            Console.Write("Telefon eklemek istediğiniz kişi id giriniz");
                            var kisiIdString = Console.ReadLine();
                            var kisiIdInt = int.Parse(kisiIdString);
                            var kisi = kisiIslem.Getir(kisiIdInt);
                            Console.WriteLine("Ad = "+ kisi.Ad+ " Soyad = "+ kisi.Soyad);
                            var kisiTelefonlar = telefonIslem.KisiTelefonTumListe(kisiIdInt);

                            foreach (var item in kisiTelefonlar)
                            {
                                if (item != null)
                                {
                                    Console.WriteLine("Telefon Türü = " + item.TelefonTuru + " Telefon No = " + item.TelefonNo);
                                }                                
                            }

                            Console.Write("Telefon türünü yazınız = ");
                            var telefonTuru = Console.ReadLine();
                            Console.WriteLine("Telefon numarasını giriniz = ");
                            var telefonNo = Console.ReadLine();

                            telefonIslem.KisiTelefonEkle(new TelefonModel
                            {
                                KisiId = kisiIdInt,
                                TelefonTuru = telefonTuru,
                                TelefonNo = telefonNo
                            });

                            BeklemeYap();
                            Console.Clear();
                            break;
                        case 4:
                            islem = false;
                            Console.Clear();
                            Console.Write("Telefon eklemek istediğiniz kişi id giriniz");
                            var kisiIdString1 = Console.ReadLine();
                            var kisiIdInt1 = int.Parse(kisiIdString1);
                            var kisi1 = kisiIslem.Getir(kisiIdInt1);
                            Console.WriteLine("Ad = " + kisi1.Ad + " Soyad = " + kisi1.Soyad);
                            var kisiTelefonlar1 = telefonIslem.KisiTelefonTumListe(kisiIdInt1);

                            foreach (var item in kisiTelefonlar1)
                            {
                                if (item != null)
                                {
                                    Console.WriteLine("Telefon Türü = " + item.TelefonTuru + " Telefon No = " + item.TelefonNo);
                                }
                            }

                            
                            BeklemeYap();
                            Console.Clear();
                            break;
                        case 5:
                            islem = false;
                            break;
                        default:
                            islem = false;
                            break;
                    }
                }
                catch
                {
                    islem = false;
                }

            }


            //kisiIslem.Kaydet(new KisiModel
            //{
            //    Ad = "Ahmet",
            //    Soyad ="Kaya"
            //});

            //kisiIslem.Kaydet(new KisiModel
            //{
            //    Ad = "Mehmet",
            //    Soyad = "Cesur"
            //});

            //kisiIslem.Guncelle(1, new KisiModel { 
            //    Ad ="Kerim",
            //    Soyad = "Kaya"
            //});


            //foreach (var kisi in kisiIslem.TumListe())
            //{
            //    if (kisi != null)
            //    {
            //        Console.WriteLine("Ad =" + kisi.Ad + " Soyad = " + kisi.Soyad);
            //    }                
            //}

            //telefonIslem.KisiTelefonEkle(new TelefonModel
            //{
            //    KisiId = 1,
            //    TelefonTuru = "Cep",
            //    TelefonNo = "0555 555 55 55"
            //});
            //telefonIslem.KisiTelefonEkle(new TelefonModel
            //{
            //    KisiId = 1,
            //    TelefonTuru = "Ev",
            //    TelefonNo = "0216 555 55 55"
            //});

            //foreach (var item in telefonIslem.KisiTelefonTumListe(1))
            //{
            //    if (item != null)
            //    {
            //        Console.WriteLine("Telefon Türü =" + item.TelefonTuru + " Telefon No = " + item.TelefonNo);
            //    }
            //}

            Console.WriteLine("Hello World!");
        }

         static void Menu()
        {
            Console.WriteLine("1 - Kişileri Listele");
            Console.WriteLine("2 - Kişi Ekle");
            Console.WriteLine("3 - Telefon Ekle");
            Console.WriteLine("4 - Kişi Telefon Listele");
            Console.WriteLine("5 - Çıkış");
        }

        static void BeklemeYap()
        {
            Console.WriteLine("Menüye Dönmek için herhangi bir tuşa basınız");
            Console.ReadLine();
        }
    }
}
