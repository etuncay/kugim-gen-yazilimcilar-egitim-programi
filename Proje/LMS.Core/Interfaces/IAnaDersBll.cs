using LMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface IAnaDersBll
    {
        List<AnaDersViewModel> Listele();
        AnaDersViewModel Getir(int id);
        int Ekle(AnaDersKayitViewModel model);
        bool Guncelle(int id, AnaDersKayitViewModel model);
        bool Sil(int id);
    }
}
