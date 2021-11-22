using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haber.MVC.Controllers
{
    [Route("[controller]")]
    public class GaleriController : Controller
    {
        private readonly RestClient _restClient;

        public GaleriController()
        {
            _restClient = new RestClient("http://localhost:42939/api/");
        }

        [HttpGet("Listele/{sayfa}")]
        public async Task<IActionResult> Listele(int sayfa=1)
        {
            

            var al = 6;
            var atla = (sayfa * al) - al;

            var haberRequest = new RestRequest($"Icerik/Filtrele?Sayfalama.Al={al}&Sayfalama.Atla={atla}&Sayfalama.Sayfalama=true&IcerikTipi=Galeri");

            var haberResult = await _restClient.GetAsync<ResponseResultModel<List<IcerikResponseViewModel>>>(haberRequest);

            ViewBag.Sayfa = sayfa;
            
            return View(haberResult);

        }

        [HttpGet("{id}/{slug}/{resimSira}")]
        public async Task<IActionResult> Index(int id, string slug, int resimSira=1)
        {

            var request = new RestRequest($"Resim/Listele?icerikId={id}");

            var response = await _restClient.GetAsync<ResponseResultModel<List<ResimResponseViewModel>>>(request);
            var result = response.Data;
            ViewBag.ResimSira = resimSira;
            ViewBag.Id = id;
            ViewBag.Slug = slug;
            return View(result);
        }
    }
}
