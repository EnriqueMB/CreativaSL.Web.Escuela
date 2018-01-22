using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Security.Cryptography;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAdministrativo_Datos
    {

        public CatAdministrativoModels ObtenerCatAdministrativo(CatAdministrativoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_CatAdministrativo");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaAdministracion = ds.Tables[0];
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CatAdministrativoModels ObtenerDetalleCatAdministrativoxID(CatAdministrativoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_administrativo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatAdministrativoXID", parametros);
                while (dr.Read())
                {
                    datos.id_administrativo = dr["id_persona"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.apPaterno = dr["apPaterno"].ToString();
                    datos.apMaterno = dr["apMaterno"].ToString();
                    datos.correo = dr["correo"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.direccion = dr["direccion"].ToString();
                    datos.Observaciones = dr["observaciones"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CatAdministrativoModels AbcCatAdministrativo(CatAdministrativoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_administrativo, datos.nombre, datos.apPaterno,
                    datos.apMaterno, datos.correo, datos.telefono, datos.direccion, datos.Observaciones, datos.clvUser, datos.passUser, 
                    datos.user
                    };
                if (datos.opcion == 1)
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_abc_CatAdministrativo", parametros);
                    while (dr.Read())
                    {
                        datos.id_administrativo = dr.GetString(dr.GetOrdinal("id_administrativo"));
                        datos.clvUser = dr.GetString(dr.GetOrdinal("usuario"));
                        datos.passUser = dr.GetString(dr.GetOrdinal("contraseña"));
                    }
                }
                else if (datos.opcion == 2 || datos.opcion == 3)
                {
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatAdministrativo", parametros);
                    if (aux != null)
                        datos.id_administrativo = aux.ToString();
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string ObtenerTipoUsuarioByUserName(CatAdministrativoModels datos)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_get_TipoUsuarioByUserName", datos.cuenta);
                return aux.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public CatAdministrativoModels PermisosXUsuario(CatAdministrativoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_PermisosXID", Datos.id_administrativo);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            Datos.TablaPermisos = ds.Tables[0];
                        }
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
