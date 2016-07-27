using Residencias.Models.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Residencias.Controllers
{
    [Authorize(Roles = "estudiante")]
    public class EstudiantesController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();

        public List<SelectListItem> Opciones = new List<SelectListItem> {
                    new SelectListItem { Value = "0", Text = "Propuesta Propia", },
                    new SelectListItem { Value = "1", Text = "Situación como Trabajador/a" }
        };
        
        // GET: Residentes
        public ActionResult Index()
        {
            ViewBag.Opciones = Opciones;
            return View(db.anteProyectos.ToList());
        }

        // GET: Residentes/Details/5
        public ActionResult WorkSchedule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnteProyectos anteProyectos = db.anteProyectos.Find(id);
            if (anteProyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Opciones = Opciones;
            ViewBag.AnteProyecto = anteProyectos;
            return View(db.anteProyectosActividades.Where(x => x.nu_anteproyecto == anteProyectos.nu_anteproyecto).ToList());
        }

        // POST: AnteProyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkSchedule(FormCollection collection)
        {

            return View();
        }

        // GET: Residentes/Anteproyectos
        public ActionResult Create()
        {
            ViewBag.Opciones = Opciones;
            return View();
        }

        // POST: AnteProyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            AnteProyectos anteProyectos = new AnteProyectos();
            try
            {
                if (ModelState.IsValid)
                {
                    anteProyectos.nombre = collection["nombre"];
                    anteProyectos.objetivo = collection["objetivo"];
                    anteProyectos.opcion_elegida = short.Parse(collection["opcion_elegida"]);
                    anteProyectos.fe_inicio = Convert.ToDateTime(collection.Get("fe_inicio"));
                    anteProyectos.fe_final = Convert.ToDateTime(collection.Get("fe_final"));
                    anteProyectos.equipo = collection.Get("equipo");
                    anteProyectos.costo = double.Parse(collection.Get("costo"));
                    anteProyectos.nombre_empresa = collection.Get("nombre_empresa");
                    anteProyectos.domicilio_empresa = collection.Get("domicilio_empresa");
                    anteProyectos.telefono_empresa = collection.Get("telefono_empresa");
                    anteProyectos.responsable_empresa = collection.Get("responsable_empresa");
                    anteProyectos.email_empresa = collection.Get("email_empresa");
                    anteProyectos.asesor_empresa = collection.Get("asesor_empresa");
                    anteProyectos.observaciones = collection.Get("observaciones");
                    db.anteProyectos.Add(anteProyectos);
                    db.SaveChanges();
                    EditEntregables(collection, anteProyectos.nu_anteproyecto);
                    EditActividades(collection, anteProyectos.nu_anteproyecto);
                    db.SaveChanges();

                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Estudiantes");
                    return Json(new { Url = redirectUrl });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex });
            }

            return View(anteProyectos);
        }

        // GET: AnteProyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnteProyectos anteProyectos = db.anteProyectos.Find(id);
            if (anteProyectos == null)
            {
                return HttpNotFound();
            }
            List<AnteProyectosEntregables> anteProyectosEntregables = db.anteProyectosEntregables.Where(x => x.nu_anteproyecto == id).ToList();
            List<AnteProyectosActividades> anteProyectosActividades = db.anteProyectosActividades.Where(x => x.nu_anteproyecto == id).ToList();
            ViewBag.Opciones = Opciones;
            ViewBag.entregables = anteProyectosEntregables;
            ViewBag.actividades = anteProyectosActividades;

            return View(anteProyectos);
        }

        // POST: AnteProyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            AnteProyectos anteProyectos;
            try
            {
                anteProyectos = db.anteProyectos.Find(int.Parse(collection["nu_anteproyecto"]));
                if (ModelState.IsValid)
                {
                    anteProyectos.nombre = collection["nombre"];
                    anteProyectos.objetivo = collection["objetivo"];
                    anteProyectos.opcion_elegida = short.Parse(collection["opcion_elegida"]);
                    anteProyectos.fe_inicio = Convert.ToDateTime(collection.Get("fe_inicio"));
                    anteProyectos.fe_final = Convert.ToDateTime(collection.Get("fe_final"));
                    anteProyectos.equipo = collection.Get("equipo");
                    anteProyectos.costo = double.Parse(collection.Get("costo"));
                    anteProyectos.nombre_empresa = collection.Get("nombre_empresa");
                    anteProyectos.domicilio_empresa = collection.Get("domicilio_empresa");
                    anteProyectos.telefono_empresa = collection.Get("telefono_empresa");
                    anteProyectos.responsable_empresa = collection.Get("responsable_empresa");
                    anteProyectos.email_empresa = collection.Get("email_empresa");
                    anteProyectos.asesor_empresa = collection.Get("asesor_empresa");
                    anteProyectos.observaciones = collection.Get("observaciones");
                    db.Entry(anteProyectos).State = EntityState.Modified;
                    EditEntregables(collection, anteProyectos.nu_anteproyecto);
                    EditActividades(collection, anteProyectos.nu_anteproyecto);
                    db.SaveChanges();

                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Estudiantes");
                    return Json(new { Url = redirectUrl });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex });
            }
                return View(anteProyectos);
        }

        protected void EditEntregables(FormCollection collection, int nu_anteproyecto)
        {
            string[] claves = collection.AllKeys.Where(x => x.Contains("Entregable_")).ToArray();
            List<AnteProyectosEntregables> entregables = db.anteProyectosEntregables.Where(x => x.nu_anteproyecto == nu_anteproyecto).ToList();
            int i = 0;
            if (entregables.Count > 0)
            {
                for (int j = claves.Count(); claves.Count() < entregables.Count; j++)
                {
                    db.anteProyectosEntregables.Remove(entregables[j]);
                    entregables.Remove(entregables[j]);
                }
                foreach (AnteProyectosEntregables entregable in entregables)
                {
                    entregable.entregable = collection.Get(claves[i]);
                    i++;
                }
            }

            for (; i < claves.Count(); i++)
            {
                AnteProyectosEntregables anteProyectosEntregables = new AnteProyectosEntregables();
                anteProyectosEntregables.nu_anteproyecto = nu_anteproyecto;
                anteProyectosEntregables.entregable = collection.Get(claves[i]);
                db.anteProyectosEntregables.Add(anteProyectosEntregables);
            }
        }

        protected void EditActividades(FormCollection collection, int nu_anteproyecto)
        {
            string[] claves = collection.AllKeys.Where(x => x.Contains("Actividad_")).ToArray();
            List<AnteProyectosActividades> actividades = db.anteProyectosActividades.Where(x => x.nu_anteproyecto == nu_anteproyecto).ToList();
            int i = 0;
            if (actividades.Count > 0)
            {
                for (int j = claves.Count(); claves.Count() < actividades.Count; j++)
                {
                    db.anteProyectosActividades.Remove(actividades[j]);
                    actividades.Remove(actividades[j]);
                }
                foreach (AnteProyectosActividades actividad in actividades)
                {
                    actividad.actividad = collection.Get(claves[i]);
                    i++;
                }
            }
            for (; i < claves.Count(); i++)
            {
                AnteProyectosActividades anteProyectosActividades = new AnteProyectosActividades();
                anteProyectosActividades.nu_anteproyecto = nu_anteproyecto;
                anteProyectosActividades.actividad = collection.Get(claves[i]);
                anteProyectosActividades.fe_inicio = Convert.ToDateTime("1973-01-01");
                anteProyectosActividades.fe_final = Convert.ToDateTime("1973-01-01");
                db.anteProyectosActividades.Add(anteProyectosActividades);
            }
        }

        // GET: AnteProyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnteProyectos anteProyectos = db.anteProyectos.Find(id);
            if (anteProyectos == null)
            {
                return HttpNotFound();
            }
            AnteProyectosDeleteConfirm anteProyectosDeleteConfirm = new AnteProyectosDeleteConfirm();
            anteProyectosDeleteConfirm.anteProyectos = anteProyectos;
            ViewBag.Opciones = Opciones;

            return View(anteProyectosDeleteConfirm);
        }

        // POST: AnteProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string nombre)
        {
            AnteProyectos anteProyectos = db.anteProyectos.Find(id);
            if(anteProyectos != null && anteProyectos.nombre.Equals(nombre)) {
                db.anteProyectos.Remove(anteProyectos);
                db.SaveChanges();
            }

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
