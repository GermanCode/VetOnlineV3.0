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
    public class serviciosController : Controller
    {
        private vetonline3Entities db = new vetonline3Entities();

        // GET: servicios
        public ActionResult Index()
        {
            var servicio = db.servicio.Include(s => s.cliente).Include(s => s.docente).Include(s => s.enfermedades).Include(s => s.evaluacion_servicio).Include(s => s.horas).Include(s => s.mascota).Include(s => s.medicacion);
            return View(servicio.ToList());
        }

        // GET: servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio servicio = db.servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: servicios/Create
        public ActionResult Create()
        {
            ViewBag.fkCliente = new SelectList(db.cliente, "id_cliente", "id_cliente");
            ViewBag.fkMedico = new SelectList(db.docente, "idDocente", "idDocente");
            ViewBag.fkEnfermedad = new SelectList(db.enfermedades, "idEnfermedad", "descEnfermedad");
            ViewBag.idServicio = new SelectList(db.evaluacion_servicio, "idEvaServ", "idEvaServ");
            ViewBag.fkHora = new SelectList(db.horas, "idHora", "estadoh");
            ViewBag.fkMascota = new SelectList(db.mascota, "idMascota", "idMascota");
            ViewBag.idServicio = new SelectList(db.medicacion, "id_medicacion_servicio", "Medicamento");
            return View();
        }

        // POST: servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicio,fkCliente,fkMedico,fkMascota,Estado,Descripcion,fecha_servicio,fkEnfermedad,fkHora")] servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkCliente = new SelectList(db.cliente, "id_cliente", "id_cliente", servicio.fkCliente);
            ViewBag.fkMedico = new SelectList(db.docente, "idDocente", "idDocente", servicio.fkMedico);
            ViewBag.fkEnfermedad = new SelectList(db.enfermedades, "idEnfermedad", "descEnfermedad", servicio.fkEnfermedad);
            ViewBag.idServicio = new SelectList(db.evaluacion_servicio, "idEvaServ", "idEvaServ", servicio.idServicio);
            ViewBag.fkHora = new SelectList(db.horas, "idHora", "estadoh", servicio.fkHora);
            ViewBag.fkMascota = new SelectList(db.mascota, "idMascota", "idMascota", servicio.fkMascota);
            ViewBag.idServicio = new SelectList(db.medicacion, "id_medicacion_servicio", "Medicamento", servicio.idServicio);
            return View(servicio);
        }

        // GET: servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio servicio = db.servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkCliente = new SelectList(db.cliente, "id_cliente", "id_cliente", servicio.fkCliente);
            ViewBag.fkMedico = new SelectList(db.docente, "idDocente", "idDocente", servicio.fkMedico);
            ViewBag.fkEnfermedad = new SelectList(db.enfermedades, "idEnfermedad", "descEnfermedad", servicio.fkEnfermedad);
            ViewBag.idServicio = new SelectList(db.evaluacion_servicio, "idEvaServ", "idEvaServ", servicio.idServicio);
            ViewBag.fkHora = new SelectList(db.horas, "idHora", "estadoh", servicio.fkHora);
            ViewBag.fkMascota = new SelectList(db.mascota, "idMascota", "idMascota", servicio.fkMascota);
            ViewBag.idServicio = new SelectList(db.medicacion, "id_medicacion_servicio", "Medicamento", servicio.idServicio);
            return View(servicio);
        }

        // POST: servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicio,fkCliente,fkMedico,fkMascota,Estado,Descripcion,fecha_servicio,fkEnfermedad,fkHora")] servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkCliente = new SelectList(db.cliente, "id_cliente", "id_cliente", servicio.fkCliente);
            ViewBag.fkMedico = new SelectList(db.docente, "idDocente", "idDocente", servicio.fkMedico);
            ViewBag.fkEnfermedad = new SelectList(db.enfermedades, "idEnfermedad", "descEnfermedad", servicio.fkEnfermedad);
            ViewBag.idServicio = new SelectList(db.evaluacion_servicio, "idEvaServ", "idEvaServ", servicio.idServicio);
            ViewBag.fkHora = new SelectList(db.horas, "idHora", "estadoh", servicio.fkHora);
            ViewBag.fkMascota = new SelectList(db.mascota, "idMascota", "idMascota", servicio.fkMascota);
            ViewBag.idServicio = new SelectList(db.medicacion, "id_medicacion_servicio", "Medicamento", servicio.idServicio);
            return View(servicio);
        }

        // GET: servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio servicio = db.servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicio servicio = db.servicio.Find(id);
            db.servicio.Remove(servicio);
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
