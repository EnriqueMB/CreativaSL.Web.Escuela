using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _Notificacion_Datos
    {
        List<ParejaPalabra> ListValues = new List<ParejaPalabra>();
        public NotificacionModels CadenaFinal(NotificacionModels datos) {
            ObtenerListaStrings(IngresarDatosTabla(datos));
            
            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.textoFinal =  r.Replace(datos.cadena, myEvaluator); 
            return datos;
        }

        public DataTable IngresarDatosTabla(NotificacionModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("nombre", typeof(string));
                _data.Columns.Add("fecha", typeof(DateTime));
                _data.Columns.Add("materia", typeof(string));
                object[] par = { datos.nombre, datos.fecha,datos.Materia };
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