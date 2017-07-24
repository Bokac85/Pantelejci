using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pantelejci_1._1.Models;

namespace Pantelejci_1._1.Controllers
{
    public class UtakmiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private void SetKluboviVariable()
        {
            ViewBag.Klubovi = db.Klubovi.Select(x => new SelectListItem()
            {
                Text = x.naziv,
                Value = x.ID.ToString(),
            }).ToList();
        }

        // GET: Utakmice
        public ActionResult Index()
        {
            SetKluboviVariable();
            return View(db.Utakmice.ToList());
        }

        // GET: Utakmice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utakmica utakmica = db.Utakmice.Find(id);
            if (utakmica == null)
            {
                return HttpNotFound();
            }
            return View(utakmica);
        }

        // GET: Utakmice/Create
        public ActionResult Create()
        {
            SetKluboviVariable();
            return View();
        }

        // POST: Utakmice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,vremeUtakmice")] Utakmica utakmica, int domacinID, int gostID)
        {
            if (ModelState.IsValid)
            {
                utakmica.Domacin = db.Klubovi.Find(domacinID);
                utakmica.Gost = db.Klubovi.Find(gostID);
                db.Utakmice.Add(utakmica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SetKluboviVariable();
            return View(utakmica);
        }

        // GET: Utakmice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utakmica utakmica = db.Utakmice.Find(id);
            if (utakmica == null)
            {
                return HttpNotFound();
            }
            return View(utakmica);
        }

        // POST: Utakmice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,vremeUtakmice")] Utakmica utakmica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utakmica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utakmica);
        }

        // GET: Utakmice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utakmica utakmica = db.Utakmice.Find(id);
            if (utakmica == null)
            {
                return HttpNotFound();
            }
            return View(utakmica);
        }

        // POST: Utakmice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utakmica utakmica = db.Utakmice.Find(id);
            db.Utakmice.Remove(utakmica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       // public ActionResult DodajPogodak ()  //


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
