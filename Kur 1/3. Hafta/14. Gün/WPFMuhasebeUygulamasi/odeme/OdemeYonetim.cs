using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFMuhasebeUygulamasi.musteri;
using WPFMuhasebeUygulamasi.odeme.Models;
using WPFMuhasebeUygulamasi.satis;
using WPFMuhasebeUygulamasi.urun;

namespace WPFMuhasebeUygulamasi.odeme
{
    public class OdemeYonetim : ABSBaseDbModel, IOdemeYonetim
    {
        private string dosyaYolu = VeritabaniTanimlama.Odemeler;
        private int id = 1;

        public override void DataGridYenile(DataGrid dataGrid)
        {
            var odemeler = Liste();
            var satisYonetim = new SatisYonetim();
            var musteriYonetim = new MusteriYonetim();
            var urunYonetim = new UrunYonetim();
            dataGrid.Items.Clear();
            var satislar = satisYonetim.Liste();

            foreach (var item in satislar)
            {
                if (!odemeler.Any(q => q.SatisId == item.Id)) {
                    var urun = urunYonetim.Getir(item.UrunId);
                    var musteri = musteriYonetim.Getir(item.MusteriId);
                    dataGrid.Items.Add(new OdemeDataGridModel
                    {
                        Id = item.Id,
                        MusteriAdiSoyadi = musteri.Ad + " " + musteri.Soyad,
                        UrunAdi = urun.Adi,
                        SatisId = item.Id,
                        ToplamFiyat = urun.BirimFiyati * item.Adet,
                        OdemeDurum = "Yapılmadı"
                    });
                }
            }

            foreach (var item in odemeler)
            {
                var satis = satisYonetim.Getir(item.SatisId);
                var urun = urunYonetim.Getir(satis.UrunId);
                var musteri = musteriYonetim.Getir(satis.MusteriId);

                dataGrid.Items.Add(new OdemeDataGridModel
                {
                    Id = item.Id,
                    MusteriAdiSoyadi = musteri.Ad + " " + musteri.Soyad,
                    UrunAdi = urun.Adi,
                    SatisId = item.SatisId,
                    ToplamFiyat = urun.BirimFiyati * satis.Adet,
                    OdemeDurum = "Yapıldı"
                });
            }


        }

        public List<OdemeDbModel> Liste()
        {
            var dbString = File.ReadAllText(dosyaYolu);

            var dbModel = JsonConvert.DeserializeObject<List<OdemeDbModel>>(dbString);

            if (dbModel == null)
            {
                dbModel = new List<OdemeDbModel>();
            }

            return dbModel;
        }

        public bool OdemeYap(OdemeDbModel model)
        {
            var liste = Liste();

            if (!liste.Any(q => q.SatisId == model.SatisId))
            {
                if (liste == null || liste.Count() == 0)
                {
                    model.Id = id;
                }
                else
                {
                    id = liste.Max(q => q.Id)+1;
                    model.Id = id;

                    
                }
                liste.Add(model);

                var dbString = JsonConvert.SerializeObject(liste);
                File.WriteAllText(dosyaYolu, dbString);
                return true;

            }
            return false;

        }
    }
}
