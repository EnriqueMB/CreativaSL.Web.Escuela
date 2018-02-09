using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class Examen_Datos
    {
        public ExamenModels ObtenerExamenPROF(ExamenModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_Examen_PROF", datos.IDAsignatura);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaDatos = ds.Tables[0];
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

        public ExamenModels ObtenerDetalleExamenPROFXID(ExamenModels datos)
        {
            try
            {
                object[] parametros = { datos.IDExamen };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_Examen_PROFXID", parametros);   //Falta Procedimiento
                while (dr.Read())
                {
                    datos.IDExamen = dr["IDExamen"].ToString();
                    datos.IDAsignatura = dr["IDAsignatura"].ToString();
                    datos.NombreExamen = dr["NombreExamen"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
                    datos.FechaExamen = dr.GetDateTime(dr.GetOrdinal("FechaExamen"));//Convert.ToDateTime(dr["fechaExamen"]);
                    datos.FechaEnvio = dr.GetDateTime(dr.GetOrdinal("FechaEnvio"));//Convert.ToDateTime(dr["fechaEnvio"]);
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExamenModels AbcExamen(ExamenModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDExamen, datos.IDAsignatura, datos.NombreExamen, datos.Descripcion, datos.FechaExamen, datos.FechaEnvio,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_Examen", parametros);
                datos.IDExamen = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDExamen))
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

        public ExamenModels DetalleExamenPROFXID(ExamenModels datos)
        {
            try
            {
                object[] parametros = { datos.IDExamen };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_DetalleExamen_PROFXID", parametros);
                while (dr.Read())
                {
                    datos.IDExamen = dr["IDExamen"].ToString();
                    datos.IDAsignatura = dr["IDAsignatura"].ToString();
                    datos.NombreExamen = dr["NombreExamen"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
                    datos.FechaExamen = dr.GetDateTime(dr.GetOrdinal("FechaExamen"));//Convert.ToDateTime(dr["fechaExamen"]);
                    datos.FechaEnvio = dr.GetDateTime(dr.GetOrdinal("FechaEnvio"));//Convert.ToDateTime(dr["fechaEnvio"]);
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