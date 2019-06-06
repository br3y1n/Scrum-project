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
    public class PROJECTsController : Controller
    {
        private GESTOR_DE_ACTIVIDADESEntities db = new GESTOR_DE_ACTIVIDADESEntities();

        // GET: PROJECTs
        public ActionResult Index()
        {
            var pROJECT = db.PROJECT.Include(p => p.TEAM_PROJECT);
            return View(pROJECT.ToList());
        }

        // GET: PROJECTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // GET: PROJECTs/Create
        public ActionResult Create()
        {
            ViewBag.tpr_ncode = new SelectList(db.TEAM_PROJECT, "tpr_ncode", "tpr_name");
            return View();
        }

        // POST: PROJECTs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pro_ncode,pro_name,pro_initial_Date,pro_final_Date,tpr_ncode")] PROJECT pROJECT)
        {
            bool validarCampos = ValidateForm(pROJECT);            

            if (ModelState.IsValid)
            {
                if (validarCampos)
                {
                    bool validarFechas = ValidarFechas(Convert.ToDateTime(pROJECT.pro_initial_Date), Convert.ToDateTime(pROJECT.pro_final_Date));
                    if (validarFechas)
                    {
                        db.PROJECT.Add(pROJECT);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ShowSuccessAlert = true;
                        return RedirectToAction("Create");
                    }
                }
                else
                {
                    ViewBag.ShowSuccessAlert = true;
                    return RedirectToAction("Create");
                }
            }

            ViewBag.tpr_ncode = new SelectList(db.TEAM_PROJECT, "tpr_ncode", "tpr_name", pROJECT.tpr_ncode);
            return View(pROJECT);
        }

        // GET: PROJECTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            ViewBag.tpr_ncode = new SelectList(db.TEAM_PROJECT, "tpr_ncode", "tpr_name", pROJECT.tpr_ncode);
            return View(pROJECT);
        }

        // POST: PROJECTs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pro_ncode,pro_name,pro_initial_Date,pro_final_Date,tpr_ncode")] PROJECT pROJECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tpr_ncode = new SelectList(db.TEAM_PROJECT, "tpr_ncode", "tpr_name", pROJECT.tpr_ncode);
            return View(pROJECT);
        }

        // GET: PROJECTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // POST: PROJECTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECT pROJECT = db.PROJECT.Find(id);
            db.PROJECT.Remove(pROJECT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public bool ValidarFechas(DateTime InitialDate, DateTime FinalDate) {
            bool isValid = true;
            if (InitialDate > FinalDate) { isValid = false;}

            return isValid;
        }

        public bool ValidateForm(PROJECT pROJECT)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(pROJECT.pro_ncode.ToString()))
                isValid = false;
            else if (String.IsNullOrEmpty(pROJECT.pro_name))
                isValid = false;
            else if (String.IsNullOrEmpty(pROJECT.pro_initial_Date.ToString()))
                isValid = false;
            else if (String.IsNullOrEmpty(pROJECT.pro_final_Date.ToString()))
                isValid = false;
            else if (String.IsNullOrEmpty(pROJECT.tpr_ncode.ToString()))
                isValid = false;


            return isValid;
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
