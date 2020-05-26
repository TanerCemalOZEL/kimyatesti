using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kimyatesti.Models;

namespace kimyatesti.Controllers
{
    public class SorusController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sorus
        public ActionResult Index()
        {
            return View(db.Soru.ToList());
        }

        // GET: Sorus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soru soru = db.Soru.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        // GET: Sorus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sorus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] Soru soru)
        {
            if (ModelState.IsValid)
            {
                db.Soru.Add(soru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soru);
        }

        // GET: Sorus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soru soru = db.Soru.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        // POST: Sorus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] Soru soru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soru);
        }

        // GET: Sorus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soru soru = db.Soru.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        // POST: Sorus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soru soru = db.Soru.Find(id);
            db.Soru.Remove(soru);
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
