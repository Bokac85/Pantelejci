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
    [Authorize(Roles=Roles.ADMIN)]
    public class IgraciController : Controller
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

        // GET: Igraci
        /* public ActionResult Index()
         {
             return View(db.Igraci.ToList());
         }*/

        [AllowAnonymous]
        public ActionResult Index(string search = "", int? klubId = null, pozicija? pozicija = null)
        {
            var igraci = db.Igraci.
                Where(x => x.ime.Contains(search)
                || x.prezime.Contains(search)
                || x.Klub.naziv.Contains(search));

            if (klubId.HasValue)
            {
                igraci = igraci.Where(x => x.Klub.ID == klubId.Value);
            }

            if (pozicija.HasValue)
            {
                igraci = igraci.Where(x => x.Pozicija == pozicija.Value);
            }

            SetKluboviVariable();

            return View(igraci.ToList());
        }

        // GET: Igraci/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = db.Igraci.Find(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // GET: Igraci/Create
        public ActionResult Create()
        {
            SetKluboviVariable();
            return View();
        }

        // POST: Igraci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ime,prezime,godinaRodjenja,Pozicija,brojDresa")] Igrac igrac,
            int klubId,
            HttpPostedFileBase upload1)
        {
            ModelState.Clear();

            if (upload1 != null)
            {
                igrac.SlikaIgraca = upload1.FileName;
            }

            if (ModelState.IsValid)
            {
                igrac.Klub = db.Klubovi.Find(klubId);

                db.Igraci.Add(igrac);
                db.SaveChanges();

                string path = Server.MapPath("~/Content/Images/Igraci/") + igrac.SlikaIgraca;
                upload1.SaveAs(path);

                return RedirectToAction("Index");
            }

            SetKluboviVariable();
            return View(igrac);
        }

        // GET: Igraci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = db.Igraci.Find(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // POST: Igraci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ime,prezime,godinaRodjenja,Pozicija,brojDresa")] Igrac igrac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(igrac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(igrac);
        }

        // GET: Igraci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igrac igrac = db.Igraci.Find(id);
            if (igrac == null)
            {
                return HttpNotFound();
            }
            return View(igrac);
        }

        // POST: Igraci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Igrac igrac = db.Igraci.Find(id);
            db.Igraci.Remove(igrac);
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
