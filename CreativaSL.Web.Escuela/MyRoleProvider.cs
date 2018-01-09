using System;
using System.Configuration;
using System.Web.Security;
using CreativaSL.Web.Escuela.Models;

namespace CreativaSL.Web.Escuela
{
    public class MyRoleProvider : RoleProvider
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            CatAdministrativoModels administrativo = new CatAdministrativoModels();
            administrativo.conexion = Conexion;
            administrativo.cuenta = username;
            CatAdministrativo_Datos administrativo_datos = new CatAdministrativo_Datos();
            string[] arr1 = new string[] { administrativo_datos.ObtenerTipoUsuarioByUserName(administrativo) };
            return arr1;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}