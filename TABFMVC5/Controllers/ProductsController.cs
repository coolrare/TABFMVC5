using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TABFMVC5.Models;
using TABFMVC5.ViewModels;

namespace TABFMVC5.Controllers
{
    public class ProductsController : Controller
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: Products
        public ActionResult Index(bool IsShowDeleted = false)
        {
            var data = repo.Get所有資料_可判斷是否顯示刪除的資料(IsShowDeleted);

            return View(data);
        }

        public ActionResult IndexTop10()
        {
            return View("Index", repo.GetTop10());
        }

        [HttpPost]
        public ActionResult IndexTop10(List<ProductBatchUpdateViewModel> products)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in products)
                {
                    var pp = repo.Find(item.ProductId);
                    pp.ProductName = item.ProductName;
                    pp.Stock = item.Stock;
                }

                repo.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;

                repo.UnitOfWork.Commit();

                return RedirectToAction("IndexTop10");
            }

            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewData.Model = product;

            return View();
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                var db = repo.UnitOfWork.Context as FabricsEntities;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                TempData["UpdatedProduct"] = product;

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            product.IsShowDeleted = true;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
