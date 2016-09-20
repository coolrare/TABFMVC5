using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TABFMVC5.Controllers
{
    public class ARController : BaseController
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

        public ActionResult File1()
        {
            return File(Server.MapPath("~/Content/Pikachu_pokemon_wikipedia_thumb400x275.jpg"), "image/jpeg");
        }

        public ActionResult File2()
        {
            return File(Server.MapPath("~/Content/Pikachu_pokemon_wikipedia_thumb400x275.jpg"), "image/jpeg", "pokemon.jpg");
        }

        public ActionResult Json1()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return Json(db.Product.Take(10), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Redirect1()
        {
            var param = new { id = 1, test = "123" };
            return RedirectToAction("Edit", "Products", param);
        }
    }
}