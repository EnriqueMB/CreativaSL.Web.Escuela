using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Models;
using System.Configuration;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/HomeAdmin
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/CatAula/Create
        [HttpGet]
        [Authorize(Roles = "4")]
        public ActionResult LoadMenu()
        {
            try
            {
                MenuModels Menu = new MenuModels();
                Menu_Datos MenuD = new Menu_Datos();
                Menu.Conexion = Conexion;
                Menu = MenuD.ObtenerMenu2(Menu);
                return View(Menu);
            }
            catch (Exception)
            {
                MenuModels Menu = new MenuModels();
                return View(Menu);
            }
        }
    }
}