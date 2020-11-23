using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shoes_Store3.Models;

namespace Shoes_Store3.Controllers
{
    public class ShoesController : Controller
    {
        private ShoesContext db = new ShoesContext();

        // GET: Shoes
        public ActionResult Index()
        {
            var shoes = db.Shoes.Include(s => s.Firma);
            return View(shoes.ToList());
        }

        // GET: Shoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // GET: Shoes/Create
        public ActionResult Create()
        {
            ViewBag.FirmaId = new SelectList(db.Firmas, "Id", "Firma_name");
            return View();
        }

        // POST: Shoes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model_Name,Size,Price,FirmaId")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                db.Shoes.Add(shoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirmaId = new SelectList(db.Firmas, "Id", "Firma_name", shoes.FirmaId);
            return View(shoes);
        }

        // GET: Shoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmaId = new SelectList(db.Firmas, "Id", "Firma_name", shoes.FirmaId);
            return View(shoes);
        }

        // POST: Shoes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model_Name,Size,Price,FirmaId")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmaId = new SelectList(db.Firmas, "Id", "Firma_name", shoes.FirmaId);
            return View(shoes);
        }

        // GET: Shoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoes shoes = db.Shoes.Find(id);
            db.Shoes.Remove(shoes);
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
