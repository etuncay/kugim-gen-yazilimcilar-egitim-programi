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
        private readonly ICacheService _cacheService;
        public IcerikController(
            IIcerikService icerikService,
            ICacheService cacheService
            )
        {
            _icerikService = icerikService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public ResponseResultModel<List<IcerikResponseViewModel>> Listele(int al, int atla, bool sayfala=false)
        {
            var sayfalama = new SayfalamaViewModel()
            {
                Al = al,
                Atla = atla,
                Sayfalama = sayfala
            };

            return _icerikService.Listele(sayfalama);
        }

        [HttpGet]
        public ResponseResultModel<List<IcerikResponseViewModel>> Filtrele([FromQuery] IcerikFitreleRequestViewModel filterModel)
        {
            
            return _icerikService.Filtrele(filterModel);
        }



        [HttpGet]
        public ResponseResultModel<IcerikResponseViewModel> Getir(int id)
        {
            var cacheKey = "icerik-"+id;

            if (_cacheService.Has(cacheKey))
            {
                return _cacheService.Get<ResponseResultModel<IcerikResponseViewModel>>(cacheKey);
            }
            else
            {
                var data = _icerikService.Getir(id);
                _cacheService.Add(cacheKey,data);
                return data;
            }
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
