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

        public List<OdemeDetayliModel> OdemeListele()
        {
            throw new NotImplementedException();
        }

        public List<OdemeDetayliModel> OdemeListele(int SatisId)
        {
            throw new NotImplementedException();
        }
    }
}
