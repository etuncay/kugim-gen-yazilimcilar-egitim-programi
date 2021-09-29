using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonDefteri
{
    /*
        Ad, soyad, 
     */

    public interface IKisi
    {
        KisiModel[] TumListe();
        KisiModel Getir(int kisiId);
        bool Kaydet(KisiModel veri);        
        bool Sil(int kisiId);
    }
}
