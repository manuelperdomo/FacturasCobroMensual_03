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
    public class CobrosMensualesController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();

        // GET: CobrosMensuales
        public ActionResult Index()
        {
            var cobrosMensuales = db.CobrosMensuales.Include(c => c.Residentes).Include(c => c.Residentes1);
            return View(cobrosMensuales.ToList());
        }

        // GET: CobrosMensuales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobrosMensuales cobrosMensuales = db.CobrosMensuales.Find(id);
            if (cobrosMensuales == null)
            {
                return HttpNotFound();
            }
            return View(cobrosMensuales);
        }

        // GET: CobrosMensuales/Create
        public ActionResult Create()
        {
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre");
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre");
            return View();
        }

        // POST: CobrosMensuales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCobroMensual,IDResidente,Mes,MontoAPagar,MontoPagado,DeudaAnterior")] CobrosMensuales cobrosMensuales)
        {
            if (ModelState.IsValid)
            {
                db.CobrosMensuales.Add(cobrosMensuales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", cobrosMensuales.IDResidente);
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", cobrosMensuales.IDResidente);
            return View(cobrosMensuales);
        }

        // GET: CobrosMensuales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobrosMensuales cobrosMensuales = db.CobrosMensuales.Find(id);
            if (cobrosMensuales == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", cobrosMensuales.IDResidente);
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", cobrosMensuales.IDResidente);
            return View(cobrosMensuales);
        }

        // POST: CobrosMensuales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCobroMensual,IDResidente,Mes,MontoAPagar,MontoPagado,DeudaAnterior")] CobrosMensuales cobrosMensuales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cobrosMensuales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", cobrosMensuales.IDResidente);
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", cobrosMensuales.IDResidente);
            return View(cobrosMensuales);
        }

        // GET: CobrosMensuales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobrosMensuales cobrosMensuales = db.CobrosMensuales.Find(id);
            if (cobrosMensuales == null)
            {
                return HttpNotFound();
            }
            return View(cobrosMensuales);
        }

        // POST: CobrosMensuales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CobrosMensuales cobrosMensuales = db.CobrosMensuales.Find(id);
            db.CobrosMensuales.Remove(cobrosMensuales);
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


        public ActionResult GenerarCobrosMensuales()
        {
            // Obtén la fecha actual y el mes actual
            DateTime fechaActual = DateTime.Now;
            DateTime mesActual = new DateTime(fechaActual.Year, fechaActual.Month, 1);

            // Verifica si ya existe un registro para el mes actual
            bool existeCobroMensual = db.CobrosMensuales.Any(c => c.Mes == mesActual);

            if (!existeCobroMensual)
            {
                // Obtiene la lista actualizada de residentes, incluyendo cualquier nuevo residente
                var residentes = db.Residentes.Include(r => r.Casas).ToList();

                foreach (var residente in residentes)
                {
                    int idResidente = residente.IDResidente; // Obtén el ID del residente

                    // Verifica si ya existe un registro para este residente y mes
                    bool existeRegistro = db.CobrosMensuales.Any(c => c.IDResidente == idResidente && c.Mes == mesActual);

                    if (!existeRegistro)
                    {
                        // Crea un nuevo registro para el mes actual
                        var nuevoCobro = new CobrosMensuales
                        {
                            IDResidente = idResidente,
                            Mes = mesActual,
                            MontoAPagar = 2500,  // Monto a pagar por mes
                            MontoPagado = 0,
                            DeudaAnterior = 0
                        };

                        db.CobrosMensuales.Add(nuevoCobro);
                    }
                }

                db.SaveChanges();  // Guarda los cambios en la base de datos
            }

            // Redirige a la acción "Index" u otra acción de tu elección
            return RedirectToAction("Index");
        }





    }


}

