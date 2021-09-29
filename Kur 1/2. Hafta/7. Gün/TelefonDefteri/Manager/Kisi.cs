using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonDefteri
{
    public class Kisi : IKisi
    {
        private  KisiModel[] veritabani = new KisiModel[100];
        private int kisiSira = 1;

        public KisiModel Getir(int kisiId)
        {

            return veritabani[kisiId];
        }

        public bool Kaydet(KisiModel veri)
        {
            try
            {
                veritabani[kisiSira] = veri;
                kisiSira++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Guncelle(int id,KisiModel veri)
        {
            try
            {
                var kisi = veritabani[id];
                kisi.Ad = veri.Ad;
                kisi.Soyad = veri.Soyad;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sil(int kisiId)
        {
            try
            {
                veritabani[kisiId] = null;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public KisiModel[] TumListe()
        {
            return veritabani;
        }

        
    }
}
