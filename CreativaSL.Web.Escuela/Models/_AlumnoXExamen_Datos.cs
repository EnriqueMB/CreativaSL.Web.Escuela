using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
                DataSet ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_ExamenPorAlumno_PROF",
                new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                new SqlParameter("@IDExamen", datos.IDExamen),
                new SqlParameter("@tablaAlumnoXExamen", datos.TablaCalificacionExamen),
                new SqlParameter("@usuario", datos.user));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaNotificacion = ds.Tables[0];

                            DataTableReader DTR = ds.Tables[1].CreateDataReader();
                            DataTable Tbl1 = ds.Tables[1];
                            while (DTR.Read())
                            {
                                datos.EnviarTarea = !DTR.IsDBNull(DTR.GetOrdinal("examen")) ? DTR.GetBoolean(DTR.GetOrdinal("examen")) : false;
                            }
                        }
                    }
                }
                return Convert.ToInt32(ds.Tables[2].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int ActualizarTexto(ref AlumnoXExamenModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_ActualizarNotificacionesExamen",
                new SqlParameter("@IDExamen", datos.IDExamen),
                new SqlParameter("@TablaTextos", datos.TablaCadenaNotificacion),
                new SqlParameter("@IDUsuario", datos.user));
                return Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        List<ParejaPalabra> ListValues = new List<ParejaPalabra>();
        public AlumnoXExamenModels CadenaFinal(AlumnoXExamenModels datos)
        {
            ObtenerListaStrings(IngresarDatosTabla(datos));

            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.CadenaFinal = r.Replace(datos.Cadena, myEvaluator);
            return datos;
        }

        public DataTable IngresarDatosTabla(AlumnoXExamenModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaExamen", typeof(DateTime));
                _data.Columns.Add("NombreExamen", typeof(string));
                _data.Columns.Add("NombreMateria", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));
                _data.Columns.Add("Calificacion", typeof(float));
                object[] par = { datos.Nombre, datos.FechaExamen, datos.NombreExamen, datos.NombreMateria, datos.NombreProfesor, datos.Calificacion };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ObtenerListaStrings(DataTable _Tabla)
        {

            try
            {
                ListValues = new List<ParejaPalabra>();
                ParejaPalabra Item;
                for (int Rows = 0; Rows < _Tabla.Rows.Count; Rows++)
                {
                    for (int Columns = 0; Columns < _Tabla.Columns.Count; Columns++)
                    {
                        Item = new ParejaPalabra();
                        Item.key = "[" + _Tabla.Columns[Columns].ColumnName + "]";
                        Item.value = _Tabla.Rows[Rows][Columns].ToString();
                        ListValues.Add(Item);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ReplaceCC(Match m)
        // Replace each Regex cc match with the number of the occurrence.
        {
            ParejaPalabra y = ListValues.Find(x => x.key == m.Value);
            return y != null ? y.value : m.Value;
        }
    }
}