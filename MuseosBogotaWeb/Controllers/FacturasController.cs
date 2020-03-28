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
    public class FacturasController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: Facturas
        public async Task<ActionResult> Index()
        {
            var factura = db.Factura.Include(f => f.TipoPago).Include(f => f.Usuario);
            return View(await factura.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.idTipoPago = new SelectList(db.TipoPago, "IdTipoPago", "NombreTipoPago");
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFactura,FechaCompra,idUsuario,idTipoPago")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoPago = new SelectList(db.TipoPago, "IdTipoPago", "NombreTipoPago", factura.idTipoPago);
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", factura.idUsuario);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoPago = new SelectList(db.TipoPago, "IdTipoPago", "NombreTipoPago", factura.idTipoPago);
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", factura.idUsuario);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFactura,FechaCompra,idUsuario,idTipoPago")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoPago = new SelectList(db.TipoPago, "IdTipoPago", "NombreTipoPago", factura.idTipoPago);
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", factura.idUsuario);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Factura factura = await db.Factura.FindAsync(id);
            db.Factura.Remove(factura);
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
