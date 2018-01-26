using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Models;
using System.Configuration;
using System.Data;
using CreativaSL.Web.Escuela.Filters;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class PlanEstudioController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/PlanEstudio 
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                CatPlanEstudio_Datos PlanDatos = new CatPlanEstudio_Datos();
                Plan.conexion = Conexion;
                Plan = PlanDatos.ObtenerCatPlanEstudio(Plan);
                return View(Plan);
            }
            catch (Exception)
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                Plan.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Plan);
            }
            
        }
        
        // GET: Admin/PlanEstudio/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                Plan.conexion = Conexion;
                return View(Plan);
            }
            catch (Exception)
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Plan);
            }
        }

        // POST: Admin/PlanEstudio/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                CatPlanEstudio_Datos PlanDatos = new CatPlanEstudio_Datos();
                Plan.conexion = Conexion;
                Plan.IDPlanEstudio = 0;
                Plan.Descripcion = collection["descripcion"];
                Plan.abreviatura = collection["abreviatura"];
                Plan.user = User.Identity.Name;
                Plan.opcion = 1;
                Plan = PlanDatos.AbcCatPlanEstudio(Plan);
                if (Plan.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return View(Plan);
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/PlanEstudio/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(int id)
        {
            try
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                CatPlanEstudio_Datos PlandDatos = new CatPlanEstudio_Datos();
                Plan.conexion = Conexion;
                Plan.IDPlanEstudio = id;
                Plan = PlandDatos.ObtenerDetalleCatPlanEstudio(Plan);
                return View(Plan);
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                CatPlanEstudio_Datos PlanDatos = new CatPlanEstudio_Datos();
                Plan.conexion = Conexion;
                Plan.opcion = 2;
                Plan.user = User.Identity.Name;
                Plan.abreviatura = collection["abreviatura"];
                Plan.IDPlanEstudio = Convert.ToInt32(collection["IDPlanEstudio"]);
                Plan.Descripcion = collection["Descripcion"];
                Plan = PlanDatos.AbcCatPlanEstudio(Plan);
                if (Plan.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente.";
                    return View(Plan);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editarón correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/PlanEstudio/Delete/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/PlanEstudio/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CatPlanEstudioModels Plan = new CatPlanEstudioModels();
                CatPlanEstudio_Datos PlanDatos = new CatPlanEstudio_Datos();
                Plan.conexion = Conexion;
                Plan.opcion = 3;
                Plan.user = User.Identity.Name;
                Plan.IDPlanEstudio = id;
                PlanDatos.AbcCatPlanEstudio(Plan);
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
