using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class TareasModels
    {
        private string _IDTarea;

        public string IDTarea
        {
            get { return _IDTarea; }
            set { _IDTarea = value; }
        }

        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private string _NombreTarea;
        [Required(ErrorMessage = "El Nombre de la Tarea es obligatorio")]
        [Display(Name = "Nombre Tarea")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\¿\?\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras")]
        public string NombreTarea
        {
            get { return _NombreTarea; }
            set { _NombreTarea = value; }
        }

        private string _Descripcion;
        [Required(ErrorMessage = "El Descripción es obligatorio")]
        [Display(Name = "Descripción")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\¿\?\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DateTime _FechaEntrega = DateTime.Now;
        [Required(ErrorMessage = "La Fecha de Entrega es obligatorio")]
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntraga
        {
            get { return _FechaEntrega; }
            set { _FechaEntrega = value; }
        }

        private DateTime _FechaEnvio = DateTime.Now;
        [Required(ErrorMessage = "La Fecha de Envio es obligatorio")]
        [Display(Name = "Fecha Inscripción")]
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