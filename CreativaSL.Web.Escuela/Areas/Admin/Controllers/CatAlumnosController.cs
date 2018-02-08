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
    public class CatAlumnosController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatAlumnos
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;
                Alumno = AlumnoDatos.ObtenerCatAlumno(Alumno);
                return View(Alumno);
            }
            catch (Exception)
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                Alumno.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Alumno);
            }
        }

        // GET: Admin/CatAlumnos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CatAlumnos/Create
        public ActionResult Create()
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;

                Alumno.TablaTipoPersonaCmb = AlumnoDatos.obtenerComboCatTipoPersona(Alumno);
                var listTipoPersona = new SelectList(Alumno.TablaTipoPersonaCmb, "id_tipoPersona", "descripcion");
                ViewData["cmbTipoPersona"] = listTipoPersona;
                return View(Alumno);
            }
            catch (Exception)
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Catedratico);
            }
        }

        // POST: Admin/CatAlumnos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;
                Alumno.IDPersona = "";
                Alumno.nombre = collection["nombre"];
                Alumno.apPaterno = collection["apPaterno"];
                Alumno.apMaterno = collection["apMaterno"];
                Alumno.correo = collection["correo"];
                Alumno.direccion = collection["direccion"];
                Alumno.telefono = collection["telefono"];
                Alumno.id_tipoPersona = 2;
                Alumno.passUser = collection["passUser"];
                Alumno.clvUser = collection["clvUser"];
                Alumno.Observaciones = collection["observaciones"];
                Alumno.NumControl = collection["NumControl"];
                Alumno.user = User.Identity.Name;
                Alumno.opcion = 1;
                Alumno = AlumnoDatos.AbcCatAlumnos(Alumno);
                if (!string.IsNullOrEmpty(Alumno.IDPersona))
                {
                    Comun.EnviarCorreo(
                  ConfigurationManager.AppSettings.Get("CorreoTxt")
                 , ConfigurationManager.AppSettings.Get("PasswordTxt")
                 , Alumno.correo
                 , "Registro Profesor"
                 , Comun.GenerarHtmlRegistoTutorAlumno(Alumno.IDPersona, Alumno.clvUser, Alumno.passUser)
                 , false
                 , ""
                 , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                 , ConfigurationManager.AppSettings.Get("HostTxt")
                 , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                 , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                   
                }
                else
                {

                    TempData["typemessage"] = "2";
                    TempData["message"] = "El usuario ingresado ya existe.";
                    return RedirectToAction("Create");
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAlumnos/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;

                Alumno.TablaTipoPersonaCmb = AlumnoDatos.obtenerComboCatTipoPersona(Alumno);
                var listTipoPersona = new SelectList(Alumno.TablaTipoPersonaCmb, "id_tipoPersona", "descripcion");
                ViewData["cmbTipoPersona"] = listTipoPersona;
                Alumno.IDPersona = id;
                Alumno = AlumnoDatos.ObtenerDetalleCatAlumno(Alumno);
                return View(Alumno);
            }
            catch (Exception)
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatAlumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;
                Alumno.IDPersona = id;
                Alumno.nombre = collection["nombre"];
                Alumno.apPaterno = collection["apPaterno"];
                Alumno.apMaterno = collection["apMaterno"];
                Alumno.correo = collection["correo"];
                Alumno.direccion = collection["direccion"];
                Alumno.telefono = collection["telefono"];
                Alumno.id_tipoPersona =2;

                Alumno.Observaciones = collection["observaciones"];
                Alumno.NumControl = collection["NumControl"];
                Alumno.user = User.Identity.Name;
                Alumno.opcion = 2;
                Alumno = AlumnoDatos.AbcCatAlumnos(Alumno);
                if (Alumno.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {

                    Alumno.TablaTipoPersonaCmb = AlumnoDatos.obtenerComboCatTipoPersona(Alumno);
                    var listTipoPersona = new SelectList(Alumno.TablaTipoPersonaCmb, "id_tipoPersona", "descripcion");
                    ViewData["cmbTipoPersona"] = listTipoPersona;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrió un error al intentar guardar.";
                    return RedirectToAction("Edit");
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAlumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatAlumnos/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;
                Alumno.opcion = 3;
                Alumno.user = User.Identity.Name;
                Alumno.IDPersona = id;
                AlumnoDatos.AbcCatAlumnos(Alumno);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se ha eliminado correctamente.";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult DarBaja(string id, int id2)
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult DarBaja(string id,  int id2, FormCollection collection)
        {
            try
            {
                CatAlumnoModels Alumno = new CatAlumnoModels();
                _CatAlumno_Datos AlumnoDatos = new _CatAlumno_Datos();
                Alumno.conexion = Conexion;
              
                Alumno.user = User.Identity.Name;
                Alumno.id_estatus = id2;
                Alumno.IDPersona = id;
                AlumnoDatos.DarBaja(Alumno);
                TempData["typemessage"] = "1";
                TempData["message"] = "La baja se llevó a cabo correctamente.";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CatAlumnos/TutorXAlumno/5
        [HttpGet]
        public ActionResult TutorXAlumno(string id)
        {
            try
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                CatTutorXAlumno_Datos TutorXAlumno_datos = new CatTutorXAlumno_Datos();
                TutorXAlumno.conexion = Conexion;
                TutorXAlumno.IDAlumno = id;
                TutorXAlumno = TutorXAlumno_datos.ObtenerCatTutorXAlumno(TutorXAlumno);
                return View(TutorXAlumno);
            }

            catch (Exception)
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }


        // GET: Admin/CatAlumnos/CreateTutor
        [HttpGet]
        public ActionResult CreateTutorXalumno(string id)
        {
            try
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                CatTutorXAlumno_Datos TutorXAlumno_datos = new CatTutorXAlumno_Datos();
                TutorXAlumno.conexion = Conexion;
                TutorXAlumno.IDAlumno = id;
                TutorXAlumno.TablaTurorCmb = TutorXAlumno_datos.obtenerComboCatTutorXalumno(TutorXAlumno);
                var list = new SelectList(TutorXAlumno.TablaTurorCmb, "IDPersona", "Nombre");
                ViewData["cmbTutor"] = list;
                return View(TutorXAlumno);
            }
            catch (Exception)
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                TutorXAlumno.IDAlumno = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("TutorXAlumno", new { id = TutorXAlumno.IDAlumno });
            }
        }

        // POST: Admin/CatAlumnos/CreateParticipanteCurso
        [HttpPost]
        public ActionResult CreateTutorXalumno(string id, FormCollection collection)
        {
            try
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                CatTutorXAlumno_Datos TutorXAlumno_datos = new CatTutorXAlumno_Datos();
                TutorXAlumno.conexion = Conexion;
                TutorXAlumno.opcion = 1;
                TutorXAlumno.IDAlumno = collection["IDAlumno"];
                TutorXAlumno.IDTutor = collection["TablaTurorCmb"];
                TutorXAlumno.user = User.Identity.Name;
                TutorXAlumno_datos.abcTutorXAlumno(TutorXAlumno);
                TempData["typemessage"] = "1";
                TempData["message"] = "El registro sea creado correctamente";

                return RedirectToAction("TutorXAlumno", new { id = TutorXAlumno.IDAlumno });
            }
            catch (Exception)
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                TutorXAlumno.IDAlumno = collection["id_alumno"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("TutorXAlumno", new { id = TutorXAlumno.IDAlumno });
            }
        }

        // GET: Admin/CatAlumnos/DeleteActividadesCurso/5
        [HttpGet]
        public ActionResult DeleteTutorAlumno(string id)
        {
            return View();
        }
        // POST: Admin/CatAlumnos/DeleteActividadesCurso/5
        [HttpPost]
        public ActionResult DeleteTutorAlumno(string id, string id2, FormCollection collection)
        {
            try
            {
                CatTutorXalumnoModels TutorXAlumno = new CatTutorXalumnoModels();
                CatTutorXAlumno_Datos TutorXAlumno_datos = new CatTutorXAlumno_Datos();
                TutorXAlumno.conexion = Conexion;
                TutorXAlumno.IDTutor = id;
                TutorXAlumno.IDAlumno = id2;
                TutorXAlumno.opcion = 3;
                TutorXAlumno.user = User.Identity.Name;
                TutorXAlumno_datos.AbcCatTutorXAlumnoModiBorr(TutorXAlumno);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

    }
}
