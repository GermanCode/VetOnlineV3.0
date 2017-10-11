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
    public class mascotasController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: mascotas
        public ActionResult Index()
        {
            var mascota = db.mascota.Include(m => m.persona).Include(m => m.raza1).Include(m => m.tipomascota);
            return View(mascota.ToList());
        }

        // GET: mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: mascotas/Create
        public ActionResult Create()
        {
            ViewBag.fkPersona = new SelectList(db.persona, "Identificacion", "Nombres");
            ViewBag.Raza = new SelectList(db.raza, "idRaza", "DescRaza");
            ViewBag.tipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc");
            return View();
        }

        // POST: mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMascota,fkPersona,nombreMasc,tipoMasc,Raza,fecha_nacimiento")] mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.mascota.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkPersona = new SelectList(db.persona, "Identificacion", "Nombres", mascota.fkPersona);
            ViewBag.Raza = new SelectList(db.raza, "idRaza", "DescRaza", mascota.Raza);
            ViewBag.tipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc", mascota.tipoMasc);
            return View(mascota);
        }

        // GET: mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkPersona = new SelectList(db.persona, "Identificacion", "Nombres", mascota.fkPersona);
            ViewBag.Raza = new SelectList(db.raza, "idRaza", "DescRaza", mascota.Raza);
            ViewBag.tipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc", mascota.tipoMasc);
            return View(mascota);
        }

        // POST: mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMascota,fkPersona,nombreMasc,tipoMasc,Raza,fecha_nacimiento")] mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkPersona = new SelectList(db.persona, "Identificacion", "Nombres", mascota.fkPersona);
            ViewBag.Raza = new SelectList(db.raza, "idRaza", "DescRaza", mascota.Raza);
            ViewBag.tipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc", mascota.tipoMasc);
            return View(mascota);
        }

        // GET: mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mascota mascota = db.mascota.Find(id);
            db.mascota.Remove(mascota);
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
