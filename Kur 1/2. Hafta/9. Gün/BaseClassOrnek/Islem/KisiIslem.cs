using BaseClassOrnek.Interface;
using BaseClassOrnek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek
{
    class KisiIslem : IKisi
    {
        public bool Ekle(KisiModel model)
        {
            if (Veritabani.Kisi.FirstOrDefault(q => q.TC == model.TC) == null)
            {
                Veritabani.Kisi.Add(model);
                return true;

            }
            return false;
        }

        public KisiModel Getir(int Id)
        {
            var kisi = Veritabani.Kisi.FirstOrDefault(q=>q.KisiId==Id);

            return kisi;
        }

        public bool Guncelle(KisiModel model)
        {
            var kisi = Veritabani.Kisi.FirstOrDefault(q => q.KisiId == model.KisiId);
            if (kisi != null){
                kisi = model;

                return true;
            }
            return false;

        }

        public List<KisiModel> Listele()
        {
            return Veritabani.Kisi;
        }

        public bool Sil(int kisiId)
        {
            var kisi = Veritabani.Kisi.FirstOrDefault(q => q.KisiId == kisiId);
            if (kisi != null)
            {
                Veritabani.Kisi.Remove(kisi);
                return true;
            }            

            return false;
        }
    }
}
