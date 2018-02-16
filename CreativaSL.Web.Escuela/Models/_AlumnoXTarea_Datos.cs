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
                DataSet ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_TareaPorAlumno_PROF",
                    new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                    new SqlParameter("@IDTarea", datos.IDTarea),
                    new SqlParameter("@tablaAlumnoXTarea", datos.TablaAlumnoTarea),
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
                                    datos.EnviarTarea = !DTR.IsDBNull(DTR.GetOrdinal("tarea")) ? DTR.GetBoolean(DTR.GetOrdinal("tarea")) : false;
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


        public int ActualizarTexto(ref AlumnoXTareaModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_ActualizarNotificacionesTarea",
                new SqlParameter("@IDTarea", datos.IDTarea),
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
        public AlumnoXTareaModels CadenaFinal(AlumnoXTareaModels datos)
        {
            ObtenerListaStrings(IngresarDatosTabla(datos));

            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.CadenaFinal = r.Replace(datos.Cadena, myEvaluator);
            return datos;
        }

        public DataTable IngresarDatosTabla(AlumnoXTareaModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaEntrega", typeof(DateTime));
                _data.Columns.Add("NombreTarea", typeof(string));
                _data.Columns.Add("NombreMateria", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));
                _data.Columns.Add("Calificacion", typeof(float));
                object[] par = { datos.Nombre, datos.FechaTarea, datos.NombreTarea, datos.NombreMateria, datos.NombreProfesor, datos.Calificacion };
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