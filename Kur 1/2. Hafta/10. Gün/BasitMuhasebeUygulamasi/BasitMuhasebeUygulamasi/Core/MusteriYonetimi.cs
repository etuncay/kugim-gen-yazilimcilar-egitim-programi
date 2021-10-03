using BasitMuhasebeUygulamasi.Interfaces;
using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Core
{
    public class MusteriYonetimi : IMusteri
    {
        public SonucModel Ekle(MusteriModel model)
        {
            var sonuc = new SonucModel();



            if (Veritabani.Musteri.FirstOrDefault(q => q.TCNO == model.TCNO)==null)
            {
                if (model.TCNO.Length == 11)
                {
                    model.Id = Veritabani.MusteriId++;
                    Veritabani.Musteri.Add(model);
                    
                    sonuc.Durum = true;

                }
                else
                {
                    sonuc.Durum = false;
                    sonuc.Mesaj = "TCNO 11 karakter olmalıdır.";
                }

            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = model.TCNO+" bu TCNO ya ait müsteri bulundu.";
            }

            return sonuc;
        }

        public MusteriModel Getir(int id)
        {
            return Veritabani.Musteri.FirstOrDefault(q=>q.Id==id);
        }

        public SonucModel Guncelle(MusteriModel model)
        {
            var sonuc = new SonucModel();

            var musteri = Veritabani.Musteri.FirstOrDefault(q => q.Id == model.Id);
            if (musteri != null)
            {
                if (model.TCNO.Length == 11)
                {
                    musteri = model;
                }
                else
                {
                    sonuc.Durum = false;
                    sonuc.Mesaj = "TCNO 11 karakter olmalıdır.";
                }
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Müşteri Bulunamadı";
            }



            return sonuc;
        }

        public List<MusteriModel> Listele()
        {
            return Veritabani.Musteri;
        }

        public SonucModel Sil(int id)
        {
            var sonuc = new SonucModel();

            var musteri = Veritabani.Musteri.FirstOrDefault(q=>q.Id==id);
            var satisYonetim = new SatisYonetim();
            if (musteri! != null)
            {
                var satislar = satisYonetim.SatislariListele(id);
                if (satislar.Count() == 0)
                {
                    Veritabani.Musteri.Remove(musteri);
                    sonuc.Durum = true;
                }
                else
                {
                    sonuc.Durum = false;
                    sonuc.Mesaj = "Müşteriye ait "+ satislar.Count()+ " adet satış işlemi bulunmaktadır.";
                }
                
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Müşteri Bulunamadı";
            }

            return sonuc;
        }
    }
}
