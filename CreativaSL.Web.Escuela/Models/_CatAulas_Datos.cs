using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAulas_Datos
    {
        public CatAulaModels AbcCatAula(CatAulaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDAula, datos.Descripcion, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatAulas", parametros);
                datos.IDAula = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDAula))
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

        public CatAulaModels ObtenerCatAulas(CatAulaModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatAulas");
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

        public CatAulaModels ObtenerDetalleCatAulas(CatAulaModels datos)
        {
            try
            {
                object[] parametros = { datos.IDAula };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatAulasXID", parametros);
                while (dr.Read())
                {
                    datos.IDAula = dr["IDAula"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
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