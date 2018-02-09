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

        // GET: /Profesor/CatMateria/Tarea/5
        [HttpGet]
        public ActionResult Tarea(string id)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.IDAsignatura = id;
                tarea = tarea_datos.ObtenerCatTareaPROF(tarea);
                return View(tarea);
            }
            catch (Exception)
            {
                TareasModels tarea = new TareasModels();
                tarea.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(tarea);
            }
        }

        // GET: /Profesor/CatMateria/CreateTarea
        [HttpGet]
        public ActionResult CreateTarea(string id)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.IDAsignatura = id;
                return View(tarea);
            }
            catch (Exception)
            {
                TareasModels tarea = new TareasModels();
                tarea.IDAsignatura = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
            }
        }

        // POST: Admin/CatMateria/CreateTarea
        [HttpPost]
        public ActionResult CreateTarea(string id, FormCollection collection)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.opcion = 1;
                tarea.IDAsignatura = collection["IDAsignatura"];
                tarea.NombreTarea = collection["NombreTarea"];
                tarea.Descripcion = collection["Descripcion"];
                tarea.FechaEntraga = DateTime.ParseExact(collection["FechaEntraga"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                tarea.FechaEnvio = DateTime.ParseExact(collection["FechaEnvio"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                tarea.IDTarea = "";
                tarea.user = User.Identity.Name;
                tarea_datos.AbcTareas(tarea);
                if (tarea.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "La Tarea sea creado correctamente";
                    return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar la información. Intente más tarde.";
                    return RedirectToAction("CreateTarea", "CatMateria", new { id = tarea.IDAsignatura });
                }
                


            }
            catch (Exception)
            {
                TareasModels tarea = new TareasModels();
                tarea.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error al intentar guardar la información. Contacte a soporte técnico.";
                return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/EditTarea/5
        [HttpGet]
        public ActionResult EditTarea(string id, string id2)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.IDTarea = id;
                tarea.IDAsignatura = id2;
                tarea = tarea_datos.ObtenerDetalleTareaPROFXID(tarea);
                return View(tarea);
            }
            catch (Exception)
            {
                TareasModels tarea = new TareasModels();
                tarea.IDAsignatura = id2;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
            }
        }

        // POST: /Profesor/CatMateria/EditTarea/5
        [HttpPost]
        public ActionResult EditTarea(string id, string id2, FormCollection collection)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.opcion = 2;
                tarea.IDTarea = id;
                tarea.IDAsignatura = collection["IDAsignatura"];
                tarea.NombreTarea = collection["NombreTarea"];
                tarea.Descripcion = collection["Descripcion"];
                tarea.FechaEntraga = DateTime.ParseExact(collection["FechaEntrega"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                tarea.FechaEnvio = DateTime.ParseExact(collection["FechaEnvio"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                tarea.user = User.Identity.Name;
                tarea_datos.AbcTareas(tarea);
                TempData["typemessage"] = "1";
                TempData["message"] = "Tarea sea editado correctamente";
                return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
            }
            catch (Exception)
            {
                TareasModels tarea = new TareasModels();
                tarea.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No se pudo guardar correctamente";
                return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/DeleteTarea/5
        [HttpGet]
        public ActionResult DeleteTarea(string id, string id2)
        {
            return View();
        }

        // POST:  /Profesor/CatMateria/DeleteTarea/5
        [HttpPost]
        public ActionResult DeleteTarea(string id, string id2, FormCollection collection)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.IDTarea = id;
                tarea.IDAsignatura = id2;
                tarea.opcion = 3;
                tarea.user = User.Identity.Name;
                tarea_datos.AbcTareas(tarea);
                TempData["typemessage"] = "1";
                TempData["message"] = "La Tarea se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Profesor/CatMateria/VerTarea/5
        [HttpGet]
        public ActionResult VerTarea(string id, string id2)
        {
            try
            {
                TareasModels tarea = new TareasModels();
                Tareas_Datos tarea_datos = new Tareas_Datos();
                tarea.conexion = Conexion;
                tarea.IDTarea = id;
                tarea.IDAsignatura = id2;
                tarea = tarea_datos.DetalleTareaPROFXID(tarea);
                return View(tarea);
            }
            catch (Exception)
            {
                TareasModels tarea = new TareasModels();
                tarea.IDAsignatura = id2;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Tarea", new { id = tarea.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/Calificacion/5
        [HttpGet]
        public ActionResult CalificacionTarea(string id, string id2)
        {
            try
            {
                AlumnoXTareaModels alumnoXtarea = new AlumnoXTareaModels();
                AlumnoXTarea_Datos alumnoXtarea_datos = new AlumnoXTarea_Datos();
                alumnoXtarea.conexion = Conexion;
                alumnoXtarea.IDTarea = id;
                alumnoXtarea.IDAsignatura = id2;
                alumnoXtarea = alumnoXtarea_datos.ObtenerAlumnoXTarea(alumnoXtarea);
                if (alumnoXtarea.TablaAlumnoTarea != null)
                {
                    alumnoXtarea.NumeroAlumno = alumnoXtarea.TablaAlumnoTarea.Rows.Count;
                }
                else
                {
                    alumnoXtarea.NumeroAlumno = 0;
                }
                return View(alumnoXtarea);
            }
            catch (Exception)
            {
                AlumnoXTareaModels alumnoXtarea = new AlumnoXTareaModels();
                alumnoXtarea.IDAsignatura = id2;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Tarea", new { id = alumnoXtarea.IDAsignatura });
            }
        }

        // POST: Admin/CatMateria/CreateEvento
        [HttpPost]
        public ActionResult CalificacionTarea(string id, FormCollection collection)
        {
            try
            {
                AlumnoXTareaModels alumnoXtarea = new AlumnoXTareaModels();
                AlumnoXTarea_Datos alumnoXtarea_datos = new AlumnoXTarea_Datos();
                alumnoXtarea.conexion = Conexion;
                alumnoXtarea.opcion = 1;
                alumnoXtarea.IDAsignatura = collection["IDAsignatura"];
                alumnoXtarea.IDTarea = collection["IDTarea"];
                alumnoXtarea.NumeroAlumno = Convert.ToInt32(collection["NumeroAlumno"]);
                alumnoXtarea.user = User.Identity.Name;
                alumnoXtarea.TablaAlumnoTarea = new DataTable();
                alumnoXtarea.TablaAlumnoTarea.Columns.Add("IDAlumno", typeof(string));
                alumnoXtarea.TablaAlumnoTarea.Columns.Add("Calificacion", typeof(float));
                string idAlumno = "";
                float Calificacion = 0.0F;
                for (int auxNumAlum = 1; auxNumAlum <= alumnoXtarea.NumeroAlumno; auxNumAlum++)
                {
                    try
                    {
                        idAlumno = collection["idAlumno" + auxNumAlum.ToString()];
                        Calificacion = Convert.ToSingle(collection["calificacion" + auxNumAlum.ToString()]);
                        alumnoXtarea.TablaAlumnoTarea.Rows.Add(idAlumno, Calificacion);

                    }
                    catch (Exception ex)
                    {
                        if (idAlumno != "")
                        {
                            Calificacion = 0.0F;
                            alumnoXtarea.TablaAlumnoTarea.Rows.Add(idAlumno, Calificacion);
                        }
                    }
                }
                if (alumnoXtarea_datos.GuardarCalificacion(ref alumnoXtarea) == 1)
                {
                    //foreach (DataRow notificacion in alumnoXtarea.TablaNotificacion.Rows)
                    //{ 
                    //    int Bagde = 0, IDTipoCelular = 0;
                    //    Bagde = Convert.ToInt32(notificacion["Badge"].ToString());
                    //    IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                    //    Comun.EnviarMensaje(notificacion["idCelular"].ToString(), notificacion["TituloNot"].ToString(), notificacion["descripcion"].ToString(), Bagde, IDTipoCelular);
                    //}
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Las Calificaciones sea agregaron correctamente";
                    return RedirectToAction("Tarea", new { id = alumnoXtarea.IDAsignatura });
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "No puede guardar correctamente";
                    return RedirectToAction("Calificacion", new { id = alumnoXtarea.IDTarea, id2 = alumnoXtarea.IDAsignatura });
                }
            }
            catch (Exception)
            {
                AlumnoXTareaModels alumnoXtarea = new AlumnoXTareaModels();
                alumnoXtarea.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("Calificacion", new { id = alumnoXtarea.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/Examen/5
        [HttpGet]
        public ActionResult Examen(string id)
        {
            try
            {
                ExamenModels examen = new ExamenModels();
                Examen_Datos examen_datos = new Examen_Datos();
                examen.conexion = Conexion;
                examen.IDAsignatura = id;
                examen = examen_datos.ObtenerExamenPROF(examen);
                return View(examen);
            }
            catch (Exception)
            {
                ExamenModels examen = new ExamenModels();
                examen.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(examen);
            }
        }

        // GET: /Profesor/CatMateria/CreateExamen
        [HttpGet]
        public ActionResult CreateExamen(string id)
        {
            try
            {
                ExamenModels examen = new ExamenModels();
                Examen_Datos examen_datos = new Examen_Datos();
                examen.conexion = Conexion;
                examen.IDAsignatura = id;
                return View(examen);
            }
            catch (Exception)
            {
                ExamenModels examen = new ExamenModels();
                examen.IDAsignatura = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Tarea", new { id = examen.IDAsignatura });
            }
        }

        // POST: Admin/CatMateria/CreateExamen
        [HttpPost]
        public ActionResult CreateExamen(string id, FormCollection collection)
        {
            try
            {
                ExamenModels examen = new ExamenModels();
                Examen_Datos examen_datos = new Examen_Datos();
                examen.conexion = Conexion;
                examen.opcion = 1;
                examen.IDAsignatura = collection["IDAsignatura"];
                examen.NombreExamen = collection["NombreExamen"];
                examen.Descripcion = collection["Descripcion"];
                examen.FechaExamen = DateTime.ParseExact(collection["FechaExamen"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                examen.FechaEnvio = DateTime.ParseExact(collection["FechaEnvio"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                examen.IDExamen = "";
                examen.user = User.Identity.Name;
                examen_datos.AbcExamen(examen);
                if (examen.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El Examen sea creado correctamente";

                    return RedirectToAction("Examen", new { id = examen.IDAsignatura });
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar la información. Intente más tarde.";
                    return RedirectToAction("CreateExamen", "CatMateria", new { id = examen.IDAsignatura });
                }
               
            }
            catch (Exception)
            {
                ExamenModels examen = new ExamenModels();
                examen.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error al intentar guardar la información. Contacte a soporte técnico.";
                return RedirectToAction("Examen", new { id = examen.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/DeleteExamen/5
        [HttpGet]
        public ActionResult DeleteExamen(string id, string id2)
        {
            return View();
        }

        // POST:  /Profesor/CatMateria/DeleteExamen/5
        [HttpPost]
        public ActionResult DeleteExamen(string id, string id2, FormCollection collection)
        {
            try
            {
                ExamenModels examen = new ExamenModels();
                Examen_Datos examen_datos = new Examen_Datos();
                examen.conexion = Conexion;
                examen.IDExamen = id;
                examen.IDAsignatura = id2;
                examen.opcion = 3;
                examen.user = User.Identity.Name;
                examen_datos.AbcExamen(examen);
                TempData["typemessage"] = "1";
                TempData["message"] = "El registro se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Profesor/CatMateria/VerExamen/5
        [HttpGet]
        public ActionResult VerExamen(string id, string id2)
        {
            try
            {
                ExamenModels examen = new ExamenModels();
                Examen_Datos examen_datos = new Examen_Datos();
                examen.conexion = Conexion;
                examen.IDExamen = id;
                examen.IDAsignatura = id2;
                examen = examen_datos.DetalleExamenPROFXID(examen);
                return View(examen);
            }
            catch (Exception)
            {
                ExamenModels examen = new ExamenModels();
                examen.IDAsignatura = id2;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Examen", new { id = examen.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/CalificacionExamen/5
        [HttpGet]
        public ActionResult CalificacionExamen(string id, string id2)
        {
            try
            {
                AlumnoXExamenModels alumnoXexamen = new AlumnoXExamenModels();
                AlumnoXExamen_Datos alumnoXexamen_datos = new AlumnoXExamen_Datos();
                alumnoXexamen.conexion = Conexion;
                alumnoXexamen.IDExamen = id;
                alumnoXexamen.IDAsignatura = id2;
                alumnoXexamen = alumnoXexamen_datos.ObtenerAlumnoXExamen(alumnoXexamen);
                if (alumnoXexamen.TablaDatos != null)
                {
                    alumnoXexamen.NumeroAlumnos = alumnoXexamen.TablaDatos.Rows.Count;
                }
                else
                {
                    alumnoXexamen.NumeroAlumnos = 0;
                }
                return View(alumnoXexamen);
            }
            catch (Exception)
            {
                AlumnoXExamenModels alumnoXexamen = new AlumnoXExamenModels();
                alumnoXexamen.IDAsignatura = id2;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Examen", new { id = alumnoXexamen.IDAsignatura });
            }
        }

        // POST: Admin/CatMateria/CreateEvento
        [HttpPost]
        public ActionResult CalificacionExamen(string id, FormCollection collection)
        {
            try
            {
                AlumnoXExamenModels alumnoXexamen = new AlumnoXExamenModels();
                AlumnoXExamen_Datos alumnoXexamen_datos = new AlumnoXExamen_Datos();
                alumnoXexamen.conexion = Conexion;
                alumnoXexamen.opcion = 1;
                alumnoXexamen.IDAsignatura = collection["IDAsignatura"];
                alumnoXexamen.IDExamen = collection["IDExamen"];
                alumnoXexamen.NumeroAlumnos = Convert.ToInt32(collection["NumeroAlumnos"]);
                alumnoXexamen.user = User.Identity.Name;
                alumnoXexamen.TablaCalificacionExamen = new DataTable();
                alumnoXexamen.TablaCalificacionExamen.Columns.Add("IDAlumno", typeof(string));
                alumnoXexamen.TablaCalificacionExamen.Columns.Add("Calificacion", typeof(float));
                string idAlumno = "";
                float Calificacion = 0.0F;
                for (int auxNumAlum = 1; auxNumAlum <= alumnoXexamen.NumeroAlumnos; auxNumAlum++)
                {
                    try
                    {
                        idAlumno = collection["idAlumno" + auxNumAlum.ToString()];
                        Calificacion = Convert.ToSingle(collection["calificacion" + auxNumAlum.ToString()]);
                        alumnoXexamen.TablaCalificacionExamen.Rows.Add(idAlumno, Calificacion);

                    }
                    catch (Exception ex)
                    {
                        if (idAlumno != "")
                        {
                            Calificacion = 0.0F;
                            alumnoXexamen.TablaCalificacionExamen.Rows.Add(idAlumno, Calificacion);
                        }
                    }
                }
                if (alumnoXexamen_datos.GuardarCalificacion(ref alumnoXexamen) == 1)
                {
                    //foreach (DataRow notificacion in alumnoXexamen.tablaNotificaciones.Rows)
                    //{
                    //    int Bagde = 0, IDTipoCelular = 0;
                    //    Bagde = Convert.ToInt32(notificacion["Badge"].ToString());
                    //    IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                    //    Comun.EnviarMensaje(notificacion["idCelular"].ToString(), notificacion["TituloNot"].ToString(), notificacion["descripcion"].ToString(), Bagde, IDTipoCelular);
                    //}

                    TempData["typemessage"] = "1";
                    TempData["message"] = "Las Calificaciones sea agregaron correctamente";
                    return RedirectToAction("Examen", new { id = alumnoXexamen.IDAsignatura });
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar la información. Intente más tarde.";
                    return RedirectToAction("CalificacionExamen", new { id = alumnoXexamen.IDExamen, id2 = alumnoXexamen.IDAsignatura });
                }
            }
            catch (Exception)
            {
                AlumnoXExamenModels alumnoXexamen = new AlumnoXExamenModels();
                alumnoXexamen.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error al intentar guardar la información. Contacte a soporte técnico.";
                return RedirectToAction("CalificacionExamen", new { id = alumnoXexamen.IDAsignatura });
            }
        }

        // GET: /Profesor/CatMateria/Evento/5
        [HttpGet]
        public ActionResult Evento(string id)
        {
            try
            {
                EventosModels evento = new EventosModels();
                Evento_Datos evento_datos = new Evento_Datos();
                evento.conexion = Conexion;
                evento.IDAsignatura = id;
                evento = evento_datos.ObtenerEventosPROF(evento);
                return View(evento);
            }
            catch (Exception)
            {
                EventosModels evento = new EventosModels();
                evento.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(evento);
            }
        }

        // GET: /Profesor/CatMateria/CreateEvento
        [HttpGet]
        [Authorize(Roles = "3")]
        public ActionResult CreateEvento(string id)
        {
            try
            {
                EventosModels evento = new EventosModels();
                Evento_Datos evento_datos = new Evento_Datos();
                evento.conexion = Conexion;
                evento.IDAsignatura = id;
                return View(evento);
            }
            catch (Exception)
            {
                EventosModels evento = new EventosModels();
                evento.IDAsignatura = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Evento", new { id = evento.IDAsignatura });
            }
        }

        // POST: Admin/CatMateria/CreateEvento
        [HttpPost]
        public ActionResult CreateEvento(string id, FormCollection collection)
        {
            try
            {
                EventosModels evento = new EventosModels();
                Evento_Datos evento_datos = new Evento_Datos();
                evento.conexion = Conexion;
                evento.opcion = 1;
                evento.IDAsignatura = collection["IDAsignatura"];
                evento.NombreEvento = collection["NombreEvento"];
                evento.Descripcion = collection["Descripcion"];
                evento.FechaEvento = DateTime.ParseExact(collection["FechaEvento"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                evento.FechaEnvio = DateTime.ParseExact(collection["FechaEnvio"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                evento.IDEvento = "";
                evento.user = User.Identity.Name;
                evento_datos.AbcEvento(evento);
                if (evento.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El Evento sea creado correctamente";
                    return RedirectToAction("Evento", new { id = evento.IDAsignatura });
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar la información. Intente más tarde.";
                    return RedirectToAction("CreateEvento", "CatMateria", new { id = evento.IDAsignatura });
                }
            }
            catch (Exception)
            {
                EventosModels evento = new EventosModels();
                evento.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error al intentar guardar la información. Contate a soporte técnico.";
                return RedirectToAction("Evento", new { id = evento.IDAsignatura });
            }
        }
        
        //POST: /Profesor/EnviarEvento/5
        [HttpPost]
        public ActionResult EnviarEvento(string id, string id2, FormCollection collection)
        {
            try
            {
                AlumnoXEventoModels alumnoXevento = new AlumnoXEventoModels();
                AlumnoXEvento_Datos alumnoXevento_datos = new AlumnoXEvento_Datos();
                alumnoXevento.conexion = Conexion;
                alumnoXevento.IDEvento = id;
                alumnoXevento.IDAsignatura = id2;
                alumnoXevento.user = User.Identity.Name;
                alumnoXevento_datos.EnviarEvento(ref alumnoXevento);
                foreach (DataRow notificacion in alumnoXevento.TablaNotificaciones.Rows)
                {
                    int Bagde = 0, IDTipoCelular = 0;
                    Bagde = Convert.ToInt32(notificacion["Badge"].ToString());
                    IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                    Comun.EnviarMensaje(notificacion["idCelular"].ToString(), notificacion["TituloNot"].ToString(), notificacion["descripcion"].ToString(), Bagde, IDTipoCelular);
                }
                return Json("");
            }
            catch
            {
                return View();
            }
        }


        // GET: /Profesor/CatMateria/DeleteEvento/5
        [HttpGet]
        public ActionResult DeleteEvento(string id, string id2)
        {
            return View();
        }

        // POST:  /Profesor/CatMateria/DeleteEvento/5
        [HttpPost]
        public ActionResult DeleteEvento(string id, string id2, FormCollection collection)
        {
            try
            {

                EventosModels evento = new EventosModels();
                Evento_Datos evento_datos = new Evento_Datos();
                evento.conexion = Conexion;
                evento.IDEvento = id;
                evento.IDAsignatura = id2;
                evento.opcion = 3;
                evento.user = User.Identity.Name;
                evento_datos.AbcEvento(evento);
                TempData["typemessage"] = "1";
                TempData["message"] = "El Evento se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: /Profesor/CatMateria/ListaAsistencia/5
        [HttpGet]
        public ActionResult ListaAsistencia(string id)
        {
            try
            {
                ListaAsistenciaModels listaAsistencia = new ListaAsistenciaModels();
                ListaAsistencia_Datos listaAsistencia_datos = new ListaAsistencia_Datos();
                listaAsistencia.conexion = Conexion;
                listaAsistencia.IDAsignatura = id;
                listaAsistencia.FechaLista = DateTime.Now;
                listaAsistencia = listaAsistencia_datos.ObtenerListaAsistencia(listaAsistencia);
                return View(listaAsistencia);
            }
            catch (Exception)
            {
                ListaAsistenciaModels listaAsistencia = new ListaAsistenciaModels();
                listaAsistencia.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(listaAsistencia);
            }
        }

        // GET: /Profesor/CatMateria/ListaAsistencia/5
        [HttpGet]
        public ActionResult PaseAsistencia(string id)
        {
            try
            {
                AlumnoXAsistenciaModels AlumXAsistencia = new AlumnoXAsistenciaModels();
                AlumnoXAsistencia_Datos AlumXAsistencia_datos = new AlumnoXAsistencia_Datos();
                AlumXAsistencia.conexion = Conexion;
                AlumXAsistencia.IDAsignatura = id;
                AlumXAsistencia.IDLista = "";
                AlumXAsistencia.FechaLista = DateTime.Now;
                AlumXAsistencia.user = User.Identity.Name;
                AlumXAsistencia = AlumXAsistencia_datos.ObtenerListaAsistenciaPROXID(AlumXAsistencia);
                if (AlumXAsistencia.TablaDatos != null)
                {
                    AlumXAsistencia.NumeroAlumnos = AlumXAsistencia.TablaDatos.Rows.Count;
                }
                else
                {
                    AlumXAsistencia.NumeroAlumnos = 0;
                }
                return View(AlumXAsistencia);
            }
            catch (Exception)
            {
                AlumnoXAsistenciaModels AlumXAsistencia = new AlumnoXAsistenciaModels();
                AlumXAsistencia.IDAsignatura = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("PaseAsistencia", new { id = AlumXAsistencia.IDAsignatura });
            }
        }

        [HttpPost]
        public ActionResult PaseAsistencia(string id, FormCollection collection)
        {
            try
            {
                AlumnoXAsistenciaModels AlumXAsistencia = new AlumnoXAsistenciaModels();
                AlumnoXAsistencia_Datos AlumXAsistencia_datos = new AlumnoXAsistencia_Datos();
                AlumXAsistencia.conexion = Conexion;
                AlumXAsistencia.opcion = 1;
                AlumXAsistencia.IDAsignatura = collection["IDAsignatura"];
                AlumXAsistencia.IDLista = collection["IDLista"];
                AlumXAsistencia.NumeroAlumnos = Convert.ToInt32(collection["NumeroAlumnos"]);
                AlumXAsistencia.user = User.Identity.Name;
                AlumXAsistencia.tablaAlumnoXAsistencia = new DataTable();
                AlumXAsistencia.tablaAlumnoXAsistencia.Columns.Add("IDLista", typeof(string));
                AlumXAsistencia.tablaAlumnoXAsistencia.Columns.Add("IDAlumno", typeof(string));
                AlumXAsistencia.tablaAlumnoXAsistencia.Columns.Add("asistencia", typeof(bool));
                string idAlumno = "", IdLista = "";

                bool asistencia = false;
                for (int auxNumAlum = 1; auxNumAlum <= AlumXAsistencia.NumeroAlumnos; auxNumAlum++)
                {
                    try
                    {
                        IdLista = collection["idLista" + auxNumAlum.ToString()];
                        idAlumno = collection["idAlumno" + auxNumAlum.ToString()];
                        object s = collection["asistencia" + auxNumAlum.ToString()];

                        asistencia = Convert.ToBoolean(collection["asistencia" + auxNumAlum.ToString()] == null ? "False" : "True");
                        AlumXAsistencia.tablaAlumnoXAsistencia.Rows.Add(IdLista, idAlumno, asistencia);

                    }
                    catch (Exception ex)
                    {
                        if (idAlumno != "")
                        {

                            AlumXAsistencia.tablaAlumnoXAsistencia.Rows.Add(IdLista, idAlumno, false);
                        }
                    }
                }
                if (AlumXAsistencia_datos.GuardarAsistencia(ref AlumXAsistencia) == 1)
                {
                    //foreach (DataRow notificacion in AlumXAsistencia.tablaNotificaciones.Rows)
                    //{
                    //    int Bagde = 0, IDTipoCelular = 0;
                    //    Bagde = Convert.ToInt32(notificacion["Badge"].ToString());
                    //    IDTipoCelular = Convert.ToInt32(notificacion["idTipoCelular"].ToString());

                    //    Comun.EnviarMensaje(notificacion["idCelular"].ToString(), notificacion["TituloNot"].ToString(), notificacion["descripcion"].ToString(), Bagde, IDTipoCelular);
                    //}

                    TempData["typemessage"] = "1";
                    TempData["message"] = "Las Asistencias se agregaron correctamente";
                    return RedirectToAction("ListaAsistencia", new { id = AlumXAsistencia.IDAsignatura });
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "No puede guardar correctamente";
                    return RedirectToAction("ListaAsistencia", new { id = AlumXAsistencia.IDAsignatura});
                }
            }
            catch (Exception)
            {
                AlumnoXAsistenciaModels alumnoXexamen = new AlumnoXAsistenciaModels();
                alumnoXexamen.IDAsignatura = collection["IDAsignatura"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("ListaAsistencia", new { id = alumnoXexamen.IDAsignatura });
            }
        }
    }
}