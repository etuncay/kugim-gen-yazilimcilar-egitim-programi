using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek.Interface
{
    public interface IKisi
    {
        List<KisiModel> Listele();
        KisiModel Getir(int Id);
        bool Ekle(KisiModel model);
        bool Guncelle(KisiModel model);
        bool Sil(int kisiId);        
    }
}
