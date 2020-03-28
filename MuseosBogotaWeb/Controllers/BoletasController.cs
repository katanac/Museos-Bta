using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MuseosBogotaWeb;
using MuseosBogotaWeb.Contexto;

namespace MuseosBogotaWeb.Controllers
{
    public class BoletasController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: Boletas
        public async Task<ActionResult> Index()
        {
            var boleta = db.Boleta.Include(b => b.TipoBoleta);
            return View(await boleta.ToListAsync());
        }

        // GET: Boletas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleta boleta = await db.Boleta.FindAsync(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // GET: Boletas/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoBoleta = new SelectList(db.TipoBoleta, "IdTipoBoleta", "NombreTipoEvento");
            return View();
        }

        // POST: Boletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idBoleta,NombreBoleta,IdTipoBoleta")] Boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.Boleta.Add(boleta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoBoleta = new SelectList(db.TipoBoleta, "IdTipoBoleta", "NombreTipoEvento", boleta.IdTipoBoleta);
            return View(boleta);
        }

        // GET: Boletas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleta boleta = await db.Boleta.FindAsync(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoBoleta = new SelectList(db.TipoBoleta, "IdTipoBoleta", "NombreTipoEvento", boleta.IdTipoBoleta);
            return View(boleta);
        }

        // POST: Boletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idBoleta,NombreBoleta,IdTipoBoleta")] Boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoBoleta = new SelectList(db.TipoBoleta, "IdTipoBoleta", "NombreTipoEvento", boleta.IdTipoBoleta);
            return View(boleta);
        }

        // GET: Boletas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleta boleta = await db.Boleta.FindAsync(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: Boletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Boleta boleta = await db.Boleta.FindAsync(id);
            db.Boleta.Remove(boleta);
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
