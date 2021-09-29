using BaseClassOrnek.Interface;
using BaseClassOrnek.Islem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek
{
    public class OgrenciIslem : BirimIslem, IOgrenciIslem
    {

        public bool DersEkle(string ders)
        {
            throw new NotImplementedException();
        }

        public List<string> DersListele(int ogrenciId)
        {
            throw new NotImplementedException();
        }

        public bool Ekle(OgrenciModel model)
        {
            throw new NotImplementedException();
        }

        public OgrenciModel Getir(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(OgrenciModel model)
        {
            throw new NotImplementedException();
        }

        public List<OgrenciModel> Listele()
        {
            throw new NotImplementedException();
        }

        public bool Sil(int ogrenciId)
        {
            throw new NotImplementedException();
        }
    }
}
