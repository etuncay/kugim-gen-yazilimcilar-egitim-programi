using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFMuhasebeUygulamasi.musteri;
using WPFMuhasebeUygulamasi.satis.Models;
using WPFMuhasebeUygulamasi.urun;

namespace WPFMuhasebeUygulamasi.satis
{
    public class SatisYonetim : ABSBaseDbModel,  ISatisYonetim
    {
        private string dosyaYolu = VeritabaniTanimlama.Satislar;
        private int id = 1;

        public override void DataGridYenile(DataGrid dataGrid)
        {
            dataGrid.Items.Clear();
            var items = Liste();

            var musteriYonetim = new MusteriYonetim();
            var urunYonetim = new UrunYonetim();

            var musteriler = musteriYonetim.Liste();
            var urunler = urunYonetim.Liste();

            foreach (var item in items)
            {
                var musteri = musteriler.FirstOrDefault(q=>q.Id == item.MusteriId);
                var urun = urunler.FirstOrDefault(q=>q.Id==item.UrunId);

                dataGrid.Items.Add(new SatisDataGridModel
                {
                    Id = item.Id,
                    Adet = item.Adet,
                    MusteriAdiSoyadi = musteri.Ad + " " + musteri.Soyad,
                    UrunAdi = urun.Adi,
                    BirimFiyati = urun.BirimFiyati,
                    ToplamFiyat = item.Adet * urun.BirimFiyati,
                }); ;
            }

        }

        public List<SatisDbModel> Liste()
        {
            var dbString = File.ReadAllText(dosyaYolu);
            var dbModel = JsonConvert.DeserializeObject<List<SatisDbModel>>(dbString);
            if (dbModel == null)
            {
                dbModel = new List<SatisDbModel>();
            }

            return dbModel;
        }

        public bool SatisYap(SatisDbModel model)
        {
            var liste = Liste();
            if (liste.Count == 0)
            {
                model.Id = id;
            }
            else
            {
                model.Id = liste.Max(q => q.Id);
            }
            liste.Add(model);
            var dbString = JsonConvert.SerializeObject(liste);
            File.WriteAllText(dosyaYolu, dbString);    

            return false;
        }

        public bool Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
