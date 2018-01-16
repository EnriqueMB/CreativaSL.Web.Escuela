using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using CreativaSL.Web.Escuela.Models;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    public class AsignaturaController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Asignatura
        [HttpGet]
        [Authorize(Roles ="4")]
        public ActionResult Index()
        {
            try
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura_Datos AsignaturaDatos = new Asignatura_Datos();
                Asignatura.conexion = Conexion;
                Asignatura = AsignaturaDatos.ObtenerAsignatura(Asignatura);
                return View(Asignatura);
            }
            catch (Exception)
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Asignatura);
            }
        }

        // GET: Admin/Asignatura/Create
        [HttpGet]
        [Authorize(Roles ="4")]
        public ActionResult Create()
        {
            try
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura_Datos AsignaturaDatos = new Asignatura_Datos();
                Asignatura.conexion = Conexion;
                Asignatura.TablaCicloEscolarCmb = AsignaturaDatos.ObtenerComboCatCicloEscolar(Asignatura);
                var list = new SelectList(Asignatura.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = list;
                Asignatura.TablaGrupoCmb = AsignaturaDatos.ObtenerComboCatGrupo(Asignatura);
                var list1 = new SelectList(Asignatura.TablaGrupoCmb, "IDGrupo", "Nombre");
                ViewData["cmbGrupoEscolar"] = list1;
                Asignatura.TablaMateriaCmb = AsignaturaDatos.ObtenerComboCatMaterias(Asignatura);
                var list2 = new SelectList(Asignatura.TablaMateriaCmb, "id_materia", "nombre");
                ViewData["cmbMateriaEscolar"] = list2;
                Asignatura.TablaHorarioCmb = AsignaturaDatos.ObtenerComboCatHorario(Asignatura);
                var list3 = new SelectList(Asignatura.TablaHorarioCmb, "IDHorario", "Descripcion");
                ViewData["cmbHorarioEscolar"] = list3;
                Asignatura.TablaProfesorCmb = AsignaturaDatos.ObtenerComboCatProfesor(Asignatura);
                var list4 = new SelectList(Asignatura.TablaProfesorCmb, "id_persona", "Descripcion");
                ViewData["cmbProfesorEscolar"] = list4;
                Asignatura.TablaAulaCmb = AsignaturaDatos.ObtenerComboCatAula(Asignatura);
                var list5 = new SelectList(Asignatura.TablaAulaCmb, "IDAula", "Descripcion");
                ViewData["cmbAulaEscolar"] = list5;
                return View(Asignatura);
            }
            catch (Exception)
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Asignatura);
            }
        }

        // POST: Admin/Asignatura/Create
        [HttpPost]
        [Authorize(Roles = "4")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura_Datos AsignaturaDatos = new Asignatura_Datos();
                Asignatura.conexion = Conexion;
                Asignatura.opcion = 1;
                Asignatura.user = User.Identity.Name;
                Asignatura.IDAsignatura = "";
                Asignatura.IDCiclo = collection["TablaCicloEscolarCmb"];
                Asignatura.IDGrupo = collection["TablaGrupoCmb"];
                Asignatura.IDMateria = collection["TablaMateriaCmb"];
                Asignatura.IDHorario = collection["TablaHorarioCmb"];
                Asignatura.IDProfesor = collection["TablaProfesorCmb"];
                Asignatura.IDAula = collection["TablaAulaCmb"];
                Asignatura = AsignaturaDatos.AbcAsignatura(Asignatura);
                if (Asignatura.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Asignatura.TablaCicloEscolarCmb = AsignaturaDatos.ObtenerComboCatCicloEscolar(Asignatura);
                    var list = new SelectList(Asignatura.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                    ViewData["cmbCicloEscolar"] = list;
                    Asignatura.TablaGrupoCmb = AsignaturaDatos.ObtenerComboCatGrupo(Asignatura);
                    var list1 = new SelectList(Asignatura.TablaGrupoCmb, "IDGrupo", "Nombre");
                    ViewData["cmbGrupoEscolar"] = list1;
                    Asignatura.TablaMateriaCmb = AsignaturaDatos.ObtenerComboCatMaterias(Asignatura);
                    var list2 = new SelectList(Asignatura.TablaMateriaCmb, "id_materia", "nombre");
                    ViewData["cmbMateriaEscolar"] = list2;
                    Asignatura.TablaHorarioCmb = AsignaturaDatos.ObtenerComboCatHorario(Asignatura);
                    var list3 = new SelectList(Asignatura.TablaHorarioCmb, "IDHorario", "Descripcion");
                    ViewData["cmbHorarioEscolar"] = list3;
                    Asignatura.TablaProfesorCmb = AsignaturaDatos.ObtenerComboCatProfesor(Asignatura);
                    var list4 = new SelectList(Asignatura.TablaProfesorCmb, "id_persona", "Descripcion");
                    ViewData["cmbProfesorEscolar"] = list4;
                    Asignatura.TablaAulaCmb = AsignaturaDatos.ObtenerComboCatAula(Asignatura);
                    var list5 = new SelectList(Asignatura.TablaAulaCmb, "IDAula", "Descripcion");
                    ViewData["cmbAulaEscolar"] = list5;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return View(Asignatura);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Asignatura/Edit/5
        [HttpGet]
        [Authorize(Roles ="4")]
        public ActionResult Edit(string id)
        {
            try
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura_Datos AsignaturaDatos = new Asignatura_Datos();
                Asignatura.IDAsignatura = id;
                Asignatura.conexion = Conexion;
                Asignatura.TablaCicloEscolarCmb = AsignaturaDatos.ObtenerComboCatCicloEscolar(Asignatura);
                var list = new SelectList(Asignatura.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = list;
                Asignatura.TablaGrupoCmb = AsignaturaDatos.ObtenerComboCatGrupo(Asignatura);
                var list1 = new SelectList(Asignatura.TablaGrupoCmb, "IDGrupo", "Nombre");
                ViewData["cmbGrupoEscolar"] = list1;
                Asignatura.TablaMateriaCmb = AsignaturaDatos.ObtenerComboCatMaterias(Asignatura);
                var list2 = new SelectList(Asignatura.TablaMateriaCmb, "id_materia", "nombre");
                ViewData["cmbMateriaEscolar"] = list2;
                Asignatura.TablaHorarioCmb = AsignaturaDatos.ObtenerComboCatHorario(Asignatura);
                var list3 = new SelectList(Asignatura.TablaHorarioCmb, "IDHorario", "Descripcion");
                ViewData["cmbHorarioEscolar"] = list3;
                Asignatura.TablaProfesorCmb = AsignaturaDatos.ObtenerComboCatProfesor(Asignatura);
                var list4 = new SelectList(Asignatura.TablaProfesorCmb, "id_persona", "Descripcion");
                ViewData["cmbProfesorEscolar"] = list4;
                Asignatura.TablaAulaCmb = AsignaturaDatos.ObtenerComboCatAula(Asignatura);
                var list5 = new SelectList(Asignatura.TablaAulaCmb, "IDAula", "Descripcion");
                ViewData["cmbAulaEscolar"] = list5;
                Asignatura = AsignaturaDatos.ObtenerDetalleAsignatura(Asignatura);
                return View(Asignatura);
            }
            catch (Exception)
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Asignatura);
            }
        }

        // POST: Admin/Asignatura/Edit/5
        [HttpPost]
        [Authorize(Roles ="4")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura_Datos AsignaturaDatos = new Asignatura_Datos();
                Asignatura.conexion = Conexion;
                Asignatura.opcion = 2;
                Asignatura.user = User.Identity.Name;
                Asignatura.IDAsignatura = collection["IDAsignatura"];
                Asignatura.IDCiclo = collection["TablaCicloEscolarCmb"];
                Asignatura.IDGrupo = collection["TablaGrupoCmb"];
                Asignatura.IDMateria = collection["TablaMateriaCmb"];
                Asignatura.IDHorario = collection["TablaHorarioCmb"];
                Asignatura.IDProfesor = collection["TablaProfesorCmb"];
                Asignatura.IDAula = collection["TablaAulaCmb"];
                Asignatura = AsignaturaDatos.AbcAsignatura(Asignatura);
                if (Asignatura.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Asignatura.TablaCicloEscolarCmb = AsignaturaDatos.ObtenerComboCatCicloEscolar(Asignatura);
                    var list = new SelectList(Asignatura.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                    ViewData["cmbCicloEscolar"] = list;
                    Asignatura.TablaGrupoCmb = AsignaturaDatos.ObtenerComboCatGrupo(Asignatura);
                    var list1 = new SelectList(Asignatura.TablaGrupoCmb, "IDGrupo", "Nombre");
                    ViewData["cmbGrupoEscolar"] = list1;
                    Asignatura.TablaMateriaCmb = AsignaturaDatos.ObtenerComboCatMaterias(Asignatura);
                    var list2 = new SelectList(Asignatura.TablaMateriaCmb, "id_materia", "nombre");
                    ViewData["cmbMateriaEscolar"] = list2;
                    Asignatura.TablaHorarioCmb = AsignaturaDatos.ObtenerComboCatHorario(Asignatura);
                    var list3 = new SelectList(Asignatura.TablaHorarioCmb, "IDHorario", "Descripcion");
                    ViewData["cmbHorarioEscolar"] = list3;
                    Asignatura.TablaProfesorCmb = AsignaturaDatos.ObtenerComboCatProfesor(Asignatura);
                    var list4 = new SelectList(Asignatura.TablaProfesorCmb, "id_persona", "Descripcion");
                    ViewData["cmbProfesorEscolar"] = list4;
                    Asignatura.TablaAulaCmb = AsignaturaDatos.ObtenerComboCatAula(Asignatura);
                    var list5 = new SelectList(Asignatura.TablaAulaCmb, "IDAula", "Descripcion");
                    ViewData["cmbAulaEscolar"] = list5;
                    Asignatura = AsignaturaDatos.ObtenerDetalleAsignatura(Asignatura);
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente.";
                    return View(Asignatura);
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Asignatura/Delete/5
        [HttpGet]
        [Authorize(Roles ="4")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/Asignatura/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                AsignaturaModels Asignatura = new AsignaturaModels();
                Asignatura_Datos AsignaturaDatos = new Asignatura_Datos();
                Asignatura.conexion = Conexion;
                Asignatura.opcion = 3;
                Asignatura.IDAsignatura = id;
                Asignatura.user = User.Identity.Name;
                Asignatura = AsignaturaDatos.AbcAsignatura(Asignatura);
                if (Asignatura.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se a eliminado correctamente";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El registro no se a eliminado correctamente. Intente nuevamente.";
                    return Json("");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
