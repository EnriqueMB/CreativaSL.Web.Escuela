using CreativaSL.Web.Escuela.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Filters;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class CatCuentaUserController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatCuentaUser
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                CatCuentaUserModels cuentaUser = new CatCuentaUserModels();
                CatCuentaUser_Datos cuentaUser_datos = new CatCuentaUser_Datos();
                cuentaUser.conexion = Conexion;
                cuentaUser.id_cuenta = User.Identity.Name;
                return View(cuentaUser);
            }
            catch (Exception)
            {
                CatCuentaUserModels cuentaUser = new CatCuentaUserModels();
                cuentaUser.tablaUsuarioCuenta = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(cuentaUser);
            }
        }
    
        [HttpPost]
        public ActionResult Index(string id, FormCollection collection)
        {
            try
            {
                CatCuentaUserModels cuentaUser = new CatCuentaUserModels();
                CatCuentaUser_Datos cuentaUser_datos = new CatCuentaUser_Datos();
                cuentaUser.conexion = Conexion;
                cuentaUser.id_cuenta = User.Identity.Name;
                cuentaUser.passUser = collection["passUser"];
                cuentaUser.passActualizado = collection["passActualizado"];
                cuentaUser.user = User.Identity.Name;
                cuentaUser = cuentaUser_datos.AbcCambiarContraseña(cuentaUser);
                if (cuentaUser.id_cuenta == Convert.ToString(1))
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "La Contraseña sea creado correctamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "La Contraseña no Coincide";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                CatCuentaUserModels cuentaUser = new CatCuentaUserModels();
                cuentaUser.tablaUsuarioCuenta = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "La Contraseña no Coincide";
                return View(cuentaUser);
            }
        }
    }
}