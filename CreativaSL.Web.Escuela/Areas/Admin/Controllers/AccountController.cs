using CreativaSL.Web.Escuela.Filters;
using CreativaSL.Web.Escuela.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.Routing;

namespace CreativaSL.Web.Escuela.Areas.Admin.Controllers
{
    [Autorizado]
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        int Verificador = 0;
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Account/Index
        [AllowAnonymous]
        public ActionResult Index()
        {
            try
            {
                FormsAuthentication.SignOut();
                if (User.Identity.IsAuthenticated)
                {
                    UsuarioModels usuario = new UsuarioModels();
                    usuario.conexion = Conexion;
                    usuario.cuenta = User.Identity.Name;
                    UsuarioDatos usuario_datos = new UsuarioDatos();
                    string id_tipoUsuario = usuario_datos.ObtenerTipoUsuarioByUserName(usuario);
                    if (id_tipoUsuario == "3")
                    {
                        return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                    }
                    else if (id_tipoUsuario == "1")
                    {
                        return RedirectToAction("Index", "HomeProfesor", new { Area = "Profesor" });
                    }
                    else
                        return RedirectToAction("LogOff", "Account");
                }
                else
                    return View();
            }
            catch (Exception)
            {
                return RedirectToAction("LogOff", "Account");
            }
        }
        //
        // POST: /Account/Index
        [HttpPost]
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(CatAdministrativoModels model, string returnUrl)
        {
            LoginDatos UD = new LoginDatos();
            model.conexion = Conexion;
            model = UD.ValidarUsuario(model);
            if (model.opcion == 1)
            {
                FormsAuthentication.SignOut();
                UsuarioDatos usuario_datos = new UsuarioDatos();
                UsuarioModels usuario = new UsuarioModels();
                usuario.conexion = Conexion;
                usuario.cuenta = model.id_administrativo;
                int TipoUsario = usuario_datos.ObtenerTipoUsuarioByUserName2(usuario);
                System.Web.HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsario;
                FormsAuthentication.SetAuthCookie(model.id_administrativo, model.RememberMe);
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(model.id_administrativo, model.RememberMe);
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                List<string> listaPermiso = new List<string>();
                foreach (var item in model.ListaPermisos)
                {
                    listaPermiso.Add(item.NombreUrl);
                }
                System.Web.HttpContext.Current.Session["SessionListaPermiso"] = listaPermiso;
                //AdministrativoPermisoJson Json = new AdministrativoPermisoJson { NombreURl = listaPermiso};
                //string userDataString = JsonConvert.SerializeObject(Json);
                //FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(TipoUsario, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);
                //authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                //Response.Cookies.Add(authCookie);               
                string id_tipoUsuario = usuario_datos.ObtenerTipoUsuarioByUserName(usuario);
                if (id_tipoUsuario == "3")
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                }
                else if (id_tipoUsuario == "1")
                {
                    return RedirectToAction("Index", "HomeProfesor", new { Area = "Profesor" });
                }
                else
                {
                    ModelState.AddModelError("", "No tienes permisos");
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    return View(model);
                }
            }
            else if (model.opcion == 2)
            {
                ModelState.AddModelError("", "Usuario no existe");
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                return View(model);
            }
            else if (model.opcion == 3)
            {
                ModelState.AddModelError("", "Error de Contraseña");
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                return View(model);
            }
            else if (model.opcion == 4)
            {
                ModelState.AddModelError("", "El usuario tiene que ser de tipo. Administrador ó Profesor");
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "El usuario o contraseña son incorrectos!!.");
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                return View(model);
            }
        }
        //
        // GET: /Account/LogOff
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckUserAvailability(string cuenta)
        {
            UsuarioModels usuario = new UsuarioModels();
            UsuarioDatos usuario_datos = new UsuarioDatos();
            usuario.conexion = Conexion;
            usuario.cuenta = cuenta;
            return Json(usuario_datos.CheckUserName(usuario), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckEmailAvailability(string email)
        {
            UsuarioModels usuario = new UsuarioModels();
            UsuarioDatos usuario_datos = new UsuarioDatos();
            usuario.conexion = Conexion;
            usuario.email = email;
            return Json(usuario_datos.CheckEmail(usuario), JsonRequestBehavior.AllowGet);
        }

        // GET: /Account/GetPassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetPassword()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: /Account/GetPassword
        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetPassword(FormCollection collection)
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario.email2 = collection["email2"];
                usuario = usuario_datos.ResetPassword(usuario);

                if (usuario.activo == true)
                {
                    Comun.EnviarCorreo(
                     ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , ConfigurationManager.AppSettings.Get("PasswordTxt")
                    , usuario.email2
                    , "Password reset Colegio"
                    , Comun.GenerarHtmlResetContraseña(usuario.cuenta, usuario.password)
                    , false
                    , ""
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                    , ConfigurationManager.AppSettings.Get("HostTxt")
                    , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                    TempData["typemessage"] = "1";
                    TempData["message"] = "Password reseateada correctamente";
                    ModelState.AddModelError("", "Password reseateada correctamente");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "Correo no existente";
                    ModelState.AddModelError("", "Correo no existente");
                }
                return RedirectToAction("GetPassword");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Correo no existente";
                return RedirectToAction("GetPassword");
            }
        }
    }

}