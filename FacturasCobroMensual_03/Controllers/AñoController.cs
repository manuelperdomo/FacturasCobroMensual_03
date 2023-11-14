using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacturasCobroMensual_03.Models;

namespace FacturasCobroMensual_03.Controllers
{
    public class AñoController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();

        // GET: Año
        public ActionResult Index()
        {
            return View(db.Año.ToList());
        }

        // GET: Año/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Año año = db.Año.Find(id);
            if (año == null)
            {
                return HttpNotFound();
            }
            return View(año);
        }

        // GET: Año/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Año/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAño,NumeroAño")] Año año)
        {
            if (ModelState.IsValid)
            {
                db.Año.Add(año);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(año);
        }

        // GET: Año/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Año año = db.Año.Find(id);
            if (año == null)
            {
                return HttpNotFound();
            }
            return View(año);
        }

        // POST: Año/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAño,NumeroAño")] Año año)
        {
            if (ModelState.IsValid)
            {
                db.Entry(año).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(año);
        }

        // GET: Año/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Año año = db.Año.Find(id);
            if (año == null)
            {
                return HttpNotFound();
            }
            return View(año);
        }

        // POST: Año/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Año año = db.Año.Find(id);
            db.Año.Remove(año);
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
