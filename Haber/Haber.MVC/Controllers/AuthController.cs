using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly RestClient _restClient;

        public AuthController()
        {
            _restClient = new RestClient("http://localhost:42939/api/");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(KullaniciGirisRequestViewModel model)
        {
            var request = new RestRequest("Auth/SignIn").AddJsonBody(model);
                


            var response = await _restClient.PostAsync<ResponseResultModel<TokenResponseResultViewModel>>(request);
           
            if (response!=null && response.Type == Haber.Models.Enums.EnumResponseResultType.Success)
            {
                HttpContext.Session.SetString("Token", response.Data.Token);

                var getS = HttpContext.Session.GetString("Token");

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(KullaniciRequestViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            return RedirectToAction("Index","Home");
        }

    }
}
