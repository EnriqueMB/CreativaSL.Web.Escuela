using CreativaSL.Web.Escuela.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class CatAlumnosGraduadosController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatAlumnos
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Index()
        {

            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;
                Alumno = AlumnoDatos.ObtenerCatAlumnoGraduados(Alumno);
                return View(Alumno);
            }
            catch (Exception)
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                Alumno.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Alumno);
            }

        }

        // GET: Admin/CatAlumnosGraduados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CatAlumnosGraduados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CatAlumnosGraduados/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CatAlumnosGraduados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CatAlumnosGraduados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CatAlumnosGraduados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatAlumnosGraduados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
