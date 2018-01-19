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
        //[Authorize(Roles = "3")]
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

        // GET: Admin/CatModalidad/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                CatModalidad_Datos ModalidadDatos = new CatModalidad_Datos();
                Modalidad.conexion = Conexion;
                Modalidad.TablaPlanEstudioCmb = ModalidadDatos.obtenerComboCatPlanEstudio(Modalidad);
                var list = new SelectList(Modalidad.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = list;
                return View(Modalidad);
            }
            catch (Exception)
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Modalidad);
            }
           
        }

        // POST: Admin/CatModalidad/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                CatModalidad_Datos ModalidadDatos = new CatModalidad_Datos();
                Modalidad.conexion = Conexion;
                Modalidad.opcion = 1;
                Modalidad.user = User.Identity.Name;
                Modalidad.IDModalidad = "";
                Modalidad.IDPlanEstudio = Convert.ToInt32(collection["TablaPlanEstudioCmb"]);
                Modalidad.Descripcion = collection["Descripcion"];
                Modalidad = ModalidadDatos.AbcCatModalidad(Modalidad);
                if (Modalidad.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Modalidad.TablaPlanEstudioCmb = ModalidadDatos.obtenerComboCatPlanEstudio(Modalidad);
                    var list = new SelectList(Modalidad.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                    ViewData["cmbPlanEstudio"] = list;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente";
                    return View(Modalidad);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatModalidad/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                CatModalidad_Datos ModalidadDatos = new CatModalidad_Datos();
                Modalidad.conexion = Conexion;
                Modalidad.IDModalidad = id;
                Modalidad.TablaPlanEstudioCmb = ModalidadDatos.obtenerComboCatPlanEstudio(Modalidad);
                var list = new SelectList(Modalidad.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = list;
                ModalidadDatos.ObtenerDetalleCatModalidad(Modalidad);
                return View(Modalidad);
            }
            catch (Exception)
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatModalidad/Edit/5
        [HttpPost]
        [Authorize( Roles = "3")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                CatModalidad_Datos ModalidadDatos = new CatModalidad_Datos();
                Modalidad.conexion = Conexion;
                Modalidad.opcion = 2;
                Modalidad.user = User.Identity.Name;
                Modalidad.IDModalidad = collection["IDModalidad"];
                Modalidad.IDPlanEstudio = Convert.ToInt32(collection["TablaPlanEstudioCmb"]);
                Modalidad.Descripcion = collection["Descripcion"];
                Modalidad = ModalidadDatos.AbcCatModalidad(Modalidad);
                if (Modalidad.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente. Intente nuevamente";
                    return View(Modalidad);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatModalidad/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatModalidad/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatModalidadModels Modalidad = new CatModalidadModels();
                CatModalidad_Datos ModalidadDatos = new CatModalidad_Datos();
                Modalidad.conexion = Conexion;
                Modalidad.IDModalidad = id;
                Modalidad.opcion = 3;
                Modalidad.user = User.Identity.Name;
                Modalidad = ModalidadDatos.AbcCatModalidad(Modalidad);
                if (Modalidad.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se elimino correctamente.";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al eliminar. Intente nuevamente.";
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
