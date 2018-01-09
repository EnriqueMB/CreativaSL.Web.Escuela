using System;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSL.Web.Escuela.Models
{
    public class LoginDatos
    {

        public CatAdministrativoModels ValidarUsuario(CatAdministrativoModels datos)
        {
            try
            {                
                object[] parametros = { datos.user, datos.password };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "Login_sp", parametros);
                while (dr.Read())
                {
                    datos.opcion = Convert.ToInt32(dr[0].ToString());
                    if(datos.opcion == 1)
                    {
                        datos.id_administrativo = dr["Id_U"].ToString();
                        datos.nombre = dr["U_Nombre"].ToString();
                        datos.apPaterno = dr["U_Apellidop"].ToString();
                        datos.apMaterno = dr["U_Apellidom"].ToString();
                        datos.user = dr["Cu_User"].ToString();
                        datos.password = dr["Cu_Pass"].ToString();
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
