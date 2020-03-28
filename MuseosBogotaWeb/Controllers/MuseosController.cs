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
    public class MuseosController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: Museos
        public async Task<ActionResult> Index()
        {
            return View(await db.Museo.ToListAsync());
        }

        // GET: Museos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museo museo = await db.Museo.FindAsync(id);
            if (museo == null)
            {
                return HttpNotFound();
            }
            return View(museo);
        }

        // GET: Museos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Museos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMuseo,Nombre,Telefono,Direccion")] Museo museo)
        {
            if (ModelState.IsValid)
            {
                db.Museo.Add(museo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(museo);
        }

        // GET: Museos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museo museo = await db.Museo.FindAsync(id);
            if (museo == null)
            {
                return HttpNotFound();
            }
            return View(museo);
        }

        // POST: Museos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMuseo,Nombre,Telefono,Direccion")] Museo museo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(museo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(museo);
        }

        // GET: Museos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museo museo = await db.Museo.FindAsync(id);
            if (museo == null)
            {
                return HttpNotFound();
            }
            return View(museo);
        }

        // POST: Museos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Museo museo = await db.Museo.FindAsync(id);
            db.Museo.Remove(museo);
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
