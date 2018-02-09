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