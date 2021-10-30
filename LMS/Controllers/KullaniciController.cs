using LMS.Core.Interfaces;
using LMS.Models.Data;
using LMS.Models.Dto;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class KullaniciController : Controller
    {
        private LMSDbContext _dbcontext;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public KullaniciController(
            LMSDbContext dbContext,
            IConfiguration config,
            ITokenService tokenService
            )
        {
            _dbcontext = dbContext;
            _config = config;
            _tokenService = tokenService;
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
        public IActionResult Giris(KullaniciGirisViewModel model)
        {
            if (ModelState.IsValid)
            {
                var query = _dbcontext.Kullanici.FirstOrDefault(q => q.Eposta == model.Eposta && q.Sifre == model.Sifre);
                if (query != null)
                {
                    var kullaniciTokenDto = new KullaniciTokenDTO()
                    {
                        Id = query.Id,
                        Ad = query.Ad,
                        Soyad = query.Soyad,
                        Eposta = query.Eposta,
                        Yetki = query.Yetki
                    };

                    var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), kullaniciTokenDto);

                    if (generatedToken != null)
                    {
                        HttpContext.Session.SetString("Token", generatedToken);


                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(model);
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(KullaniciKayitViewModel model)
        {

            if (ModelState.IsValid)
            {
                var entity = new KullaniciEntity()
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Eposta = model.Eposta,
                    Sifre = model.Sifre,
                    Aktif = true
                };
                _dbcontext.Kullanici.Add(entity);

                if (_dbcontext.SaveChanges() > 0)
                {
                    return RedirectToAction("Giris");
                }
            }
            

            return View(model);
        }
    }
}
