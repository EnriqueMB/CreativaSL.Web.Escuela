using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CreativaSL.Web.Escuela.Models
{
    public class ListaAsistenciaModels
    {
        private string _IDLista;

        public string IDLista
        {
            get { return _IDLista; }
            set { _IDLista = value; }
        }

        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private DateTime _FechaLista;

        public DateTime FechaLista
        {
            get { return _FechaLista; }
            set { _FechaLista = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
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