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
    public class TipoEventoesController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: TipoEventoes
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoEvento.ToListAsync());
        }

        // GET: TipoEventoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvento tipoEvento = await db.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvento);
        }

        // GET: TipoEventoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEventoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTipo,NombreTipoEvento")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                db.TipoEvento.Add(tipoEvento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoEvento);
        }

        // GET: TipoEventoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvento tipoEvento = await db.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEventoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTipo,NombreTipoEvento")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEvento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEvento);
        }

        // GET: TipoEventoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvento tipoEvento = await db.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoEvento tipoEvento = await db.TipoEvento.FindAsync(id);
            db.TipoEvento.Remove(tipoEvento);
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
