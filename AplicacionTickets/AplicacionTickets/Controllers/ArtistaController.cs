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
    public class ArtistaController : Controller
    {
        private TicketsDB db = new TicketsDB();

        //
        // GET: /Artista/

        public ActionResult Index()
        {
            return View(db.Artistas.ToList());
        }

        //
        // GET: /Artista/Details/5

        public ActionResult Details(int id = 0)
        {
            Artista artista = db.Artistas.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        //
        // GET: /Artista/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artista/Create

        [HttpPost]
        public ActionResult Create(Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Artistas.Add(artista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artista);
        }

        //
        // GET: /Artista/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artista artista = db.Artistas.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        //
        // POST: /Artista/Edit/5

        [HttpPost]
        public ActionResult Edit(Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artista);
        }

        //
        // GET: /Artista/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artista artista = db.Artistas.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        //
        // POST: /Artista/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Artista artista = db.Artistas.Find(id);
            db.Artistas.Remove(artista);
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