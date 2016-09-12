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
            //var data = db.Product.Find(id);

            var data = db.Database.SqlQuery<Product>("SELECT * FROM dbo.Product WHERE ProductId=@p0", id).AsQueryable().FirstOrDefault();

            return View(data);
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

        public ActionResult RemoveProduct(int id)
        {
            var item = db.Product.Find(id);

            // 1.
            // db.OrderLine.Where(p => p.ProductId == id);

            // 2.
            // item.OrderLine

            //foreach (var orderLine in item.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(orderLine);
            //}

            // 3.
            db.OrderLine.RemoveRange(item.OrderLine);

            db.Product.Remove(item);

            db.SaveChanges();

            return RedirectToAction("ListProducts");
        }

        public ActionResult DoublePriceProducts()
        {
            db.Database.ExecuteSqlCommand("UPDATE dbo.Product SET Price=Price*2");

            return RedirectToAction("ListProducts");
        }
    }
}