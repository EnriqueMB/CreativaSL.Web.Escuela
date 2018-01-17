using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _Roles_Datos
    {
        public RoleModels AbcCatRoles(RoleModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion,datos.id_roles,datos.nombre,datos.descripcion,datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_AspNetRoles", parametros);
                datos.id_roles = aux.ToString();
                if (!string.IsNullOrEmpty(datos.id_roles))
                {
                    datos.Completado = true;
                }
                else
                {
                    datos.Completado = false;
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RoleModels ObtenerDetalleRoles(RoleModels datos)
        {
            try
            {
                object[] parametros = { datos.id_roles };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatRolesXID", parametros);
                while (dr.Read())
                {
                    datos.id_roles = dr["id_role"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RoleModels ObtenerCatRoles(RoleModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_v2_CatAspNetRoles");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            Datos.TablaDatos = ds.Tables[0];
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