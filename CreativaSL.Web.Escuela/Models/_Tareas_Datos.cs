using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class Tareas_Datos
    {
        public TareasModels ObtenerCatTareaPROF(TareasModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_Tarea_PROF", datos.IDAsignatura);
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

        public TareasModels ObtenerDetalleTareaPROFXID(TareasModels datos)
        {
            try
            {
                object[] parametros = { datos.IDTarea };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_Tarea_PROFXID", parametros);
                while (dr.Read())
                {
                    datos.IDTarea = dr["IDTarea"].ToString();
                    datos.IDAsignatura = dr["IDAsignatura"].ToString();
                    datos.NombreTarea = dr["NombreTarea"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
                    datos.FechaEntraga = dr.GetDateTime(dr.GetOrdinal("FechaEntrega"));//Convert.ToDateTime(dr["FechaEntrega"]);
                    datos.FechaEnvio = dr.GetDateTime(dr.GetOrdinal("FechaEnvio"));//Convert.ToDateTime(dr["FechaEnvio"]);
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TareasModels AbcTareas(TareasModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDTarea, datos.IDAsignatura, datos.NombreTarea, datos.Descripcion, datos.FechaEntraga, datos.FechaEnvio,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_Tareas", parametros);
                datos.IDTarea = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDTarea))
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

        public TareasModels DetalleTareaPROFXID(TareasModels datos)
        {
            try
            {
                object[] parametros = { datos.IDTarea };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_DetalleTarea_PROFXID", parametros);
                while (dr.Read())
                {
                    datos.IDTarea = dr["IDTarea"].ToString();
                    datos.IDAsignatura = dr["IDAsignatura"].ToString();
                    datos.NombreTarea = dr["NombreTarea"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
                    datos.FechaEntraga = dr.GetDateTime(dr.GetOrdinal("FechaEntrega"));//Convert.ToDateTime(dr["fechaEntrega"]);
                    datos.FechaEnvio = dr.GetDateTime(dr.GetOrdinal("fechaEnvio")); //Convert.ToDateTime(dr["fechaEnvio"]);
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