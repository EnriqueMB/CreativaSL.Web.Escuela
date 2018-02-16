using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXAsistenciaModels
    {
        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private int _NumeroAlumnos;

        public int NumeroAlumnos
        {
            get { return _NumeroAlumnos; }
            set { _NumeroAlumnos = value; }
        }

        private string _IDLista;

        public string IDLista
        {
            get { return _IDLista; }
            set { _IDLista = value; }
        }

        private string _IDAlumno;

        public string IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private bool _Asistencia;

        public bool Asistencia
        {
            get { return _Asistencia; }
            set { _Asistencia = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private DataTable _TablaNotificaciones;

        public DataTable TablaNotificaciones
        {
            get { return _TablaNotificaciones; }
            set { _TablaNotificaciones = value; }
        }

        private DateTime _FechaLista;

        public DateTime FechaLista
        {
            get { return _FechaLista; }
            set { _FechaLista = value; }
        }

        private DataTable _tablaAlumnoXAsistencia;

        public DataTable tablaAlumnoXAsistencia
        {
            get { return _tablaAlumnoXAsistencia; }
            set { _tablaAlumnoXAsistencia = value; }
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

        private bool _EnviarTarea;

        public bool EnviarTarea
        {
            get { return _EnviarTarea; }
            set { _EnviarTarea = value; }
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

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private DataTable _TablaCadenaNotificacion;

        public DataTable TablaCadenaNotificacion
        {
            get { return _TablaCadenaNotificacion; }
            set { _TablaCadenaNotificacion = value; }
        }

        private DataTable _TablaNotificacion;

        public DataTable TablaNotificacion
        {
            get { return _TablaNotificacion; }
            set { _TablaNotificacion = value; }
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