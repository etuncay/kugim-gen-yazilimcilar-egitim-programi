using LMS.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [JWTAuthorize]
    public class DersController : Controller
    {
        public IActionResult Listele(int anaDersId)
        {


            return View();
        }



    }
}
