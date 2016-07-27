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
    public class ParametrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parametros
        public ActionResult Index()
        {
            var parametros = db.Parametros.Include(p => p.periodo);
            return View(parametros.ToList());
        }

        // GET: Parametros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametros parametros = db.Parametros.Find(id);
            if (parametros == null)
            {
                return HttpNotFound();
            }
            return View(parametros);
        }

        // GET: Parametros/Create
        public ActionResult Create()
        {
            ViewBag.nu_periodo = new SelectList(db.periodos, "nu_periodo", "nu_periodo");
            return View();
        }

        // POST: Parametros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nu_parametro,nu_periodo")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                db.Parametros.Add(parametros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nu_periodo = new SelectList(db.periodos, "nu_periodo", "nu_periodo", parametros.nu_periodo);
            return View(parametros);
        }

        // GET: Parametros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametros parametros = db.Parametros.Find(id);
            if (parametros == null)
            {
                return HttpNotFound();
            }
            ViewBag.nu_periodo = new SelectList(db.periodos, "nu_periodo", "nu_periodo", parametros.nu_periodo);
            return View(parametros);
        }

        // POST: Parametros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nu_parametro,nu_periodo")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parametros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nu_periodo = new SelectList(db.periodos, "nu_periodo", "nu_periodo", parametros.nu_periodo);
            return View(parametros);
        }

        // GET: Parametros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametros parametros = db.Parametros.Find(id);
            if (parametros == null)
            {
                return HttpNotFound();
            }
            return View(parametros);
        }

        // POST: Parametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parametros parametros = db.Parametros.Find(id);
            db.Parametros.Remove(parametros);
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
