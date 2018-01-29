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
    public class CatTutorController : Controller
    {
        // GET: Admin/CatTutor
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
       
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                CatTutorModels Tutor = new CatTutorModels();
                _CatTutor_Datos TutorDatos = new _CatTutor_Datos();
                Tutor.conexion = Conexion;
                Tutor = TutorDatos.ObtenerCatTutor(Tutor);
                return View(Tutor);
            }
            catch (Exception)
            {
                CatTutorModels Tutor = new CatTutorModels();
                Tutor.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Tutor);
            }
        }

        // GET: Admin/CatTutor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CatTutor/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatTutorModels Tutor = new CatTutorModels();
                _CatTutor_Datos TutorDatos = new _CatTutor_Datos();
                Tutor.conexion = Conexion;
                return View(Tutor);
            }
            catch
            {
                CatTutorModels Tutor = new CatTutorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Tutor);
            }
        }

        // POST: Admin/CatTutor/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatTutorModels Tutor = new CatTutorModels();
                _CatTutor_Datos TutorDatos = new _CatTutor_Datos();
                Tutor.conexion = Conexion;
                Tutor.IDPersona = "";
                Tutor.Nombre = collection["nombre"];
                Tutor.ApPaterno = collection["apPaterno"];
                Tutor.ApMaterno = collection["apMaterno"];
                Tutor.Correo = collection["correo"];
                Tutor.Direccion = collection["direccion"];
                Tutor.Telefono = collection["telefono"];
                Tutor.IDTipoPersona = 4;

                Tutor.clvUser = collection["clvUser"];

                Tutor.passUser = collection["passUser"];
                Tutor.Observaciones = collection["observaciones"];
                Tutor.user = User.Identity.Name;
                Tutor.opcion = 1;
                Tutor = TutorDatos.AbcCatTutor(Tutor);
                if (string.IsNullOrEmpty(Tutor.IDPersona))
                {
                   
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El usuario ingresado ya existe.";
                    return RedirectToAction("Create");
                }
                else
                {
                    Comun.EnviarCorreo(
                    ConfigurationManager.AppSettings.Get("CorreoTxt")
                   , ConfigurationManager.AppSettings.Get("PasswordTxt")
                   , Tutor.Correo
                   , "Registro Profesor"
                   , Comun.GenerarHtmlRegistoTutorAlumno(Tutor.IDPersona,Tutor.clvUser, Tutor.passUser)
                   , false
                   , ""
                   , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                   , ConfigurationManager.AppSettings.Get("HostTxt")
                   , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                   , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        //[Authorize(Roles = "3")]
        // GET: Admin/CatTutor/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                CatTutorModels Tutor = new CatTutorModels();
                _CatTutor_Datos TutorDatos = new _CatTutor_Datos();
                Tutor.conexion = Conexion;

                Tutor.IDPersona = id;
                Tutor = TutorDatos.ObtenerDetalleCatCatedratico(Tutor);
                return View(Tutor);
            }
            catch (Exception ex)
            {
                CatTutorModels Tutor = new CatTutorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatTutor/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatTutorModels Tutor = new CatTutorModels();
                _CatTutor_Datos TutorDatos = new _CatTutor_Datos();
                Tutor.conexion = Conexion;
                Tutor.IDPersona = id;
                Tutor.Nombre = collection["nombre"];
                Tutor.ApPaterno = collection["apPaterno"];
                Tutor.ApMaterno = collection["apMaterno"];
                Tutor.Correo = collection["correo"];
                Tutor.Direccion = collection["direccion"];
                Tutor.Telefono = collection["telefono"];
                Tutor.IDTipoPersona = 4;

                Tutor.clvUser = collection["clvUser"];

                Tutor.passUser = collection["passUser"];
                Tutor.Observaciones = collection["observaciones"];
                Tutor.user = User.Identity.Name;
                Tutor.opcion = 2;
                Tutor = TutorDatos.AbcCatTutor(Tutor);
                if (Tutor.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editaron correctamente.";
                    return RedirectToAction("Edit");
                }
                
            }
            catch
            {
                CatTutorModels Tutor = new CatTutorModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
                
            }
        }

        // GET: Admin/CatTutor/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatTutor/Delete/5
     

        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatTutorModels Tutor = new CatTutorModels();
                _CatTutor_Datos TutorDatos = new _CatTutor_Datos();
                Tutor.conexion = Conexion;
                Tutor.opcion = 3;
                Tutor.user = User.Identity.Name;
                Tutor.IDPersona = id;
                TutorDatos.AbcCatTutor(Tutor);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se ha eliminado correctamente.";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
