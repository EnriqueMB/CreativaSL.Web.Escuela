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
    public class CatCursoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        [HttpGet]
        //[Authorize(Roles = "3")]
        // GET: Admin/CatEspecialidad
        public ActionResult Index()
        {
            try
            {
                CatCursoModels Curso = new CatCursoModels();
                _CatCurso_Datos CursoDatos = new _CatCurso_Datos();
                Curso.conexion = Conexion;
                Curso = CursoDatos.ObtenerCatCurso(Curso);
                return View(Curso);
            }
            catch (Exception)
            {
                CatCursoModels Curso = new CatCursoModels();
                Curso.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Curso);
            }
        }
        // GET: Admin/CatEspecialidad/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatCursoModels Curso = new CatCursoModels();
                _CatCurso_Datos CursoDatos = new _CatCurso_Datos();
                Curso.conexion = Conexion;
                Curso.tablaEspecialidadCmb = CursoDatos.obtenerComboCatCurso(Curso);
                var list = new SelectList(Curso.tablaEspecialidadCmb, "id_especialidad", "descripcion");
                ViewData["cmbTipoEspecialidad"] = list;

                return View(Curso);
            }
            catch (Exception)
            {
                CatEspecialidadModels Especialidad = new CatEspecialidadModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Especialidad);
            }
        }
        // POST: Admin/CatEspecialidad/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatCursoModels Curso = new CatCursoModels();
                _CatCurso_Datos CursoDatos = new _CatCurso_Datos();
                Curso.conexion = Conexion;
                Curso.IDCurso = "";
                Curso.abreviatura = collection["abreviatura"];
                Curso.Descripcion = collection["Descripcion"];
                Curso.IDEspecialidad = collection["tablaEspecialidadCmb"];
                Curso.user = User.Identity.Name;
                Curso.opcion = 1;
                Curso = CursoDatos.AbcCatCurso(Curso);
                if (Curso.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Curso.tablaEspecialidadCmb = CursoDatos.obtenerComboCatCurso(Curso);
                    var list = new SelectList(Curso.tablaEspecialidadCmb, "id_especialidad", "descripcion");
                    ViewData["cmbTipoEspecialidad"] = list;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return RedirectToAction("Create", "CatCurso");
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatEspecialidad/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatCursoModels Curso = new CatCursoModels();
                _CatCurso_Datos CursoDatos = new _CatCurso_Datos();
                Curso.conexion = Conexion;
                Curso.tablaEspecialidadCmb = CursoDatos.obtenerComboCatCurso(Curso);
                var list = new SelectList(Curso.tablaEspecialidadCmb, "id_especialidad", "descripcion");
                ViewData["cmbTipoEspecialidad"] = list;
                Curso.IDCurso = id;
                Curso = CursoDatos.ObtenerDetalleCatEspecialidad(Curso);
                return View(Curso);
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
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatCursoModels Curso = new CatCursoModels();
                _CatCurso_Datos CursoDatos = new _CatCurso_Datos();
                Curso.conexion = Conexion;
                Curso.opcion = 2;
                Curso.IDCurso = id;
                Curso.user = User.Identity.Name;
                Curso.abreviatura = collection["abreviatura"];
                Curso.Descripcion = collection["Descripcion"];
                Curso.IDEspecialidad = collection["tablaEspecialidadCmb"];
                Curso = CursoDatos.AbcCatCurso(Curso);
                if (Curso.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente.";
                    return View(Curso);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editarón correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        } 
        // GET: Admin/CatEspecialidad/Delete/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatEspecialidad/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatCursoModels Curso = new CatCursoModels();
                _CatCurso_Datos CursoDatos = new _CatCurso_Datos();
                Curso.conexion = Conexion;
                Curso.opcion = 3;
                Curso.user = User.Identity.Name;
                Curso.IDCurso = id;
                CursoDatos.AbcCatCurso(Curso);
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