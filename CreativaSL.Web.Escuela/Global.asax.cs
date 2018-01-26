using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CreativaSL.Web.Escuela.Models;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Security.Principal;
using System.Web.Security;
using CreativaSL.Web.Escuela.Filters;
using System.Web.SessionState;

namespace CreativaSL.Web.Escuela
{
    [Autorizado]
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        [Autorizado]
        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e) //EndRequest
        {
            IPrincipal usr = HttpContext.Current.User;
            // If we are dealing with an authenticated forms authentication request
            if (usr.Identity.IsAuthenticated && usr.Identity.AuthenticationType == "Forms")
            {
                var httpApp = (HttpApplication)sender;
                string URL = httpApp.Request.FilePath.ToLower();
                string[] URLS = System.Text.RegularExpressions.Regex.Split(URL, "/");
                if (httpApp.Request.RawUrl.Split('/').Length > 2)
                {
                    string URLValida = URLS[2];
                    HttpContext context = HttpContext.Current;
                    if (context != null && context.Session != null)
                    {
                        int TipoUsuario = (int)HttpContext.Current.Session["SessionTipoUsuario"];
                        List<string> ListaPermiso = new List<string>();
                        ListaPermiso = (List<string>)HttpContext.Current.Session["SessionListaPermiso"];

                        if (URLValida == "account" || URLValida == "requestdata")
                        {

                        }
                        else
                        {
                            if (string.IsNullOrEmpty(ListaPermiso.Find(x => x.Equals(URLValida))))
                            {
                                if (TipoUsuario == 3)
                                {
                                    Response.Redirect("/Admin/HomeAdmin");
                                    //return RedirectToAction("Index", "HomeAdmin");
                                    //mandar a login
                                }
                                else if (TipoUsuario == 1)
                                {
                                    Response.Redirect("/Admin/HomeProfesor");
                                }
                            }
                        }
                    }
                    
                    //FormsIdentity fIdent = User.Identity as FormsIdentity;
                    //// Create a CustomIdentity based on the FormsAuthenticationTicket  
                    //CustomIdentity ci = new CustomIdentity(fIdent.Ticket);
                    //// Create the CustomPrincipal
                    //if (URLValida == "account")
                    //{

                    //}
                    //else
                    //{
                    //    if (string.IsNullOrEmpty(ci.NombreUrl.Find(x => x.Equals(URLValida))))
                    //    {
                    //        if (fIdent.Ticket.Version == 3)
                    //        {
                    //            Response.Redirect("/Admin/HomeAdmin/");
                    //            //return RedirectToAction("Index", "HomeAdmin");
                    //            //mandar a login
                    //        }
                    //        else if (fIdent.Ticket.Version == 1)
                    //        {
                    //            Response.Redirect("/Admin/HomeProfesor/");
                    //        }
                    //    }
                    //}
                }
            
            }
        }
    }
}
