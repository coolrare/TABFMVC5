using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TABFMVC5.Controllers
{
    public class ARController : Controller
    {
        public ActionResult View1()
        {
            return View();
        }

        public ActionResult View2()
        {
            return View("View1");
        }
    }
}