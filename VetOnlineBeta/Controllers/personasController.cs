﻿using System;
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
    public class personasController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: personas
        public ActionResult Index()
        {
            var persona = db.persona.Include(p => p.docente).Include(p => p.estudiante);
            return View(persona.ToList());
        }

        // GET: personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: personas/Create
        public ActionResult Create()
        {
            ViewBag.Identificacion = new SelectList(db.docente, "idDocente", "idDocente");
            ViewBag.Identificacion = new SelectList(db.estudiante, "idEstudiante", "idEstudiante");
            return View();
        }

        // POST: personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificacion,Nombres,Apellidos,fkRol")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Identificacion = new SelectList(db.docente, "idDocente", "idDocente", persona.Identificacion);
            ViewBag.Identificacion = new SelectList(db.estudiante, "idEstudiante", "idEstudiante", persona.Identificacion);
            return View(persona);
        }

        // GET: personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.Identificacion = new SelectList(db.docente, "idDocente", "idDocente", persona.Identificacion);
            ViewBag.Identificacion = new SelectList(db.estudiante, "idEstudiante", "idEstudiante", persona.Identificacion);
            return View(persona);
        }

        // POST: personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificacion,Nombres,Apellidos,fkRol")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Identificacion = new SelectList(db.docente, "idDocente", "idDocente", persona.Identificacion);
            ViewBag.Identificacion = new SelectList(db.estudiante, "idEstudiante", "idEstudiante", persona.Identificacion);
            return View(persona);
        }

        // GET: personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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
