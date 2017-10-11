using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VetOnlineBeta;

namespace VetOnlineBeta.Controllers
{
    public class docentesController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: docentes
        public ActionResult Index()
        {
            var docente = db.docente.Include(d => d.persona);
            return View(docente.ToList());
        }

        // GET: docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docente docente = db.docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: docentes/Create
        public ActionResult Create()
        {
            ViewBag.idDocente = new SelectList(db.persona, "Identificacion", "Nombres");
            return View();
        }

        // POST: docentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDocente,fecha_creacion_d,Telefono")] docente docente)
        {
            if (ModelState.IsValid)
            {
                db.docente.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDocente = new SelectList(db.persona, "Identificacion", "Nombres", docente.idDocente);
            return View(docente);
        }

        // GET: docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docente docente = db.docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDocente = new SelectList(db.persona, "Identificacion", "Nombres", docente.idDocente);
            return View(docente);
        }

        // POST: docentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDocente,fecha_creacion_d,Telefono")] docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDocente = new SelectList(db.persona, "Identificacion", "Nombres", docente.idDocente);
            return View(docente);
        }

        // GET: docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docente docente = db.docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            docente docente = db.docente.Find(id);
            db.docente.Remove(docente);
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
