using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Core
{
    public class IfModelIsInvalidAttribute : ActionFilterAttribute
    {
        #region Properties

        public string RedirectToController { get; set; }

        public string RedirectToAction { get; set; }

        public string RedirectToPage { get; set; }
        public bool IsForm { get; set; } = false;

        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var dict = new RouteValueDictionary();

                Controller controller = context.Controller as Controller;
                if (!String.IsNullOrEmpty(RedirectToController))
                {
                    dict.Add("controller", RedirectToController);
                    dict.Add("action", RedirectToAction);
                    context.Result = new RedirectToRouteResult(dict);

                }
                else if (!String.IsNullOrEmpty(RedirectToAction))
                {
                    if (IsForm)
                    {
                        context.Result = new ViewResult
                        {
                            ViewName = RedirectToAction,
                            ViewData = controller.ViewData,
                            TempData = controller.TempData
                        };
                    }
                    else
                    {
                        dict.Add("action", RedirectToAction);
                        context.Result = new RedirectToRouteResult(dict);
                    }
                    
                }
                else if (!String.IsNullOrEmpty(RedirectToPage))
                {
                    dict.Add("page", RedirectToPage);
                    context.Result = new RedirectToRouteResult(dict);
                }

            }
        }
    }
}
