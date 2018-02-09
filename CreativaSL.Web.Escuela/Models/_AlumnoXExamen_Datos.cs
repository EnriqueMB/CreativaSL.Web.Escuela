using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXExamen_Datos
    {
        public AlumnoXExamenModels ObtenerAlumnoXExamen(AlumnoXExamenModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_AlumnoXExamen_PROFXID", datos.IDExamen, datos.IDAsignatura);
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


        public int GuardarCalificacion(ref AlumnoXExamenModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_ExamenPorAlumno_PROF",
                new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                new SqlParameter("@IDExamen", datos.IDExamen),
                new SqlParameter("@tablaAlumnoXExamen", datos.TablaCalificacionExamen),
                new SqlParameter("@usuario", datos.user));
                return Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}