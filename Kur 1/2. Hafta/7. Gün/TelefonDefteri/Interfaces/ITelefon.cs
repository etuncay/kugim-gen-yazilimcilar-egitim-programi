using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonDefteri
{
     interface ITelefon
    {
        TelefonModel[] KisiTelefonTumListe(int kisiId); 
        bool KisiTelefonEkle(TelefonModel veri);
        bool KisiTelefonGuncelle(int telefonId, TelefonModel veri);
        bool KisiTelefonSil(int telefonId);
    }
}
