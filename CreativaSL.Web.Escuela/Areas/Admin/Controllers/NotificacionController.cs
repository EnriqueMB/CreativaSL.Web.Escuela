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
    public class NotificacionController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        [HttpGet]
        public ActionResult Index()
        {
            NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
            _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();
            NotificacionGeneral.conexion = Conexion;
            NotificacionGeneral = NotificacionGeneralDatos.obtenerCatNotificacionGeneral(NotificacionGeneral);
            return View(NotificacionGeneral);
         
        }
        

        [HttpGet]
        public ActionResult NotificacionesGenerales() {
            NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
            _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();
            NotificacionGeneral.conexion = Conexion;

            NotificacionGeneral.TablaTipoNotificacionCmb = NotificacionGeneralDatos.obtenerListaTipoNotificacion(NotificacionGeneral);
            var listtn = new SelectList(NotificacionGeneral.TablaTipoNotificacionCmb, "id_tipoNotificacion", "descripcion");
            ViewData["cmbTipoNotificacion"] = listtn;

            NotificacionGeneral.TablaCicloEscolarCmb = NotificacionGeneralDatos.ObtenerComboCatCicloEscolar(NotificacionGeneral);
            var list = new SelectList(NotificacionGeneral.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
            ViewData["cmbCicloEscolar"] = list;

            NotificacionGeneral.TablaPlanEstudioCmb = NotificacionGeneralDatos.ObtenerComboCatPlanEstudio(NotificacionGeneral);
            var listaPE = new SelectList(NotificacionGeneral.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
            ViewData["cmbPlanEstudio"] = listaPE;

            NotificacionGeneral.TablaModalidadCmb = NotificacionGeneralDatos.ObtenerComboCatModalidad(NotificacionGeneral);
            var listModalidad = new SelectList(NotificacionGeneral.TablaModalidadCmb, "IDModalidad", "Descripcion");
            ViewData["cmbModalidad"] = listModalidad;

            NotificacionGeneral.TablaEspecialidadCmb = NotificacionGeneralDatos.ObtenerComboCatEspecialidad(NotificacionGeneral);
            var listEspecialidad = new SelectList(NotificacionGeneral.TablaEspecialidadCmb, "id_especialidad", "descripcion");
            ViewData["cmbEspecialidad"] = listEspecialidad;

            NotificacionGeneral.TablaCursosCmb = NotificacionGeneralDatos.ObtenerComboCatCursos(NotificacionGeneral);
            var listCursos = new SelectList(NotificacionGeneral.TablaCursosCmb, "IDCurso", "Descripcion");
            ViewData["cmbCursos"] = listCursos;


            NotificacionGeneral.TablaGrupoCmb = NotificacionGeneralDatos.ObtenerComboCatGrupo(NotificacionGeneral);
            var listGrupoOr = new SelectList(NotificacionGeneral.TablaGrupoCmb, "IDGrupo", "Nombre");
            ViewData["cmbGrupo"] = listGrupoOr;

            NotificacionGeneral.tutores = Convert.ToBoolean("true");

            NotificacionGeneral.TablaAlumnosXGrupo = NotificacionGeneralDatos.ObtenertablaCatAlumnoXGrupo(NotificacionGeneral);
            var listAlumnosXGrupo = new SelectList(NotificacionGeneral.TablaAlumnosXGrupo, "IDPersona", "nombre");
            ViewData["tblAlumnosXGrupo"] = listAlumnosXGrupo;
            return View();
        }
        [HttpPost]
        public ActionResult NotificacionesGenerales(FormCollection collection)
        {
            try
            {
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.IDNotificacionGeneral = "";
                NotificacionGeneral.idplanEstudio = Convert.ToInt32(collection["TablaPlanEstudioCmb"]);
                NotificacionGeneral.IDModalidad = collection["TablaModalidadCmb"];
                NotificacionGeneral.IDEspecialidad = collection["TablaEspecialidadCmb"];
                NotificacionGeneral.curso = collection["TablaCursosCmb"];
                NotificacionGeneral.grupo = collection["TablaGrupoCmb"];
                NotificacionGeneral.ciclo = collection["TablaCicloEscolarCmb"];
                NotificacionGeneral.IDTipoNotificacion = Convert.ToInt32(collection["TablaTipoNotificacionCmb"]);
                NotificacionGeneral.titulo = collection["titulo"];
                NotificacionGeneral.texto = collection["texto"];
                NotificacionGeneral.tutores = (collection["tutores"]).StartsWith("true");
                NotificacionGeneral.numAlumnos = Convert.ToInt32(collection["contAlumnos"]);
                NotificacionGeneral.TablaAlumnos = new DataTable();
                NotificacionGeneral.TablaAlumnos.Columns.Add("id_alumno", typeof(string));
                NotificacionGeneral.user = User.Identity.Name;
                string idalumno = "";
                NotificacionGeneral.opcion = 1;
                for (int i = 0; i <= NotificacionGeneral.numAlumnos; i++)
                {
                    try
                    {
                        idalumno = collection["alumno-" + i.ToString()];
                        if (!string.IsNullOrEmpty(idalumno))
                        {
                            NotificacionGeneral.TablaAlumnos.Rows.Add(idalumno);
                        }

                    }
                    catch
                    {
                        if (idalumno != "")
                        {
                            NotificacionGeneral.TablaAlumnos.Rows.Add(NotificacionGeneral);
                        }
                    }
                }
                NotificacionGeneralDatos.insertarNotificacion(NotificacionGeneral);

                if (NotificacionGeneral.Resultado == 1)
                {
                    foreach (DataRow notificacion in NotificacionGeneral.TablaAlumnos.Rows)
                    {
                        int Bagde = 0, IDTipoCelular = 0;
                        Bagde = Convert.ToInt32(notificacion["Badge"].ToString());
                        IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                        Comun.EnviarMensaje(notificacion["token"].ToString(), notificacion["titulo"].ToString(), notificacion["descripcion"].ToString(), Bagde, IDTipoCelular);
                    }
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Se ha realizado el envio correctamente.";
                    return RedirectToAction("NotificacionesGenerales");
                }
                else
                {
                    NotificacionGeneral.TablaCicloEscolarCmb = NotificacionGeneralDatos.ObtenerComboCatCicloEscolar(NotificacionGeneral);
                    var list = new SelectList(NotificacionGeneral.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                    ViewData["cmbCicloEscolar"] = list;

                    NotificacionGeneral.TablaPlanEstudioCmb = NotificacionGeneralDatos.ObtenerComboCatPlanEstudio(NotificacionGeneral);
                    var listaPE = new SelectList(NotificacionGeneral.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                    ViewData["cmbPlanEstudio"] = listaPE;

                    NotificacionGeneral.TablaModalidadCmb = NotificacionGeneralDatos.ObtenerComboCatModalidad(NotificacionGeneral);
                    var listModalidad = new SelectList(NotificacionGeneral.TablaModalidadCmb, "IDModalidad", "Descripcion");
                    ViewData["cmbModalidad"] = listModalidad;

                    NotificacionGeneral.TablaEspecialidadCmb = NotificacionGeneralDatos.ObtenerComboCatEspecialidad(NotificacionGeneral);
                    var listEspecialidad = new SelectList(NotificacionGeneral.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                    ViewData["cmbEspecialidad"] = listEspecialidad;

                    NotificacionGeneral.TablaCursosCmb = NotificacionGeneralDatos.ObtenerComboCatCursos(NotificacionGeneral);
                    var listCursos = new SelectList(NotificacionGeneral.TablaCursosCmb, "IDCurso", "Descripcion");
                    ViewData["cmbCursos"] = listCursos;


                    NotificacionGeneral.TablaGrupoCmb = NotificacionGeneralDatos.ObtenerComboCatGrupo(NotificacionGeneral);
                    var listGrupoOr = new SelectList(NotificacionGeneral.TablaGrupoCmb, "IDGrupo", "Nombre");
                    ViewData["cmbGrupo"] = listGrupoOr;

                    NotificacionGeneral.tutores = Convert.ToBoolean("true");

                    NotificacionGeneral.TablaAlumnosXGrupo = NotificacionGeneralDatos.ObtenertablaCatAlumnoXGrupo(NotificacionGeneral);
                    var listAlumnosXGrupo = new SelectList(NotificacionGeneral.TablaAlumnosXGrupo, "IDPersona", "nombre");
                    ViewData["tblAlumnosXGrupo"] = listAlumnosXGrupo;

                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrió un error. Por favor Contacte a soporte técnico";
                    return RedirectToAction("NotificacionesGenerales");
                }

                return View();
            }
            catch (Exception ex)
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error. Por favor Contacte a soporte técnico";
                return RedirectToAction("NotificacionesGenerales");
            }
        }

        // GET: Admin/Notificacion 
        
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

        [HttpGet]
        public ActionResult Detalle(string id) {
            NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
            _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();
            NotificacionGeneral.conexion = Conexion;
            NotificacionGeneral.IDNotificacionGeneral = id;
            NotificacionGeneral = NotificacionGeneralDatos.obtenerDetalleCatNotificacionGeneralXID(NotificacionGeneral);

            return View(NotificacionGeneral);
        }

        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatGrupo/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.IDNotificacionGeneral = id;
                NotificacionGeneral.opcion = 2;
                NotificacionGeneral.TablaAlumnos = new DataTable();
                NotificacionGeneral.TablaAlumnos.Columns.Add("id_alumno", typeof(string));
                NotificacionGeneral.user = User.Identity.Name;
                 NotificacionGeneralDatos.insertarNotificacion(NotificacionGeneral);
                if (NotificacionGeneral.Resultado == 1)
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
        public ActionResult ReenviarNotificacion(string id)
        {
            try
            {
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();

                
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.IDNotificacionGeneral = id;
                NotificacionGeneralDatos.ReenviarNotificacion(NotificacionGeneral);

                if (NotificacionGeneral.Resultado == 1)
                {
                    foreach (DataRow notificacion in NotificacionGeneral.TablaAlumnos.Rows)
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
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboModalidad(int idplanEstudio)
        {
            try
            {
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();

                List<CatModalidadModels> listaModalidad = new List<CatModalidadModels>();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.idplanEstudio = idplanEstudio;

                listaModalidad = NotificacionGeneralDatos.ObtenerComboCatModalidad(NotificacionGeneral);
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
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();

                List<CatEspecialidadModels> listaEspecialidad = new List<CatEspecialidadModels>();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.IDModalidad = IDModalidad;

                listaEspecialidad = NotificacionGeneralDatos.ObtenerComboCatEspecialidad(NotificacionGeneral);
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
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();

                List<CatCursoModels> listaEspecialidad = new List<CatCursoModels>();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.IDEspecialidad = IDEspecialidad;

                listaEspecialidad = NotificacionGeneralDatos.ObtenerComboCatCursos(NotificacionGeneral);
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
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();

                List<CatGrupoModels> listaGrupo = new List<CatGrupoModels>();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.ciclo = ciclo;
                NotificacionGeneral.IDEspecialidad = IDEspecialidad;
                NotificacionGeneral.curso = curso;

                listaGrupo = NotificacionGeneralDatos.ObtenerComboCatGrupo(NotificacionGeneral);
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
                NotificacionesGeneralesModels NotificacionGeneral = new NotificacionesGeneralesModels();
                _NotificacionesGenerales_Datos NotificacionGeneralDatos = new _NotificacionesGenerales_Datos();

                List<CatAlumnoModels> listaAlumnosXGrupo = new List<CatAlumnoModels>();
                NotificacionGeneral.conexion = Conexion;
                NotificacionGeneral.grupo = grupo;


                listaAlumnosXGrupo = NotificacionGeneralDatos.ObtenertablaCatAlumnoXGrupo(NotificacionGeneral);
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