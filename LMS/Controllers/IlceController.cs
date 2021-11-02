using LMS.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class IlceController : Controller
    {
        private readonly LMSDbContext _dbcontext;

        public IlceController(LMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        public JsonResult JsonSelectList(int ilId)
        {
            var ilceler = _dbcontext.Ilce.Where(q => q.IlId == ilId).ToList(); 

            return Json(new SelectList(ilceler, "Id", "Tanim"));
        }
    }
}
