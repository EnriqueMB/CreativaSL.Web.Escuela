using CreativaSL.Web.Escuela.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class NotificacionController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Notificacion
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                NotificacionModels Notificacion = new NotificacionModels();

                Notificacion.conexion = Conexion;
                
                return View(Notificacion);
            }
            catch (Exception)
            {
                NotificacionModels Notificacion = new NotificacionModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Notificacion);
            }

        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                NotificacionModels Notificacion = new NotificacionModels();
                _Notificacion_Datos NotificacionDatos = new _Notificacion_Datos();
                Notificacion.conexion = Conexion;
                Notificacion.IDNotificacion = "";
                Notificacion.nombre = collection["nombre"];
                Notificacion.Materia = collection["materia"];
                Notificacion.fecha = DateTime.ParseExact(collection["fecha"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Notificacion.cadena = collection["cadena"]; 
                Notificacion = NotificacionDatos.CadenaFinal(Notificacion);
                Notificacion.user = User.Identity.Name;
                Notificacion.opcion = 1;
                //Notificacion = CatedraticoDatos.AbcCatCatedratico(Catedratico);
                //if (string.IsNullOrEmpty(Catedratico.id_persona))
                //{

                //    TempData["typemessage"] = "2";
                //    TempData["message"] = "El usuario ingresado ya existe.";
                //    return RedirectToAction("Create");
                //}
                //else
                //{
                //    Comun.EnviarCorreo(
                //    ConfigurationManager.AppSettings.Get("CorreoTxt")
                //   , ConfigurationManager.AppSettings.Get("PasswordTxt")
                //   , Catedratico.correo
                //   , "Registro Profesor"
                //   , Comun.GenerarHtmlRegistoUsuario(Catedratico.clvUser, Catedratico.passUser)
                //   , false
                //   , ""
                //   , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                //   , ConfigurationManager.AppSettings.Get("HostTxt")
                //   , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                //   , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                //    TempData["typemessage"] = "1";
                //    TempData["message"] = "Los datos se guardaron correctamente.";
                //    return RedirectToAction("Index");
                //}
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico" + ex;
                return RedirectToAction("Index");
            }
        }
    }
}