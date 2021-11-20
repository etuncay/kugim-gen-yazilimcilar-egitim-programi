using Haber.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("Yukle")]
        public ResponseResultModel<string> Yukle(IFormFile file)
        {
            var baseUrl = "https://localhost:44364/";

            var result = new ResponseResultModel<string>();
            result.Type = Models.Enums.EnumResponseResultType.Error;

            if (file != null)
            {
                result.Data = "file/" + Guid.NewGuid() + "-" + file.FileName;


                using (Stream fileStream = new FileStream("wwwroot/" + result.Data, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                    result.Data = baseUrl + result.Data;
                }
            }
            else
            {
                
                result.Message = "Resim Bulunamadı";

            }

            return result;
        }
    }
}
