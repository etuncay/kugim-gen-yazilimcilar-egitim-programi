using BaseClassOrnek.Interface;
using BaseClassOrnek.Islem;
using BaseClassOrnek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek
{
    public class PersonelIslem : BirimIslem,  IPersonelIslem
    {
        private KisiIslem kisiIslem = new KisiIslem();

        public bool Ekle(PersonelModel model)
        {
            //Kisi Varsa 
            if(Veritabani.Kisi.FirstOrDefault(q=>q.KisiId== model.KisiId) != null)
            {
                //Aktif Personel Değilse
                if(Veritabani.Personel.FirstOrDefault(q => q.KisiId==model.KisiId && q.Durum == true) == null)
                {
                    if (BirimKontrol(model.BirimAdi))
                    {
                        Veritabani.Personel.Add(model);
                        return true;
                    }                    
                }
            }

            return false;
        }

        public PersonelModel Getir(int Id)
        {
            return Veritabani.Personel.FirstOrDefault(q=>q.PersonelId==Id);
        }

        public bool Gorevlendir(int personelId, string birimAdi)
        {
            var personel = Veritabani.Personel.Where(q => q.PersonelId == personelId && q.Durum==true);

            if (personel.Count()==1)
            {
                personel.First().BirimAdi = birimAdi;
                return true;
            }

            return false;
        }

        public bool Guncelle(PersonelModel model)
        {
            var personel = Veritabani.Personel.Where(q => q.PersonelId == model.PersonelId && q.Durum == true);

            if (personel.Count() == 1)
            {
                var p = personel.First();

                p.SicilNo = model.SicilNo;
                p.PersonelTipi = model.PersonelTipi;
                p.Unvan = model.Unvan;
                p.BirimAdi = model.BirimAdi;
                return true;
            }

            return false;
        }

        public List<PersonelModel> Listele()
        {
            return Veritabani.Personel;
        }

        public bool Sil(int personelId)
        {
            var personel = Veritabani.Personel.FirstOrDefault(q => q.PersonelId == personelId && q.Durum == true);
            if (personel != null)
            {
                Veritabani.Personel.Remove(personel);
                return true;
            }

            return false;
        }
    }
}
