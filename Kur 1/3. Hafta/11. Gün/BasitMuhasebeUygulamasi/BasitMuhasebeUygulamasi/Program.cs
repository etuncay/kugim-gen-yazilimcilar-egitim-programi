using BasitMuhasebeUygulamasi.Core;
using BasitMuhasebeUygulamasi.Models;
using System;

namespace BasitMuhasebeUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            var musteriYonetim = new MusteriYonetimi();

            var musteri1 = new MusteriModel
            {
                Ad = "Selami",
                Soyad = "Şahin",
                TCNO = "11111111111",
                Adres = "İstanbul"
            };

           var sonuc =  musteriYonetim.Ekle(musteri1);


            foreach (var musteri in musteriYonetim.Listele()) 
            {
                Console.WriteLine($"{musteri.Id}| {musteri.Ad}| {musteri.Soyad}| {musteri.TCNO}| {musteri.Adres}");
            }

            var musteri1Getir = musteriYonetim.Getir(musteri1.Id);

            musteri1Getir.Adres = "Kocaali";

            musteriYonetim.Guncelle(musteri1Getir);





            Console.WriteLine("Hello World!");
        }
    }
}
