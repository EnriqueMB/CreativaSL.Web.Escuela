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
        
        public int ActualizarTexto(ref AlumnoXEventoModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_ActualizarNotificaciones",
                new SqlParameter("@IDEvento", datos.IDEvento),
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
        public AlumnoXEventoModels CadenaFinal(AlumnoXEventoModels datos)
        {
            ObtenerListaStrings(IngresarDatosTabla(datos));

            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.CadenaFinal = r.Replace(datos.Cadena, myEvaluator);
            return datos;
        }

        public DataTable IngresarDatosTabla(AlumnoXEventoModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaEvento", typeof(DateTime));
                _data.Columns.Add("NombreEvento", typeof(string));
                _data.Columns.Add("NombreMateria", typeof(string));
                object[] par = { datos.Nombre, datos.FechaEvento, datos.NombreEvento, datos.NombreMateria };
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