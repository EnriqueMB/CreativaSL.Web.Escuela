using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXTarea_Datos
    {
        public AlumnoXTareaModels ObtenerAlumnoXTarea(AlumnoXTareaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_AlumnoXTarea_PROFXID", datos.IDTarea, datos.IDAsignatura);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaAlumnoTarea = ds.Tables[0];
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

        public int GuardarCalificacion(ref AlumnoXTareaModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_TareaPorAlumno_PROF",
                    new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                    new SqlParameter("@IDTarea", datos.IDTarea),
                    new SqlParameter("@tablaAlumnoXTarea", datos.TablaAlumnoTarea),
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