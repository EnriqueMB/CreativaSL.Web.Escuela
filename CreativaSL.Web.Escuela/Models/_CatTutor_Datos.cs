using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatTutor_Datos
    {
        public CatTutorModels AbcCatTutor(CatTutorModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDPersona, datos.Nombre.Trim(), datos.ApPaterno.Trim(), datos.ApMaterno.Trim(), datos.Correo,
                    datos.Telefono, datos.Direccion, datos.Observaciones, datos.clvUser, datos.passUser, datos.user
                };
                if (datos.opcion == 1)
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_abc_CatTutores", parametros);
                    while (dr.Read())
                    {
                        datos.IDPersona = dr.GetString(dr.GetOrdinal("tutor"));
                        datos.clvUser = dr.GetString(dr.GetOrdinal("usuario"));
                        datos.passUser = dr.GetString(dr.GetOrdinal("Contraseña"));
                        datos.Completado = true;
                    }
                }

                else if (datos.opcion == 2 || datos.opcion == 3)
                {
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatTutores", parametros);
                    datos.IDPersona = aux.ToString();
                    if (!string.IsNullOrEmpty(datos.IDPersona))
                    {
                        datos.Completado = true;
                    }
                    else
                    {
                        datos.Completado = false;
                    }

                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CatTutorModels ObtenerDetalleCatCatedratico(CatTutorModels datos)
        {
            try
            {
                object[] parametros = { datos.IDPersona };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatTutorXID", parametros);
                while (dr.Read())
                {
                    datos.IDPersona = dr["id_persona"].ToString();
                    datos.Nombre = dr["nombre"].ToString();
                    datos.ApPaterno = dr["apPaterno"].ToString();
                    datos.ApMaterno = dr["apMaterno"].ToString();
                    datos.Correo = dr["correo"].ToString();
                    datos.Telefono = dr["telefono"].ToString();
                    datos.Direccion = dr["direccion"].ToString();
                    datos.Observaciones = dr["observaciones"].ToString();
                    
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CatTutorModels ObtenerCatTutor(CatTutorModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatTutor");
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