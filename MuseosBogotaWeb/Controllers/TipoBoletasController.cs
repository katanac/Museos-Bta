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
    public class TipoBoletasController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: TipoBoletas
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoBoleta.ToListAsync());
        }

        // GET: TipoBoletas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBoleta tipoBoleta = await db.TipoBoleta.FindAsync(id);
            if (tipoBoleta == null)
            {
                return HttpNotFound();
            }
            return View(tipoBoleta);
        }

        // GET: TipoBoletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoBoletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTipoBoleta,NombreTipoEvento")] TipoBoleta tipoBoleta)
        {
            if (ModelState.IsValid)
            {
                db.TipoBoleta.Add(tipoBoleta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoBoleta);
        }

        // GET: TipoBoletas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBoleta tipoBoleta = await db.TipoBoleta.FindAsync(id);
            if (tipoBoleta == null)
            {
                return HttpNotFound();
            }
            return View(tipoBoleta);
        }

        // POST: TipoBoletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTipoBoleta,NombreTipoEvento")] TipoBoleta tipoBoleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoBoleta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoBoleta);
        }

        // GET: TipoBoletas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBoleta tipoBoleta = await db.TipoBoleta.FindAsync(id);
            if (tipoBoleta == null)
            {
                return HttpNotFound();
            }
            return View(tipoBoleta);
        }

        // POST: TipoBoletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoBoleta tipoBoleta = await db.TipoBoleta.FindAsync(id);
            db.TipoBoleta.Remove(tipoBoleta);
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
