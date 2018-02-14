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
    public class HistorialController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Historial
        public ActionResult Index()
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();
                Historial.conexion = Conexion;
                Historial.TablaCicloEscolarCmb = HistorialDatos.ObtenerComboCatCicloEscolar(Historial);
                var list = new SelectList(Historial.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = list;

                Historial.TablaPlanEstudioCmb = HistorialDatos.ObtenerComboCatPlanEstudio(Historial);
                var listaPE = new SelectList(Historial.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = listaPE;

                Historial.TablaModalidadCmb = HistorialDatos.ObtenerComboCatModalidad(Historial);
                var listModalidad = new SelectList(Historial.TablaModalidadCmb, "IDModalidad", "Descripcion");
                ViewData["cmbModalidad"] = listModalidad;

                Historial.TablaEspecialidadCmb = HistorialDatos.ObtenerComboCatEspecialidad(Historial);
                var listEspecialidad = new SelectList(Historial.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                ViewData["cmbEspecialidad"] = listEspecialidad;

                Historial.TablaCursosCmb = HistorialDatos.ObtenerComboCatCursos(Historial);
                var listCursos = new SelectList(Historial.TablaCursosCmb, "IDCurso", "Descripcion");
                ViewData["cmbCursos"] = listCursos;


                Historial.TablaGrupoCmb = HistorialDatos.ObtenerComboCatGrupo(Historial);
                var listGrupoOr = new SelectList(Historial.TablaGrupoCmb, "IDGrupo", "Nombre");
                ViewData["cmbGrupo"] = listGrupoOr;



                Historial.TablaAlumnosXGrupo = HistorialDatos.ObtenertablaCatAlumnoXGrupo(Historial);
                var listAlumnosXGrupo = new SelectList(Historial.TablaAlumnosXGrupo, "IDPersona", "nombre");
                ViewData["TablaAlumnosXGrupo"] = listAlumnosXGrupo;

                return View();
            }
            catch (Exception ex) {
                throw ex;
            }
           
        }
        [HttpGet]
        public ActionResult GrupoConcluido(string id) {
            try { 
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();
                Historial.id_alumno = id;
                Historial.conexion = Conexion;
                Historial = HistorialDatos.ObtenerListaCursoCursados(Historial);
                return View(Historial);
            }
            catch (Exception)
            {
                HistorialModels Historial = new HistorialModels();
                Historial.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Historial);
            }
        }
        [HttpGet]
        public ActionResult MateriasCursadas(string id)
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();
                Historial.id_alumno = id;
                Historial.conexion = Conexion;
                Historial = HistorialDatos.ObtenerListaMateriasCursadas(Historial);
                return View(Historial);
            }
            catch (Exception)
            {
                HistorialModels Historial = new HistorialModels();
                Historial.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Historial);
            }
        }
        //FUNCIONES MEDIANTE AJAX DESDE VISTA
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboModalidad(int idplanEstudio)
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();

                List<CatModalidadModels> listaModalidad = new List<CatModalidadModels>();
                Historial.conexion = Conexion;
                Historial.idplanEstudio = idplanEstudio;

                listaModalidad = HistorialDatos.ObtenerComboCatModalidad(Historial);
                return Json(listaModalidad, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboEspecialidad(string IDModalidad)
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();

                List<CatEspecialidadModels> listaEspecialidad = new List<CatEspecialidadModels>();
                Historial.conexion = Conexion;
                Historial.IDModalidad = IDModalidad;

                listaEspecialidad = HistorialDatos.ObtenerComboCatEspecialidad(Historial);
                return Json(listaEspecialidad, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboCursos(string IDEspecialidad)
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();

                List<CatCursoModels> listaEspecialidad = new List<CatCursoModels>();
                Historial.conexion = Conexion;
                Historial.IDEspecialidad = IDEspecialidad;

                listaEspecialidad = HistorialDatos.ObtenerComboCatCursos(Historial);
                return Json(listaEspecialidad, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboGrupo(string ciclo, string IDEspecialidad, string curso)
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();

                List<CatGrupoModels> listaGrupo = new List<CatGrupoModels>();
                Historial.conexion = Conexion;
                Historial.ciclo = ciclo;
                Historial.IDEspecialidad = IDEspecialidad;
                Historial.curso = curso;

                listaGrupo = HistorialDatos.ObtenerComboCatGrupo(Historial);
                return Json(listaGrupo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TablaAlumnosXGrupo(string grupo)
        {
            try
            {
                HistorialModels Historial = new HistorialModels();
                _Historial_Datos HistorialDatos = new _Historial_Datos();

                List<CatAlumnoModels> listaAlumnosXGrupo = new List<CatAlumnoModels>();
                Historial.conexion = Conexion;
                Historial.grupo = grupo;


                listaAlumnosXGrupo = HistorialDatos.ObtenertablaCatAlumnoXGrupo(Historial);
                return Json(listaAlumnosXGrupo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

    }
}