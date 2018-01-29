using CreativaSL.Web.Escuela.Filters;
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
    [Autorizado]
    public class CatGradoEstudioProfesorController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatGradoEstudioProfesor
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                CatGradoEstudioProfesor_Datos gradoEscolarProfesor_datos = new CatGradoEstudioProfesor_Datos();
                gradoEscolarProfesor.conexion = Conexion;
                gradoEscolarProfesor = gradoEscolarProfesor_datos.ObtenerCatGradoEstudioProfesor(gradoEscolarProfesor);
                return View(gradoEscolarProfesor);
            }
            catch (Exception)
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                gradoEscolarProfesor.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(gradoEscolarProfesor);
            }
        }

        // GET: Admin/CatGradoEstudioProfesor/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                return View(gradoEscolarProfesor);
            }
            catch (Exception)
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(gradoEscolarProfesor);
            }
        }

        // POST: Admin/CatGradoEstudioProfesor/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                CatGradoEstudioProfesor_Datos gradoEscolarProfesor_datos = new CatGradoEstudioProfesor_Datos();
                gradoEscolarProfesor.conexion = Conexion;
                gradoEscolarProfesor.Descripcion = collection["descripcion"];
                gradoEscolarProfesor.opcion = 1;
                gradoEscolarProfesor.user = User.Identity.Name;
                gradoEscolarProfesor.IDGradoEstudio = "";
                gradoEscolarProfesor = gradoEscolarProfesor_datos.AbcCatGradoEstudioProfesor(gradoEscolarProfesor);
                if (gradoEscolarProfesor.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return RedirectToAction("Create");
                }
            }

            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatGradoEstudioProfesor/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                CatGradoEstudioProfesor_Datos gradoEscolarProfesor_datos = new CatGradoEstudioProfesor_Datos();
                gradoEscolarProfesor.conexion = Conexion;
                gradoEscolarProfesor.IDGradoEstudio = id;
                gradoEscolarProfesor = gradoEscolarProfesor_datos.ObtenerDetalleCatGradoEstudioProfesorXID(gradoEscolarProfesor);
                return View(gradoEscolarProfesor);
            }
            catch (Exception)
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatGradoEstudioProfesor/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                CatGradoEstudioProfesor_Datos gradoEscolarProfesor_datos = new CatGradoEstudioProfesor_Datos();
                gradoEscolarProfesor.conexion = Conexion;
                gradoEscolarProfesor.IDGradoEstudio = collection["IDGradoEstudio"];
                gradoEscolarProfesor.Descripcion = collection["descripcion"];
                gradoEscolarProfesor.opcion = 2;
                gradoEscolarProfesor.user = User.Identity.Name;
                gradoEscolarProfesor = gradoEscolarProfesor_datos.AbcCatGradoEstudioProfesor(gradoEscolarProfesor);
                if (gradoEscolarProfesor.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return RedirectToAction("Edit");
                }
            }

            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatGradoEstudioProfesor/Delete/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatGradoEstudioProfesor/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatGradoEstudioProfesorModels gradoEscolarProfesor = new CatGradoEstudioProfesorModels();
                CatGradoEstudioProfesor_Datos gradoEscolarProfesor_datos = new CatGradoEstudioProfesor_Datos();
                gradoEscolarProfesor.conexion = Conexion;
                gradoEscolarProfesor.IDGradoEstudio = id;
                gradoEscolarProfesor.opcion = 3;
                gradoEscolarProfesor.user = User.Identity.Name;
                gradoEscolarProfesor = gradoEscolarProfesor_datos.AbcCatGradoEstudioProfesor(gradoEscolarProfesor);
                if (gradoEscolarProfesor.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se a eliminado correctamente.";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El registro no se a eliminado correctamente.";
                    return Json("");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
