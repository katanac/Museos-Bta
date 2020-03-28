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
    public class EventoesController : Controller
    {
        private ModelMuseos db = new ModelMuseos();

        // GET: Eventoes
        public async Task<ActionResult> Index()
        {
            var evento = db.Evento.Include(e => e.Museo).Include(e => e.TipoEvento);
            return View(await evento.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = await db.Evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventoes/Create
        public ActionResult Create()
        {
            ViewBag.IdMuseo = new SelectList(db.Museo, "IdMuseo", "Nombre");
            ViewBag.IdTipo = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento");
            return View();
        }

        // POST: Eventoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Idevento,NombreEvento,Fecha,CantidadAsistentes,IdMuseo,IdTipo")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Evento.Add(evento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdMuseo = new SelectList(db.Museo, "IdMuseo", "Nombre", evento.IdMuseo);
            ViewBag.IdTipo = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento", evento.IdTipo);
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = await db.Evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMuseo = new SelectList(db.Museo, "IdMuseo", "Nombre", evento.IdMuseo);
            ViewBag.IdTipo = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento", evento.IdTipo);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Idevento,NombreEvento,Fecha,CantidadAsistentes,IdMuseo,IdTipo")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdMuseo = new SelectList(db.Museo, "IdMuseo", "Nombre", evento.IdMuseo);
            ViewBag.IdTipo = new SelectList(db.TipoEvento, "IdTipo", "NombreTipoEvento", evento.IdTipo);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = await db.Evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Evento evento = await db.Evento.FindAsync(id);
            db.Evento.Remove(evento);
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
