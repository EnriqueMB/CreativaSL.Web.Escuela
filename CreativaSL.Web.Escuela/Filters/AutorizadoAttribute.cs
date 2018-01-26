using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CreativaSL.Web.Escuela.Models;
using System.Configuration;
using System.Security.Principal;

namespace CreativaSL.Web.Escuela.Filters
{
    public class AutorizadoAttribute : ActionFilterAttribute
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.Session["SessionTipoUsuario"] == null)
                {
                    UsuarioModels Usuario = new UsuarioModels();
                    UsuarioDatos usuario_datos = new UsuarioDatos();
                    Usuario.conexion = Conexion;
                    IPrincipal user = HttpContext.Current.User;
                    Usuario.cuenta = user.Identity.Name;
                    int TipoUsario = usuario_datos.ObtenerTipoUsuarioByUserName2(Usuario);
                    HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsario;
                }
                if (HttpContext.Current.Session["SessionListaPermiso"] == null)
                {
                    CatAdministrativoModels Administrativo = new CatAdministrativoModels();

                    LoginDatos LoginD = new LoginDatos();
                    Administrativo.conexion = Conexion;
                    IPrincipal user = HttpContext.Current.User;
                    Administrativo.cuenta = user.Identity.Name;
                    Administrativo = LoginD.ObtenerPermisos(Administrativo);
                    List<string> ListaPermiso = new List<string>();
                    foreach (var item in Administrativo.ListaPermisos)
                    {
                        ListaPermiso.Add(item.NombreUrl);
                    }
                    HttpContext.Current.Session["SessionListaPermiso"] = ListaPermiso;
                }
                else
                {
                    int TipoUsuario = (int)HttpContext.Current.Session["SessionTipoUsuario"];
                    List<string> ListaPermiso = new List<string>();
                    ListaPermiso = (List<string>)HttpContext.Current.Session["SessionListaPermiso"];

                    HttpContext.Current.Session["SessionTipoUsuario"] = TipoUsuario;
                    HttpContext.Current.Session["SessionListaPermiso"] = ListaPermiso;
                }
            }

        }
    }
}