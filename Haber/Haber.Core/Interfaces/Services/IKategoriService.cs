using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Interfaces.Services
{
    public interface IKategoriService
    {
        ResponseResultModel<List<KategoriResponseViewModel>> Listele();
        ResponseResultModel<KategoriResponseViewModel> Getir(int id);
        ResponseResultModel<int> Ekle(KategoriRequestViewModel model);
        ResponseResultModel Guncelle(int id, KategoriRequestViewModel model);
        ResponseResultModel Sil(int id);
    }
}
