using CreativaSL.Web.Escuela.Filters;
using CreativaSL.Web.Escuela.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class ReportesController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        
        // GET: Admin/Reportes
        public ActionResult Index()
        {
            try
            {
                ReportesModels Reportes = new ReportesModels();
                _Reportes_Datos ReportesDatos = new _Reportes_Datos();
                Reportes.conexion = Conexion;
                Reportes.listaCicloEscolar = ReportesDatos.ObtenerComboCatCicloEscolar(Reportes);
                var listaCicloEscolar = new SelectList(Reportes.listaCicloEscolar, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = listaCicloEscolar;

                Reportes.listaPlanEstudio = ReportesDatos.ObtenerComboCatPlanEstudio(Reportes);
                var listaPlanEstudios = new SelectList(Reportes.listaPlanEstudio, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = listaPlanEstudios;

                Reportes.listaModalidad = ReportesDatos.ObtenerComboCatModalidad(Reportes);
                var listaModalidad = new SelectList(Reportes.listaModalidad, "IDModalidad", "Descripcion");
                ViewData["cmbModalidad"] = listaModalidad;

                Reportes.listaEspecialidad = ReportesDatos.ObtenerComboCatEspecialidad(Reportes);
                var listaEspecialidad = new SelectList(Reportes.listaEspecialidad, "id_especialidad", "descripcion");
                ViewData["cmbEspecialidad"] = listaEspecialidad;

                Reportes.listaCursos = ReportesDatos.ObtenerComboCatCursos(Reportes);
                var listaCursos = new SelectList(Reportes.listaCursos, "IDCurso", "Descripcion");
                ViewData["cmbCursos"] = listaCursos;

                Reportes.listaGrupos = ReportesDatos.ObtenerComboCatGrupo(Reportes);
                var listaGrupos = new SelectList(Reportes.listaGrupos, "IDGrupo", "Nombre");
                ViewData["cmbGrupos"] = listaGrupos;

                

              


                return View(Reportes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Reenviar(string id, string id2, int id3,string id4,string id5)
        {
            try
            {
                ReportesModels Reportes = new ReportesModels();
                _Reportes_Datos ReportesDatos = new _Reportes_Datos();
                _NotificacionCadena_Datos NotificacionCadenaDatos = new _NotificacionCadena_Datos();
                Reportes.id_tipo_notificacion = id3;
                Reportes.conexion = Conexion;
                Reportes.id_registro = id;
                Reportes.id_alumno = id2;
                Reportes.id_grupo = id4;
                Reportes.id_curso = id5;
                Reportes.user = User.Identity.Name;
                ReportesDatos.insertarNotificacion(Reportes);

                if (Reportes.Resultado == 1)
                {
                    Reportes.TablaNotificacionXTipo = new DataTable();
                    Reportes.TablaNotificacionXTipo.Columns.Add("IDNotificacion", typeof(string));
                    Reportes.TablaNotificacionXTipo.Columns.Add("Titulo", typeof(string));
                    Reportes.TablaNotificacionXTipo.Columns.Add("Cadena", typeof(string));
                    Reportes.TablaNotificacionXTipo.Columns.Add("Resumen", typeof(string));
                    foreach (DataRow notificacion in Reportes.TablaAlumnos.Rows)
                    {
                        if (Reportes.id_tipo_notificacion == 110)
                        {
                            Reportes.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            Reportes.fechaEvento = Convert.ToDateTime(notificacion["fechaEvento"].ToString());
                            Reportes.nombreEvento = notificacion["nombreEvento"].ToString();
                            Reportes.notificacionPlantilla = notificacion["descripcion"].ToString();
                            Reportes.resumen = notificacion["resumen"].ToString();
                            Reportes.materia = notificacion["materia"].ToString();
                            Reportes.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(Reportes);



                        }
                        else if (Reportes.id_tipo_notificacion == 111)
                        {
                            Reportes.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            Reportes.fechaEvento = Convert.ToDateTime(notificacion["fechaExamen"].ToString());
                            Reportes.nombreEvento = notificacion["nombreExamen"].ToString();
                            Reportes.calificacion = Convert.ToSingle(notificacion["calificacion"].ToString());
                            Reportes.materia = notificacion["materia"].ToString();
                            Reportes.notificacionPlantilla = notificacion["descripcion"].ToString();
                            Reportes.resumen = notificacion["resumen"].ToString();
                            Reportes.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(Reportes);

                        }
                        else if (Reportes.id_tipo_notificacion == 112)
                        {
                            Reportes.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            Reportes.fechaTarea = Convert.ToDateTime(notificacion["fechaEntrega"].ToString());
                            Reportes.nombreEvento = notificacion["nombreTarea"].ToString();
                            Reportes.calificacion = Convert.ToSingle(notificacion["calificacion"].ToString());
                            Reportes.materia = notificacion["materia"].ToString();
                            Reportes.notificacionPlantilla = notificacion["descripcion"].ToString();
                            Reportes.resumen = notificacion["resumen"].ToString();
                            Reportes.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(Reportes);
                        }
                        else if (Reportes.id_tipo_notificacion == 113)
                        {
                            Reportes.nombreAlumno = notificacion["nombreCompleto"].ToString();
                            Reportes.fechaTarea = Convert.ToDateTime(notificacion["fechaLista"].ToString());
                            Reportes.calificacion = Convert.ToSingle(notificacion["calificacion"].ToString());
                            Reportes.materia = notificacion["materia"].ToString();
                            Reportes.notificacionPlantilla = notificacion["descripcion"].ToString();
                            Reportes.resumen = notificacion["resumen"].ToString();
                            Reportes.profesor = notificacion["profesor"].ToString();
                            NotificacionCadenaDatos.CadenaFinal(Reportes);
                        }
                        Reportes.TablaNotificacionXTipo.Rows.Add(notificacion["id_notificacionDetalle"].ToString(), notificacion["titulo"].ToString(), Reportes.notificacionFinal, notificacion["resumen"].ToString());


                        string descripcion = Reportes.notificacionFinal;
                        int Bagde = 0, IDTipoCelular = 0;
                        Bagde = Convert.ToInt32(notificacion["badge"].ToString());
                        IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                        Comun.EnviarMensaje(notificacion["token"].ToString(), notificacion["titulo"].ToString(), notificacion["resumen"].ToString(), Bagde, IDTipoCelular);
                    }
                    ReportesDatos.actualizarDetalleNotificacion(Reportes);
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
        [HttpGet]
        public ActionResult Detalle(string id, string id2, string id3)
        {
            try
            {
                ReportesModels Reportes = new ReportesModels();
                _Reportes_Datos ReportesDatos = new _Reportes_Datos();
                Reportes.conexion = Conexion;

                Reportes.id_curso =id;
                Reportes.id_grupo =  id2;
                Reportes.fechaReporte =  DateTime.ParseExact(id3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Reportes = ReportesDatos.ObtenerReporteDetalle(Reportes);
                return View(Reportes);
                //return RedirectToAction("TablaNotificacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}