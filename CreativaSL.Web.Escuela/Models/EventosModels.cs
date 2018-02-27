using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CreativaSL.Web.Escuela.Models
{
    public class EventosModels
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

        private string _NombreEvento;
        [Required(ErrorMessage = "El nombre del evento es obligatorio")]
        [Display(Name = "Nombre del evento")]
        [StringLength(70, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string NombreEvento
        {
            get { return _NombreEvento; }
            set { _NombreEvento = value; }
        }
        private string _Descripcion;
        [Required(ErrorMessage = "La descripción es obligatorio")]
        [Display(Name = "Descripción")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DateTime _FechaEvento = DateTime.Now;
        [Required(ErrorMessage = "La fecha del evento es obligatorio")]
        [Display(Name = "Fecha del evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEvento
        {
            get { return _FechaEvento; }
            set { _FechaEvento = value; }
        }

        private DateTime _FechaEnvio = DateTime.Now;
        [Required(ErrorMessage = "La fecha de envio es obligatorio")]
        [Display(Name = "Fecha envio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEnvio
        {
            get { return _FechaEnvio; }
            set { _FechaEnvio = value; }
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