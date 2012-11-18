using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicacionTickets.Models;

namespace AplicacionTickets.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class EspectaculoController : Controller
    {
        private TicketsDB db = new TicketsDB();

        //
        // GET: /Espectaculo/

        public ActionResult Index()
        {
            var espectaculos = db.Espectaculos.Include(e => e.Lugar).Include(e => e.Artista);
            return View(espectaculos.ToList());
        }

        //
        // GET: /Espectaculo/Details/5

        public ActionResult Details(int id = 0)
        {
            Espectaculo espectaculo = db.Espectaculos.Find(id);
            if (espectaculo == null)
            {
                return HttpNotFound();
            }
            return View(espectaculo);
        }

        //
        // GET: /Espectaculo/Create

        public ActionResult Create()
        {
            ViewBag.LugarId = new SelectList(db.Lugares, "LugarId", "Nombre");
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre");
            return View();
        }

        //
        // POST: /Espectaculo/Create

        [HttpPost]
        public ActionResult Create(Espectaculo espectaculo)
        {
            if (ModelState.IsValid)
            {
                db.Espectaculos.Add(espectaculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LugarId = new SelectList(db.Lugares, "LugarId", "Nombre", espectaculo.LugarId);
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre", espectaculo.ArtistaId);
            return View(espectaculo);
        }

        //
        // GET: /Espectaculo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Espectaculo espectaculo = db.Espectaculos.Find(id);
            if (espectaculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.LugarId = new SelectList(db.Lugares, "LugarId", "Nombre", espectaculo.LugarId);
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre", espectaculo.ArtistaId);
            return View(espectaculo);
        }

        //
        // POST: /Espectaculo/Edit/5

        [HttpPost]
        public ActionResult Edit(Espectaculo espectaculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(espectaculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LugarId = new SelectList(db.Lugares, "LugarId", "Nombre", espectaculo.LugarId);
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre", espectaculo.ArtistaId);
            return View(espectaculo);
        }

        //
        // GET: /Espectaculo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Espectaculo espectaculo = db.Espectaculos.Find(id);
            if (espectaculo == null)
            {
                return HttpNotFound();
            }
            return View(espectaculo);
        }

        //
        // POST: /Espectaculo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Espectaculo espectaculo = db.Espectaculos.Find(id);
            db.Espectaculos.Remove(espectaculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}