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
    public class YorumlarViewComponent : ViewComponent
    {
        private readonly RestClient _restClient;

        public YorumlarViewComponent()
        {
            _restClient = new RestClient("http://localhost:42939/api/");
        }


        public async Task<IViewComponentResult> InvokeAsync(int icerikId)
        {

            var request = new RestRequest($"Yorum/Listele?icerikId={icerikId}");
            var response = await _restClient.GetAsync<ResponseResultModel<List<YorumResponseViewModel>>>(request);

            var result = response.Data;

            return View(result);
        }
    }
}
