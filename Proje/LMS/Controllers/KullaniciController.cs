using LMS.BLL;
using LMS.Core;
using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models.Dto;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LMS.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly IKullaniciBll _kullaniciBll;
        public KullaniciController(
            IKullaniciBll kullaniciBll,
            IConfiguration config,
            ITokenService tokenService
            )
        {
            _config = config;
            _tokenService = tokenService;

            _kullaniciBll = kullaniciBll;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Giris()
        {
            
            
            return View();
        }

        [HttpPost]
        [IfModelIsInvalid(RedirectToAction = "Giris" , IsForm = true)]
        public IActionResult Giris(KullaniciGirisViewModel model)
        {
           
            var kullaniciTokenDto = _kullaniciBll.Giris(model);


            if (kullaniciTokenDto != null)
            {

                var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), kullaniciTokenDto);

                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        [IfModelIsInvalid(RedirectToAction ="Kayit", IsForm = true)]
        public IActionResult Kayit(KullaniciKayitViewModel model)
        {

            var result = _kullaniciBll.Kayit(model);

            return result > 0 ? RedirectToAction("Giris"): View(model);
        }
    }
}
