using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TABFMVC5.Models;

namespace TABFMVC5.Controllers
{
    public class EFController : Controller
    {
        public ActionResult CreateProduct()
        {
            var db = new FabricsEntities();

            var data = new Product()
            {
                ProductName = "Will",
                Active = true,
                Stock = 1,
                Price = 100
            };

            db.Product.Add(data);

            db.SaveChanges();

            return View(data);
        }
    }
}