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