using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MuseosBogotaWeb.Contexto;

namespace MuseosBogotaWeb.Controllers
{
    public class ReservasController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: Reservas
        public async Task<ActionResult> Index()
        {
            var reservas = db.Reservas.Include(r => r.Factura).Include(r => r.TipoEvento).Include(r => r.Usuario);
            return View(await reservas.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = await db.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.idFactura = new SelectList(db.Factura, "IdFactura", "IdFactura");
            ViewBag.IdEvento = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento");
            ViewBag.Idusuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdReserva,FechaReserva,numeroBoletas,IdEvento,Idusuario,idFactura")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reservas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", reservas.idFactura);
            ViewBag.IdEvento = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento", reservas.IdEvento);
            ViewBag.Idusuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", reservas.Idusuario);
            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = await db.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", reservas.idFactura);
            ViewBag.IdEvento = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento", reservas.IdEvento);
            ViewBag.Idusuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", reservas.Idusuario);
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdReserva,FechaReserva,numeroBoletas,IdEvento,Idusuario,idFactura")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", reservas.idFactura);
            ViewBag.IdEvento = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento", reservas.IdEvento);
            ViewBag.Idusuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", reservas.Idusuario);
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = await db.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservas reservas = await db.Reservas.FindAsync(id);
            db.Reservas.Remove(reservas);
            await db.SaveChangesAsync();
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
