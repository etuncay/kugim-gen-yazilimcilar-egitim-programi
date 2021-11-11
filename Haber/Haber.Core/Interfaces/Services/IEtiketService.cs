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
    public interface IEtiketService
    {
        ResponseResultModel<List<EtiketResponseViewModel>> Listele();
        ResponseResultModel<EtiketResponseViewModel> Getir(int id);
        ResponseResultModel<int> Ekle(EtiketRequestViewModel model);
        ResponseResultModel Guncelle(int id, EtiketRequestViewModel model);
        ResponseResultModel Sil(int id);
    }
}
