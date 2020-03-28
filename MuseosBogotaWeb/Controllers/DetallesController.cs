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
    public class DetallesController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: Detalles
        public async Task<ActionResult> Index()
        {
            var detalle = db.Detalle.Include(d => d.Factura);
            return View(await detalle.ToListAsync());
        }

        // GET: Detalles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = await db.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura");
            return View();
        }

        // POST: Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDetalle,DescripcionCompra,IdBoleta,IdFactura,valorCompra")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Detalle.Add(detalle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", detalle.IdFactura);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = await db.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", detalle.IdFactura);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDetalle,DescripcionCompra,IdBoleta,IdFactura,valorCompra")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "IdFactura", detalle.IdFactura);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = await db.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Detalle detalle = await db.Detalle.FindAsync(id);
            db.Detalle.Remove(detalle);
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
