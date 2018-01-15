using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using CreativaSL.Web.Escuela.Models;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class CatHorarioController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatHorario
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Index()
        {
            try
            {
                CatHorarioModels Horario = new CatHorarioModels();
                CatHorario_Datos HorarioDatos = new CatHorario_Datos();
                Horario.conexion = Conexion;
                Horario = HorarioDatos.ObtenerCatHorarios(Horario);
                return View(Horario);
            }
            catch (Exception)
            {
                CatHorarioModels Horario = new CatHorarioModels();
                Horario.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Horario);
            }
        }

        // GET: Admin/CatHorario/Create
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Create()
        {
            try
            {
                CatHorarioModels Horario = new CatHorarioModels();
                return View(Horario);
            }
            catch (Exception)
            {
                CatHorarioModels Horario = new CatHorarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Horario);
            }
        }

        // POST: Admin/CatHorario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatHorarioModels Horario = new CatHorarioModels();
                CatHorario_Datos HorarioDatos = new CatHorario_Datos();
                Horario.conexion = Conexion;
                Horario.opcion = 1;
                Horario.user = User.Identity.Name;
                TimeSpan HoraInicioA, HoraFinA;
                TimeSpan.TryParse(collection["HoraInicio"], out HoraInicioA);
                Horario.HoraInicio = HoraInicioA;
                TimeSpan.TryParse(collection["HoraFin"], out HoraFinA);
                Horario.HoraFin = HoraFinA;
                Horario.IDHorario = "";
                Horario = HorarioDatos.AbcCatHorario(Horario);
                if (Horario.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return View(Horario);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatHorario/Edit/5
        [HttpGet]
        [Authorize(Roles ="4")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatHorarioModels Horario = new CatHorarioModels();
                CatHorario_Datos HorarioDatos = new CatHorario_Datos();
                Horario.IDHorario = id;
                Horario.conexion = Conexion;
                Horario = HorarioDatos.ObtenerDetalleCatHorario(Horario);
                return View(Horario);
            }
            catch (Exception)
            {
                CatHorarioModels Horario = new CatHorarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Horario);
            }
        }

        // POST: Admin/CatHorario/Edit/5
        [HttpPost]
        [Authorize(Roles = "4")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatHorarioModels Horario = new CatHorarioModels();
                CatHorario_Datos HorarioDatos = new CatHorario_Datos();
                Horario.conexion = Conexion;
                Horario.opcion = 2;
                Horario.user = User.Identity.Name;
                TimeSpan HoraInicioA, HoraFinA;
                TimeSpan.TryParse(collection["HoraInicio"], out HoraInicioA);
                Horario.HoraInicio = HoraInicioA;
                TimeSpan.TryParse(collection["HoraFin"], out HoraFinA);
                Horario.HoraFin = HoraFinA;
                Horario.IDHorario = collection["IDHorario"];
                Horario = HorarioDatos.AbcCatHorario(Horario);
                if (Horario.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return View(Horario);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatHorario/Delete/5
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatHorario/Delete/5
        [HttpPost]
        [Authorize(Roles = "4")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatHorarioModels Horario = new CatHorarioModels();
                CatHorario_Datos HorarioDatos = new CatHorario_Datos();
                Horario.opcion = 3;
                Horario.user = User.Identity.Name;
                Horario.IDHorario = id;
                Horario.conexion = Conexion;
                Horario = HorarioDatos.AbcCatHorario(Horario);
                if (Horario.Completado == true)
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
