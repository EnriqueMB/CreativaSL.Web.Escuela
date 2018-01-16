using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatHorario_Datos
    {
        public CatHorarioModels AbcCatHorario(CatHorarioModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDHorario, datos.HoraInicio, datos.HoraFin, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatHorario", parametros);
                datos.IDHorario = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDHorario))
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

        public CatHorarioModels ObtenerCatHorarios(CatHorarioModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatHorario");
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

        public CatHorarioModels ObtenerDetalleCatHorario(CatHorarioModels datos)
        {
            try
            {
                object[] parametros = { datos.IDHorario };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatHorarioXID", parametros);
                while (dr.Read())
                {
                    datos.IDHorario = dr["IDHorario"].ToString();
                    datos.HoraInicio = dr.GetTimeSpan(dr.GetOrdinal("HoraInicio"));
                    datos.HoraFin = dr.GetTimeSpan(dr.GetOrdinal("HoraFin"));
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