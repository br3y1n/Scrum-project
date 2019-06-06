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
    public class ACTIVITiesController : Controller
    {
        private GESTOR_DE_ACTIVIDADESEntities db = new GESTOR_DE_ACTIVIDADESEntities();

        // GET: ACTIVITies
        public ActionResult Index()
        {
            return View(db.ACTIVITY.ToList());
        }

        // GET: ACTIVITies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            if (aCTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITY);
        }

        // GET: ACTIVITies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACTIVITies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "act_code,act_description,act_date_delivery")] ACTIVITY aCTIVITY)
        {
            if (ModelState.IsValid)
            {
                db.ACTIVITY.Add(aCTIVITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVITY);
        }

        // GET: ACTIVITies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            if (aCTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITY);
        }

        // POST: ACTIVITies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "act_code,act_description,act_date_delivery")] ACTIVITY aCTIVITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVITY);
        }

        // GET: ACTIVITies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            if (aCTIVITY == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITY);
        }

        // POST: ACTIVITies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACTIVITY aCTIVITY = db.ACTIVITY.Find(id);
            db.ACTIVITY.Remove(aCTIVITY);
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
