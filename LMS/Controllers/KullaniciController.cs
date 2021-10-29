using LMS.Models.Data;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class KullaniciController : Controller
    {
        private LMSDbContext _dbcontext;

        public KullaniciController(LMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Giris()
        {
            return View();
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
                    AktivasyonKey = "aktivasyon-key",
                    AktivasyonSonTarihSaat = DateTime.Now.AddDays(3),
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
