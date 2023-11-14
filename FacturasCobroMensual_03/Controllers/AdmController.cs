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
    public class AdmController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();

        // GET: Adm
        public ActionResult Index()
        {
            return View(db.Adm.ToList());
        }

        // GET: Adm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm adm = db.Adm.Find(id);
            if (adm == null)
            {
                return HttpNotFound();
            }
            return View(adm);
        }

        // GET: Adm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAdm,Nombre,Correo,Pass")] Adm adm)
        {
            if (ModelState.IsValid)
            {
                db.Adm.Add(adm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adm);
        }

        // GET: Adm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm adm = db.Adm.Find(id);
            if (adm == null)
            {
                return HttpNotFound();
            }
            return View(adm);
        }

        // POST: Adm/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAdm,Nombre,Correo,Pass")] Adm adm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adm);
        }

        // GET: Adm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm adm = db.Adm.Find(id);
            if (adm == null)
            {
                return HttpNotFound();
            }
            return View(adm);
        }

        // POST: Adm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adm adm = db.Adm.Find(id);
            db.Adm.Remove(adm);
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
