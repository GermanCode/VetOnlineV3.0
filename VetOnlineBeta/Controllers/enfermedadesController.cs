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
    public class enfermedadesController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: enfermedades
        public ActionResult Index()
        {
            var enfermedades = db.enfermedades.Include(e => e.tipoenfermedad);
            return View(enfermedades.ToList());
        }

        // GET: enfermedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermedades enfermedades = db.enfermedades.Find(id);
            if (enfermedades == null)
            {
                return HttpNotFound();
            }
            return View(enfermedades);
        }

        // GET: enfermedades/Create
        public ActionResult Create()
        {
            ViewBag.fkTipoEnf = new SelectList(db.tipoenfermedad, "id_tipo_enfermedad", "tipoEnf");
            return View();
        }

        // POST: enfermedades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEnfermedad,descEnfermedad,fkTipoEnf")] enfermedades enfermedades)
        {
            if (ModelState.IsValid)
            {
                db.enfermedades.Add(enfermedades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkTipoEnf = new SelectList(db.tipoenfermedad, "id_tipo_enfermedad", "tipoEnf", enfermedades.fkTipoEnf);
            return View(enfermedades);
        }

        // GET: enfermedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermedades enfermedades = db.enfermedades.Find(id);
            if (enfermedades == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkTipoEnf = new SelectList(db.tipoenfermedad, "id_tipo_enfermedad", "tipoEnf", enfermedades.fkTipoEnf);
            return View(enfermedades);
        }

        // POST: enfermedades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEnfermedad,descEnfermedad,fkTipoEnf")] enfermedades enfermedades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermedades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkTipoEnf = new SelectList(db.tipoenfermedad, "id_tipo_enfermedad", "tipoEnf", enfermedades.fkTipoEnf);
            return View(enfermedades);
        }

        // GET: enfermedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermedades enfermedades = db.enfermedades.Find(id);
            if (enfermedades == null)
            {
                return HttpNotFound();
            }
            return View(enfermedades);
        }

        // POST: enfermedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enfermedades enfermedades = db.enfermedades.Find(id);
            db.enfermedades.Remove(enfermedades);
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
