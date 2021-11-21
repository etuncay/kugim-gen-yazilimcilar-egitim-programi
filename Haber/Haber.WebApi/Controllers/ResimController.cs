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
  
    public class ResimController : BaseController
    {
        private readonly IResimService _resimService;


        public ResimController(IResimService resimService)
        {
            _resimService = resimService;
        }

        [HttpGet]
        public ResponseResultModel<List<ResimResponseViewModel>> Listele(int icerikId) {

            return _resimService.Listele(icerikId);
        }
        

        [HttpPost]
        public ResponseResultModel Ekle(ResimRequestViewModel model )
        {

            return _resimService.Ekle(model);
        }

        [HttpDelete]
        public ResponseResultModel Sil(int icerikId)
        {

            return _resimService.Sil(icerikId);
        }
    }
}
