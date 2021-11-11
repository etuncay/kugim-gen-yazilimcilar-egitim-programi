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
    public interface IIcerikService
    {
        ResponseResultModel<List<IcerikResponseViewModel>> Listele();
        ResponseResultModel<IcerikResponseViewModel> Getir(int id);
        ResponseResultModel<int> Ekle(IcerikRequestViewModel model);
        ResponseResultModel Guncelle(int id, IcerikRequestViewModel model);
        ResponseResultModel Sil(int id);
        ResponseResultModel<int> YorumEkle(int id, int kullaniciId, string govde);
    }
}
