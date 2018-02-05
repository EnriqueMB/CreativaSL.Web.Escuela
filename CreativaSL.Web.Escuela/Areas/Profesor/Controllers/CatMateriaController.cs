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
    public class CatMateriaController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Profesor/CatMateria
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                CatProfesorXMateriaModels profXmateria = new CatProfesorXMateriaModels();
                CatMateriaXProfesor_Datos profXmateria_datos = new CatMateriaXProfesor_Datos();
                profXmateria.conexion = Conexion;
                profXmateria.IDProfesor = User.Identity.Name;
                profXmateria = profXmateria_datos.ObtenerCatProXMateriaPROF(profXmateria);
                return View(profXmateria);
            }
            catch (Exception)
            {
                CatProfesorXMateriaModels profXmateria = new CatProfesorXMateriaModels();
                profXmateria.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(profXmateria);
            }
        }

        // GET: /Profesor/CatMateria/Tarea/5
        [HttpGet]
        public ActionResult ListaAlumno(string id, string id2)
        {
            try
            {
                CatAlumnosXGrupoModels alumnoXgrupo = new CatAlumnosXGrupoModels();
                CatAlumnoXGrupo_Datos alumnoXgrupo_datos = new CatAlumnoXGrupo_Datos();
                alumnoXgrupo.conexion = Conexion;
                alumnoXgrupo.IDAsignatura = id;
                alumnoXgrupo.IDMateria = id2;
                alumnoXgrupo.IDProfesor = User.Identity.Name;
                alumnoXgrupo = alumnoXgrupo_datos.ObtenerCatAlumnoXGrupoPROF(alumnoXgrupo);
                return View(alumnoXgrupo);
            }
            catch (Exception)
            {
                CatAlumnosXGrupoModels alumnoXgrupo = new CatAlumnosXGrupoModels();
                alumnoXgrupo.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(alumnoXgrupo);
            }
        }
    }
}