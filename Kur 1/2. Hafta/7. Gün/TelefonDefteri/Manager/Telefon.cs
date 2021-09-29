using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonDefteri
{
    class Telefon : ITelefon
    {
        private TelefonModel[] veritabani = new TelefonModel[200];
        private int sira = 0;

        public bool KisiTelefonEkle(TelefonModel veri)
        {
            var kisiTelefonlar = new TelefonModel[2];
            var list = new int[2];
            var i = 0;
            var y = 0;
            foreach (var item in veritabani)
            {
                if (item != null)
                {
                    if (item.KisiId == veri.KisiId)
                    {
                        kisiTelefonlar[i] = item;
                        i++;
                        list[i] = y;
                    }
                }
                y++;
            }
            var telefon1 = kisiTelefonlar[0];
            if (telefon1 != null)
            {
                if (telefon1.TelefonTuru == veri.TelefonTuru)
                {
                    veritabani[list[0]] = veri;
                }
            }
            else
            {
                veritabani[list[0]] = veri;
            }
            var telefon2 = kisiTelefonlar[1];
            if (telefon2 != null)
            {
                if (telefon2.TelefonTuru == veri.TelefonTuru)
                {
                    veritabani[list[1]] = veri;
                }
            }
            else
            {
                veritabani[list[1]] = veri;
            }



            return false;
        }

        public bool KisiTelefonGuncelle(int telefonId, TelefonModel veri)
        {
            try
            {
                var telefon = veritabani[telefonId];
                telefon.TelefonTuru = veri.TelefonTuru;
                telefon.TelefonNo = veri.TelefonNo;
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool KisiTelefonSil(int telefonId)
        {
            try
            {
                veritabani[telefonId] = null;

                return false;
            }
            catch
            {
                return false;
            }

            
        }

        public TelefonModel[] KisiTelefonTumListe(int kisiId)
        {
            var result = new TelefonModel[2];
            try
            {
                var i = 0;
                foreach (var item in veritabani)
                {
                    if (item != null)
                    {
                        if (item.KisiId == kisiId)
                        {
                            result[i] = item;
                            i++;
                        }
                    }
                }
            }
            catch
            {

            }

            return result;


        }
    }
}
