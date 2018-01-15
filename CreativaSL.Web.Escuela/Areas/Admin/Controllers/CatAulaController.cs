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
    public class CatAulaController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatAula
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Index()
        {
            try
            {
                CatAulaModels Aula = new CatAulaModels();
                CatAulas_Datos AulaDatos = new CatAulas_Datos();
                Aula.conexion = Conexion;
                Aula = AulaDatos.ObtenerCatAulas(Aula);
                return View(Aula);
            }
            catch (Exception)
            {
                CatAulaModels Aula = new CatAulaModels();
                Aula.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Aula);
            }
        }

        // GET: Admin/CatAula/Create
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Create()
        {
            try
            {
                CatAulaModels Aula = new CatAulaModels();
                return View(Aula);
            }
            catch (Exception)
            {
                CatAulaModels Aula = new CatAulaModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Aula);
            }
        }

        // POST: Admin/CatAula/Create
        [HttpPost]
        [Authorize(Roles = "4")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatAulaModels Aula = new CatAulaModels();
                CatAulas_Datos AulaDatos = new CatAulas_Datos();
                Aula.conexion = Conexion;
                Aula.opcion = 1;
                Aula.user = User.Identity.Name;
                Aula.Descripcion = collection["Descripcion"];
                Aula.IDAula = "";
                Aula = AulaDatos.AbcCatAula(Aula);
                if (Aula.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return View(Aula);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAula/Edit/5
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatAulaModels Aula = new CatAulaModels();
                CatAulas_Datos AulaDatos = new CatAulas_Datos();
                Aula.conexion = Conexion;
                Aula.IDAula = id;
                Aula = AulaDatos.ObtenerDetalleCatAulas(Aula);
                return View(Aula);
            }
            catch (Exception)
            {
                CatAulaModels Aula = new CatAulaModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatAula/Edit/5
        [HttpPost]
        [Authorize(Roles = "4")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatAulaModels Aula = new CatAulaModels();
                CatAulas_Datos AulaDatos = new CatAulas_Datos();
                Aula.conexion = Conexion;
                Aula.opcion = 2;
                Aula.user = User.Identity.Name;
                Aula.IDAula = collection["IDAula"];
                Aula.Descripcion = collection["Descripcion"];
                Aula = AulaDatos.AbcCatAula(Aula);
                if (Aula.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return View(Aula);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAula/Delete/5
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatAula/Delete/5
        [HttpPost]
        [Authorize(Roles = "4")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatAulaModels Aula = new CatAulaModels();
                CatAulas_Datos AulaDatos = new CatAulas_Datos();
                Aula.conexion = Conexion;
                Aula.IDAula = id;
                Aula.opcion = 3;
                Aula.user = User.Identity.Name;
                Aula = AulaDatos.AbcCatAula(Aula);
                if (Aula.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se a eliminado correctamente";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El registro no se a eliminado correctamente. Intente nuevamente.";
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
