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
    public class CatCatedraticoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatCatedratico
        [HttpGet]
        [Authorize(Roles = "4")]
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
        [Authorize(Roles = "4")]
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
        [Authorize(Roles = "4")]
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
                Catedratico.id_tipoPersona = Convert.ToInt32(collection["TablaTipoPersonaCmb"]);
                Catedratico.id_gradoEstudio = collection["TablaGradoEstudioCmb"];
                Catedratico.clvUser = collection["clvUser"];
                Catedratico.clave = collection["clave"];
                Catedratico.passUser = collection["passUser"];
                Catedratico.curriculum = collection["curriculum"];
                Catedratico.user = User.Identity.Name;
                Catedratico.opcion = 1;
                Catedratico = CatedraticoDatos.AbcCatCatedratico(Catedratico);
                if (Catedratico.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Catedratico.TablaGradoEstudioCmb = CatedraticoDatos.obtenerComboCatGradoEstudio(Catedratico);
                    var list = new SelectList(Catedratico.TablaGradoEstudioCmb, "IDGradoEstudio", "Descripcion");
                    ViewData["cmbGradoEstudio"] = list;
                    Catedratico.TablaTipoPersonaCmb = CatedraticoDatos.obtenerComboCatTipoPersona(Catedratico);
                    var listTipoPersona = new SelectList(Catedratico.TablaTipoPersonaCmb, "id_tipoPersona", "descripcion");
                    ViewData["cmbTipoPersona"] = listTipoPersona;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return View(Catedratico);
                }
            }
            catch
            {

                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrio un error el intentar guardar. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        [Authorize(Roles = "4")]
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
        [Authorize(Roles = "4")]
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
                Catedratico.id_tipoPersona = Convert.ToInt32(collection["TablaTipoPersonaCmb"]);
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
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente.";
                    return View(Catedratico);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se editarón correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Delete(string id)
        {
            return View();
        }


        
        [HttpPost]
        [Authorize(Roles = "4")]
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