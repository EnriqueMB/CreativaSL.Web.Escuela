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
        public AlumnoXAsistenciaModels ObtenerListaAsistenciaPROXID(AlumnoXAsistenciaModels Datos)
        {
            try
            {
                object[] parametros =
                {
                    Datos.IDAsignatura, Datos.IDLista, Datos.FechaLista, Datos.user
                };
                DataSet Ds = null;
                Ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_abc_ListaAsistencia_PROF", parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        //DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        //while (Dr.Read())
                        //{
                            Datos.TablaDatos = Ds.Tables[0];
                        //}
                        DataTableReader DTR = Ds.Tables[1].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[1];
                        while (DTR.Read())
                        {
                            Datos.IDLista = !DTR.IsDBNull(DTR.GetOrdinal("IDLista")) ? DTR.GetString(DTR.GetOrdinal("IDLista")) : string.Empty;
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

        public int GuardarAsistencia(ref AlumnoXAsistenciaModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_AsistenciaPorAlumno_PROF",
                new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                new SqlParameter("@IDLista", datos.IDLista),
                new SqlParameter("@tablaAlumnoXAsistencia", datos.tablaAlumnoXAsistencia),
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