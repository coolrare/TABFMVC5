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
        FabricsEntities db = new FabricsEntities();

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product data)
        {
            db.Product.Add(data);
            db.SaveChanges();

            return RedirectToAction("ShowProduct", new { id = data.ProductId });
        }

        public ActionResult ShowProduct(int id)
        {
            return View(db.Product.Find(id));
        }

        public ActionResult ListProducts(string keyword)
        {
            var data = db.Product.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            return View(data);
        }

        public ActionResult EditProduct(int id)
        {
            return View(db.Product.Find(id));
        }

        [HttpPost]
        public ActionResult EditProduct(int id, Product data)
        {
            var item = db.Product.Find(id);

            item.ProductName = data.ProductName;
            item.Price = data.Price;

            db.SaveChanges();

            return RedirectToAction("ShowProduct", new { id = id });
        }
    }
}