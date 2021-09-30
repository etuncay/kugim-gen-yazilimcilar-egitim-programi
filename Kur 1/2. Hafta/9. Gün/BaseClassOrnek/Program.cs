using System;
using System.Collections.Generic;
using BaseClassOrnek.Islem;
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
                TC = "23232323"
            };

            kisiIslem.Ekle(kisi1);
            kisiIslem.Ekle(kisi2);
            kisiIslem.Ekle(kisi3);
            kisiIslem.Ekle(kisi4);
            kisiIslem.Ekle(kisi5);

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


            var islemDurumu =ogrenciIslem.BirimKontrol("Bilgisayar Mühendisliği");

            var ogrenci1 = new OgrenciModel
            {
                KisiId = kisi4.KisiId,
                BirimAdi = "Elektronik Mühendisliği",
                Durum = true,
                OgrenciId = Veritabani.OgrenciId++,
                OgrenciNo = "212222222",
                Ders = new System.Collections.Generic.List<string>
                {
                    "Matematik", "Fizik", "Elektronik 1"
                }
            };
            var ogrenci2 = new OgrenciModel
            {
                KisiId = kisi5.KisiId,
                BirimAdi = "Bilgisayar Mühendisliği",
                Durum = true,
                OgrenciId = Veritabani.OgrenciId++,
                OgrenciNo = "333333333",
                Ders = new System.Collections.Generic.List<string>
                {
                    "Programlama", "Sunucu Yönetimi", "Elektronik 1"
                }
            };

            ogrenciIslem.Ekle(ogrenci1);
            ogrenciIslem.Ekle(ogrenci2);


            foreach (var ogrenciItem in ogrenciIslem.Listele())
            {
                var kisi = kisiIslem.Getir(ogrenciItem.KisiId);
                
                Console.WriteLine($"Id =  {ogrenciItem.OgrenciId}, Numara = {ogrenciItem.OgrenciNo}, Ad Soyad = {kisi.Ad} {kisi.Soyad} Birimi = {ogrenciItem.BirimAdi}, Durum = {ogrenciItem.Durum}");
                foreach (var dersItem in ogrenciIslem.DersListele(ogrenciItem.OgrenciId))
                {
                    Console.WriteLine($" Ders = {dersItem}");
                }
            }

            ogrenciIslem.BirimGuncelle(ogrenci1.OgrenciId, "Mekatronik Mühendisliği");


           var birim= ogrenciIslem.BirimGetir(0);



            var ogrenci1dersler = new List<string> {
                "Türkçe", "Spor", "İngilizce"
            };

            ogrenciIslem.DersEkle(ogrenci1.OgrenciId, ogrenci1dersler);

            ogrenciIslem.DersEkle(ogrenci1.OgrenciId, "Sağlık");


            Console.WriteLine("Hello World!");
        }
    }
}
