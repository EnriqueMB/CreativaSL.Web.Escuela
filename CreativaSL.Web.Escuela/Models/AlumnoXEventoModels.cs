using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXEventoModels
    {
        private string _IDEvento;

        public string IDEvento
        {
            get { return _IDEvento; }
            set { _IDEvento = value; }
        }
        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }


        private string _IDAlumno;

        public string IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private DataTable _TablaXEvento;

        public DataTable TablaXEvento
        {
            get { return _TablaXEvento; }
            set { _TablaXEvento = value; }
        }

        private DataTable _TablaNotificaciones;

        public DataTable TablaNotificaciones
        {
            get { return _TablaNotificaciones; }
            set { _TablaNotificaciones = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private DateTime _FechaEvento;

        public DateTime FechaEvento
        {
            get { return _FechaEvento; }
            set { _FechaEvento = value; }
        }

        private string _NombreEvento;

        public string NombreEvento
        {
            get { return _NombreEvento; }
            set { _NombreEvento = value; }
        }

        private string _Cadena;

        public string Cadena
        {
            get { return _Cadena; }
            set { _Cadena = value; }
        }

        private string _CadenaFinal;

        public string CadenaFinal
        {
            get { return _CadenaFinal; }
            set { _CadenaFinal = value; }
        }

        private string _IDNofificacionDetalle;

        public string IDNotificacionDetalle
        {
            get { return _IDNofificacionDetalle; }
            set { _IDNofificacionDetalle = value; }
        }

        private DataTable _TablaCadenaNotificacion;

        public DataTable TablaCadenaNotificacion
        {
            get { return _TablaCadenaNotificacion; }
            set { _TablaCadenaNotificacion = value; }
        }

        private string _NombreMateria;

        public string NombreMateria
        {
            get { return _NombreMateria; }
            set { _NombreMateria = value; }
        }

        private string _Resumen;

        public string Resumen
        {
            get { return _Resumen; }
            set { _Resumen = value; }
        }

        private string _NombreProfesor;

        public string NombreProfesor
        {
            get { return _NombreProfesor; }
            set { _NombreProfesor = value; }
        }


        #region Datos de control
        public int Resultado { get; set; }
        public bool Completado { get; set; }
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}