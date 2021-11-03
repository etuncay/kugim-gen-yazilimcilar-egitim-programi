using LMS.Core;
using LMS.Core.Interfaces;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [JWTAuthorize]
    public class AnaDersController : Controller
    {
        private readonly IAnaDersBll _anaDersBll;
        public AnaDersController( IAnaDersBll anaDersBll)
        {
            _anaDersBll = anaDersBll;
        }

        public IActionResult Listele()
        {
            
            return View(_anaDersBll.Listele());
        }

        public IActionResult Getir(int id)
        {
            return id <= 0 ? 
                RedirectToAction("Listele") : 
                View(_anaDersBll.Getir(id));
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [IfModelIsInvalid(RedirectToAction = "Ekle", IsForm =true)]
        public IActionResult Ekle(AnaDersKayitViewModel model)
        {

            return _anaDersBll.Ekle(model) > 0 ?
                RedirectToAction("Listele") : 
                View(model);
        }


        public IActionResult Guncelle(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Listele");
            }

           


            return View(_anaDersBll.Getir(id));
        }

        [HttpPost]
        [IfModelIsInvalid(RedirectToAction = "Guncelle", IsForm = true)]
        public IActionResult Guncelle(int id, AnaDersKayitViewModel model)
        {
            if(id <= 0)
            {
                return RedirectToAction("Listele");
            }

            return _anaDersBll.Guncelle(id, model)? 
                RedirectToAction("Listele"):
                View(model);
        }

        public IActionResult Sil(int id)
        {
            _anaDersBll.Sil(id);

            return  RedirectToAction("Listele");
        }
    }
}
