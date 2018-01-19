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
    public class RolesController : Controller
    {
        // GET: Admin/Roles
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                RoleModels Roles = new RoleModels();
                _Roles_Datos RolesDatos = new _Roles_Datos();
                Roles.conexion = Conexion;
                Roles = RolesDatos.ObtenerCatRoles(Roles);
                return View(Roles);
            }
            catch (Exception)
            {
                RoleModels Roles = new RoleModels();
                Roles.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Roles);
            }
        }

        // GET: Admin/Roles/Create
        public ActionResult Create()
        {
            try
            {
                RoleModels Roles = new RoleModels();
                _Roles_Datos RolesDatos = new _Roles_Datos();
                Roles.conexion = Conexion;
                return View(Roles);
            }
            catch {
                RoleModels Roles = new RoleModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Roles);
            }
        }

        // POST: Admin/Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                RoleModels Roles = new RoleModels();
                _Roles_Datos RolesDatos = new _Roles_Datos();
                Roles.conexion = Conexion;
                Roles.id_roles = "";
                Roles.descripcion = collection["descripcion"];
                Roles.nombre = collection["nombre"];
                Roles.user = User.Identity.Name;
                Roles.opcion = 1;
                Roles = RolesDatos.AbcCatRoles(Roles);
                if (Roles.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return View(Roles);
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                RoleModels Roles = new RoleModels();
                _Roles_Datos RolesDatos = new _Roles_Datos();
                Roles.conexion = Conexion;
               
                Roles.id_roles = id;
                Roles = RolesDatos.ObtenerDetalleRoles(Roles);
                return View(Roles);
            }
            catch (Exception)
            {
                RoleModels Roles = new RoleModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                RoleModels Roles = new RoleModels();
                _Roles_Datos RolesDatos = new _Roles_Datos();
                Roles.conexion = Conexion;
                Roles.id_roles = id;
                Roles.descripcion = collection["descripcion"];
                Roles.nombre = collection["nombre"];
                Roles.user = User.Identity.Name;
                Roles.opcion = 2;
                Roles = RolesDatos.AbcCatRoles(Roles);
                if (Roles.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return View(Roles);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                RoleModels Roles = new RoleModels();
                _Roles_Datos RolesDatos = new _Roles_Datos();
                Roles.conexion = Conexion;
                Roles.opcion = 3;
                Roles.user = User.Identity.Name;
                Roles.id_roles = id;
                RolesDatos.AbcCatRoles(Roles);
                TempData["typemessage"] = "1";
                TempData["message"] = "El resgistro se a eliminado correctamente.";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
