using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Models;
using System.Configuration;
using System.Data;
using System.Globalization;
using CreativaSL.Web.Escuela.Filters;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class CatCicloEscolarController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatCicloEscolar
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                CatCicloEscolarModels Ciclo = new CatCicloEscolarModels();
                CatCicloEscolar_Datos CicloDatos = new CatCicloEscolar_Datos();
                Ciclo.conexion = Conexion;
                Ciclo = CicloDatos.ObtenerCatCicloEscolar(Ciclo);
                return View(Ciclo);
            }
            catch (Exception)
            {
                CatCicloEscolarModels Ciclo = new CatCicloEscolarModels();
                Ciclo.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Ciclo);
            }
           
        }

        // GET: Admin/CatCicloEscolar/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                CicloEscolar.CicloActual = Convert.ToBoolean("true");
                return View(CicloEscolar);
            }
            catch (Exception)
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(CicloEscolar);
            }
        }

        // POST: Admin/CatCicloEscolar/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                CatCicloEscolar_Datos CicloEscolar_datos = new CatCicloEscolar_Datos();
                CicloEscolar.conexion = Conexion;
                CicloEscolar.Nombre = collection["nombre"];
                CicloEscolar.Descripcion = collection["descripcion"];
                CicloEscolar.FechaInicio = DateTime.ParseExact(collection["fechaInicio"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CicloEscolar.FechaFin = DateTime.ParseExact(collection["fechaFin"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CicloEscolar.CicloActual = collection["CicloActual"].StartsWith("true");
                CicloEscolar.opcion = 1;
                CicloEscolar.user = User.Identity.Name;
                CicloEscolar.IDCiclo = "";
                CicloEscolar = CicloEscolar_datos.AbcCatCicloEscolar(CicloEscolar);
                if (CicloEscolar.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    CicloEscolar.CicloActual = Convert.ToBoolean("true");
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardarón correctamente. Intente nuevamente.";
                    return View(CicloEscolar);
                }
            }

            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardarón correctamente. Intente más tarde";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatCicloEscolar/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                CatCicloEscolar_Datos CicloEscolar_datos = new CatCicloEscolar_Datos();
                CicloEscolar.conexion = Conexion;
                CicloEscolar.IDCiclo = id;
                CicloEscolar = CicloEscolar_datos.ObtenerDetalleCatCicloEscolar(CicloEscolar);
                return View(CicloEscolar);
            }
            catch (Exception)
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatCicloEscolar/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                CatCicloEscolar_Datos CicloEscolar_datos = new CatCicloEscolar_Datos();
                CicloEscolar.conexion = Conexion;
                CicloEscolar.IDCiclo = collection["IDCiclo"];
                CicloEscolar.Nombre = collection["nombre"];
                CicloEscolar.Descripcion = collection["descripcion"];
                CicloEscolar.FechaInicio = DateTime.ParseExact(collection["fechaInicio"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CicloEscolar.FechaFin = DateTime.ParseExact(collection["fechaFin"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CicloEscolar.CicloActual = collection["CicloActual"].StartsWith("true");
                CicloEscolar.opcion = 2;
                CicloEscolar.user = User.Identity.Name;
                CicloEscolar = CicloEscolar_datos.AbcCatCicloEscolar(CicloEscolar);
                if (CicloEscolar.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente. Intente nuevamente.";
                    return View(CicloEscolar);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se edito correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatCicloEscolar/Delete/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatCicloEscolar/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatCicloEscolarModels CicloEscolar = new CatCicloEscolarModels();
                CatCicloEscolar_Datos CicloEscolar_datos = new CatCicloEscolar_Datos();
                CicloEscolar.conexion = Conexion;
                CicloEscolar.IDCiclo = id;
                CicloEscolar.opcion = 3;
                CicloEscolar.user = User.Identity.Name;
                CicloEscolar = CicloEscolar_datos.AbcCatCicloEscolar(CicloEscolar);
                if (CicloEscolar.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se a eliminado correctamente.";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El resgistro no se a eliminado correctamente. Intente nuevamente.";
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
