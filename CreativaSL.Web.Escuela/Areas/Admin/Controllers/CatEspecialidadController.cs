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
    public class CatEspecialidadController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        [HttpGet]
        //[Authorize(Roles = "3")]
        // GET: Admin/CatEspecialidad
        public ActionResult Index()
        {
            try
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                _CatEspecialidad_Datos EspecialidadDatos = new _CatEspecialidad_Datos();
                Especialidad.conexion = Conexion;
                Especialidad = EspecialidadDatos.ObtenerCatEspecialidad(Especialidad);
                return View(Especialidad);
            }
            catch (Exception)
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                Modalidad.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Modalidad);
            }
        }
        // GET: Admin/CatEspecialidad/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                _CatEspecialidad_Datos EspecialidadDatos = new _CatEspecialidad_Datos();
                Especialidad.conexion = Conexion;
                Especialidad.tablaModalidadCmb = EspecialidadDatos.obtenerComboCatModalidad(Especialidad);
                var list = new SelectList(Especialidad.tablaModalidadCmb, "IDModalidad", "descripcion");
                ViewData["cmbTipoModalidad"] = list;
                
                return View(Especialidad);
            }
            catch (Exception)
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Especialidad);
            }
        }
        // POST: Admin/CatEspecialidad/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                _CatEspecialidad_Datos EspecialidadDatos = new _CatEspecialidad_Datos();
                Especialidad.conexion = Conexion;
                Especialidad.id_especialidad = "";
                Especialidad.descripcion = collection["Descripcion"];
                Especialidad.id_modalidad = collection["tablaModalidadCmb"];
                Especialidad.user = User.Identity.Name;
                Especialidad.opcion = 1;
                Especialidad = EspecialidadDatos.AbcCatEspecialidad(Especialidad);
                if (Especialidad.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Especialidad.tablaModalidadCmb = EspecialidadDatos.obtenerComboCatModalidad(Especialidad);
                    var list = new SelectList(Especialidad.tablaModalidadCmb, "IDModalidad", "descripcion");
                    ViewData["cmbTipoModalidad"] = list;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return View(Especialidad);
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatEspecialidad/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                _CatEspecialidad_Datos EspecialidadDatos = new _CatEspecialidad_Datos();
                Especialidad.conexion = Conexion;
                Especialidad.tablaModalidadCmb = EspecialidadDatos.obtenerComboCatModalidad(Especialidad);
                var list = new SelectList(Especialidad.tablaModalidadCmb, "IDModalidad", "descripcion");
                ViewData["cmbTipoModalidad"] = list;
                Especialidad.id_especialidad = id;
                Especialidad = EspecialidadDatos.ObtenerDetalleCatEspecialidad(Especialidad);
                return View(Especialidad);
            }
            catch (Exception)
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/PlanEstudio/Edit/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                _CatEspecialidad_Datos EspecialidadDatos = new _CatEspecialidad_Datos();
                Especialidad.conexion = Conexion;
                Especialidad.opcion = 2;
                Especialidad.id_especialidad = id;
                Especialidad.user = User.Identity.Name;
                Especialidad.descripcion = collection["Descripcion"];
                Especialidad.id_modalidad = collection["tablaModalidadCmb"];
                Especialidad = EspecialidadDatos.AbcCatEspecialidad(Especialidad);
                if (Especialidad.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente.";
                    return View(Especialidad);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editarón correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }
         
        // GET: Admin/CatEspecialidad/Delete/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(int id)
        {
            return View();
        }
         

        // POST: Admin/CatEspecialidad/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                _CatEspecialidad_Datos EspecialidadDatos = new _CatEspecialidad_Datos();
                Especialidad.conexion = Conexion;
                Especialidad.opcion = 3;
                Especialidad.user = User.Identity.Name;
                Especialidad.id_especialidad = id;
                EspecialidadDatos.AbcCatEspecialidad(Especialidad);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se a eliminado correctamente.";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

    }

}