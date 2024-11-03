using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity; // Đảm bảo bạn có dòng này cho EntityState
using NQHuy_Project2_2210900105.Models; // Thay thế với namespace của bạn

namespace NQHuy_Project2_2210900105.Controllers
{
    public class AdminController : Controller
    {
        private QLCH db = new QLCH();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.QuảnTrị.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quảnTrị = db.QuảnTrị.Find(id);
            if (quảnTrị == null)
            {
                return HttpNotFound();
            }

            return View(quảnTrị);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "admin_username,admin_pass,admin_status")] QuảnTrị quảnTrị)
        {
            if (ModelState.IsValid)
            {
                db.QuảnTrị.Add(quảnTrị);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quảnTrị);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quảnTrị = db.QuảnTrị.Find(id);
            if (quảnTrị == null)
            {
                return HttpNotFound();
            }

            return View(quảnTrị);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "admin_username,admin_pass,admin_status")] QuảnTrị quảnTrị)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quảnTrị).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quảnTrị);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quảnTrị = db.QuảnTrị.Find(id);
            if (quảnTrị == null)
            {
                return HttpNotFound();
            }

            return View(quảnTrị);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var quảnTrị = db.QuảnTrị.Find(id);
            if (quảnTrị != null)
            {
                db.QuảnTrị.Remove(quảnTrị);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Products
        public ActionResult AdProIndex()
        {
            return View(db.PRODUCTs.ToList());
        }

        // GET: Product/Details/5
        public ActionResult AdProDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.PRODUCTs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult AdProCreate()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdProCreate(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Add(product);
                db.SaveChanges();
                return RedirectToAction("AdProIndex");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult AdProEdit(int id)
        {
            var product = db.PRODUCTs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdProEdit(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdProIndex");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult AdProDelete(int id)
        {
            var product = db.PRODUCTs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("AdProDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.PRODUCTs.Find(id);
            if (product != null)
            {
                db.PRODUCTs.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("AdProIndex");
        }
    }
}
