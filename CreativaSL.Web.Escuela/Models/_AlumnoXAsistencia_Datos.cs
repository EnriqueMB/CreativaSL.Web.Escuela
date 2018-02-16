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
                DataSet ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_AsistenciaPorAlumno_PROF",
                new SqlParameter("@IDAsignatura", datos.IDAsignatura),
                new SqlParameter("@IDLista", datos.IDLista),
                new SqlParameter("@tablaAlumnoXAsistencia", datos.tablaAlumnoXAsistencia),
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
                                datos.EnviarTarea = !DTR.IsDBNull(DTR.GetOrdinal("asistencia")) ? DTR.GetBoolean(DTR.GetOrdinal("asistencia")) : false;
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
        public int ActualizarTexto(ref AlumnoXAsistenciaModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_ActualizarNotificacionesAsistencia",
                new SqlParameter("@IDLista", datos.IDLista),
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
        public AlumnoXAsistenciaModels CadenaFinal(AlumnoXAsistenciaModels datos)
        {
            ObtenerListaStrings(IngresarDatosTabla(datos));

            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.CadenaFinal = r.Replace(datos.Cadena, myEvaluator);
            return datos;
        }

        public DataTable IngresarDatosTabla(AlumnoXAsistenciaModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaLista", typeof(DateTime));
                _data.Columns.Add("NombreMateria", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.Nombre, datos.FechaLista, datos.NombreMateria, datos.NombreProfesor };
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