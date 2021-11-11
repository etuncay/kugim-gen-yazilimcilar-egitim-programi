using Haber.Core.Interfaces.Services;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Haber.WebApi.Controllers
{
    public class KullaniciController : BaseController
    {
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet]
        public ResponseResultModel<List<KullaniciResponseViewModel>> Listele()
        {
            return _kullaniciService.Listele();
        }

        [HttpGet]
        public ResponseResultModel<KullaniciResponseViewModel> Getir(int id)
        {
            return _kullaniciService.Getir(id);
        }

        [HttpPost]
        public ResponseResultModel<int> Ekle(KullaniciRequestViewModel model)
        {
            return _kullaniciService.Ekle(model);
        }

        [HttpPut]
        public ResponseResultModel Guncelle(int id, KullaniciRequestViewModel model)
        {
            return _kullaniciService.Guncelle(id, model);
        }

        [HttpDelete]
        public ResponseResultModel Sil(int id)
        {
            return _kullaniciService.Sil(id);
        }

        [HttpPut]
        public ResponseResultModel SifreGuncelle(int id, string yeniSifre)
        {
            return _kullaniciService.SifreGuncelle(id, yeniSifre);
        }

    }
}
