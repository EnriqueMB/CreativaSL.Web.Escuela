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
    public class CatPlantillaTipoNotificacionController : Controller
    {

        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatPlantillaTipoNotificacion
        public ActionResult Index()
        {
            try
            {
                CatPlantillaTipoNotificacionModels PlantillaTipoNotificacion = new CatPlantillaTipoNotificacionModels();
                _CatPlantillaTipoNotificacion_Datos PlantillaTipoNotificacionDatos = new _CatPlantillaTipoNotificacion_Datos();
                PlantillaTipoNotificacion.conexion = Conexion;

                PlantillaTipoNotificacion = PlantillaTipoNotificacionDatos.obtenerCatPlantillaTipoNotificacion(PlantillaTipoNotificacion);
                return View(PlantillaTipoNotificacion);
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

        // GET: Admin/CatPlantillaTipoNotificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CatPlantillaTipoNotificacion/Create
        public ActionResult Create()
        {
            CatPlantillaTipoNotificacionModels PlantillaTipoNotificacion = new CatPlantillaTipoNotificacionModels();
            _CatPlantillaTipoNotificacion_Datos PlantillaTipoNotificacionDatos =new _CatPlantillaTipoNotificacion_Datos();
            PlantillaTipoNotificacion.conexion = Conexion;

            PlantillaTipoNotificacion.listaTipoNotificacion = PlantillaTipoNotificacionDatos.obtenerListaTipoNotificacion(PlantillaTipoNotificacion);
            var list = new SelectList(PlantillaTipoNotificacion.listaTipoNotificacion, "id_tipoNotificacion", "descripcion");
            ViewData["cmbTipoNotificacion"] = list;

            PlantillaTipoNotificacion.listaVariableNotificacion = PlantillaTipoNotificacionDatos.ObtenerCatVariablesNotificacion(PlantillaTipoNotificacion);
            var lista = new SelectList(PlantillaTipoNotificacion.listaVariableNotificacion, "clave", "descripcion");
            ViewData["tablaVariables"] = lista;
            return View();
        }

        // POST: Admin/CatPlantillaTipoNotificacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatPlantillaTipoNotificacionModels PlantillaTipoNotificacion = new CatPlantillaTipoNotificacionModels();
                _CatPlantillaTipoNotificacion_Datos PlantillaTipoNotificacionDatos = new _CatPlantillaTipoNotificacion_Datos();
                PlantillaTipoNotificacion.conexion = Conexion;
                PlantillaTipoNotificacion.user = User.Identity.Name;
                PlantillaTipoNotificacion.opcion = 1;
                PlantillaTipoNotificacion.id_plantilla = "";
                PlantillaTipoNotificacion.id_tipoNotificacion = Convert.ToInt32(collection["listaTipoNotificacion"]);
                PlantillaTipoNotificacion.titulo = collection["titulo"];
                PlantillaTipoNotificacion.texto = collection["texto"];
                PlantillaTipoNotificacion = PlantillaTipoNotificacionDatos.AbcPlatillaTipoNotificacion(PlantillaTipoNotificacion);
                if (string.IsNullOrEmpty(PlantillaTipoNotificacion.id_plantilla))
                {

                    TempData["typemessage"] = "2";
                    TempData["message"] = "El usuario ingresado ya existe.";
                    return RedirectToAction("Create");
                }
                else
                {
                    
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Ocurrió un error el intentar guardar. Contacte a soporte técnico";
                return View();
            }
        }

        // GET: Admin/CatPlantillaTipoNotificacion/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                CatPlantillaTipoNotificacionModels PlantillaTipoNotificacion = new CatPlantillaTipoNotificacionModels();
                _CatPlantillaTipoNotificacion_Datos PlantillaTipoNotificacionDatos = new _CatPlantillaTipoNotificacion_Datos();
                PlantillaTipoNotificacion.conexion = Conexion;

                PlantillaTipoNotificacion.listaTipoNotificacion = PlantillaTipoNotificacionDatos.obtenerListaTipoNotificacion(PlantillaTipoNotificacion);
                var list = new SelectList(PlantillaTipoNotificacion.listaTipoNotificacion, "id_tipoNotificacion", "descripcion");
                ViewData["cmbTipoNotificacion"] = list;

                PlantillaTipoNotificacion.listaVariableNotificacion = PlantillaTipoNotificacionDatos.ObtenerCatVariablesNotificacion(PlantillaTipoNotificacion);
                var lista = new SelectList(PlantillaTipoNotificacion.listaVariableNotificacion, "clave", "descripcion");
                ViewData["tablaVariables"] = lista;
                PlantillaTipoNotificacion.id_plantilla = id;
                PlantillaTipoNotificacion = PlantillaTipoNotificacionDatos.ObtenerDetallePlantillaNotificacion(PlantillaTipoNotificacion);
                return View(PlantillaTipoNotificacion);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        // POST: Admin/CatPlantillaTipoNotificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatPlantillaTipoNotificacionModels PlantillaTipoNotificacion = new CatPlantillaTipoNotificacionModels();
                _CatPlantillaTipoNotificacion_Datos PlantillaTipoNotificacionDatos = new _CatPlantillaTipoNotificacion_Datos();
                PlantillaTipoNotificacion.conexion = Conexion;
                PlantillaTipoNotificacion.user = User.Identity.Name;
                PlantillaTipoNotificacion.opcion =2;
                PlantillaTipoNotificacion.id_plantilla = id;
                PlantillaTipoNotificacion.id_tipoNotificacion = Convert.ToInt32(collection["listaTipoNotificacion"]);
                PlantillaTipoNotificacion.titulo = collection["titulo"];
                PlantillaTipoNotificacion.texto = collection["texto"];
                PlantillaTipoNotificacion = PlantillaTipoNotificacionDatos.AbcPlatillaTipoNotificacion(PlantillaTipoNotificacion);
                if (string.IsNullOrEmpty(PlantillaTipoNotificacion.id_plantilla))
                {

                    TempData["typemessage"] = "2";
                    TempData["message"] = "El usuario ingresado ya existe.";
                    return RedirectToAction("Create");
                }
                else
                {

                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CatPlantillaTipoNotificacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatPlantillaTipoNotificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //AJAX 
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult TablaPalabras(int idtiponotificacion)
        {
            try
            {
                CatPlantillaTipoNotificacionModels PlantillaTipoNotificacion = new CatPlantillaTipoNotificacionModels();
                _CatPlantillaTipoNotificacion_Datos PlantillaTipoNotificacionDatos = new _CatPlantillaTipoNotificacion_Datos();

                List<CatVariablesNotificacionModels> listaVariablesNotificaciones = new List<CatVariablesNotificacionModels>();
                PlantillaTipoNotificacion.conexion = Conexion;
                PlantillaTipoNotificacion.id_tipoNotificacion = idtiponotificacion;

                listaVariablesNotificaciones = PlantillaTipoNotificacionDatos.ObtenerCatVariablesNotificacion(PlantillaTipoNotificacion);
                return Json(listaVariablesNotificaciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
