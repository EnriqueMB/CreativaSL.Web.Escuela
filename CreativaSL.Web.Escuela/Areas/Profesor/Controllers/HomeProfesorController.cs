using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Filters;
using CreativaSL.Web.Escuela.Models;
using System.Configuration;

namespace CreativaSL.Web.Escuela.Areas.Profesor.Controllers
{
    public class HomeProfesorController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Profesor/HomeProfesor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadMenu()
        {
            try
            {
                MenuModels Menu = new MenuModels();
                Menu_Datos MenuD = new Menu_Datos();
                Menu.Conexion = Conexion;
                Menu.User = User.Identity.Name;
                Menu.TipoMenu = 2;
                Menu = MenuD.ObtenerMenu2(Menu);
                return View(Menu);
            }
            catch (Exception)
            {
                MenuModels Menu = new MenuModels();
                return View(Menu);
            }
        }

        // GET: Profesor/HomeProfesor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesor/HomeProfesor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesor/HomeProfesor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profesor/HomeProfesor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesor/HomeProfesor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profesor/HomeProfesor/Delete/5
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
    }
}
