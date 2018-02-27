using CreativaSL.Web.Escuela.Filters;
using CreativaSL.Web.Escuela.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class NotificacionProfesorController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/NotificacionProfesor
        public ActionResult Index()
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                NotificacionProfesor.conexion = Conexion;



                NotificacionProfesor.TablaCicloEscolarCmb = NotificacionProfesorDatos.ObtenerComboCatCicloEscolar(NotificacionProfesor);
                var list = new SelectList(NotificacionProfesor.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = list;

                NotificacionProfesor.TablaPlanEstudioCmb = NotificacionProfesorDatos.ObtenerComboCatPlanEstudio(NotificacionProfesor);
                var listaPE = new SelectList(NotificacionProfesor.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = listaPE;

                NotificacionProfesor.TablaModalidadCmb = NotificacionProfesorDatos.ObtenerComboCatModalidad(NotificacionProfesor);
                var listModalidad = new SelectList(NotificacionProfesor.TablaModalidadCmb, "IDModalidad", "Descripcion");
                ViewData["cmbModalidad"] = listModalidad;

                NotificacionProfesor.TablaEspecialidadCmb = NotificacionProfesorDatos.ObtenerComboCatEspecialidad(NotificacionProfesor);
                var listEspecialidad = new SelectList(NotificacionProfesor.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                ViewData["cmbEspecialidad"] = listEspecialidad;

                NotificacionProfesor.TablaCursosCmb = NotificacionProfesorDatos.ObtenerComboCatCursos(NotificacionProfesor);
                var listCursos = new SelectList(NotificacionProfesor.TablaCursosCmb, "IDCurso", "Descripcion");
                ViewData["cmbCursos"] = listCursos;


                NotificacionProfesor.TablaGrupoCmb = NotificacionProfesorDatos.ObtenerComboCatGrupo(NotificacionProfesor);
                var listGrupoOr = new SelectList(NotificacionProfesor.TablaGrupoCmb, "IDGrupo", "Nombre");
                ViewData["cmbGrupo"] = listGrupoOr;

                NotificacionProfesor.TablaProfesorCmb = NotificacionProfesorDatos.obtenerComboCatCatedraticos(NotificacionProfesor);
                var listaProfesor = new SelectList(NotificacionProfesor.TablaProfesorCmb,"id_persona","nombre");
                ViewData["cmbProfesor"] = listaProfesor;

                NotificacionProfesor.TablaDatos = new DataTable();

                //NotificacionProfesor = NotificacionProfesorDatos.obtenerCatNotificacionProfesor(NotificacionProfesor);
                return View(NotificacionProfesor);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult TablaNotificacion(string id,string id2)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                NotificacionProfesor.conexion = Conexion;

                NotificacionProfesor.id_profesor = id;
                NotificacionProfesor.grupo = id2;


                NotificacionProfesor = NotificacionProfesorDatos.obtenerCatNotificacionProfesor(NotificacionProfesor);
                return View(NotificacionProfesor);
                //return RedirectToAction("TablaNotificacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult TablaNotificacionesEnviadas(string id, string id2)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                NotificacionProfesor.conexion = Conexion;

                NotificacionProfesor.id_profesor = id;
                NotificacionProfesor.grupo = id2;


                NotificacionProfesor = NotificacionProfesorDatos.obtenerCatNotificacionProfesorEnviadas(NotificacionProfesor);
                return View(NotificacionProfesor);
                //return RedirectToAction("TablaNotificacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Detalle(string id,string id2,string id3)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.IDNotificacionGeneral = id;
                NotificacionProfesor.id_profesor = id2;
                
                NotificacionProfesor.grupo = id3;
                NotificacionProfesor = NotificacionProfesorDatos.obtenerDetalleCatNotificacionGeneralXID(NotificacionProfesor);

                return View(NotificacionProfesor);
            }
            catch (Exception)
            {
                NotificacionModels Notificacion = new NotificacionModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Notificacion);
            }

        }
        public ActionResult ReenviarNotificacion(string id,string id2,int id3)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                _NotificacionCadena_Datos NotificacionCadenaDatos = new _NotificacionCadena_Datos();
                NotificacionProfesor.IDTipoNotificacion = id3;
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.IDNotificacionGeneral = id;
                NotificacionProfesor.id_registro = id2;
                NotificacionProfesor.user = User.Identity.Name;
                NotificacionProfesorDatos.ReenviarNotificacion(NotificacionProfesor);

                if (NotificacionProfesor.Resultado == 1)
                {
                    NotificacionProfesor.TablaNotificacionXTipo = new DataTable();
                    NotificacionProfesor.TablaNotificacionXTipo.Columns.Add("IDNotificacion", typeof(string));
                    NotificacionProfesor.TablaNotificacionXTipo.Columns.Add("Titulo", typeof(string));
                    NotificacionProfesor.TablaNotificacionXTipo.Columns.Add("Cadena", typeof(string));
                    NotificacionProfesor.TablaNotificacionXTipo.Columns.Add("Resumen", typeof(string));
                    foreach (DataRow notificacion in NotificacionProfesor.TablaAlumnos.Rows)
                    {
                        if (NotificacionProfesor.IDTipoNotificacion == 110) {
                            NotificacionProfesor.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            NotificacionProfesor.fechaEvento= Convert.ToDateTime(notificacion["fechaEvento"].ToString());
                            NotificacionProfesor.nombreEvento = notificacion["nombreEvento"].ToString();
                            NotificacionProfesor.notificacionPlantilla = notificacion["descripcion"].ToString();
                            NotificacionProfesor.resumen= notificacion["resumen"].ToString();
                            NotificacionProfesor.materia = notificacion["materia"].ToString();
                            NotificacionProfesor.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(NotificacionProfesor);
                           


                        }
                        else if (NotificacionProfesor.IDTipoNotificacion == 111)
                        {
                            NotificacionProfesor.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            NotificacionProfesor.fechaEvento = Convert.ToDateTime(notificacion["fechaExamen"].ToString());
                            NotificacionProfesor.nombreEvento = notificacion["nombreExamen"].ToString();
                            NotificacionProfesor.calificacion = Convert.ToSingle(notificacion["calificacion"].ToString());
                            NotificacionProfesor.materia = notificacion["materia"].ToString();
                            NotificacionProfesor.notificacionPlantilla = notificacion["descripcion"].ToString();
                            NotificacionProfesor.resumen = notificacion["resumen"].ToString();
                            NotificacionProfesor.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(NotificacionProfesor);

                        }
                        else if (NotificacionProfesor.IDTipoNotificacion == 112)
                        {
                            NotificacionProfesor.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            NotificacionProfesor.fechaTarea = Convert.ToDateTime(notificacion["fechaEntrega"].ToString());
                            NotificacionProfesor.nombreEvento = notificacion["nombreTarea"].ToString();
                            NotificacionProfesor.calificacion = Convert.ToSingle(notificacion["calificacion"].ToString());
                            NotificacionProfesor.materia = notificacion["materia"].ToString();
                            NotificacionProfesor.notificacionPlantilla = notificacion["descripcion"].ToString();
                            NotificacionProfesor.resumen = notificacion["resumen"].ToString();
                            NotificacionProfesor.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(NotificacionProfesor);
                        }
                        else if (NotificacionProfesor.IDTipoNotificacion == 113)
                        {
                            NotificacionProfesor.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            NotificacionProfesor.fechaTarea = Convert.ToDateTime(notificacion["fechaLista"].ToString());
                            NotificacionProfesor.calificacion = Convert.ToSingle(notificacion["calificacion"].ToString());
                            NotificacionProfesor.materia = notificacion["materia"].ToString();
                            NotificacionProfesor.notificacionPlantilla = notificacion["descripcion"].ToString();
                            NotificacionProfesor.resumen = notificacion["resumen"].ToString();
                            NotificacionProfesor.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(NotificacionProfesor);
                        }
                        NotificacionProfesor.TablaNotificacionXTipo.Rows.Add(notificacion["id_notificacionDetalle"].ToString(), notificacion["titulo"].ToString(), NotificacionProfesor.notificacionFinal, notificacion["resumen"].ToString());
                       
                       
                        string descripcion = NotificacionProfesor.notificacionFinal;
                        int Bagde = 0, IDTipoCelular = 0;
                        Bagde = Convert.ToInt32(notificacion["badge"].ToString());
                        IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());
                        
                        Comun.EnviarMensaje(notificacion["token"].ToString(), notificacion["titulo"].ToString(), notificacion["resumen"].ToString(), Bagde, IDTipoCelular);
                    }
                    NotificacionProfesorDatos.actualizarDetalleNotificacion(NotificacionProfesor);
                }


                TempData["message"] = "El reenvio se llevó a cabo correctamente";
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
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, string id2, string id3, FormCollection collection)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.IDNotificacionGeneral = id;
                NotificacionProfesor.id_profesor = id2;
                NotificacionProfesor.grupo = id3;
                NotificacionProfesor.opcion = 2;
                NotificacionProfesor.TablaAlumnos = new DataTable();
                NotificacionProfesor.TablaAlumnos.Columns.Add("id_alumno", typeof(string));
                NotificacionProfesor.user = User.Identity.Name;
                NotificacionProfesorDatos.insertarNotificacion(NotificacionProfesor);
                if (NotificacionProfesor.Resultado == 1)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se elimino correctamente.";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El registro no se elimino correctamente.";
                    return Json("");
                }
            }
            catch
            {
                return View();
            }
        }
        //FUNCIONES MEDIANTE AJAX DESDE VISTA
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult llenarTabla(string id_profesor,string id_grupo)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                
               
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.id_profesor = id_profesor;
                NotificacionProfesor.grupo = id_grupo;

                NotificacionProfesor = NotificacionProfesorDatos.obtenerCatNotificacionProfesor(NotificacionProfesor);


                var list = new List<Dictionary<string, object>>();

                foreach (DataRow row in NotificacionProfesor.TablaDatos.Rows)
                {
                    var dict = new Dictionary<string, object>();

                    foreach (DataColumn col in NotificacionProfesor.TablaDatos.Columns)
                    {
                        dict[col.ColumnName] = (Convert.ToString(row[col]));
                    }
                    list.Add(dict);
                }
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                return Json(list, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

      [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboModalidad(int idplanEstudio)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();
                
                List<CatModalidadModels> listaModalidad = new List<CatModalidadModels>();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.idplanEstudio = idplanEstudio;

                listaModalidad = NotificacionProfesorDatos.ObtenerComboCatModalidad(NotificacionProfesor);
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
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();

                List<CatEspecialidadModels> listaEspecialidad = new List<CatEspecialidadModels>();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.IDModalidad = IDModalidad;

                listaEspecialidad = NotificacionProfesorDatos.ObtenerComboCatEspecialidad(NotificacionProfesor);
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
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();

                List<CatCursoModels> listaEspecialidad = new List<CatCursoModels>();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.IDEspecialidad = IDEspecialidad;

                listaEspecialidad = NotificacionProfesorDatos.ObtenerComboCatCursos(NotificacionProfesor);
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
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();

                List<CatGrupoModels> listaGrupo = new List<CatGrupoModels>();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.ciclo = ciclo;
                NotificacionProfesor.IDEspecialidad = IDEspecialidad;
                NotificacionProfesor.curso = curso;

                listaGrupo = NotificacionProfesorDatos.ObtenerComboCatGrupo(NotificacionProfesor);
                return Json(listaGrupo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboProfesor(string grupo)
        {
            try
            {
                NotificacionesProfesorModels NotificacionProfesor = new NotificacionesProfesorModels();
                _Notificaciones_Profesor_Datos NotificacionProfesorDatos = new _Notificaciones_Profesor_Datos();

                List<CatCatedraticoModels> listaGrupo = new List<CatCatedraticoModels>();
                NotificacionProfesor.conexion = Conexion;
                NotificacionProfesor.grupo = grupo;
               

                listaGrupo = NotificacionProfesorDatos.obtenerComboCatCatedraticos(NotificacionProfesor);
                return Json(listaGrupo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
