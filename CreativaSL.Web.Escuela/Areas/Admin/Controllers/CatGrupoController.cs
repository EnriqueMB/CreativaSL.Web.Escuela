using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSL.Web.Escuela.Models;
using System.Data;
using System.Configuration;
using CreativaSL.Web.Escuela.Filters;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    public class CatGrupoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatGrupo
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Index()
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();
                Grupo.conexion = Conexion;
                Grupo = GrupoDatos.ObtenerCatGrupo(Grupo);
                return View(Grupo);
            }
            catch (Exception)
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                Grupo.TablaDatos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Grupo);
            }
        }

        // GET: Admin/CatGrupo/Create
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Create()
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();
                Grupo.conexion = Conexion;
                Grupo.TablaCicloEscolarCmb = GrupoDatos.ObtenerComboCatCicloEscolar(Grupo);
                var list = new SelectList(Grupo.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = list;
                Grupo.TablaPlanEstudioCmb = GrupoDatos.ObtenerComboCatPlanEstudio(Grupo);
                var list2 = new SelectList(Grupo.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = list2;
                Grupo.TablaModalidadCmb = GrupoDatos.ObtenerComboCatModalidad(Grupo);
                var list3 = new SelectList(Grupo.TablaModalidadCmb, "IDModalidad", "Descripcion");
                ViewData["cmbModalidad"] = list3;
                Grupo.TablaEspecialidadCmb = GrupoDatos.ObtenerComboCatEspecialidad(Grupo);
                var list4 = new SelectList(Grupo.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                ViewData["cmbEspecialidad"] = list4;
                Grupo.TablaCursosCmb = GrupoDatos.ObtenerComboCatCursos(Grupo);
                var list5 = new SelectList(Grupo.TablaCursosCmb, "IDCurso", "Descripcion");
                ViewData["cmbCursos"] = list5;
                return View(Grupo);
            }
            catch (Exception)
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(Grupo);
            }

        }
        // POST: Admin/CatGrupo/ComboModalidad
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboModalidad(int id)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();

                List<CatModalidadModels> listaModalidad = new List<CatModalidadModels>();
                Grupo.conexion = Conexion;
                Grupo.IDPlanEstudio = id;

                listaModalidad = GrupoDatos.ObtenerComboCatModalidad(Grupo);
                return Json(listaModalidad, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Admin/CatGrupo/ComboEspecialidad
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboEspecialidad(string IDMod)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();

                List<CatEspecialidadModels> listaEspecialidad = new List<CatEspecialidadModels>();
                Grupo.conexion = Conexion;
                Grupo.IDModalidad = IDMod;

                listaEspecialidad = GrupoDatos.ObtenerComboCatEspecialidad(Grupo);
                return Json(listaEspecialidad, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Admin/CatGrupo/ComboCruso
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult ComboCurso(string IDEsp)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();

                List<CatCursoModels> listaCurso = new List<CatCursoModels>();
                Grupo.conexion = Conexion;
                Grupo.IDEspecialidad = IDEsp;

                listaCurso = GrupoDatos.ObtenerComboCatCursos(Grupo);
                return Json(listaCurso, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Admin/CatGrupo/Create
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();
                Grupo.conexion = Conexion;
                Grupo.opcion = 1;
                Grupo.user = User.Identity.Name;
                Grupo.IDGrupo = collection["IDGrupo"];
                Grupo.Clave = collection["Clave"];
                Grupo.Nombre = collection["Nombre"];
                Grupo.IDCiclo = collection["TablaCicloEscolarCmb"];
                Grupo.IDPlanEstudio = Convert.ToInt32(collection["TablaPlanEstudioCmb"]);
                Grupo.IDModalidad = collection["TablaModalidadCmb"];
                Grupo.IDEspecialidad = collection["TablaEspecialidadCmb"];
                Grupo.IDCurso = collection["TablaCursosCmb"];
                Grupo = GrupoDatos.AbcCatGrupo(Grupo);
                if (Grupo.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se guardaron correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Grupo.TablaCicloEscolarCmb = GrupoDatos.ObtenerComboCatCicloEscolar(Grupo);
                    var list = new SelectList(Grupo.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                    ViewData["cmbCicloEscolar"] = list;
                    Grupo.TablaPlanEstudioCmb = GrupoDatos.ObtenerComboCatPlanEstudio(Grupo);
                    var list2 = new SelectList(Grupo.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                    ViewData["cmbPlanEstudio"] = list2;
                    Grupo.TablaModalidadCmb = GrupoDatos.ObtenerComboCatModalidad(Grupo);
                    var list3 = new SelectList(Grupo.TablaModalidadCmb, "IDModalidad", "Descripcion");
                    ViewData["cmbModalidad"] = list3;
                    Grupo.TablaEspecialidadCmb = GrupoDatos.ObtenerComboCatEspecialidad(Grupo);
                    var list4 = new SelectList(Grupo.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                    ViewData["cmbEspecialidad"] = list4;
                    Grupo.TablaCursosCmb = GrupoDatos.ObtenerComboCatCursos(Grupo);
                    var list5 = new SelectList(Grupo.TablaCursosCmb, "IDCurso", "Descripcion");
                    ViewData["cmbCursos"] = list5;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se guardaron correctamente. Intente nuevamente";
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatGrupo/Edit/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();
                Grupo.conexion = Conexion;
                Grupo.IDGrupo = id;
                Grupo.TablaCicloEscolarCmb = GrupoDatos.ObtenerComboCatCicloEscolar(Grupo);
                var list = new SelectList(Grupo.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                ViewData["cmbCicloEscolar"] = list;
                Grupo.TablaPlanEstudioCmb = GrupoDatos.ObtenerComboCatPlanEstudio(Grupo);
                var list2 = new SelectList(Grupo.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                ViewData["cmbPlanEstudio"] = list2;
                Grupo.TablaModalidadCmb = GrupoDatos.ObtenerComboCatModalidad(Grupo);
                var list3 = new SelectList(Grupo.TablaModalidadCmb, "IDModalidad", "Descripcion");
                ViewData["cmbModalidad"] = list3;
                Grupo.TablaEspecialidadCmb = GrupoDatos.ObtenerComboCatEspecialidad(Grupo);
                var list4 = new SelectList(Grupo.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                ViewData["cmbEspecialidad"] = list4;
                Grupo.TablaCursosCmb = GrupoDatos.ObtenerComboCatCursos(Grupo);
                var list5 = new SelectList(Grupo.TablaCursosCmb, "IDCurso", "Descripcion");
                ViewData["cmbCursos"] = list5;
                GrupoDatos.ObtenerDetalleCatGrupo(Grupo);
                return View(Grupo);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // POST: Admin/CatGrupo/Edit/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();
                Grupo.conexion = Conexion;
                Grupo.opcion = 2;
                Grupo.user = User.Identity.Name;
                Grupo.IDGrupo = collection["IDGrupo"];
                Grupo.Clave = collection["Clave"];
                Grupo.Nombre = collection["Nombre"];
                Grupo.IDCiclo = collection["TablaCicloEscolarCmb"];
                Grupo.IDPlanEstudio = Convert.ToInt32(collection["TablaPlanEstudioCmb"]);
                Grupo.IDModalidad = collection["TablaModalidadCmb"];
                Grupo.IDEspecialidad = collection["TablaEspecialidadCmb"];
                Grupo.IDCurso = collection["TablaCursosCmb"];
                Grupo = GrupoDatos.AbcCatGrupo(Grupo);
                if (Grupo.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Los datos se editarón correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Grupo.TablaCicloEscolarCmb = GrupoDatos.ObtenerComboCatCicloEscolar(Grupo);
                    var list = new SelectList(Grupo.TablaCicloEscolarCmb, "IDCiclo", "Nombre");
                    ViewData["cmbCicloEscolar"] = list;
                    Grupo.TablaPlanEstudioCmb = GrupoDatos.ObtenerComboCatPlanEstudio(Grupo);
                    var list2 = new SelectList(Grupo.TablaPlanEstudioCmb, "IDPlanEstudio", "Descripcion");
                    ViewData["cmbPlanEstudio"] = list2;
                    Grupo.TablaModalidadCmb = GrupoDatos.ObtenerComboCatModalidad(Grupo);
                    var list3 = new SelectList(Grupo.TablaModalidadCmb, "IDModalidad", "Descripcion");
                    ViewData["cmbModalidad"] = list3;
                    Grupo.TablaEspecialidadCmb = GrupoDatos.ObtenerComboCatEspecialidad(Grupo);
                    var list4 = new SelectList(Grupo.TablaEspecialidadCmb, "id_especialidad", "descripcion");
                    ViewData["cmbEspecialidad"] = list4;
                    Grupo.TablaCursosCmb = GrupoDatos.ObtenerComboCatCursos(Grupo);
                    var list5 = new SelectList(Grupo.TablaCursosCmb, "IDCurso", "Descripcion");
                    ViewData["cmbCursos"] = list5;
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Los datos no se editarón correctamente. Intente nuevamente";
                    return RedirectToAction("Edit");
                }
            }
            catch
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Los datos no se guardaron correctamente. Contacte a soporte técnico.";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatGrupo/Delete/5
        [HttpGet]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CatGrupo/Delete/5
        [HttpPost]
        //[Authorize(Roles = "3")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatGrupoModels Grupo = new CatGrupoModels();
                CatGrupo_Datos GrupoDatos = new CatGrupo_Datos();
                Grupo.conexion = Conexion;
                Grupo.IDGrupo = id;
                Grupo.opcion = 3;
                Grupo.user = User.Identity.Name;
                Grupo = GrupoDatos.AbcCatGrupo(Grupo);
                if (Grupo.Completado == true)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = "El registro se elimino correctamente.";
                    return Json("");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "El registro no se elimino correctamente.";
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
