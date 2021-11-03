using LMS.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [JWTAuthorize("Idari")]
    public class IdariController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
