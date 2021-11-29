using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC.Controllers
{
    [Route("[controller]")]
    public class HaberController : Controller
    {
        private readonly RestClient _restClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HaberController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _restClient = new RestClient("http://localhost:42939/api/");
        }

        [HttpGet("{id}/{slug}")]
        public async Task<IActionResult> Index(int id, string slug)
        {

            var haberRequest = new RestRequest($"Icerik/Getir?Id={id}");

            var haberResult = await _restClient.GetAsync<ResponseResultModel<IcerikResponseViewModel>>(haberRequest);



            return View(haberResult.Data);
        }

        [HttpGet("kategori/{kategoriId}/{sayfa}")]
        public async Task<IActionResult> Kategori(int kategoriId,  int sayfa)
        {
            
            var al = 6;
            var atla = (sayfa * al)-al;

            var haberRequest = new RestRequest($"Icerik/Filtrele?Sayfalama.Al={al}&Sayfalama.Atla={atla}&Sayfalama.Sayfalama=true&KategoriId={kategoriId}");

            var haberResult = await _restClient.GetAsync<ResponseResultModel<List<IcerikResponseViewModel>>>(haberRequest);

            ViewBag.Sayfa = sayfa;
            ViewBag.KategoriId = kategoriId;

            return View(haberResult);
        }


        [HttpPost("YorumEkle")]
        public async Task<IActionResult> YorumEkle(int icerikId,string slug, string govde)
        {
            var _authHelper = new AuthHelper(_httpContextAccessor);

            var model = new YorumRequestViewModel()
            {
                IcerikId =icerikId,
                KullaniciAdi = _authHelper.GetUserName(),
                Govde = govde,
                Aktif = false
            };

            var request = new RestRequest("Yorum/Ekle").AddJsonBody(model);

            var response = await _restClient.PostAsync<ResponseResultModel<int>>(request);


            if (response != null && response.Type == Haber.Models.Enums.EnumResponseResultType.Success)
            { 
                
            }

            return RedirectToAction("Index", new { id = icerikId, slug });
        }

    }
}
