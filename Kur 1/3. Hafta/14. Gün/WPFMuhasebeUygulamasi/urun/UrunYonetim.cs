using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFMuhasebeUygulamasi.urun.Models;

namespace WPFMuhasebeUygulamasi.urun
{
    public class UrunYonetim : ABSBaseDbModel, IUrunYonetim
    {
        private string dosyaYolu = VeritabaniTanimlama.Urunler;

        private int id = 1;

        public UrunYonetim()
        {

        }

        public override void DataGridYenile(DataGrid dataGrid)
        {
            var items = Liste();

            dataGrid.Items.Clear();

            foreach (var item in items)
            {
                dataGrid.Items.Add(new UrunDbModel
                {
                    Id = item.Id,
                    Adi = item.Adi,
                    BirimFiyati = item.BirimFiyati,
                    DepoAdet = item.DepoAdet
                });
            }
        }

        public bool Ekle(UrunDbModel model)
        {
            var dbString = File.ReadAllText(dosyaYolu);

            var dbModel = JsonConvert.DeserializeObject<List<UrunDbModel>>(dbString);
            if (dbModel == null || dbModel.Count()==0)
            {
                dbModel = new List<UrunDbModel>();
                model.Id = id;
            }
            else
            {
                model.Id = dbModel.Max(q => q.Id) + 1;
            }

            dbModel.Add(model);

            dbString = JsonConvert.SerializeObject(dbModel);

            File.WriteAllText(dosyaYolu,dbString);

            return true;
        }

        public UrunDbModel Getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(UrunDbModel model)
        {
            if (int.TryParse(model.Id.ToString(), out int id) && id > 0)
            {
                var dbString = File.ReadAllText(dosyaYolu);
                var dbModel = JsonConvert.DeserializeObject<List<UrunDbModel>>(dbString);

                var item = dbModel.FirstOrDefault(q => q.Id == id);
                if (item != null)
                {
                    item.Adi = model.Adi;
                    item.BirimFiyati = model.BirimFiyati;
                    item.DepoAdet = model.DepoAdet;
                }
                dbString = JsonConvert.SerializeObject(dbModel);

                File.WriteAllText(dosyaYolu, dbString);
            }



            return false;
        }

        public List<UrunDbModel> Liste()
        {
            var dbString = File.ReadAllText(dosyaYolu);
            var result = JsonConvert.DeserializeObject<List<UrunDbModel>>(dbString);
            if (result == null) result = new List<UrunDbModel>();
            return result;
        }

        public bool Sil(int id)
        {
            var dbString = File.ReadAllText(dosyaYolu);
            var dbModel = JsonConvert.DeserializeObject<List<UrunDbModel>>(dbString);

            var item = dbModel.FirstOrDefault(q => q.Id == id);
            if (item != null)
            {
                dbModel.Remove(item);
                dbString = JsonConvert.SerializeObject(dbModel);

                File.WriteAllText(dosyaYolu, dbString);

                return true;
            }

            return false;
        }
    }
}
