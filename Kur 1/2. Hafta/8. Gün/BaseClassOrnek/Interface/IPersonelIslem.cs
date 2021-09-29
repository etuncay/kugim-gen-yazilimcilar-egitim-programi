using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek.Interface
{
    interface IPersonelIslem 
    {
        List<PersonelModel> Listele();
        PersonelModel Getir(int Id);
        bool Ekle(PersonelModel model);
        bool Guncelle(PersonelModel model);
        bool Sil(int personelId);

        bool Gorevlendir(int personelId, string birimAdi);
    }
}
