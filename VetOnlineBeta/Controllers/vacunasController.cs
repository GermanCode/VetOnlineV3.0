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
    public class vacunasController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: vacunas
        public ActionResult Index()
        {
            return View(db.vacunas.ToList());
        }

        // GET: vacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacunas vacunas = db.vacunas.Find(id);
            if (vacunas == null)
            {
                return HttpNotFound();
            }
            return View(vacunas);
        }

        // GET: vacunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vacunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVacuna,fkTipoEnfermedad,descVacuna")] vacunas vacunas)
        {
            if (ModelState.IsValid)
            {
                db.vacunas.Add(vacunas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacunas);
        }

        // GET: vacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacunas vacunas = db.vacunas.Find(id);
            if (vacunas == null)
            {
                return HttpNotFound();
            }
            return View(vacunas);
        }

        // POST: vacunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVacuna,fkTipoEnfermedad,descVacuna")] vacunas vacunas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacunas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacunas);
        }

        // GET: vacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacunas vacunas = db.vacunas.Find(id);
            if (vacunas == null)
            {
                return HttpNotFound();
            }
            return View(vacunas);
        }

        // POST: vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vacunas vacunas = db.vacunas.Find(id);
            db.vacunas.Remove(vacunas);
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
