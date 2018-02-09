using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXEvento_Datos
    {
        public AlumnoXEventoModels ObtenerAlumnoXEvento(AlumnoXEventoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_AlumnoXEventoPROFXID", datos.IDEvento);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaXEvento = ds.Tables[0];
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

        public int EnviarEvento(ref AlumnoXEventoModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_EventoPorAlumnoPROF",
                new SqlParameter("@IDEvento", datos.IDEvento),
                new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                new SqlParameter("@usuario", datos.user));
                datos.TablaNotificaciones = dt.Tables[1];
                return Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}