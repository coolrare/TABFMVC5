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

        public ActionResult PartialView1()
        {
            return PartialView();
        }

        public ActionResult Content1()
        {
            return Content("<script>alert('OK');</script>", "text/html");
        }
        public string Content2()
        {
            return "<script>alert('OK');</script>";
        }

        public ActionResult Robots()
        {
            return Content("Disallow: /", "text/plain");
        }

    }
}