using System;
using System.Web.Mvc;

namespace TABFMVC5.Controllers
{
    public class 寫入ViewBag_Key2的值Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Key2 = "Will 2";
        }
    }
}