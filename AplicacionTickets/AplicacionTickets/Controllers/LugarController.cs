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
    public class LugarController : Controller
    {
        private TicketsDB db = new TicketsDB();

        //
        // GET: /Lugar/

        public ActionResult Index()
        {
            return View(db.Lugares.ToList());
        }

        //
        // GET: /Lugar/Details/5

        public ActionResult Details(int id = 0)
        {
            Lugar lugar = db.Lugares.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        //
        // GET: /Lugar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lugar/Create

        [HttpPost]
        public ActionResult Create(Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Lugares.Add(lugar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        //
        // GET: /Lugar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Lugar lugar = db.Lugares.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        //
        // POST: /Lugar/Edit/5

        [HttpPost]
        public ActionResult Edit(Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugar);
        }

        //
        // GET: /Lugar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Lugar lugar = db.Lugares.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        //
        // POST: /Lugar/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Lugar lugar = db.Lugares.Find(id);
            db.Lugares.Remove(lugar);
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