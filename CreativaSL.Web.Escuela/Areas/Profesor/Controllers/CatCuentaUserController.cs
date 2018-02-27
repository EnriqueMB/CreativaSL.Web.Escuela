using CreativaSL.Web.Escuela.Filters;
using CreativaSL.Web.Escuela.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Areas.Profesor.Controllers
{
    [Autorizado]
    public class CatCuentaUserController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Profesor/CatCuentaUser
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
        public ActionResult Index(FormCollection collection)
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
                    TempData["message"] = "La Contraseña se ha creado correctamente";
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "La Contraseña no Coincide";
                }
                return View(cuentaUser);
            }
            catch (Exception)
            {
                CatCuentaUserModels cuentaUser = new CatCuentaUserModels();
                cuentaUser.tablaUsuarioCuenta = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "La Contraseña no Coinciden";
                return View(cuentaUser);
            }
        }
    }
}