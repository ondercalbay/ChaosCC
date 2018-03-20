using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChaosCC.DataLayer.EntityFramework;
using ChaosCC.Entity;

namespace ChaosCC.UIYonetim.Controllers
{
    public class EtkinliksController : Controller
    {
        private ChaosContext db = new ChaosContext();

        // GET: Etkinliks
        public ActionResult Index()
        {
            return View(db.Etkinlikler.ToList());
        }

        // GET: Etkinliks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlik etkinlik = db.Etkinlikler.Find(id);
            if (etkinlik == null)
            {
                return HttpNotFound();
            }
            return View(etkinlik);
        }

        // GET: Etkinliks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etkinliks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Yer,EtlinlikTuru,Tarih,Aciklama,EkleyenId,EklemeZamani,GuncelleyenId,GuncellemeZamani,Aktif")] Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                db.Etkinlikler.Add(etkinlik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etkinlik);
        }

        // GET: Etkinliks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlik etkinlik = db.Etkinlikler.Find(id);
            if (etkinlik == null)
            {
                return HttpNotFound();
            }
            return View(etkinlik);
        }

        // POST: Etkinliks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Yer,EtlinlikTuru,Tarih,Aciklama,EkleyenId,EklemeZamani,GuncelleyenId,GuncellemeZamani,Aktif")] Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etkinlik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etkinlik);
        }

        // GET: Etkinliks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlik etkinlik = db.Etkinlikler.Find(id);
            if (etkinlik == null)
            {
                return HttpNotFound();
            }
            return View(etkinlik);
        }

        // POST: Etkinliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etkinlik etkinlik = db.Etkinlikler.Find(id);
            db.Etkinlikler.Remove(etkinlik);
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
