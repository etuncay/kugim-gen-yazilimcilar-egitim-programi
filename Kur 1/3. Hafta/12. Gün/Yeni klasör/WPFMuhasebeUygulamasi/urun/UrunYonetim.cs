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
        private string dosyaYolu = "D:\\Git\\myshelf\\kugim-gen-yazilimcilar-egitim-programi\\Kur 1\\3. Hafta\\12. Gün\\Yeni klasör\\WPFMuhasebeUygulamasi\\DB\\urunler.txt";
        private int id = 1;

        public UrunYonetim()
        {
            DosyaKontrolEt(dosyaYolu);

            
        }

        public override void DataGridYenile(DataGrid dataGrid)
        {
            var items = Liste();

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
            throw new NotImplementedException();
        }

        public List<UrunDbModel> Liste()
        {
            var dbString = File.ReadAllText(dosyaYolu);
            return  JsonConvert.DeserializeObject<List<UrunDbModel>>(dbString);
        }

        public bool Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
