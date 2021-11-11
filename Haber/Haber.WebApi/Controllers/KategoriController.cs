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
    public class KategoriController : BaseController
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(
            IKategoriService kategoriService
            )
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public ResponseResultModel<List<KategoriResponseViewModel>> Listele()
        {
            return _kategoriService.Listele();
        }

        [HttpGet]
        public ResponseResultModel<KategoriResponseViewModel> Getir(int id)
        {
            return _kategoriService.Getir(id);
        }

        [HttpPost]
        public ResponseResultModel<int> Ekle(KategoriRequestViewModel model)
        {
            return _kategoriService.Ekle(model);
        }

        [HttpPut]
        public ResponseResultModel Guncelle(int id, KategoriRequestViewModel model)
        {
            return _kategoriService.Guncelle(id, model);
        }

        [HttpDelete]
        public ResponseResultModel Sil(int id)
        {
            return _kategoriService.Sil(id);
        }
    }
}
