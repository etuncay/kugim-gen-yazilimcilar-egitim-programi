using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Response;
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

        public HaberController()
        {
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


    }
}
