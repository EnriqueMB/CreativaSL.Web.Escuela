using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatModalidad_Datos
    {
        public CatModalidadModels AbcCatModalidad(CatModalidadModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDModalidad, datos.IDPlanEstudio, datos.Descripcion, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatModalidad", parametros);
                datos.IDModalidad = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDModalidad))
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

        public CatModalidadModels ObtenerCatModalidad(CatModalidadModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatModalidad");
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

        public CatModalidadModels ObtenerDetalleCatModalidad(CatModalidadModels datos)
        {
            try
            {
                object[] parametros = { datos.IDModalidad };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatModalidadXID", parametros);
                while (dr.Read())
                {
                    datos.IDModalidad = dr["IDModalidad"].ToString();
                    datos.IDPlanEstudio = Convert.ToInt32(dr["IDPlanEstudio"].ToString());
                    datos.Descripcion = dr["Descripcion"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatPlanEstudioModels> obtenerComboCatPlanEstudio(CatModalidadModels datos)
        {
            try
            {
                List<CatPlanEstudioModels> lista = new List<CatPlanEstudioModels>();
                CatPlanEstudioModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatPlanEstudio");
                while (dr.Read())
                {
                    item = new CatPlanEstudioModels();
                    item.IDPlanEstudio = Convert.ToInt32(dr["IDPlanEstudio"].ToString());
                    item.Descripcion = dr["PlanEstudio"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}