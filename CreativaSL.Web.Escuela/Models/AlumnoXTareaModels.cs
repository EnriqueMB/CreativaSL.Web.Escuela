using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXTareaModels
    {
        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private int _NumeroAlumno;

        public int NumeroAlumno
        {
            get { return _NumeroAlumno; }
            set { _NumeroAlumno = value; }
        }

        private string _IDTarea;

        public string IDTarea
        {
            get { return _IDTarea; }
            set { _IDTarea = value; }
        }

        private string _IDAlumno;

        public string IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private float _Calificacion;

        public float Calificacion
        {
            get { return _Calificacion; }
            set { _Calificacion = value; }
        }

        private DataTable _TablaAlumnoTarea;

        public DataTable TablaAlumnoTarea
        {
            get { return _TablaAlumnoTarea; }
            set { _TablaAlumnoTarea = value; }
        }

        private DataTable _TablaNotificacion;

        public DataTable TablaNotificacion
        {
            get { return _TablaNotificacion; }
            set { _TablaNotificacion = value; }
        }

        
        private DataTable _TablaCadenaNotificacion;

        public DataTable TablaCadenaNotificacion
        {
            get { return _TablaCadenaNotificacion; }
            set { _TablaCadenaNotificacion = value; }
        }
        
        private DateTime _FechaTarea;

        public DateTime FechaTarea
        {
            get { return _FechaTarea; }
            set { _FechaTarea = value; }
        }

        private string _NombreTarea;

        public string NombreTarea
        {
            get { return _NombreTarea; }
            set { _NombreTarea = value; }
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