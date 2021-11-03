using LMS.Core;
using LMS.Data;
using LMS.Data;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Yeni([FromForm] BasvuruKayitViewModel model)
        {

            if (ModelState.IsValid)
            {
                var basvuruDosyaYol = "file/"+ Guid.NewGuid() +"-"+model.BasvuruDosya.FileName;
                var resimDosyaYol = "file/"+ Guid.NewGuid() +"-"+ model.ResimDosya.FileName;
                

                using (Stream fileStream = new FileStream("wwwroot/"+basvuruDosyaYol, FileMode.Create))
                {
                    await model.BasvuruDosya.CopyToAsync(fileStream);
                }

                using (Stream fileStream = new FileStream("wwwroot/" + resimDosyaYol, FileMode.Create))
                {
                    await model.ResimDosya.CopyToAsync(fileStream);
                }


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
