using LMS.Core;
using LMS.Models.Data;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace LMS.Controllers
{
    public class IletisimController : Controller
    {
        private readonly LMSDbContext _dbcontext;


        public IletisimController(LMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [JWTAuthorize]
        public IActionResult Index(string mesaj = "")
        {
            var _userId = int.Parse(User.Claims.First(q => q.Type == ClaimTypes.NameIdentifier).Value);

            var result = _dbcontext.Iletisim
                .Include(q=>q.Ilce)
                .Where(q => q.KullaniciId == _userId)
                .Select(q=> new IletisimViewModel() {
                    IlId = q.Ilce.IlId,
                    IlceId = q.IlceId,
                    Adres = q.Adres,
                    Telefon = q.Telefon
                }).FirstOrDefault();

            var il = _dbcontext.Il.ToList();

            ViewBag.Il = _dbcontext.Il.ToList();

            if (result == null)
            {
                result = new IletisimViewModel();
            }

            ViewBag.Mesaj = mesaj;

            return View(result);
        }

        [HttpPost]
        [IfModelIsInvalid(RedirectToAction="Index")]
        public IActionResult Kaydet(IletisimKayitViewModel model)
        {
            var _userId = int.Parse(User.Claims.First(q => q.Type == ClaimTypes.NameIdentifier).Value);

            var query = _dbcontext.Iletisim.FirstOrDefault(q => q.KullaniciId == _userId);

            if (query == null)
            {
                var entity = new IletisimEntity()
                {
                    IlceId = model.IlceId,
                    KullaniciId = _userId,
                    Adres = model.Adres,
                    Telefon = model.Telefon,
                    OlusturulmaTarihi = System.DateTime.Now,
                };

                _dbcontext.Iletisim.Add(entity);
            }
            else
            {
                query.IlceId = model.IlceId;
                query.Adres = model.Adres;
                query.Telefon = model.Telefon;
                query.GuncellenmeTarihi = System.DateTime.Now;
                
            }


            var mesaj = "";
            if (_dbcontext.SaveChanges() > 0)
            {
                mesaj  = "Güncelleme Yapıldı";
            }

            return RedirectToAction("Index" ,new { mesaj });
        }

    }
}
