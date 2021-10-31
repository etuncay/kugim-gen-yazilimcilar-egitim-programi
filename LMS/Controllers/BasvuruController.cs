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
    [JWTAuthorize]
    public class BasvuruController : Controller
    {
        private readonly LMSDbContext _dbcontext;

        public BasvuruController(LMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Yeni(BasvuruKayitViewModel model)
        {

            if (ModelState.IsValid)
            {
                var basvuruDosyaYol = "";
                var resimDosyaYol = "";

                var basvuruEntity = new BasvuruEntity()
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Eposta = model.Eposta,
                    CepTelefonu = model.CepTelefonu,
                    TCNO = model.TCNO,
                    BasvuruDosyaYol = basvuruDosyaYol,
                    ResimDosyaYol = resimDosyaYol,
                    OlusturulmaTarihi = DateTime.Now
                };

                _dbcontext.Basvuru.Add(basvuruEntity);
                if (_dbcontext.SaveChanges() > 0)
                {
                    var basvuruSureci = new BasvuruSureciEntity()
                    {
                        BasvuruId = basvuruEntity.Id,
                        BasvuruSurecTipi = Core.Enums.EnumBasvuruSurecTipi.BasvuruYapildi,
                        OlusturulmaTarihi = DateTime.Now,
                        Tarih = DateTime.Now,
                        Aciklama= "",
                    };
                    _dbcontext.BasvuruSureci.Add(basvuruSureci);
                    _dbcontext.SaveChanges();
                }
            }

            return View(model);
        }
    }


}
