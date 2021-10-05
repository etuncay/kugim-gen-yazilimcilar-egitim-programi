using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Interfaces
{
    public interface IOdeme
    {
        SonucModel OdemeAl(int satisId);
        List<OdemeDetayliModel> OdemeListele();
        List<OdemeDetayliModel> OdemeGetirMusteriIdIle(int musteriId);
        OdemeDetayliModel GetirSatisDurumunaGore(int satisId);
    }
}
