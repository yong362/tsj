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
    public class excelsController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: excels
        public ActionResult Index(string saleperson, string Location)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.excel
                           orderby d.ID
                           select d.CreatedBy;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.saleperson = new SelectList(GenreLst);

            var movies = from m in db.excel
                         select m;

            if (!String.IsNullOrEmpty(Location))
            {
                movies = movies.Where(s => s.Location.Contains(Location));
            }

            if (!string.IsNullOrEmpty(saleperson))
            {
                movies = movies.Where(x => x.CreatedBy == saleperson);
            }

            return View(movies);
        }

        // GET: excels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            excel excel = db.excel.Find(id);
            if (excel == null)
            {
                return HttpNotFound();
            }
            return View(excel);
        }

        // GET: excels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: excels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreatedBy,EquipmentName,ReleaseDate,TypeofAssets,Barcode,Location,RoomName")] excel excel)
        {
            if (ModelState.IsValid)
            {
                db.excel.Add(excel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excel);
        }

        // GET: excels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            excel excel = db.excel.Find(id);
            if (excel == null)
            {
                return HttpNotFound();
            }
            return View(excel);
        }

        // POST: excels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreatedBy,EquipmentName,ReleaseDate,TypeofAssets,Barcode,Location,RoomName")] excel excel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excel);
        }

        // GET: excels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            excel excel = db.excel.Find(id);
            if (excel == null)
            {
                return HttpNotFound();
            }
            return View(excel);
        }

        // POST: excels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            excel excel = db.excel.Find(id);
            db.excel.Remove(excel);
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
