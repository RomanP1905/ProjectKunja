using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wagenpark.Models;

namespace Wagenpark.Controllers
{
    public class onderhoudsController : Controller
    {
        private OnderhoudEntittitititeieittieABC db = new OnderhoudEntittitititeieittieABC();

        // GET: onderhouds
        public ActionResult Index()
        {
            return View(db.onderhouds.ToList());
        }

        // GET: onderhouds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            onderhoud onderhoud = db.onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // GET: onderhouds/Create
        public ActionResult Create()
        {

            autodingeke dba = new autodingeke();
            ViewBag.Kentekenlist = new SelectList(dba.autoes, "Kenteken", "Kenteken");

            WerkplaatsEntitie dbwerkplaats = new WerkplaatsEntitie();
            ViewBag.WerkplaatsList = new SelectList(dbwerkplaats.werkplaats, "werkplaatsnr", "naam");
            return View();
        }

        // POST: onderhouds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "auto_onderhoud_id,onderhoudsdatum,kosten,auto_kenteken,werkplaats_werkplaatsnr")] onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.onderhouds.Add(onderhoud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(onderhoud);
        }

        // GET: onderhouds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            onderhoud onderhoud = db.onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // POST: onderhouds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "auto_onderhoud_id,onderhoudsdatum,kosten,auto_kenteken,werkplaats_werkplaatsnr")] onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onderhoud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(onderhoud);
        }

        // GET: onderhouds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            onderhoud onderhoud = db.onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // POST: onderhouds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            onderhoud onderhoud = db.onderhouds.Find(id);
            db.onderhouds.Remove(onderhoud);
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
