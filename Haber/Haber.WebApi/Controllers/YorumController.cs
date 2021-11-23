using Haber.Core.Interfaces.Services;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.WebApi.Controllers
{

    public class YorumController : BaseController
    {
        private readonly IYorumService _yorumService;

        public YorumController(IYorumService yorumService)
        {
            _yorumService = yorumService;
        }

        public ResponseResultModel<int> Ekle(YorumRequestViewModel model)
        {
           
            return _yorumService.Ekle(model);
        }

        public ResponseResultModel<List<YorumResponseViewModel>> Listele(int icerikId)
        {
            
            return _yorumService.Listele(icerikId);
        }
    }
}
