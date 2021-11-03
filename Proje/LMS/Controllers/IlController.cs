using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class IlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
