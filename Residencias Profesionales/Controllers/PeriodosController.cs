using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Residencias.Models;
using Residencias.Models.Api;

namespace Residencias.Controllers
{
    [Authorize(Roles = "administrador")]
    public class PeriodosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Periodos
        public ActionResult Index()
        {
            List<IndexPeriodos> periodos = new List<IndexPeriodos>();
            foreach(var item in db.periodos.ToList()) {
                var i = new IndexPeriodos(item);
                periodos.Add(i);
            }

            return View(periodos);
        }

        // GET: Periodos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodos periodos = db.periodos.Find(id);
            if (periodos == null)
            {
                return HttpNotFound();
            }
            return View(periodos);
        }

        // GET: Periodos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nu_periodo,fe_inicio,fe_final")] Periodos periodos)
        {
            if (ModelState.IsValid)
            {
                db.periodos.Add(periodos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodos);
        }

        // GET: Periodos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodos periodos = db.periodos.Find(id);
            if (periodos == null)
            {
                return HttpNotFound();
            }
            return View(periodos);
        }

        // POST: Periodos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nu_periodo,fe_inicio,fe_final")] Periodos periodos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodos);
        }

        // GET: Periodos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodos periodos = db.periodos.Find(id);
            if (periodos == null)
            {
                return HttpNotFound();
            }
            return View(periodos);
        }

        // POST: Periodos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodos periodos = db.periodos.Find(id);
            db.periodos.Remove(periodos);
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
