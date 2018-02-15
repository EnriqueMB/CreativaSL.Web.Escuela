using CreativaSL.Web.Escuela.Filters;
using CreativaSL.Web.Escuela.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class ReportesController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        
        // GET: Admin/Reportes
        public ActionResult Index()
        {
            try
            {
                ReportesModels Reportes = new ReportesModels();
                _Reportes_Datos ReportesDatos = new _Reportes_Datos();

                Reportes.listaCatedraticos = ReportesDatos.ObtenerComboProfesor(Reportes);
                var list1 = new SelectList(Reportes.listaCatedraticos, "id_persona", "nombre");
                ViewData["cmbProfesor"] = list1;

                Reportes.listaMateria = ReportesDatos.ObtenerComboCatMaterias(Reportes);
                var list2 = new SelectList(Reportes.listaMateria, "id_materia", "nombre");
                ViewData["cmbMaterias"]= list2;

               // Reportes.listaGrupo=ReportesD


                return View(Reportes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}