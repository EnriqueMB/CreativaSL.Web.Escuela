using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatPlanEstudio_Datos
    {
        public CatPlanEstudioModels AbcCatPlanEstudio(CatPlanEstudioModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDPlanEstudio, datos.Descripcion,datos.abreviatura, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatPlanEstudios", parametros);
                int Resultado = 0;
                int.TryParse(aux.ToString(), out Resultado);
                if (Resultado == -1)
                {
                    datos.Resultado = Resultado;
                    datos.Completado = false;
                }
                else
                {
                    datos.Resultado = Resultado;
                    datos.Completado = true;
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatPlanEstudioModels ObtenerCatPlanEstudio(CatPlanEstudioModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatPlanEstudios");
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

        public CatPlanEstudioModels ObtenerDetalleCatPlanEstudio(CatPlanEstudioModels datos)
        {
            try
            {
                object[] parametros = { datos.IDPlanEstudio };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatPlanEstudiosXID", parametros);
                while (dr.Read())
                {
                    datos.IDPlanEstudio = Convert.ToInt32(dr["IDPlanEstudio"].ToString());
                    datos.Descripcion = dr["Descripcion"].ToString();
                    datos.abreviatura = dr["Abreviatura"].ToString();
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