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
    }
}