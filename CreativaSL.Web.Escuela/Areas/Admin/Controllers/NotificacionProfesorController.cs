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
    public class NotificacionProfesorController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/NotificacionProfesor
        public ActionResult Index()
        {
            NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
            _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
            NotificacionProfesor.conexion = Conexion;
            NotificacionProfesor = NotificacionProfesorDatos.obtenerCatNotificacionProfesor(NotificacionProfesor);
            return View(NotificacionProfesor);
        }
        public ActionResult ReenviarNotificacion(string id,string id2,int id3)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();

                NotificacionProfesor.IDTipoNotificacion = id3;
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.IDNotificacionGeneral = id;
                NotificacionProfesor.id_registro = id2;
                NotificacionProfesorDatos.ReenviarNotificacion(NotificacionProfesor);

                if (NotificacionProfesor.Resultado == 1)
                {
                    foreach (DataRow notificacion in NotificacionProfesor.TablaAlumnos.Rows)
                    {
                        int Bagde = 0, IDTipoCelular = 0;
                        Bagde = Convert.ToInt32(notificacion["Badge"].ToString());
                        IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                        Comun.EnviarMensaje(notificacion["token"].ToString(), notificacion["titulo"].ToString(), notificacion["descripcion"].ToString(), Bagde, IDTipoCelular);
                    }

                }


                TempData["message"] = "El Evento se elimino correctamente";
                return Json("");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Admin/NotificacionProfesor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NotificacionProfesor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NotificacionProfesor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NotificacionProfesor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NotificacionProfesor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NotificacionProfesor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NotificacionProfesor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
