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
    public class PromocionController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Promocion
        [HttpGet]
        public ActionResult Index()
        {
            PromocionModels Promocion = new PromocionModels();
            _Promocion_Datos PromocionDatos = new _Promocion_Datos();
            Promocion.conexion = Conexion;
            Promocion.TablaCicloEscolarCmb = PromocionDatos.ObtenerComboCatCicloEscolar(Promocion);
            var list = new SelectList(Promocion.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
            ViewData["cmbCicloEscolar"] = list;

            Promocion.TablaPlanEstudioCmb = PromocionDatos.ObtenerComboCatPlanEstudio(Promocion);
            var listaPE = new SelectList(Promocion.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
            ViewData["cmbPlanEstudio"] = listaPE;

            Promocion.TablaModalidadCmb = PromocionDatos.ObtenerComboCatModalidad(Promocion);
            var listModalidad = new SelectList(Promocion.TablaModalidadCmb, "IDModalidad", "Descripcion");
            ViewData["cmbModalidad"] = listModalidad;

            Promocion.TablaEspecialidadCmb = PromocionDatos.ObtenerComboCatEspecialidad(Promocion);
            var listEspecialidad = new SelectList(Promocion.TablaEspecialidadCmb, "id_especialidad", "descripcion");
            ViewData["cmbEspecialidad"] = listEspecialidad;

            Promocion.TablaCursosCmb = PromocionDatos.ObtenerComboCatCursos(Promocion);
            var listCursos = new SelectList(Promocion.TablaCursosCmb, "IDCurso", "Descripcion");
            ViewData["cmbCursos"] = listCursos;


            Promocion.TablaGrupoCmb = PromocionDatos.ObtenerComboCatGrupo(Promocion);
            var listGrupoOr = new SelectList(Promocion.TablaGrupoCmb, "IDGrupo", "Nombre");
            ViewData["cmbGrupo"] = listGrupoOr;

            Promocion.TablaGrupoDCmb = PromocionDatos.ObtenerComboCatGrupo(Promocion);
            var listGrupoD = new SelectList(Promocion.TablaGrupoDCmb, "IDGrupo", "Nombre");
            ViewData["cmbGrupoD"] = listGrupoD;

            Promocion.TablaAlumnosXGrupo = PromocionDatos.ObtenertablaCatAlumnoXGrupo(Promocion);
            var listAlumnosXGrupo = new SelectList(Promocion.TablaAlumnosXGrupo, "IDGrupo", "Nombre");
            ViewData["tblAlumnosXGrupo"] = listAlumnosXGrupo;

            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                PromocionModels Promocion = new PromocionModels();
                _Promocion_Datos PromocionDatos = new _Promocion_Datos();
                Promocion.conexion = Conexion;
                Promocion.grupo = collection["TablaGrupoCmb"];
                Promocion.grupoD = collection["TablaGrupoDCmb"];
                Promocion.numAlumnos = Convert.ToInt32(collection["contAlumnos"]);
                Promocion.TablaAlumnos = new DataTable();
                Promocion.TablaAlumnos.Columns.Add("id_alumno", typeof(string));
                string idalumno = "";
                for (int i=0;i<=Promocion.numAlumnos+1;i++) {
                    try
                    {
                        idalumno = collection["alumno-" + i.ToString()];
                        if(!string.IsNullOrEmpty(idalumno))
                        {
                            Promocion.TablaAlumnos.Rows.Add(idalumno);
                        }
                       
                    }
                    catch {
                            if (idalumno != "")
                            {
                                Promocion.TablaAlumnos.Rows.Add(Promocion);
                            }
                         }
                    }
                Promocion.user = User.Identity.Name;
                Promocion.opcion = 1;
                PromocionDatos.PromoverGrupo(Promocion);

               // Promocion = MateriaDatos.AbcCatMateria(Materia);
                if (Promocion.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Se ha promovido al grupo correctamenta.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Promocion.TablaCicloEscolarCmb = PromocionDatos.ObtenerComboCatCicloEscolar(Promocion);
                    var list = new SelectList(Promocion.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                    ViewData["cmbCicloEscolar"] = list;

                    Promocion.TablaPlanEstudioCmb = PromocionDatos.ObtenerComboCatPlanEstudio(Promocion);
                    var listaPE = new SelectList(Promocion.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                    ViewData["cmbPlanEstudio"] = listaPE;

                    Promocion.TablaModalidadCmb = PromocionDatos.ObtenerComboCatModalidad(Promocion);
                    var listModalidad = new SelectList(Promocion.TablaModalidadCmb, "IDModalidad", "Descripcion");
                    ViewData["cmbModalidad"] = listModalidad;

                    Promocion.TablaEspecialidadCmb = PromocionDatos.ObtenerComboCatEspecialidad(Promocion);
                    var listEspecialidad = new SelectList(Promocion.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                    ViewData["cmbEspecialidad"] = listEspecialidad;

                    Promocion.TablaCursosCmb = PromocionDatos.ObtenerComboCatCursos(Promocion);
                    var listCursos = new SelectList(Promocion.TablaCursosCmb, "IDCurso", "Descripcion");
                    ViewData["cmbCursos"] = listCursos;


                    Promocion.TablaGrupoCmb = PromocionDatos.ObtenerComboCatGrupo(Promocion);
                    var listGrupoOr = new SelectList(Promocion.TablaGrupoCmb, "IDGrupo", "Nombre");
                    ViewData["cmbGrupo"] = listGrupoOr;

                    Promocion.TablaGrupoDCmb = PromocionDatos.ObtenerComboCatGrupo(Promocion);
                    var listGrupoD = new SelectList(Promocion.TablaGrupoDCmb, "IDGrupo", "Nombre");
                    ViewData["cmbGrupoD"] = listGrupoD;

                    Promocion.TablaAlumnosXGrupo = PromocionDatos.ObtenertablaCatAlumnoXGrupo(Promocion);
                    var listAlumnosXGrupo = new SelectList(Promocion.TablaAlumnosXGrupo, "IDGrupo", "Nombre");
                    ViewData["tblAlumnosXGrupo"] = listAlumnosXGrupo;


                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrió un error al intentar guardar.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error el intentar promover al grupo. Por favor Contacte a soporte técnico" ;
                return RedirectToAction("Index");
            }
        }




        //FUNCIONES MEDIANTE AJAX DESDE VISTA
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboModalidad(int idplanEstudio)
        {
            try
            {
                PromocionModels Promocion = new PromocionModels();
                _Promocion_Datos PromocionDatos = new _Promocion_Datos();

                List<CatModalidadModels> listaModalidad = new List<CatModalidadModels>();
                Promocion.conexion = Conexion;
                Promocion.idplanEstudio = idplanEstudio;

                listaModalidad = PromocionDatos.ObtenerComboCatModalidad(Promocion);
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
                PromocionModels Promocion = new PromocionModels();
                _Promocion_Datos PromocionDatos = new _Promocion_Datos();

                List<CatEspecialidadModels> listaEspecialidad = new List<CatEspecialidadModels>();
                Promocion.conexion = Conexion;
                Promocion.IDModalidad = IDModalidad;

                listaEspecialidad = PromocionDatos.ObtenerComboCatEspecialidad(Promocion);
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
                PromocionModels Promocion = new PromocionModels();
                _Promocion_Datos PromocionDatos = new _Promocion_Datos();

                List<CatCursoModels> listaEspecialidad = new List<CatCursoModels>();
                Promocion.conexion = Conexion;
                Promocion.IDEspecialidad = IDEspecialidad;

                listaEspecialidad = PromocionDatos.ObtenerComboCatCursos(Promocion);
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
                PromocionModels Promocion = new PromocionModels();
                _Promocion_Datos PromocionDatos = new _Promocion_Datos();

                List<CatGrupoModels> listaGrupo = new List<CatGrupoModels>();
                Promocion.conexion = Conexion;
                Promocion.ciclo = ciclo;
                Promocion.IDEspecialidad = IDEspecialidad;
                Promocion.curso = curso;

                listaGrupo = PromocionDatos.ObtenerComboCatGrupo(Promocion);
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
                PromocionModels Promocion = new PromocionModels();
                _Promocion_Datos PromocionDatos = new _Promocion_Datos();

                List<CatAlumnoModels> listaAlumnosXGrupo = new List<CatAlumnoModels>();
                Promocion.conexion = Conexion;
                Promocion.grupo = grupo;


                listaAlumnosXGrupo = PromocionDatos.ObtenertablaCatAlumnoXGrupo(Promocion);
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
