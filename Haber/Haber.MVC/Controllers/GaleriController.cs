using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC.Controllers
{
    public class GaleriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
