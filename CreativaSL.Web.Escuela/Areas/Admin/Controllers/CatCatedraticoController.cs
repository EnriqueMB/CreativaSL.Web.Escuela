﻿using CreativaSL.Web.Escuela.Filters;
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
    public class CatCatedraticoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatCatedratico
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            
            try
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                _CatCatedratico_Datos CatedraticoDatos = new _CatCatedratico_Datos();
                Catedratico.conexion = Conexion;
                Catedratico = CatedraticoDatos.ObtenerCatCatedratico(Catedratico);
                return View(Catedratico);
            }
            catch (Exception)
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                Catedratico.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Catedratico);
            }
           
        }
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                _CatCatedratico_Datos CatedraticoDatos = new _CatCatedratico_Datos();
                Catedratico.conexion = Conexion;
                Catedratico.TablaGradoEstudioCmb = CatedraticoDatos.obtenerComboCatGradoEstudio(Catedratico);
                var list = new SelectList(Catedratico.TablaGradoEstudioCmb, "IDGradoEstudio", "Descripcion");
                ViewData["cmbGradoEstudio"] = list;
                Catedratico.TablaTipoPersonaCmb = CatedraticoDatos.obtenerComboCatTipoPersona(Catedratico);
                var listTipoPersona = new SelectList(Catedratico.TablaTipoPersonaCmb, "id_tipoPersona", "descripcion");
                ViewData["cmbTipoPersona"] = listTipoPersona;
                return View(Catedratico);
            }
            catch (Exception)
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Catedratico);
            }

        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                _CatCatedratico_Datos CatedraticoDatos = new _CatCatedratico_Datos();
                Catedratico.conexion = Conexion;
                Catedratico.id_persona = "";
                Catedratico.nombre = collection["nombre"];
                Catedratico.apPaterno = collection["apPaterno"];
                Catedratico.apMaterno = collection["apMaterno"];
                Catedratico.correo = collection["correo"];
                Catedratico.direccion = collection["direccion"];
                Catedratico.telefono = collection["telefono"];
                Catedratico.id_tipoPersona = 1;
                Catedratico.id_gradoEstudio = collection["TablaGradoEstudioCmb"];
                Catedratico.clvUser = collection["clvUser"];
                Catedratico.clave = collection["clave"];
                Catedratico.passUser = collection["passUser"];
                Catedratico.curriculum = collection["curriculum"];
                Catedratico.user = User.Identity.Name;
                Catedratico.opcion = 1;
                Catedratico = CatedraticoDatos.AbcCatCatedratico(Catedratico);
                if (string.IsNullOrEmpty(Catedratico.id_persona))
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
                   , Catedratico.correo
                   , "Registro Profesor"
                   , Comun.GenerarHtmlRegistoUsuario(Catedratico.clvUser, Catedratico.passUser)
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
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                _CatCatedratico_Datos CatedraticoDatos = new _CatCatedratico_Datos();
                Catedratico.conexion = Conexion;
                Catedratico.TablaGradoEstudioCmb = CatedraticoDatos.obtenerComboCatGradoEstudio(Catedratico);
                var list = new SelectList(Catedratico.TablaGradoEstudioCmb, "IDGradoEstudio", "Descripcion");
                ViewData["cmbGradoEstudio"] = list;
                Catedratico.TablaTipoPersonaCmb = CatedraticoDatos.obtenerComboCatTipoPersona(Catedratico);
                var listTipoPersona = new SelectList(Catedratico.TablaTipoPersonaCmb, "id_tipoPersona", "descripcion");
                ViewData["cmbTipoPersona"] = listTipoPersona;
                Catedratico.id_persona = id;
                Catedratico = CatedraticoDatos.ObtenerDetalleCatCatedratico(Catedratico);
                return View(Catedratico);
            }
            catch (Exception ex)
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {


                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                _CatCatedratico_Datos CatedraticoDatos = new _CatCatedratico_Datos();
                Catedratico.conexion = Conexion;
                Catedratico.id_persona = "";
                Catedratico.nombre = collection["nombre"];
                Catedratico.apPaterno = collection["apPaterno"];
                Catedratico.apMaterno = collection["apMaterno"];
                Catedratico.correo = collection["correo"];
                Catedratico.direccion = collection["direccion"];
                Catedratico.telefono = collection["telefono"];
                Catedratico.id_tipoPersona = 1;
                Catedratico.id_gradoEstudio = collection["TablaGradoEstudioCmb"];
                
                Catedratico.clave = collection["clave"];
               
                Catedratico.curriculum = collection["curriculum"];
                Catedratico.user = User.Identity.Name;
                Catedratico.id_persona = id;
                Catedratico.opcion = 2;
                Catedratico = CatedraticoDatos.AbcCatCatedratico(Catedratico);
                if (Catedratico.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editaron correctamente.";
                    return RedirectToAction("Edit");
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }
        
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatCatedraticoModels Catedratico = new CatCatedraticoModels();
                _CatCatedratico_Datos CatedraticoDatos = new _CatCatedratico_Datos();
                Catedratico.conexion = Conexion;
                Catedratico.opcion = 3;
                Catedratico.user = User.Identity.Name;
                Catedratico.id_persona = id;
                CatedraticoDatos.AbcCatCatedratico(Catedratico);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se ha eliminado correctamente.";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/CatCatedratico/MateriaP/5
        [HttpGet]
        public ActionResult MateriaP(string id)
        {
            try
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                CatMateriaXProfesor_Datos MateriaProfesorD = new CatMateriaXProfesor_Datos();
                MateriaProfesor.IDProfesor = id;
                MateriaProfesor.conexion = Conexion;
                MateriaProfesor = MateriaProfesorD.ObtenerListMaterias(MateriaProfesor);
                return View(MateriaProfesor);
            }
            catch (Exception)
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                MateriaProfesor.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(MateriaProfesor);
            }
        }

        //GET: Admin/CatCatedratico/CreateMateria/5
        [HttpGet]
        public ActionResult CreateMateria(string id)
        {
            try
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                CatMateriaXProfesor_Datos MateriaProfesorD = new CatMateriaXProfesor_Datos();
                MateriaProfesor.IDProfesor = id;
                MateriaProfesor.conexion = Conexion;
                MateriaProfesor.tablaModalidadCmb = MateriaProfesorD.obtenerComboCatModalidad(MateriaProfesor);
                var list = new SelectList(MateriaProfesor.tablaModalidadCmb, "IDModalidad", "descripcion");
                ViewData["cmbTipoModalidad"] = list;
                MateriaProfesor.TablaMateriaCmb = MateriaProfesorD.obtenerComboCatMateriaPorProfesor(MateriaProfesor);
                var listTipoPersona = new SelectList(MateriaProfesor.TablaMateriaCmb, "IDMateria", "NombreM");
                ViewData["cmbMateria"] = listTipoPersona;

                return View(MateriaProfesor);
            }
            catch (Exception)
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                MateriaProfesor.IDProfesor = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("MateriaP", new { id = MateriaProfesor.IDProfesor });
            }
        }

        //GET: Admin/CatCatedratico/CreateMateria/5
        [HttpPost]
        public ActionResult CreateMateria(string id, FormCollection collection)
        {
            try
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                CatMateriaXProfesor_Datos MateriaProfesorD = new CatMateriaXProfesor_Datos();
                MateriaProfesor.conexion = Conexion;
                MateriaProfesor.opcion = 1;
                MateriaProfesor.IDProfesor = collection["IDProfesor"];
                MateriaProfesor.IDMateria = collection["TablaMateriaCmb"];
                MateriaProfesor.user = User.Identity.Name;
                MateriaProfesor = MateriaProfesorD.AbcCatMateriaXProfesor(MateriaProfesor);
                if (MateriaProfesor.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("MateriaP", new { id = MateriaProfesor.IDProfesor });
                }
                else
                {
                    MateriaProfesor.TablaMateriaCmb = MateriaProfesorD.obtenerComboCatMateriaPorProfesor(MateriaProfesor);
                    var listTipoPersona = new SelectList(MateriaProfesor.TablaMateriaCmb, "IDMateria", "NombreM");
                    ViewData["cmbMateria"] = listTipoPersona;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("MateriaP", "CreateMateria", new { id = MateriaProfesor.IDProfesor });
                }
            }
            catch (Exception)
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                MateriaProfesor.IDProfesor = collection["IDProfesor"];
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos se guardaron correctamente.";
                return RedirectToAction("MateriaP", new { id = MateriaProfesor.IDProfesor });
            }
        }

        // POST: Admin/CatCatedratico/Materia
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult CombMateria(string IDEsp, string IDProfesor)
        {
            try
            {
                CatMateriaXProfesorModels Materia = new CatMateriaXProfesorModels();
                CatMateriaXProfesor_Datos MateriaDatos = new CatMateriaXProfesor_Datos();

                List<CatMateriaXProfesorModels> listaMateria = new List<CatMateriaXProfesorModels>();
                Materia.conexion = Conexion;
                Materia.IDModalidad = IDEsp;
                Materia.IDProfesor = IDProfesor;
                listaMateria = MateriaDatos.obtenerComboCatMateriaPorProfesor(Materia);
                return Json(listaMateria, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Admin/CatCatedratico/DeleteMateria/5
        [HttpGet]
        public ActionResult DeleteMateria(string id, string id2)
        {
            return View();
        }

        //POST: Admin/CatCatedratico/DeleteMateria/5
        [HttpPost]
        public ActionResult DeleteMateria(string id, string id2, FormCollection collection)
        {
            try
            {
                CatMateriaXProfesorModels MateriaProfesor = new CatMateriaXProfesorModels();
                CatMateriaXProfesor_Datos MateriaProfesorD = new CatMateriaXProfesor_Datos();
                MateriaProfesor.conexion = Conexion;
                MateriaProfesor.opcion = 3;
                MateriaProfesor.IDProfesor = id2;
                MateriaProfesor.IDMateria = id;
                MateriaProfesor.user = User.Identity.Name;
                MateriaProfesor = MateriaProfesorD.AbcCatMateriaXProfesor(MateriaProfesor);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se ha eliminado correctamente.";
                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Admin/CatCatedratico/Permisos/5
        [HttpGet]
        public ActionResult Permisos(string id)
        {
            try
            {
                CatAdministrativoModels Permisos = new CatAdministrativoModels();
                CatAdministrativo_Datos PermisosD = new CatAdministrativo_Datos();
                Permisos.conexion = Conexion;
                Permisos.id_administrativo = id;
                Permisos.id_tipoUser = 2;
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

        // POST: Admin/CatCatedratico/Permisos
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