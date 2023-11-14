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
    public class CasasController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();

        // GET: Casas
        public ActionResult Index()
        {
            var casas = db.Casas.Include(c => c.Residentes);
            return View(casas.ToList());
        }

        // GET: Casas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casas casas = db.Casas.Find(id);
            if (casas == null)
            {
                return HttpNotFound();
            }
            return View(casas);
        }

        // GET: Casas/Create
        public ActionResult Create()
        {
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre");
            return View();
        }

        // POST: Casas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCasa,NumeroCasa,Calle,Nota,IDResidente")] Casas casas)
        {
            if (ModelState.IsValid)
            {
                db.Casas.Add(casas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", casas.IDResidente);
            return View(casas);
        }

        // GET: Casas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casas casas = db.Casas.Find(id);
            if (casas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", casas.IDResidente);
            return View(casas);
        }

        // POST: Casas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCasa,NumeroCasa,Calle,Nota,IDResidente")] Casas casas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", casas.IDResidente);
            return View(casas);
        }

        // GET: Casas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casas casas = db.Casas.Find(id);
            if (casas == null)
            {
                return HttpNotFound();
            }
            return View(casas);
        }

        // POST: Casas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Casas casas = db.Casas.Find(id);
            db.Casas.Remove(casas);
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
