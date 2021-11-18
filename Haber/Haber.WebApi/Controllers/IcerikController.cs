using Haber.Core.Interfaces.Services;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.WebApi.Controllers
{
    public class IcerikController : BaseController
    {
        private readonly IIcerikService _icerikService;

        public IcerikController(
            IIcerikService icerikService
            )
        {
            _icerikService = icerikService;
        }

        [HttpGet]
        public ResponseResultModel<List<IcerikResponseViewModel>> Listele()
        {
            return _icerikService.Listele();
        }

        [HttpGet]
        public ResponseResultModel<IcerikResponseViewModel> Getir(int id)
        {
            return _icerikService.Getir(id);
        }

        [HttpPost]
        public ResponseResultModel<int> Ekle(IcerikRequestViewModel model)
        {

            //if (model.Resim != null)
            //{
            //    model.ResimUrl = "file/" + Guid.NewGuid() + "-" + model.Resim.FileName;


            //    using (Stream fileStream = new FileStream("wwwroot/" + model.ResimUrl, FileMode.Create))
            //    {
            //        model.Resim.CopyToAsync(fileStream);
            //    }
            //}
            


            return  _icerikService.Ekle(model);
        }

        [HttpPut]
        public ResponseResultModel Guncelle(int id, IcerikRequestViewModel model)
        {
            //if (model.Resim != null)
            //{
            //    model.ResimUrl = "file/" + Guid.NewGuid() + "-" + model.Resim.FileName;


            //    using (Stream fileStream = new FileStream("wwwroot/" + model.ResimUrl, FileMode.Create))
            //    {
            //        model.Resim.CopyTo(fileStream);
            //    }
            //}

            return _icerikService.Guncelle(id, model);
        }

        [HttpDelete]
        public ResponseResultModel Sil(int id)
        {
            return _icerikService.Sil(id);
        }
    }
}
