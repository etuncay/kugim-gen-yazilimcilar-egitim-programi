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
    public class MansetHaberViewComponent : ViewComponent
    {
        private readonly RestClient _restClient;

        public MansetHaberViewComponent()
        {
            _restClient = new RestClient("http://localhost:42939/api/");
        }


        public async Task<IViewComponentResult> InvokeAsync(int al)
        {

            var request = new RestRequest($"Icerik/Listele?al={al}&atla=0&sayfala=true");

            var response = await _restClient.GetAsync<ResponseResultModel<List<IcerikResponseViewModel>>>(request);
            var result = response.Data;
            return View(result);
        }
    }
}
