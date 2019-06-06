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
    public class TEAM_PROJECTController : Controller
    {
        private GESTOR_DE_ACTIVIDADESEntities db = new GESTOR_DE_ACTIVIDADESEntities();

        // GET: TEAM_PROJECT
        public ActionResult Index()
        {
            var tEAM_PROJECT = db.TEAM_PROJECT.Include(t => t.ACTIVITY).Include(t => t.WORKERS);
            return View(tEAM_PROJECT.ToList());
        }

        // GET: TEAM_PROJECT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM_PROJECT tEAM_PROJECT = db.TEAM_PROJECT.Find(id);
            if (tEAM_PROJECT == null)
            {
                return HttpNotFound();
            }
            return View(tEAM_PROJECT);
        }

        // GET: TEAM_PROJECT/Create
        public ActionResult Create()
        {
            ViewBag.act_code = new SelectList(db.ACTIVITY, "act_code", "act_description");
            ViewBag.wok_code = new SelectList(db.WORKERS, "wok_code", "wok_name");
            return View();
        }

        // POST: TEAM_PROJECT/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tpr_ncode,tpr_name,wok_code,act_code")] TEAM_PROJECT tEAM_PROJECT)
        {
            if (ModelState.IsValid)
            {
                db.TEAM_PROJECT.Add(tEAM_PROJECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.act_code = new SelectList(db.ACTIVITY, "act_code", "act_description", tEAM_PROJECT.act_code);
            ViewBag.wok_code = new SelectList(db.WORKERS, "wok_code", "wok_name", tEAM_PROJECT.wok_code);
            return View(tEAM_PROJECT);
        }

        // GET: TEAM_PROJECT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM_PROJECT tEAM_PROJECT = db.TEAM_PROJECT.Find(id);
            if (tEAM_PROJECT == null)
            {
                return HttpNotFound();
            }
            ViewBag.act_code = new SelectList(db.ACTIVITY, "act_code", "act_description", tEAM_PROJECT.act_code);
            ViewBag.wok_code = new SelectList(db.WORKERS, "wok_code", "wok_name", tEAM_PROJECT.wok_code);
            return View(tEAM_PROJECT);
        }

        // POST: TEAM_PROJECT/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tpr_ncode,tpr_name,wok_code,act_code")] TEAM_PROJECT tEAM_PROJECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEAM_PROJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.act_code = new SelectList(db.ACTIVITY, "act_code", "act_description", tEAM_PROJECT.act_code);
            ViewBag.wok_code = new SelectList(db.WORKERS, "wok_code", "wok_name", tEAM_PROJECT.wok_code);
            return View(tEAM_PROJECT);
        }

        // GET: TEAM_PROJECT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM_PROJECT tEAM_PROJECT = db.TEAM_PROJECT.Find(id);
            if (tEAM_PROJECT == null)
            {
                return HttpNotFound();
            }
            return View(tEAM_PROJECT);
        }

        // POST: TEAM_PROJECT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEAM_PROJECT tEAM_PROJECT = db.TEAM_PROJECT.Find(id);
            db.TEAM_PROJECT.Remove(tEAM_PROJECT);
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
