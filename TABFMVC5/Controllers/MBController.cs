using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TABFMVC5.Controllers
{
    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Key1"] = "Will 1";

            ViewBag.Key2 = "Will 2";

            var product = db.Product.Find(1);

            ViewBag.Product = product;

            return PartialView();
        }
    }
}