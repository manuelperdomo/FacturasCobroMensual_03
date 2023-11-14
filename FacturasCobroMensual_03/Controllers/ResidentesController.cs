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
    public class ResidentesController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();

        // GET: Residentes
        public ActionResult Index()
        {
            return View(db.Residentes.ToList());
        }

        // GET: Residentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residentes residentes = db.Residentes.Find(id);
            if (residentes == null)
            {
                return HttpNotFound();
            }
            return View(residentes);
        }

        // GET: Residentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Residentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDResidente,Nombre,Apellido,Cedula,CorreoElectronico,Telefono,Nota,Inquilino")] Residentes residentes)
        {
            if (ModelState.IsValid)
            {
                db.Residentes.Add(residentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(residentes);
        }

        // GET: Residentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residentes residentes = db.Residentes.Find(id);
            if (residentes == null)
            {
                return HttpNotFound();
            }
            return View(residentes);
        }

        // POST: Residentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDResidente,Nombre,Apellido,Cedula,CorreoElectronico,Telefono,Nota,Inquilino")] Residentes residentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(residentes);
        }

        // GET: Residentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residentes residentes = db.Residentes.Find(id);
            if (residentes == null)
            {
                return HttpNotFound();
            }
            return View(residentes);
        }

        // POST: Residentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Residentes residentes = db.Residentes.Find(id);
            db.Residentes.Remove(residentes);
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
