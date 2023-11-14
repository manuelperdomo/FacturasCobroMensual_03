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
    public class PagosRealizadosController : Controller
    {
        private Factura_01Entities1 db = new Factura_01Entities1();    



        // GET: PagosRealizados
        public ActionResult Index()
        {
            var pagosRealizados = db.PagosRealizados.Include(p => p.Adm).Include(p => p.Año).Include(p => p.Casas).Include(p => p.Meses).Include(p => p.Residentes);
            return View(pagosRealizados.ToList());
        }

        // GET: PagosRealizados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagosRealizados pagosRealizados = db.PagosRealizados.Find(id);
            if (pagosRealizados == null)
            {
                return HttpNotFound();
            }
            return View(pagosRealizados);
        }

        // GET: PagosRealizados/Create
        public ActionResult Create()
        {
            ViewBag.IDAtendidoPor = new SelectList(db.Adm, "IDAdm", "Nombre");
            ViewBag.IDAño = new SelectList(db.Año, "IDAño", "NumeroAño");
            ViewBag.IDCasas = new SelectList(db.Casas, "IDCasa", "NumeroCasa");
            ViewBag.IDMeses = new SelectList(db.Meses, "IDMes", "NombreMes");
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre");
            return View();
        }

        // POST: PagosRealizados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPago,IDResidente,IDCasas,IDAtendidoPor,FechaPago,Monto,Descripcion,IDMeses,IDAño,MesesPagoPrueba")] PagosRealizados pagosRealizados)
        {
            if (ModelState.IsValid)
            {
                db.PagosRealizados.Add(pagosRealizados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAtendidoPor = new SelectList(db.Adm, "IDAdm", "Nombre", pagosRealizados.IDAtendidoPor);
            ViewBag.IDAño = new SelectList(db.Año, "IDAño", "NumeroAño", pagosRealizados.IDAño);
            ViewBag.IDCasas = new SelectList(db.Casas, "IDCasa", "NumeroCasa", pagosRealizados.IDCasas);
            ViewBag.IDMeses = new SelectList(db.Meses, "IDMes", "NombreMes", pagosRealizados.IDMeses);
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", pagosRealizados.IDResidente);
            return View(pagosRealizados);
        }

        // GET: PagosRealizados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagosRealizados pagosRealizados = db.PagosRealizados.Find(id);
            if (pagosRealizados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAtendidoPor = new SelectList(db.Adm, "IDAdm", "Nombre", pagosRealizados.IDAtendidoPor);
            ViewBag.IDAño = new SelectList(db.Año, "IDAño", "NumeroAño", pagosRealizados.IDAño);
            ViewBag.IDCasas = new SelectList(db.Casas, "IDCasa", "NumeroCasa", pagosRealizados.IDCasas);
            ViewBag.IDMeses = new SelectList(db.Meses, "IDMes", "NombreMes", pagosRealizados.IDMeses);
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", pagosRealizados.IDResidente);
            return View(pagosRealizados);
        }

        // POST: PagosRealizados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPago,IDResidente,IDCasas,IDAtendidoPor,FechaPago,Monto,Descripcion,IDMeses,IDAño,MesesPagoPrueba")] PagosRealizados pagosRealizados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagosRealizados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAtendidoPor = new SelectList(db.Adm, "IDAdm", "Nombre", pagosRealizados.IDAtendidoPor);
            ViewBag.IDAño = new SelectList(db.Año, "IDAño", "NumeroAño", pagosRealizados.IDAño);
            ViewBag.IDCasas = new SelectList(db.Casas, "IDCasa", "NumeroCasa", pagosRealizados.IDCasas);
            ViewBag.IDMeses = new SelectList(db.Meses, "IDMes", "NombreMes", pagosRealizados.IDMeses);
            ViewBag.IDResidente = new SelectList(db.Residentes, "IDResidente", "Nombre", pagosRealizados.IDResidente);
            return View(pagosRealizados);
        }

        // GET: PagosRealizados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagosRealizados pagosRealizados = db.PagosRealizados.Find(id);
            if (pagosRealizados == null)
            {
                return HttpNotFound();
            }
            return View(pagosRealizados);
        }

        // POST: PagosRealizados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagosRealizados pagosRealizados = db.PagosRealizados.Find(id);
            db.PagosRealizados.Remove(pagosRealizados);
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

        public ActionResult RealizarCobroMensualIndividual(int idResidente, decimal montoPago)
        {
            // Obtener el mes actual
            DateTime mesActual = DateTime.Now;

            // Buscar el residente por su ID
            var residente = db.Residentes.Include(r => r.Casas).FirstOrDefault(r => r.IDResidente == idResidente);

            if (residente != null)
            {
                // Obtener el ID del residente y su casa
                var casaDelResidente = db.Casas.FirstOrDefault(c => c.IDResidente == idResidente);

                // Verificar si ya existe un registro para este mes en CobrosMensuales
                var cobroMensualExistente = db.CobrosMensuales.FirstOrDefault(c => c.IDResidente == idResidente && c.Mes.Year == mesActual.Year && c.Mes.Month == mesActual.Month);

                if (cobroMensualExistente == null)
                {
                    // Si no existe, crear un nuevo registro en CobrosMensuales
                    var nuevoCobroMensual = new CobrosMensuales
                    {
                        IDResidente = idResidente,
                        // Crear un objeto DateTime con la fecha actual
                        Mes = new DateTime(mesActual.Year, mesActual.Month, 1), // Día 1 asumiendo que es el primer día del mes
                        MontoAPagar = 2500, // Monto fijo mensual
                        MontoPagado = 0,   // Inicialmente no ha pagado
                        DeudaAnterior = 0  // Inicialmente sin deuda anterior
                    };

                    db.CobrosMensuales.Add(nuevoCobroMensual);
                    db.SaveChanges();

                    cobroMensualExistente = nuevoCobroMensual;
                }

                // Calcular el monto total a pagar (incluyendo la deuda anterior)
                decimal montoTotalAPagar = cobroMensualExistente.MontoAPagar + cobroMensualExistente.DeudaAnterior;

                // Realizar el pago
                decimal pagoDelResidente = montoPago; // Usar el monto pasado como parámetro

                if (pagoDelResidente >= montoTotalAPagar)
                {
                    // El residente ha pagado lo que debía
                    cobroMensualExistente.MontoPagado = montoTotalAPagar;
                    cobroMensualExistente.DeudaAnterior = 0; // No hay deuda pendiente
                }
                else
                {
                    // El residente ha pagado parcialmente
                    cobroMensualExistente.MontoPagado = pagoDelResidente;
                    cobroMensualExistente.DeudaAnterior = montoTotalAPagar - pagoDelResidente;
                }

                // Actualizar la información en CobrosMensuales
                db.Entry(cobroMensualExistente).State = EntityState.Modified;
                db.SaveChanges();

                // Registra el abono si el residente paga en exceso
                if (pagoDelResidente > montoTotalAPagar)
                {
                    decimal excesoPago = pagoDelResidente - montoTotalAPagar;

                    var abono = new PagosRealizados
                    {
                        IDResidente = idResidente,
                        IDCasas = casaDelResidente?.IDCasa,
                        FechaPago = DateTime.Now,
                        Monto = excesoPago,
                        Descripcion = "Abono"
                    };

                    db.PagosRealizados.Add(abono);
                    db.SaveChanges();
                }
            }

            // Después de procesar el pago, redirige al usuario a una vista de confirmación o a donde desees.
            return RedirectToAction("index");
        }






    }
}
