using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Interfaces
{
    public interface ISatis
    {

        SatisDetayliModel Getir(int id);
        List<SatisDetayliModel> SatislariListele();
        List<SatisDetayliModel> SatislariListele(int musteriId);
        List<MusteriModel> UrunuSatinAlmisMusteriler(int urunId);
        SonucModel SatisYap(SatisModel model);
        SonucModel SatisIptal(int id);
    }
}
