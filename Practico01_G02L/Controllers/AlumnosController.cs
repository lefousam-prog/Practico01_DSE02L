using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practico01_G02L.Models;

namespace Practico01_G02L.Controllers
{
    public class AlumnosController : Controller
    {
        private EscuelaDBContext db = new EscuelaDBContext();


        // GET: Alumnos
        public ActionResult Index(string BuscarNombre, int? grado=null, int? seccion=null)
        {


            List<Grado> listGrado = null;
            listGrado = db.Grados.ToList();

            List<SelectListItem> igrado = listGrado.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemgrado = igrado;


            List<Seccion> listSeccion = null;
            listSeccion = db.Secciones.ToList();

            List<SelectListItem> iseccion = listSeccion.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemseccion = iseccion;


            var alumnos = from p in db.Alumnos
                          select p;

            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                alumnos = alumnos.Where(s => s.Nombres.Contains(BuscarNombre));
            }
            if (grado!=null)
            {
                alumnos = alumnos.Where(s => s.Idgrado==grado);
            }
            if (seccion!=null)
            {
                alumnos = alumnos.Where(s => s.IdSeccion == seccion);
            }
           // return View(db.Alumnos.ToList());
            return View(alumnos);
        }

        public ActionResult ViewNotes()
        {

             return View(db.Notas.ToList());            
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        public ActionResult InsertNotes(int? id)
        {
            List<Materia> listMateria = null;
            listMateria = db.Materias.ToList();

            List<SelectListItem> imateria = listMateria.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemmateria = imateria;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            
         
            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult InsertNotes([Bind(Include = "Idalumno,idmateria,nota1,nota2,nota3,periodo")] Nota nota)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Notas.Add(nota);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(nota);
        //}
        public ActionResult InsertNotes(int Id, int idmateria, decimal nota1, decimal nota2, decimal nota3, decimal periodo)
        {
            Nota nota = new Nota();
            nota.IdAlumno = Id;
            nota.IdMateria = idmateria;
            nota.Nota1 = nota1;
            nota.Nota2 = nota2;
            nota.Nota3 = nota3;
            nota.Periodo = periodo;
            if (ModelState.IsValid)
            {
                db.Notas.Add(nota);
                db.SaveChanges();
                return RedirectToAction("ViewNotes");
            }

            return View(nota);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            List<Grado> listGrado = null;
            listGrado = db.Grados.ToList();

            List<SelectListItem> igrado = listGrado.ConvertAll(d =>
           {
               return new SelectListItem()
               {
                   Text = d.Nombre.ToString(),
                   Value = d.Id.ToString(),
                   Selected = false
               };
           });

            ViewBag.itemgrado = igrado;

            List<Seccion> listSeccion = null;
            listSeccion = db.Secciones.ToList();

            List<SelectListItem> iseccion = listSeccion.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemseccion = iseccion;

            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,Apellidos,Fechanacimiento,Sexo,Direccion,Telefono,Idgrado,IdSeccion")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }

            List<Grado> listGrado = null;
            listGrado = db.Grados.ToList();

            List<SelectListItem> igrado = listGrado.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemgrado = igrado;

            List<Seccion> listSeccion = null;
            listSeccion = db.Secciones.ToList();

            List<SelectListItem> iseccion = listSeccion.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemseccion = iseccion;
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,Apellidos,Fechanacimiento,Sexo,Direccion,Telefono,Idgrado,IdSeccion")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumno);
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
