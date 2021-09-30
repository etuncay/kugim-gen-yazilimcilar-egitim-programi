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
    public class OgrenciIslem : AbstBirimIslem, IOgrenciIslem
    {

        

        public bool BirimGuncelle(int ogrenciId, string birimAdi)
        {
            
            if (BirimKontrol(birimAdi))
            {
                var ogrenci = Getir(ogrenciId);
                if (ogrenci != null && ogrenci.BirimAdi != birimAdi)
                {
                    ogrenci.BirimAdi = birimAdi;
                    return true;
                }                
            }

            return false;
        }

        public override bool BirimKontrol(string birimAdi)
        {
            if (Birimler.FirstOrDefault(q => q == birimAdi) != null)
            {
                return true;
            }

            return false;
        }

        public bool DersEkle(int ogrenciId ,string ders)
        {
            var ogrenci = Getir(ogrenciId);

            //if (ogrenci.Ders.Contains(ders))
            //if(ogrenci.Ders.FirstOrDefault(q=>q==ders)==null)
            if(ogrenci.Ders.Any(q=>q == ders))
            //if(ogrenci.Ders.Count(q=>q == ders)==0)
            {
                ogrenci.Ders.Add(ders);
                return true;
            }

            return false;
        }

        public bool DersEkle(int ogrenciId, List<string> dersler)
        {
            foreach (var ders in dersler)
            {
                DersEkle(ogrenciId, ders, 4);
            }

            return false;
        }

        public bool DersEkle(int ogrenciId, string ders, int dersSayisi)
        {
            var ogrenci = Getir(ogrenciId);

            if (ogrenci.Ders.Count() < dersSayisi)
            {
                ogrenci.Ders.Add(ders);

                return true;
            }


            return false;
        }

        public List<string> DersListele(int ogrenciId)
        {
            var ogrenci = Getir(ogrenciId);

            if (ogrenci != null)
            {
                return ogrenci.Ders;
            }

            return null;
        }

        public bool Ekle(OgrenciModel model)
        {
            var ogrenci = Veritabani.Ogrenci.FirstOrDefault(q=>q.OgrenciId== model.OgrenciId && q.BirimAdi == model.BirimAdi);

            if (ogrenci == null)
            {
                Veritabani.Ogrenci.Add(model);

                return false;
            }

            return false;
        }

        public OgrenciModel Getir(int ogrenciId)
        {
            return Veritabani.Ogrenci.FirstOrDefault(q=>q.OgrenciId== ogrenciId);
        }

        public bool Guncelle(OgrenciModel model)
        {
            var ogrenci = Getir(model.OgrenciId);

            if (ogrenci != null)
            {
                ogrenci.Durum = model.Durum;
                ogrenci.KisiId = model.KisiId;
                ogrenci.OgrenciNo = model.OgrenciNo;
                //Bölümünü
                BirimGuncelle(model.OgrenciId, model.BirimAdi);
                //Dersleri
                foreach (var ders in model.Ders)
                {
                    DersEkle(model.OgrenciId, ders);
                }

                return true;
            }

            return false;
        }

        public List<OgrenciModel> Listele()
        {
            return Veritabani.Ogrenci;
        }

        public bool Sil(int ogrenciId)
        {
            var ogrenci = Getir(ogrenciId);

            Veritabani.Ogrenci.Remove(ogrenci);

            return true;
        }
    }
}
