using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek.Interface
{
    interface IOgrenciIslem
    {
        List<OgrenciModel> Listele();
        OgrenciModel Getir(int Id);
        bool Ekle(OgrenciModel model);
        bool Guncelle(OgrenciModel model);
        bool Sil(int ogrenciId);
        bool DersEkle(string ders);
        List<string> DersListele(int ogrenciId);
    }
}
