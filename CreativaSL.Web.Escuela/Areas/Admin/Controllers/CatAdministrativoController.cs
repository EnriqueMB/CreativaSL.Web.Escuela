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
    public class CatAdministrativoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatAdministrativo
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo = administrativo_datos.ObtenerCatAdministrativo(administrativo);
                return View(administrativo);
            }
            catch (Exception)
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                administrativo.tablaAdministracion = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(administrativo);
            }
        }

        // GET: Admin/CatAdministrativo/Create
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                return View(administrativo);
            }
            catch (Exception)
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(administrativo);
            }
        }

        // POST: Admin/CatAdministrativo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.nombre = collection["nombre"];
                administrativo.apPaterno = collection["apPaterno"];
                administrativo.apMaterno = collection["apMaterno"];
                administrativo.correo = collection["correo"];
                administrativo.telefono = collection["telefono"];
                administrativo.direccion = collection["direccion"];
                administrativo.Observaciones = collection["observaciones"];
                administrativo.clvUser = collection["clvUser"];
                administrativo.passUser = collection["passUser"];
                administrativo.opcion = 1;
                administrativo.user = User.Identity.Name;
                administrativo.id_administrativo = "";
                administrativo_datos.AbcCatAdministrativo(administrativo);
                if (string.IsNullOrEmpty(administrativo.id_administrativo))
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El usuario ingresado ya existe.";
                    return View(administrativo);
                }
                else
                {
                    Comun.EnviarCorreo(
                   ConfigurationManager.AppSettings.Get("CorreoTxt")
                  , ConfigurationManager.AppSettings.Get("PasswordTxt")
                  , administrativo.correo
                  , "Registro Administrativo"
                  , Comun.GenerarHtmlRegistoUsuario(administrativo.clvUser, administrativo.passUser)
                  , false
                  , ""
                  , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                  , ConfigurationManager.AppSettings.Get("HostTxt")
                  , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                  , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se a guardado correctamente";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAdministrativo/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.id_administrativo = id;
                administrativo = administrativo_datos.ObtenerDetalleCatAdministrativoxID(administrativo);
                return View(administrativo);
            }
            catch (Exception)
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatAdministrativo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.id_administrativo = collection["id_administrativo"];
                administrativo.nombre = collection["nombre"];
                administrativo.apPaterno = collection["apPaterno"];
                administrativo.apMaterno = collection["apMaterno"];
                administrativo.correo = collection["correo"];
                administrativo.telefono = collection["telefono"];
                administrativo.direccion = collection["direccion"];
                administrativo.Observaciones = collection["observaciones"];
                administrativo.clvUser = "";
                administrativo.passUser = "";
                administrativo.opcion = 2;
                administrativo.user = User.Identity.Name;
                administrativo_datos.AbcCatAdministrativo(administrativo);

                TempData["typemessage"] = "1";
                TempData["message"] = "Los datos se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se edito correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAdministrativo/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatAdministrativo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.id_administrativo = id;
                administrativo.opcion = 3;
                administrativo.user = User.Identity.Name;
                administrativo_datos.AbcCatAdministrativo(administrativo);
                TempData["typemessage"] = "1";
                TempData["message"] = "El registro se a eliminado correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
