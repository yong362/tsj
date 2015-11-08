using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class testsController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        public ActionResult Index(string saleperson, string Location)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.test
                           orderby d.ID
                           select d.SalesPerson;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.saleperson = new SelectList(GenreLst);

            var movies = from m in db.test
                         select m;

            if (!String.IsNullOrEmpty(Location))
            {
                movies = movies.Where(s => s.Residence.Contains(Location));
            }

            if (!string.IsNullOrEmpty(saleperson))
            {
                movies = movies.Where(x => x.SalesPerson == saleperson);
            }

            return View(movies);
        }

        // GET: Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test test = db.test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,Email,Residence,SalesPerson,ItemBought,MonthBought,Price,Qty,Sales")] test test)
        {
            if (ModelState.IsValid)
            {
                db.test.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test test = db.test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,Email,Residence,SalesPerson,ItemBought,MonthBought,Price,Qty,Sales")] test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test test = db.test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            test test = db.test.Find(id);
            db.test.Remove(test);
            db.SaveChanges();
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
    }
}
