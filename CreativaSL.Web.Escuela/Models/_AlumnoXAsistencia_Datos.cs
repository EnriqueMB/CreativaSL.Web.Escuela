using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXAsistencia_Datos
    {
        public AlumnoXAsistenciaModels ObtenerListaAsistenciaPROXID(AlumnoXAsistenciaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_AlumnoXAsistenciaPROFXID", datos.IDLista, datos.IDAsignatura);
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

        public int GuardarAsistencia(ref AlumnoXAsistenciaModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_abc_AsistenciaPorAlumnoPROF",
                new SqlParameter("@id_lista", datos.IDLista),
                new SqlParameter("@tablaAlumnoXAsistencia", datos.TablaDatos),
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