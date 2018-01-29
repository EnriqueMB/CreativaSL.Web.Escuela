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
    public class CatAdministrativoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatAdministrativo
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo = administrativo_datos.ObtenerCatAdministrativo(administrativo);
                return View(administrativo);
            }
            catch (Exception)
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                administrativo.tablaAdministracion = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(administrativo);
            }
        }

        // GET: Admin/CatAdministrativo/Create
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                return View(administrativo);
            }
            catch (Exception)
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(administrativo);
            }
        }

        // POST: Admin/CatAdministrativo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.nombre = collection["nombre"];
                administrativo.apPaterno = collection["apPaterno"];
                administrativo.apMaterno = collection["apMaterno"];
                administrativo.correo = collection["correo"];
                administrativo.telefono = collection["telefono"];
                administrativo.direccion = collection["direccion"];
                administrativo.Observaciones = collection["observaciones"];
                administrativo.clvUser = collection["clvUser"];
                administrativo.passUser = collection["passUser"];
                administrativo.opcion = 1;
                administrativo.user = User.Identity.Name;
                administrativo.id_administrativo = "";
                administrativo_datos.AbcCatAdministrativo(administrativo);
                if (string.IsNullOrEmpty(administrativo.id_administrativo))
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El usuario ingresado ya existe.";
                    return RedirectToAction("Create");
                }
                else
                {
                    Comun.EnviarCorreo(
                   ConfigurationManager.AppSettings.Get("CorreoTxt")
                  , ConfigurationManager.AppSettings.Get("PasswordTxt")
                  , administrativo.correo
                  , "Registro Administrativo"
                  , Comun.GenerarHtmlRegistoUsuario(administrativo.clvUser, administrativo.passUser)
                  , false
                  , ""
                  , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                  , ConfigurationManager.AppSettings.Get("HostTxt")
                  , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                  , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se han guardado correctamente";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAdministrativo/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.id_administrativo = id;
                administrativo = administrativo_datos.ObtenerDetalleCatAdministrativoxID(administrativo);
                return View(administrativo);
            }
            catch (Exception)
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatAdministrativo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.id_administrativo = collection["id_administrativo"];
                administrativo.nombre = collection["nombre"];
                administrativo.apPaterno = collection["apPaterno"];
                administrativo.apMaterno = collection["apMaterno"];
                administrativo.correo = collection["correo"];
                administrativo.telefono = collection["telefono"];
                administrativo.direccion = collection["direccion"];
                administrativo.Observaciones = collection["observaciones"];
                administrativo.clvUser = "";
                administrativo.passUser = "";
                administrativo.opcion = 2;
                administrativo.user = User.Identity.Name;
                administrativo_datos.AbcCatAdministrativo(administrativo);

                TempData["typemessage"] = "1";
                TempData["message"] = "Los datos se editaron correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editaron correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatAdministrativo/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/CatAdministrativo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatAdministrativoModels administrativo = new CatAdministrativoModels();
                CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
                administrativo.conexion = Conexion;
                administrativo.id_administrativo = id;
                administrativo.opcion = 3;
                administrativo.user = User.Identity.Name;
                administrativo_datos.AbcCatAdministrativo(administrativo);
                TempData["typemessage"] = "1";
                TempData["message"] = "El registro se ha eliminado correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CatAdministrativo/Permisos
        [HttpGet]
        public ActionResult Permisos(string id)
        {
            try
            {
                CatAdministrativoModels Permisos = new CatAdministrativoModels();
                CatAdministrativo_Datos PermisosD = new CatAdministrativo_Datos();
                Permisos.conexion = Conexion;
                Permisos.id_administrativo = id;
                Permisos = PermisosD.ObtenerPermisoUsuario(Permisos);
                if (Permisos.ListaPermisos != null)
                {
                    Permisos.numeroMenu = Permisos.ListaPermisos.Count;
                }
                else
                {
                    Permisos.numeroMenu = 0;
                }
                return View(Permisos);
            }
            catch (Exception)
            {
                CatAdministrativoModels Permisos = new CatAdministrativoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatAdministrativo/Permisos
        [HttpPost]
        public ActionResult Permisos(string id, FormCollection collection)
        {
            try
            {
                CatAdministrativoModels Administrador = new CatAdministrativoModels();
                CatAdministrativo_Datos AdministradorD = new CatAdministrativo_Datos();
                Administrador.numeroMenu = Convert.ToInt32(collection["Total"]);
                Administrador.opcion = 1;
                Administrador.user = User.Identity.Name;
                Administrador.conexion = Conexion;
                Administrador.id_administrativo = collection["id_administrativo"];
                Administrador.TablaPermisos = new DataTable();
                Administrador.TablaPermisos.Columns.Add("IDPermiso", typeof(string));
                Administrador.TablaPermisos.Columns.Add("Ver", typeof(bool));
                string IdPermiso = "";
                string IDPermisos = "";
                bool Ver = false;
                bool Ver2 = false;
                for (int AuxNumero = 1; AuxNumero <= Administrador.numeroMenu; AuxNumero++)
                {
                    try
                    {
                        IdPermiso = collection["idPermiso" + AuxNumero.ToString()];
                        Ver = Convert.ToBoolean(collection["Permiso" + AuxNumero.ToString()] == null ? "False" : "True");
                        if (!string.IsNullOrEmpty(IdPermiso))
                        {
                            Administrador.TablaPermisos.Rows.Add(IdPermiso, Ver);
                        }
                        IDPermisos = collection["ID" + AuxNumero.ToString()];
                        Ver2 = Convert.ToBoolean(collection["PermisoD" + AuxNumero.ToString()] == null ? "False" : "True");
                        if (!string.IsNullOrEmpty(IDPermisos))
                        {
                            Administrador.TablaPermisos.Rows.Add(IDPermisos, Ver2);
                        }
                       
                    }
                    catch (Exception)
                    {
                        if (IdPermiso != "")
                        {
                            Administrador.TablaPermisos.Rows.Add(Administrador, false);
                        }
                    }
                }
                if (AdministradorD.GuardarPermisos(Administrador) == 1)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los permisos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los permisos no se guardaron correctamente. Intente más tarde.";
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los permisos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }
    }
}
