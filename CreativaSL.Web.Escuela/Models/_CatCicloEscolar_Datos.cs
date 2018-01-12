using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatCicloEscolar_Datos
    {
        public CatCicloEscolarModels AbcCatCicloEscolar(CatCicloEscolarModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDCiclo, datos.Nombre, datos.Descripcion, datos.FechaInicio, datos.FechaFin, datos.CicloActual, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatCicloEscolar", parametros);
                datos.IDCiclo = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDCiclo))
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

        public CatCicloEscolarModels ObtenerCatCicloEscolar(CatCicloEscolarModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatCicloEscolar");
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

        public CatCicloEscolarModels ObtenerDetalleCatCicloEscolar(CatCicloEscolarModels datos)
        {
            try
            {
                object[] parametros = { datos.IDCiclo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatCicloEscolarXID", parametros);
                while (dr.Read())
                {
                    datos.IDCiclo = dr["IDCiclo"].ToString();
                    datos.Nombre = dr["Nombre"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
                    datos.FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"));
                    datos.FechaFin = dr.GetDateTime(dr.GetOrdinal("FechaFin"));
                    datos.CicloActual = dr.GetBoolean(dr.GetOrdinal("CicloActual"));
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