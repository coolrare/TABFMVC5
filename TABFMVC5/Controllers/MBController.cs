using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TABFMVC5.ViewModels;

namespace TABFMVC5.Controllers
{
    public class MBController : BaseController
    {
        [計算Action執行時間並寫入ViewBag_Time]
        [寫入ViewBag_Key2的值]
        public ActionResult Index()
        {
            ViewData["Key1"] = "Will 1";

            //ViewBag.Key2 = "Will 2";

            var product = db.Product.Find(1);

            ViewBag.Product = product;

            return PartialView();
        }

        public ActionResult Temp1()
        {
            TempData["Error"] = "發生錯誤";

            return RedirectToAction("Index");
        }

        public ActionResult Simple1(int id, string name)
        {
            return Content(id + " - " + name);
        }

        public ActionResult Simple1(FormCollection form)
        {
            return Content(form["id"] + " - " + form["name"]);
        }

        public ActionResult Complex1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Complex1(UserLoginViewModel data)
        {
            return Content(data.username + " - " + data.password);
        }
        
        public ActionResult Complex2()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Complex2(UserLoginViewModel data1, UserLoginViewModel data2)
        {
            return Content(data1.username + " - " + data1.password + " | " + data2.username + " - " + data2.password);
        }

        public ActionResult LateModelBinding()
        {
            return View("Complex1");
        }

        [HttpPost]
        public ActionResult LateModelBinding(FormCollection form)
        {
            UserLoginViewModel data = new UserLoginViewModel();
            if (TryUpdateModel(data))
            {
                return Content(data.username + " - " + data.password);
            }
            else
            {
                return Content("ERROR");
            }
        }

        [HandleError(ExceptionType = typeof(ArgumentException), View = "ArgumentExceptionError")]
        public ActionResult HandleError1(TestErrorViewModel data)
        {
            return View();
        }

    }
}