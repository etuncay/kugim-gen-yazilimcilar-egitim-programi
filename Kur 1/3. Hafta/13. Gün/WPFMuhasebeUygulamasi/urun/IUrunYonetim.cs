using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMuhasebeUygulamasi.urun.Models;

namespace WPFMuhasebeUygulamasi.urun
{
    public interface IUrunYonetim
    {
        List<UrunDbModel> Liste();
        UrunDbModel Getir(int id);
        bool Ekle(UrunDbModel model);
        bool Guncelle(UrunDbModel model);
        bool Sil(int id);
    }
}
