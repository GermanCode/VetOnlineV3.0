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
    public class razasController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: razas
        public ActionResult Index()
        {
            var raza = db.raza.Include(r => r.tipomascota);
            return View(raza.ToList());
        }

        // GET: razas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            raza raza = db.raza.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // GET: razas/Create
        public ActionResult Create()
        {
            ViewBag.fkTipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc");
            return View();
        }

        // POST: razas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRaza,fkTipoMasc,DescRaza")] raza raza)
        {
            if (ModelState.IsValid)
            {
                db.raza.Add(raza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkTipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc", raza.fkTipoMasc);
            return View(raza);
        }

        // GET: razas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            raza raza = db.raza.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkTipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc", raza.fkTipoMasc);
            return View(raza);
        }

        // POST: razas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRaza,fkTipoMasc,DescRaza")] raza raza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkTipoMasc = new SelectList(db.tipomascota, "idTipoMascota", "descTipoMasc", raza.fkTipoMasc);
            return View(raza);
        }

        // GET: razas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            raza raza = db.raza.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // POST: razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            raza raza = db.raza.Find(id);
            db.raza.Remove(raza);
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
