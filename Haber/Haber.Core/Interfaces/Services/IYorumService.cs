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
    public interface IYorumService
    {
        ResponseResultModel<List<YorumResponseViewModel>> Listele(int icerikId);
        ResponseResultModel<int> Ekle(YorumRequestViewModel model);
    }
}
