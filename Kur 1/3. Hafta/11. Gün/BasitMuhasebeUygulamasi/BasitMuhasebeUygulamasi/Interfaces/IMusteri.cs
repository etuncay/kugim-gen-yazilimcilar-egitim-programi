using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Interfaces
{
    public interface IMusteri
    {
        List<MusteriModel> Listele();
        MusteriModel Getir(int id);
        SonucModel Ekle(MusteriModel model);
        SonucModel Guncelle(MusteriModel model);
        SonucModel Sil(int id);
    }
}
