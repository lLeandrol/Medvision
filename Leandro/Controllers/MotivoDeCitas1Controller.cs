using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Leandro.Models;

namespace Leandro.Controllers
{
    public class MotivoDeCitas1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: MotivoDeCitas1
        public ActionResult Index()
        {
            return View(db.MotivoDeCita.ToList());
        }

        // GET: MotivoDeCitas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoDeCita motivoDeCita = db.MotivoDeCita.Find(id);
            if (motivoDeCita == null)
            {
                return HttpNotFound();
            }
            return View(motivoDeCita);
        }

        // GET: MotivoDeCitas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotivoDeCitas1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EstadoPaciente,Descripcion")] MotivoDeCita motivoDeCita)
        {
            if (ModelState.IsValid)
            {
                db.MotivoDeCita.Add(motivoDeCita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motivoDeCita);
        }

        // GET: MotivoDeCitas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoDeCita motivoDeCita = db.MotivoDeCita.Find(id);
            if (motivoDeCita == null)
            {
                return HttpNotFound();
            }
            return View(motivoDeCita);
        }

        // POST: MotivoDeCitas1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EstadoPaciente,Descripcion")] MotivoDeCita motivoDeCita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motivoDeCita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motivoDeCita);
        }

        // GET: MotivoDeCitas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoDeCita motivoDeCita = db.MotivoDeCita.Find(id);
            if (motivoDeCita == null)
            {
                return HttpNotFound();
            }
            return View(motivoDeCita);
        }

        // POST: MotivoDeCitas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotivoDeCita motivoDeCita = db.MotivoDeCita.Find(id);
            db.MotivoDeCita.Remove(motivoDeCita);
            db.SaveChanges();
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
