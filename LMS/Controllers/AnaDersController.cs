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
    public class AnaDersController : Controller
    {
        private readonly LMSDbContext _dbcontext;

        public AnaDersController(LMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IActionResult Listele()
        {
            var result = new List<AnaDersViewModel>();

            _dbcontext.AnaDers.ToList().ForEach(q =>
            {
                result.Add(new AnaDersViewModel
                {
                    Id = q.Id,
                    UstId = q.UstId,
                    Ad = q.Ad,
                    Aciklama = q.Aciklama,
                    Aktif = q.Aktif,
                    GuncellenmeTarihi = q.GuncellenmeTarihi,
                    OlusturulmaTarihi = q.OlusturulmaTarihi
                });
            });

            return View(result);
        }

        public IActionResult Getir(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Listele");
            }

            var result = _dbcontext.AnaDers.Where(q=>q.Id==id)
                .Select(q => new AnaDersViewModel()
                {
                    Id =  q.Id,
                    Ad = q.Ad,
                    UstId = q.UstId,
                    Aciklama = q.Aciklama,
                    Aktif = q.Aktif,
                    OlusturulmaTarihi = q.OlusturulmaTarihi,
                    GuncellenmeTarihi = q.GuncellenmeTarihi
                }).FirstOrDefault();

            //var result = new AnaDersViewModel() { 
            //    Id = query.Id,
            //    Ad = query.Ad,
            //};



            return View(result);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [IfModelIsInvalid(RedirectToAction = "Ekle", IsForm =true)]
        public IActionResult Ekle(AnaDersKayitViewModel model)
        {
            var entity = new AnaDersEntity()
            {
                UstId = model.UstId,
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                Aktif = model.Aktif,
                OlusturulmaTarihi = DateTime.Now,
            };
            _dbcontext.AnaDers.Add(entity);

            if (_dbcontext.SaveChanges() > 0)
            {
                return RedirectToAction("Listele");
            }

            return View(model);
        }


        public IActionResult Guncelle(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Listele");
            }

            var result = _dbcontext.AnaDers.Where(q => q.Id == id)
                .Select(q => new AnaDersKayitViewModel()
                {
                    Ad = q.Ad,
                    UstId = q.UstId,
                    Aciklama = q.Aciklama,
                    Aktif = q.Aktif
                }).FirstOrDefault();

            ViewBag.Id = id;


            return View(result);
        }

        [HttpPost]
        public IActionResult Guncelle(int id, AnaDersKayitViewModel model)
        {
            if(id <= 0)
            {
                return RedirectToAction("Listele");
            }


            if (ModelState.IsValid)
            {
                var query = _dbcontext.AnaDers.FirstOrDefault(q => q.Id == id);
                if (query!=null)
                {
                    query.Ad = model.Ad;
                    query.Aciklama = model.Aciklama;
                    query.Aktif = model.Aktif;

                    if (_dbcontext.SaveChanges() > 0)
                    {
                        return RedirectToAction("Listele");
                    }
                }
            }

            return View(model);
        }

        public IActionResult Sil(int id)
        {
            var query = _dbcontext.AnaDers.FirstOrDefault(q => q.Id == id);

            if (query != null)
            {
                _dbcontext.AnaDers.Remove(query);

                if (_dbcontext.SaveChanges() > 0)
                {
                    return RedirectToAction("Listele");
                }

            }

            return RedirectToAction("Listele");
        }
    }
}
