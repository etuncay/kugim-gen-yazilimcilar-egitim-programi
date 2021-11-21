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
    public class HaberFotograflarViewComponent : ViewComponent
    {
        private readonly RestClient _restClient;

        public HaberFotograflarViewComponent()
        {
            _restClient = new RestClient("http://localhost:42939/api/");
        }


        public async Task<IViewComponentResult> InvokeAsync(int icerikId)
        {

            var request = new RestRequest($"Resim/Listele?icerikId={icerikId}");

            var response = await _restClient.GetAsync<ResponseResultModel<List<ResimResponseViewModel>>>(request);
            var result = response.Data;
            return View(result);
        }
    }
}
