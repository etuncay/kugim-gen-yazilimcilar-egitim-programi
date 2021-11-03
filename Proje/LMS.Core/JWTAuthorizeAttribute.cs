using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JWTAuthorizeAttribute : ActionFilterAttribute
    {
        private string _rol;
        public JWTAuthorizeAttribute() { }

        public JWTAuthorizeAttribute(string rol)
        {
            _rol = rol;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var IsAuthenticated = context.HttpContext.Request.HttpContext.User.Identity.IsAuthenticated;

            if (IsAuthenticated)
            {
                var claimsIndentity = context.HttpContext.Request.HttpContext.User.Identity as ClaimsIdentity;

                var kullaniciRol = claimsIndentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault();

                if ( kullaniciRol != null)
                {
                   if(_rol != null && kullaniciRol.Value != _rol)
                    {
                        context.Result = new BadRequestResult();
                    }
                }
                else
                {
                    if (_rol != null)
                    {
                        context.Result = new BadRequestResult();
                    }
                }
                

            }
            else
            {
                context.Result = new RedirectResult("/Kullanici/Giris");
            }

            base.OnActionExecuting(context);
        }
    }
}
