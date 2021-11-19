using Haber.Core.Interfaces.Services;
using Haber.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IIcerikService _icerikService;
        public HomeController(
            IIcerikService icerikService,
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _icerikService = icerikService;
        }

        public IActionResult Index()
        {
            var mansetHaberleri = _icerikService.Listele(new Haber.Models.ViewModels.SayfalamaViewModel()
            {
                Sayfalama = true,
                Al = 5,
                Atla =0
            });

            var result = new HomeHaberViewModel() {
                MansetHaberleri = mansetHaberleri.Data
                
            };



            return View(result);
        }

    }
}
