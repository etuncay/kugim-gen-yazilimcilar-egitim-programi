using BasitMuhasebeUygulamasi.Interfaces;
using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Core
{
    public class UrunYonetim : IUrun
    {
        public SonucModel AdetEkle(int id, int adet)
        {
            var sonuc = new SonucModel();
            var urun = Veritabani.Urun.FirstOrDefault(q=>q.Id==id);
            if (urun != null)
            {
                //urun.Adet = urun.Adet + adet;
                urun.Adet += adet;
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Ürün Bulunamadı";
            }

            return sonuc;
        }

        public SonucModel BirimFiyatiGuncelle(int id, int birimFiyati)
        {
            var sonucModel = new SonucModel();

            var urun = Veritabani.Urun.FirstOrDefault(q=>q.Id==id);
            if (urun != null)
            {
                if (birimFiyati <= 0)
                {
                    urun.BirimFiyati = birimFiyati;
                }

                sonucModel.Durum = true;
            }
            else
            {
                sonucModel.Durum = false;
                sonucModel.Mesaj = "Ürün Bulunamadı";

            }

            return sonucModel;
        }

        public SonucModel Ekle(UrunModel model)
        {
            var sonuc = new SonucModel();

            if (Veritabani.Urun.FirstOrDefault(q => q.Adi == model.Adi) == null)
            {
                model.Id = Veritabani.UrunId++;

                Veritabani.Urun.Add(model);

                sonuc.Durum = true;
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = model.Adi + " bu tanımda ürün bulunmaktadır.";
            }


            return sonuc;
        }

        public UrunModel Getir(int id)
        {
            return Veritabani.Urun.FirstOrDefault(q=>q.Id==id);
        }

        public SonucModel Guncelle(UrunModel model)
        {
            var sonuc = new SonucModel();

            var urun = Veritabani.Urun.FirstOrDefault(q=>q.Id==model.Id);
            if (urun != null)
            {
                urun = model;
                sonuc.Durum = true;
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Ürün Bulunamadı";
            }

            return sonuc;
        }

        public List<UrunModel> Listele()
        {
            return Veritabani.Urun;
        }

        public SonucModel Sil(int id)
        {
            var sonuc = new SonucModel();

            var urun = Veritabani.Urun.FirstOrDefault(q => q.Id == id);


            var satisYonetim = new SatisYonetim();

            var urunuSatinAlmisMusteriler = satisYonetim.UrunuSatinAlmisMusteriler(id);

            if (urun != null)
            {
                if (urunuSatinAlmisMusteriler.Count() == 0)
                {
                    Veritabani.Urun.Remove(urun);
                    sonuc.Durum = true;
                }
                else
                {
                    sonuc.Durum = false;
                    sonuc.Mesaj = $"Bu ürünü {urunuSatinAlmisMusteriler.Count()} satın almıştır.";
                }

               
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Ürün Bulunamadı";
            }

            return sonuc;
        }
    }
}
