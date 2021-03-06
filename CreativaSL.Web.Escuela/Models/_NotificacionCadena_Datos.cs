﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _NotificacionCadena_Datos
    {
        List<ParejaPalabra> ListValues = new List<ParejaPalabra>();

        public ReportesModels CadenaFinal(ReportesModels datos)
        {
            if (datos.id_tipo_notificacion == 110)
            {
                ObtenerListaStrings(IngresarDatosTablaEventos(datos));
            }
            else if (datos.id_tipo_notificacion == 111)
            {
                ObtenerListaStrings(IngresarDatosTablaExamen(datos));
            }
            else if (datos.id_tipo_notificacion == 112)
            {
                ObtenerListaStrings(IngresarDatosTablaTarea(datos));
            }
            else if (datos.id_tipo_notificacion == 113)
            {
                ObtenerListaStrings(IngresarDatosTablaAsistencia(datos));
            }

            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.notificacionFinal = r.Replace(datos.notificacionPlantilla, myEvaluator);
            return datos;
        }

        public DataTable IngresarDatosTablaAsistencia(ReportesModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaLista", typeof(DateTime));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));

                object[] par = { datos.nombreAlumno, datos.fechaEvento, datos.materia, datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IngresarDatosTablaTarea(ReportesModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("nombreTarea", typeof(string));
                _data.Columns.Add("FechaTarea", typeof(DateTime));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("Calificacion", typeof(float));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.nombreAlumno, datos.nombreEvento, datos.fechaEvento, datos.materia, datos.calificacion, datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IngresarDatosTablaExamen(ReportesModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("NombreExamen", typeof(string));
                _data.Columns.Add("FechaExamen", typeof(DateTime));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("Calificacion", typeof(float));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.nombreAlumno, datos.nombreEvento,datos.fechaEvento, datos.materia, datos.calificacion, datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IngresarDatosTablaEventos(ReportesModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaEvento", typeof(DateTime));
                _data.Columns.Add("NombreEvento", typeof(string));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.nombreAlumno, datos.fechaEvento, datos.nombreEvento, datos.materia, datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public NotificacionesProfesorModels CadenaFinal(NotificacionesProfesorModels datos)
        {
            if (datos.IDTipoNotificacion == 110) {
                ObtenerListaStrings(IngresarDatosTablaEventos(datos));
            }
            else if (datos.IDTipoNotificacion == 111)
            {
                ObtenerListaStrings(IngresarDatosTablaExamen(datos));
            }
            else if (datos.IDTipoNotificacion == 112) {
                ObtenerListaStrings(IngresarDatosTablaTarea(datos));
            }
            else if (datos.IDTipoNotificacion == 113)
            {
                ObtenerListaStrings(IngresarDatosTablaAsistencia(datos));
            }

            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
            string sRegex = @"\[\w+[a-zA-Z]\]";
            Regex r = new Regex(sRegex);
            datos.notificacionFinal = r.Replace(datos.notificacionPlantilla, myEvaluator);
            return datos;
        }

        public DataTable IngresarDatosTablaAsistencia(NotificacionesProfesorModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaLista", typeof(DateTime));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));

                object[] par = { datos.nombreAlumno,  datos.fechaEvento, datos.materia,datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IngresarDatosTablaTarea(NotificacionesProfesorModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("nombreTarea", typeof(string));
                _data.Columns.Add("FechaTarea", typeof(DateTime));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("Calificacion", typeof(float));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.nombreAlumno,datos.nombreEvento ,datos.fechaEvento, datos.materia,datos.calificacion,datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IngresarDatosTablaExamen(NotificacionesProfesorModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("NombreExamen", typeof(string));
                _data.Columns.Add("FechaExamen", typeof(DateTime));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("Calificacion", typeof(float));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.nombreAlumno, datos.nombreEvento, datos.fechaEvento, datos.materia,datos.calificacion,datos.profesor };
                _data.Rows.Add(par);

                return _data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IngresarDatosTablaEventos(NotificacionesProfesorModels datos)
        {
            try
            {
                DataTable _data = new DataTable();
                _data.Columns.Add("Nombre", typeof(string));
                _data.Columns.Add("FechaEvento", typeof(DateTime));
                _data.Columns.Add("NombreEvento", typeof(string));
                _data.Columns.Add("Materia", typeof(string));
                _data.Columns.Add("NombreProfesor", typeof(string));
                object[] par = { datos.nombreAlumno, datos.fechaEvento, datos.nombreEvento,datos.materia,datos.profesor };
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