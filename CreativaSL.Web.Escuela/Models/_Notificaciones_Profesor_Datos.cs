using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _Notificaciones_Profesor_Datos
    {
        public NotificacionesProfesorModels obtenerCatNotificacionProfesor(NotificacionesProfesorModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatNotificacionesDefinidas");
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
        public void actualizarDetalleNotificacion(NotificacionesProfesorModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_NotificacionDetalleActualizar",
                    new SqlParameter("@TablaNotificacion", datos.TablaNotificacionXTipo)
                     );

                if (dr != null)
                {
                    if (dr.Tables.Count == 1)
                    {
                        

                        DataTableReader DTR = dr.Tables[0].CreateDataReader();
                        DataTable Tbl1 = dr.Tables[0];
                        while (DTR.Read())
                        {
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ReenviarNotificacion(NotificacionesProfesorModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_get_ReenviarTipoNotificacionXID",
                    new SqlParameter("@id_notificacion", datos.IDNotificacionGeneral),
                    new SqlParameter("@id_registro", datos.id_registro),
                    new SqlParameter("@tipo_notificacion", datos.IDTipoNotificacion)
                     );

                if (dr != null)
                {
                    if (dr.Tables.Count == 2)
                    {
                        datos.TablaAlumnos = dr.Tables[0];

                        DataTableReader DTR = dr.Tables[1].CreateDataReader();
                        DataTable Tbl1 = dr.Tables[1];
                        while (DTR.Read())
                        {
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}