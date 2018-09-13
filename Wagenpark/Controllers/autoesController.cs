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

    [Authorize(Roles = "Dealer, Dealer0, Dealer1, Dealer2, Dealer3, Dealer4, Dealer5, Dealer6, Dealer7, Admin")]
    public class autoesController : Controller
    {
        
        autodingeke db = new autodingeke();
        autodingeke dba = new autodingeke();
        // GET: autoes
        public ActionResult Searching(string Searching)
        {
            return View(dba.autoes.Where(x => x.kenteken.Contains(Searching) || Searching == null).ToList());
        }
        public ActionResult Index(string Searching)
        {
            return View(dba.autoes.Where(x => x.kenteken.Contains(Searching) || x.merk.Contains(Searching) ||Searching == null).ToList());
        }

        // GET: autoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: autoes/Create
        public ActionResult Create()
        {

            DealerEntities dbc = new DealerEntities();
            ViewBag.DealerList = new SelectList(dbc.dealers, "dealernr", "naam");
            return View();
        }

        // POST: autoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "auto_id,kenteken,merk,Type,DEALER_DealerNr")] auto auto)
        {
            if (ModelState.IsValid)
            {
                db.autoes.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        // GET: autoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: autoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "auto_id,kenteken,merk,Type,DEALER_DealerNr")] auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        // GET: autoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: autoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auto auto = db.autoes.Find(id);
            db.autoes.Remove(auto);
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
