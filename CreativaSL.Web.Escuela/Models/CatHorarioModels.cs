using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatHorarioModels
    {
        private string _IDHorario;

        public string IDHorario
        {
            get { return _IDHorario; }
            set { _IDHorario = value; }
        }


        private TimeSpan _HoraInicio = new TimeSpan(12, 00, 0);
        [Required(ErrorMessage = "La Hora de Inicio es obligatorio")]
        [Display(Name = "Hora de Inicio")]
        public TimeSpan HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private TimeSpan _HoraFin = new TimeSpan(12, 30, 0);
        [Required(ErrorMessage = "La Hora fin es obligatorio")]
        [Display(Name = "Hora fin")]
        public TimeSpan HoraFin
        {
            get { return _HoraFin; }
            set { _HoraFin = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
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