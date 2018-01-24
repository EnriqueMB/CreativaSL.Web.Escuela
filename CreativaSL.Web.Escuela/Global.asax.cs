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

namespace CreativaSL.Web.Escuela
{
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

        protected void Application_EndRequest(object sender, EventArgs e)
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
                    FormsIdentity fIdent = User.Identity as FormsIdentity;
                    // Create a CustomIdentity based on the FormsAuthenticationTicket  
                    CustomIdentity ci = new CustomIdentity(fIdent.Ticket);
                    // Create the CustomPrincipal
                    if (URLValida == "account")
                    {

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(ci.NombreUrl.Find(x => x.Equals(URLValida))))
                        {
                            Response.Redirect("/Admin/HomeAdmin/");
                            //return RedirectToAction("Index", "HomeAdmin");
                            //mandar a login
                        }
                    }
                }
            
            }
        }

        public MenuModels ObtenerDetalleCatURL(MenuModels datos)
        {
            try
            {
                object[] parametros = { datos.NombreMenu };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "", parametros);
                while (dr.Read())
                {
                    datos.NombreMenu = dr["IDAula"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        //protected void Application_BeginRequest()
        //{
        //    if (!Context.Request.IsSecureConnection)
        //    {
        //        This is an insecure connection, so redirect to the secure version
        //       UriBuilder uri = new UriBuilder(Context.Request.Url);


        //    }

        //}
    }
}
