using Haber.Core.Interfaces.Services;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Response;
using Haber.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestClient _restClient;
        public HomeController(
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _restClient = new RestClient("http://localhost:42939/api/");
        }

        public async Task<IActionResult> Index()
        {

            var mansetrequest = new RestRequest($"Icerik/Listele?al={5}&atla=0&sayfala=true");
            var mansetHaberleri =await _restClient.GetAsync<ResponseResultModel<List<IcerikResponseViewModel>>>(mansetrequest);

            var govderequest = new RestRequest($"Icerik/Listele?al={12}&atla=5&sayfala=true");

            var govdeHaberleri = await _restClient.GetAsync<ResponseResultModel<List<IcerikResponseViewModel>>>(govderequest);

            var result = new HomeHaberViewModel() {
                MansetHaberleri = mansetHaberleri.Data,
                GovdeHaberleri = govdeHaberleri.Data
            };

            return View(result);
        }

    }
}
