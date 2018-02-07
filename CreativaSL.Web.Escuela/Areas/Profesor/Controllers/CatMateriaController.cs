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