using LMS.Core;
using LMS.Models.Data;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [JWTAuthorize("Yonetici")]
    public class YoneticiController : Controller
    {
        private readonly LMSDbContext _dbcontext;

        public YoneticiController(LMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kullanicilar()
        {

            var kullanicilar = new List<KullaniciViewModel>();

            foreach (var item in _dbcontext.Kullanici.ToList())
            {
                kullanicilar.Add(new KullaniciViewModel
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    Eposta = item.Eposta,
                    Aktif = item.Aktif,
                    Yetki = item.Yetki,
                    OlusturulmaTarihi = item.OlusturulmaTarihi,
                    GuncellenmeTarihi = item.GuncellenmeTarihi
                });
            }




            return View(kullanicilar);
        }
    }
}
