using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC.ViewComponents
{
    public class KategoriHaberViewComponent : ViewComponent
    {
        private readonly RestClient _restClient;

        public KategoriHaberViewComponent()
        {
            _restClient = new RestClient("http://localhost:42939/api/");
        }


        public async Task<IViewComponentResult> InvokeAsync(int kategoriId, int al)
        {

            var request = new RestRequest($"/Icerik/Filtrele?Sayfalama.Al={al}&Sayfalama.Sayfalama=true&KategoriId={kategoriId}");
            var response = await _restClient.GetAsync<ResponseResultModel<List<IcerikResponseViewModel>>>(request);

            var result = response.Data;

            return View(result);
        }
    }
}
