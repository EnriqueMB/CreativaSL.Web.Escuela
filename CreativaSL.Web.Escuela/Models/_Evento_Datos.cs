using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class Evento_Datos
    {
        public EventosModels ObtenerEventosPROF(EventosModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_Eventos_PROF", datos.IDAsignatura);
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
        
        public EventosModels AbcEvento(EventosModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDEvento, datos.IDAsignatura, datos.NombreEvento, datos.Descripcion, datos.FechaEvento, datos.FechaEnvio,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_Evento", parametros);
                datos.IDEvento = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDEvento))
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
    }
}