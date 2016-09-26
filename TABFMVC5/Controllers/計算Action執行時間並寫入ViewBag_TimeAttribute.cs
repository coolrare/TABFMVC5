using System;
using System.Web.Mvc;

namespace TABFMVC5.Controllers
{
    public class 計算Action執行時間並寫入ViewBag_TimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.TimeStart = DateTime.Now;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Time = DateTime.Now - (DateTime)filterContext.Controller.ViewBag.TimeStart;
        }

    }
}