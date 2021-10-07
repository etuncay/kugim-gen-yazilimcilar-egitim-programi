using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFMuhasebeUygulamasi.musteri.Models;

namespace WPFMuhasebeUygulamasi.musteri
{
    public class MusteriYonetim : ABSBaseDbModel, IMusteriYonetim
    {
        private string dosyaYolu = VeritabaniTanimlama.Musteriler;
        private int id = 1;

        public MusteriYonetim()
        {
            
        }

        public override void DataGridYenile(DataGrid dataGrid)
        {
            var items = Liste();

            foreach (var item in items)
            {
                dataGrid.Items.Add(new MusteriDbModel
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    Adres = item.Adres,
                    CepTelefonu = item.CepTelefonu,
                    TCNO = item.TCNO
                });
            }
        }

        public bool Ekle(MusteriDbModel model)
        {
            
            var dbString = File.ReadAllText(dosyaYolu);

            var dbModel = JsonConvert.DeserializeObject<List<MusteriDbModel>>(dbString);
            if (dbModel == null)
            {
                dbModel = new List<MusteriDbModel>();
                model.Id = id;
            }
            else
            {
                model.Id = dbModel.Max(q=>q.Id)+1;
            }
            dbModel.Add(model);

            dbString = JsonConvert.SerializeObject(dbModel);

            File.WriteAllText(dosyaYolu, dbString);

            return true;
        }

        public MusteriDbModel Getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(MusteriDbModel model)
        {
            if(int.TryParse(model.Id.ToString(), out int  id) && id > 0)
            {
                var dbString = File.ReadAllText(dosyaYolu);
                var dbModel = JsonConvert.DeserializeObject<List<MusteriDbModel>>(dbString);

                var item = dbModel.FirstOrDefault(q => q.Id == id);
                if (item != null)
                {
                    item.Ad = model.Ad;
                    item.Soyad = model.Soyad;
                    item.TCNO = model.TCNO;
                    item.Adres = model.Adres;
                    item.CepTelefonu = model.CepTelefonu;
                }
                dbString = JsonConvert.SerializeObject(dbModel);

                File.WriteAllText(dosyaYolu, dbString);
            }



            return false;
        }

        public List<MusteriDbModel> Liste()
        {
            var dbString = File.ReadAllText(dosyaYolu);
            var dbModel = JsonConvert.DeserializeObject<List<MusteriDbModel>>(dbString);
            if (dbModel == null)
            {
                dbModel = new List<MusteriDbModel>();
            }
            return dbModel;
        }

        public bool Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
