using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Interfaces
{
    public interface IUrun
    {
        List<UrunModel> Listele();
        UrunModel Getir(int id);
        SonucModel Ekle(UrunModel model);
        SonucModel Guncelle(UrunModel model);
        SonucModel Sil(int id);
        SonucModel AdetEkle(int id, int adet);
        SonucModel BirimFiyatiGuncelle(int id, int birimFiyati);
    }
}
