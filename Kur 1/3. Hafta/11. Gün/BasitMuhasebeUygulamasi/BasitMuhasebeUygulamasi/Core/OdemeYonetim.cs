using BasitMuhasebeUygulamasi.Interfaces;
using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Core
{
    public class OdemeYonetim : IOdeme
    {
        public OdemeDetayliModel GetirSatisDurumunaGore(int satisId)
        {
            var odemeSonuc = Veritabani.Odeme.FirstOrDefault(q=>q.SatisId==satisId);
            var satisYonetim = new SatisYonetim();

            var satis = satisYonetim.Getir(satisId);


            var sonucModel = new OdemeDetayliModel
            {
                Id = odemeSonuc.Id,
                OdemeTutari = odemeSonuc.OdemeTutari,
                SatisBilgisi = satis.MusteriAdSoyad+ " Ad Soyad lı Müşteri" + " "+ satis.UrunAdi+ " Adlı ürünü satın aldı",
                SatisId = odemeSonuc.SatisId,
                Tarih = odemeSonuc.Tarih
            };

            return sonucModel;
        }

        public SonucModel OdemeAl(int satisId)
        {
            var sonuc = new SonucModel();

            var satisYonetim = new SatisYonetim();
            var urunYonetim = new UrunYonetim();
           
            var satis = satisYonetim.Getir(satisId);

            if (satis != null)
            {
                var urun = urunYonetim.Getir(satis.UrunId);

                var odemeModel = new OdemeModel()
                {
                    Id = Veritabani.OdemeId++,
                    OdemeTutari = urun.BirimFiyati * satis.Adet,
                    SatisId = satisId,
                    Tarih = DateTime.Now
                };
                Veritabani.Odeme.Add(odemeModel);

                sonuc.Durum = true;

            }
            else
            {
                sonuc.Durum = false;
                sonuc.Mesaj = "Satış İşlemi Bulunamadı";
            }





            return sonuc;

        }

        public List<OdemeDetayliModel> OdemeGetirMusteriIdIle(int musteriId)
        {
            var result = new List<OdemeDetayliModel>();
            var satisYonetim = new SatisYonetim();
            var urunYonetim = new UrunYonetim();

            var musteriyeSatislar = satisYonetim.SatislariListele(musteriId);

            foreach (var satisItem in musteriyeSatislar)
            {
                var odeme = Veritabani.Odeme.FirstOrDefault(q=>q.SatisId== satisItem.Id);
                if (odeme != null)
                {
                    var satis = satisYonetim.Getir(odeme.SatisId);
                    var urun = urunYonetim.Getir(satis.UrunId);
                    result.Add(new OdemeDetayliModel
                    {
                        Id = odeme.Id,
                        OdemeTutari = urun.BirimFiyati + satis.Adet,
                        SatisId = odeme.SatisId,
                        Tarih = odeme.Tarih,
                        SatisBilgisi = satis.MusteriAdSoyad + " Ad Soyad lı Müşteri" + " " + satis.UrunAdi + " Adlı ürünü satın aldı",
                    });
                }
            }

            return result;
        }

        public List<OdemeDetayliModel> OdemeListele()
        {
            var result = new List<OdemeDetayliModel>();
            var satisYonetim = new SatisYonetim();
            var urunYonetim = new UrunYonetim();

            foreach (var item in Veritabani.Odeme)
            {
                var satis = satisYonetim.Getir(item.SatisId);
                var urun = urunYonetim.Getir(satis.UrunId);
                result.Add(new OdemeDetayliModel { 
                    Id  = item.Id,
                    OdemeTutari = urun.BirimFiyati + satis.Adet,
                    SatisId = item.SatisId,
                    Tarih = item.Tarih,
                    SatisBilgisi = satis.MusteriAdSoyad + " Ad Soyad lı Müşteri" + " " + satis.UrunAdi + " Adlı ürünü satın aldı",
                });
            }

            return result;

        }

    }
}
