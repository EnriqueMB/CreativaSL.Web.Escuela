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
    public class CatMateriaController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        [HttpGet]
        //[Authorize(Roles = "3")]
        // GET: Admin/CatMateria
        public ActionResult Index()
        {
            try
            {
                CatMateriaModels Materia = new CatMateriaModels();
                _CatMateria_Datos MateriaDatos = new _CatMateria_Datos();
                Materia.conexion = Conexion;
                Materia = MateriaDatos.ObtenerCatMateria(Materia);
                return View(Materia);
            }
            catch (Exception)
            {
                CatMateriaModels Materia = new CatMateriaModels();
                Materia.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Materia);
            }
           
        }

        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatMateriaModels Materia = new CatMateriaModels();
                _CatMateria_Datos MateriaDatos = new _CatMateria_Datos();
                Materia.conexion = Conexion;
                Materia.tablaCursoCmb = MateriaDatos.obtenerComboCatCurso(Materia);
                var list = new SelectList(Materia.tablaCursoCmb, "IDCurso", "descripcion");
                ViewData["cmbTipoCurso"] = list;

                Materia.tablaTipoMateriaCmb = MateriaDatos.obtenerComboCatTipoMaterias(Materia);
                var listtm = new SelectList(Materia.tablaTipoMateriaCmb, "id_tipoMateria", "descripcion");
                ViewData["cmbTipoMateria"] = listtm;

                return View(Materia);
            }
            catch (Exception)
            {
                CatMateriaModels Materia = new CatMateriaModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Materia);
            }
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatMateriaModels Materia = new CatMateriaModels();
                _CatMateria_Datos MateriaDatos = new _CatMateria_Datos();
                Materia.conexion = Conexion;
                Materia.id_materia = "";
                Materia.nombre = collection["Nombre"];
                Materia.clave = collection["Clave"];
                Materia.horaSemana = Convert.ToInt32(collection["horaSemana"]);
                Materia.id_curso = collection["tablaCursoCmb"];
                Materia.id_tipoMateria = Convert.ToInt32(collection["tablaTipoMateriaCmb"]);
                Materia.user = User.Identity.Name;
                Materia.opcion = 1;
                Materia = MateriaDatos.AbcCatMateria(Materia);
                if (Materia.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Materia.tablaCursoCmb = MateriaDatos.obtenerComboCatCurso(Materia);
                    var list = new SelectList(Materia.tablaCursoCmb, "IDCurso", "descripcion");
                    ViewData["cmbTipoCurso"] = list;
                    Materia.tablaTipoMateriaCmb = MateriaDatos.obtenerComboCatTipoMaterias(Materia);
                    var listtm = new SelectList(Materia.tablaTipoMateriaCmb, "id_tipoMateria", "descripcion");
                    ViewData["cmbTipoMateria"] = listtm;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Ocurrio un error al intentar guardar.";
                    return View(Materia);
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
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatMateriaModels Materia = new CatMateriaModels();
                _CatMateria_Datos MateriaDatos = new _CatMateria_Datos();
                Materia.conexion = Conexion;
                Materia.tablaCursoCmb = MateriaDatos.obtenerComboCatCurso(Materia);
                var list = new SelectList(Materia.tablaCursoCmb, "IDCurso", "descripcion");
                ViewData["cmbTipoCurso"] = list;

                Materia.tablaTipoMateriaCmb = MateriaDatos.obtenerComboCatTipoMaterias(Materia);
                var listtm = new SelectList(Materia.tablaTipoMateriaCmb, "id_tipoMateria", "descripcion");
                ViewData["cmbTipoMateria"] = listtm;
                Materia.id_materia = id;
                Materia = MateriaDatos.ObtenerDetalleCatMateria(Materia);
                return View(Materia);
            }
            catch (Exception)
            {
                CatMateriaModels Materia = new CatMateriaModels();
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

                CatMateriaModels Materia = new CatMateriaModels();
                _CatMateria_Datos MateriaDatos = new _CatMateria_Datos();
                Materia.conexion = Conexion;
                Materia.id_materia = "";
                Materia.nombre = collection["Nombre"];
                Materia.clave = collection["Clave"];
                Materia.horaSemana = Convert.ToInt32(collection["horaSemana"]);
                Materia.id_curso = collection["tablaCursoCmb"];
                Materia.id_tipoMateria = Convert.ToInt32(collection["tablaTipoMateriaCmb"]);
                Materia.user = User.Identity.Name;
                Materia.opcion = 2;
                Materia.id_materia = id;
                Materia.user = User.Identity.Name;
                
                Materia = MateriaDatos.AbcCatMateria(Materia);
                if (Materia.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente.";
                    return View(Materia);
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
        //[Authorize(Roles = "3")]
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatMateriaModels Materia = new CatMateriaModels();
                _CatMateria_Datos MateriaDatos = new _CatMateria_Datos();
                Materia.conexion = Conexion;
                Materia.opcion = 3;
                Materia.user = User.Identity.Name;
                Materia.id_materia = id;
                MateriaDatos.AbcCatMateria(Materia);
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