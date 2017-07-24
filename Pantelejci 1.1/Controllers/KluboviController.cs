using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pantelejci_1._1.Models;

namespace Pantelejci_1._1.Controllers
{
    public class KluboviController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private void SetStadioniVariable()
        {
            ViewBag.Stadioni = db.Stadioni.Select(x => new SelectListItem()
            {
                Text = x.naziv,
                Value = x.ID.ToString(),
            }).ToList();
        }
        // GET: Klubovi
        public ActionResult Index()
        {
            return View(db.Klubovi.ToList());
        }

        // GET: Klubovi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klub klub = db.Klubovi.Find(id);
            if (klub == null)
            {
                return HttpNotFound();
            }
            return View(klub);
        }

        // GET: Klubovi/Create
        public ActionResult Create()
        {
            SetStadioniVariable();

            return View();
        }

        // POST: Klubovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,naziv,grad,godinaOsnivanja")] Klub klub,
            int stadionId,
            HttpPostedFileBase upload)
        {
            ModelState.Clear();

            if(upload != null)
            {
                klub.SlikaKluba = upload.FileName; 
            }

            if (ModelState.IsValid)
            {
                klub.Stadion = db.Stadioni.Find(stadionId);

                db.Klubovi.Add(klub);
                db.SaveChanges();

                string path = Server.MapPath("~/Content/Images/Klubovi/") + klub.SlikaKluba;
    upload.SaveAs(path);

                return RedirectToAction("Index");
            }
            SetStadioniVariable();

            return View(klub);
        }

        // GET: Klubovi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klub klub = db.Klubovi.Find(id);
            if (klub == null)
            {
                return HttpNotFound();
            }
            SetStadioniVariable();

            return View(klub);
        }

        // POST: Klubovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Edit([Bind(Include = "ID,naziv,grad,godinaOsnivanja")] Klub klub, int stadionID) //
        public ActionResult Edit(int id, int stadionID)
        {
            Klub klub = db.Klubovi.Find(id);
            if (TryUpdateModel(klub, new string[] { "naziv", "grad", "godinaOsnivanja" }))
            {
                klub.Stadion = db.Stadioni.Find(stadionID);   
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SetStadioniVariable();
            return View(klub);
        }
        
              // GET: Klubovi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klub klub = db.Klubovi.Find(id);
            if (klub == null)
            {
                return HttpNotFound();
            }
            //SetStadioniVariable();

            return View(klub);
        }

        // POST: Klubovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klub klub = db.Klubovi.Find(id);
            db.Klubovi.Remove(klub);
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
