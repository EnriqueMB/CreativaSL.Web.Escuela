using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAlumnoXGrupo_Datos
    {
        #region Datos Profesor
        public int GuardarCalificacion(CatAlumnosXGrupoModels datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_CalificacionesFinales",
                new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                
                new SqlParameter("@tablaCalificacionesXAlumno", datos.TablaCalificaciones),
                new SqlParameter("@usuario", datos.user));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            //datos.TablaNotificacion = ds.Tables[0];

                            DataTableReader DTR = ds.Tables[0].CreateDataReader();
                            DataTable Tbl1 = ds.Tables[0];
                            while (DTR.Read())
                            {
                                datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 1;
                            }
                        }
                    }
                }
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public CatAlumnosXGrupoModels ObtenerCatAlumnoXGrupoPROFCalificacionFinal(CatAlumnosXGrupoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_ListaDAlumnoCalificacionXasignaturaFinal", datos.IDAsignatura, datos.IDProfesor, datos.IDMateria);
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

        public CatAlumnosXGrupoModels ObtenerCatAlumnoXGrupoPROF(CatAlumnosXGrupoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_ListaDAlumnoXasignatura", datos.IDAsignatura, datos.IDProfesor, datos.IDMateria);
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

        #endregion
    }
}