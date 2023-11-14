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
    public class MesesController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();

        // GET: Meses
        public ActionResult Index()
        {
            return View(db.Meses.ToList());
        }

        // GET: Meses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meses meses = db.Meses.Find(id);
            if (meses == null)
            {
                return HttpNotFound();
            }
            return View(meses);
        }

        // GET: Meses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMes,NombreMes")] Meses meses)
        {
            if (ModelState.IsValid)
            {
                db.Meses.Add(meses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meses);
        }

        // GET: Meses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meses meses = db.Meses.Find(id);
            if (meses == null)
            {
                return HttpNotFound();
            }
            return View(meses);
        }

        // POST: Meses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMes,NombreMes")] Meses meses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meses);
        }

        // GET: Meses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meses meses = db.Meses.Find(id);
            if (meses == null)
            {
                return HttpNotFound();
            }
            return View(meses);
        }

        // POST: Meses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meses meses = db.Meses.Find(id);
            db.Meses.Remove(meses);
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
