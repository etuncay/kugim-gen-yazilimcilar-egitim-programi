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
    public class EtiketController : BaseController
    {
        private readonly IEtiketService _etiketService;

        public EtiketController(
            IEtiketService etiketService
            )
        {
            _etiketService = etiketService;
        }

        [HttpGet]
        public ResponseResultModel<List<EtiketResponseViewModel>> Listele()
        {
            return _etiketService.Listele();
        }

        [HttpGet]
        public ResponseResultModel<EtiketResponseViewModel> Getir(int id)
        {
            return _etiketService.Getir(id);
        }

        [HttpPost]
        public ResponseResultModel<int> Ekle(EtiketRequestViewModel model)
        {
            return _etiketService.Ekle(model);
        }

        [HttpPut]
        public ResponseResultModel Guncelle(int id, EtiketRequestViewModel model)
        {
            return _etiketService.Guncelle(id, model);
        }

        [HttpDelete]
        public ResponseResultModel Sil(int id)
        {
            return _etiketService.Sil(id);
        }
    }
}
