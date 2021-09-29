using System;
using BaseClassOrnek.Models;

namespace BaseClassOrnek
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kisi
            //Personeller
            //Ogrenciler

            var kisiIslem = new KisiIslem();
            var personelIslem = new PersonelIslem();
            var ogrenciIslem = new OgrenciIslem();

            //Personel
            var kisi1 = new KisiModel
            {
                KisiId = Veritabani.KisiId++,
                Ad = "Mehmet",
                Soyad = "Kayaaaaa",
                DogumYeri = "Sakarya",
                TC = "2222222222"
            };
            //Personel
            var kisi2 = new KisiModel
            {
                KisiId = Veritabani.KisiId++,
                Ad = "Halim",
                Soyad = "Selim",
                DogumYeri = "Bolu",
                TC = "11111111111"
            };
            //Ogrenci
            var kisi3 = new KisiModel
            {
                KisiId = Veritabani.KisiId++,
                Ad = "Ali",
                Soyad = "Bal",
                DogumYeri = "Kocaeli",
                TC = "33333333"
            };

            //Ogrenci
            var kisi4 = new KisiModel
            {
                KisiId = Veritabani.KisiId++,
                Ad = "Hasan",
                Soyad = "Kaya",
                DogumYeri = "İstanbul",
                TC = "55555555555"
            };

            var kisi5 = new KisiModel
            {
                KisiId = Veritabani.KisiId++,
                Ad = "Kerim",
                Soyad = "Kaya",
                DogumYeri = "İstanbul",
                TC = "55555555555"
            };

            kisiIslem.Ekle(kisi1);
            kisiIslem.Ekle(kisi2);
            kisiIslem.Ekle(kisi3);
            kisiIslem.Ekle(kisi4);

            kisi1.Soyad = "Kaya";

            kisiIslem.Guncelle(kisi1);

            kisiIslem.Sil(kisi3.KisiId);

            var personelModel1 = new PersonelModel
            {
                PersonelId = Veritabani.PersonelId++,
                KisiId = kisi1.KisiId,
                BirimAdi = "Mühendislik",
                PersonelTipi = "İdari",
                SicilNo ="001",
                Unvan = "Bilgisayar İşletmeni",
                Durum = true
            };
            personelIslem.Ekle(personelModel1);

            var personelModel1Guncel = new PersonelModel
            {
                PersonelId = personelModel1.PersonelId,
                KisiId = kisi1.KisiId,
                BirimAdi = "Rektörlük",
                PersonelTipi = "İdari",
                SicilNo = "001",
                Unvan = "Bilgisayar İşletmeni",
                Durum = true
            };

            personelIslem.Guncelle(personelModel1Guncel);



            var kisiler = Veritabani.Kisi;
            var personeler = Veritabani.Personel;            
            var ogrenciler = Veritabani.Ogrenci;

            personelIslem.Sil(personelModel1.PersonelId);

            Console.WriteLine("Hello World!");
        }
    }
}
