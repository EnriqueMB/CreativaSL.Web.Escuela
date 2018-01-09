using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Models;
using System.Data;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class CatModalidadController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatModalidad
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Index()
        {
            try
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                CatModalidad_Datos ModalidadDatos = new CatModalidad_Datos();
                Modalidad.conexion = Conexion;
                Modalidad = ModalidadDatos.ObtenerCatModalidad(Modalidad);
                return View(Modalidad);
            }
            catch (Exception)
            {
                CatPlanEstudioModels Modalidad = new CatPlanEstudioModels();
                Modalidad.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Modalidad);
            }
        }

        // GET: Admin/CatModalidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CatModalidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CatModalidad/Create
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

        // GET: Admin/CatModalidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CatModalidad/Edit/5
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

        // GET: Admin/CatModalidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatModalidad/Delete/5
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
