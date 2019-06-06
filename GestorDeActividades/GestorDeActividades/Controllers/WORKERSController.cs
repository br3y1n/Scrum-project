using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestorDeActividades.Models;

namespace GestorDeActividades.Controllers
{
    public class WORKERSController : Controller
    {
        private GESTOR_DE_ACTIVIDADESEntities db = new GESTOR_DE_ACTIVIDADESEntities();

        // GET: WORKERS
        public ActionResult Index()
        {
            var wORKERS = db.WORKERS.Include(w => w.ROLES);
            return View(wORKERS.ToList());
        }

        // GET: WORKERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKERS wORKERS = db.WORKERS.Find(id);
            if (wORKERS == null)
            {
                return HttpNotFound();
            }
            return View(wORKERS);
        }

        // GET: WORKERS/Create
        public ActionResult Create()
        {
            ViewBag.rol_code = new SelectList(db.ROLES, "rol_code", "rol_name");
            return View();
        }

        // POST: WORKERS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wok_code,wok_name,rol_code")] WORKERS wORKERS)
        {
            if (ModelState.IsValid)
            {
                db.WORKERS.Add(wORKERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rol_code = new SelectList(db.ROLES, "rol_code", "rol_name", wORKERS.rol_code);
            return View(wORKERS);
        }

        // GET: WORKERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKERS wORKERS = db.WORKERS.Find(id);
            if (wORKERS == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol_code = new SelectList(db.ROLES, "rol_code", "rol_name", wORKERS.rol_code);
            return View(wORKERS);
        }

        // POST: WORKERS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wok_code,wok_name,rol_code")] WORKERS wORKERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wORKERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rol_code = new SelectList(db.ROLES, "rol_code", "rol_name", wORKERS.rol_code);
            return View(wORKERS);
        }

        // GET: WORKERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKERS wORKERS = db.WORKERS.Find(id);
            if (wORKERS == null)
            {
                return HttpNotFound();
            }
            return View(wORKERS);
        }

        // POST: WORKERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WORKERS wORKERS = db.WORKERS.Find(id);
            db.WORKERS.Remove(wORKERS);
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
