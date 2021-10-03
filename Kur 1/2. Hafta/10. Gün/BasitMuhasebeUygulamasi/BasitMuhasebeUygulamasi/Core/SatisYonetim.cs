using BasitMuhasebeUygulamasi.Interfaces;
using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Core
{
    public class SatisYonetim : ISatis
    {
        public SatisDetayliModel Getir(int id)
        {
            var sonuc = new SatisDetayliModel();
            var urunYonetim = new UrunYonetim();
            var musteriYonetim = new MusteriYonetimi();

            var satis = Veritabani.Satis.FirstOrDefault(q => q.Id == id && q.IptalTarihi==null);
            if (satis != null)
            {
                var musteri = musteriYonetim.Getir(satis.MusteriId);
                var urun = urunYonetim.Getir(satis.UrunId);

                sonuc.Id = satis.Id;
                sonuc.Adet = satis.Adet;
                sonuc.MusteriAdSoyad = musteri.Ad+ " "+ musteri.Soyad;
                sonuc.UrunAdi = urun.Adi;
                sonuc.UrunId = satis.UrunId;
                sonuc.MusteriId = satis.MusteriId;
            }
            return sonuc;
        }

        public SonucModel SatisIptal(int id)
        {
            var sonuc = new SonucModel();

            var satis = Veritabani.Satis.FirstOrDefault(q=>q.Id==id && q.IptalTarihi==null);
            if (satis != null)
            {
                var odemeYonetim = new OdemeYonetim();

                if (odemeYonetim.GetirSatisDurumunaGore(id) == null)
                {
                    //Veritabani.Satis.Remove(satis);
                    satis.IptalTarihi = DateTime.Now;
                    sonuc.Durum = true;
                }
                else
                {
                    sonuc.Durum = false;
                    sonuc.Mesaj = "Ödemesi alınmış satışın iptali olmaz";
                }

                
            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Satış İşlemi Bulunamadı";
            }




            return sonuc;
        }

        public List<SatisDetayliModel> SatislariListele()
        {
            var data = new List<SatisDetayliModel>();

            var musteriYonetim = new MusteriYonetimi();
            var urunYonetim = new UrunYonetim();

            foreach (var satis in Veritabani.Satis.Where(q=>q.IptalTarihi==null))
            {

                var musteri = musteriYonetim.Getir(satis.Id);
                var urun = urunYonetim.Getir(satis.Id);

                data.Add(new SatisDetayliModel {
                    Id = satis.Id,
                    MusteriAdSoyad = musteri.Ad + " "+ musteri.Soyad,
                    UrunAdi = urun.Adi,
                    Adet = satis.Adet,
                    Tarih = satis.Tarih
                });
            }


            return data;
        }

        public List<SatisDetayliModel> SatislariListele(int musteriId)
        {
            var data = new List<SatisDetayliModel>();

            var musteriYonetim = new MusteriYonetimi();
            var urunYonetim = new UrunYonetim();

            foreach (var satis in Veritabani.Satis.Where(q => q.MusteriId == musteriId && q.IptalTarihi==null).ToList())
            {

                var musteri = musteriYonetim.Getir(satis.Id);
                var urun = urunYonetim.Getir(satis.Id);

                data.Add(new SatisDetayliModel
                {
                    Id = satis.Id,
                    MusteriAdSoyad = musteri.Ad + " " + musteri.Soyad,
                    UrunAdi = urun.Adi,
                    Adet = satis.Adet,
                    Tarih = satis.Tarih
                });
            }


            return data;
        }

        public SonucModel SatisYap(SatisModel model)
        {
            var sonuc = new SonucModel();

            model.Id = Veritabani.SatisId++;

            sonuc.Durum = true;


            return sonuc;
        }

        public List<MusteriModel> UrunuSatinAlmisMusteriler(int urunId)
        {
            var sonuc =new List<MusteriModel>();

            var satislar = Veritabani.Satis.Where(q => q.UrunId == urunId && q.IptalTarihi==null).ToList();

            var musteriYonetim = new MusteriYonetimi();

            if (satislar.Count() > 0)
            {
                foreach (var satis in satislar)
                {
                    var musteri = musteriYonetim.Getir(satis.MusteriId);

                    sonuc.Add(musteri);
                }
            }


            return sonuc;
        }
    }
}
