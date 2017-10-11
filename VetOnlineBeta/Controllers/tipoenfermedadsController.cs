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
    public class tipoenfermedadsController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: tipoenfermedads
        public ActionResult Index()
        {
            return View(db.tipoenfermedad.ToList());
        }

        // GET: tipoenfermedads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoenfermedad tipoenfermedad = db.tipoenfermedad.Find(id);
            if (tipoenfermedad == null)
            {
                return HttpNotFound();
            }
            return View(tipoenfermedad);
        }

        // GET: tipoenfermedads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoenfermedads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_enfermedad,tipoEnf")] tipoenfermedad tipoenfermedad)
        {
            if (ModelState.IsValid)
            {
                db.tipoenfermedad.Add(tipoenfermedad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoenfermedad);
        }

        // GET: tipoenfermedads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoenfermedad tipoenfermedad = db.tipoenfermedad.Find(id);
            if (tipoenfermedad == null)
            {
                return HttpNotFound();
            }
            return View(tipoenfermedad);
        }

        // POST: tipoenfermedads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_enfermedad,tipoEnf")] tipoenfermedad tipoenfermedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoenfermedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoenfermedad);
        }

        // GET: tipoenfermedads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoenfermedad tipoenfermedad = db.tipoenfermedad.Find(id);
            if (tipoenfermedad == null)
            {
                return HttpNotFound();
            }
            return View(tipoenfermedad);
        }

        // POST: tipoenfermedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoenfermedad tipoenfermedad = db.tipoenfermedad.Find(id);
            db.tipoenfermedad.Remove(tipoenfermedad);
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
