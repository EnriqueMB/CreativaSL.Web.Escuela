using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAlumnoModels
    {
        private string _IDPersona;

        public string IDPersona
        {
            get { return _IDPersona; }
            set { _IDPersona = value; }
        }

        private string _NumControl;
        [Required(ErrorMessage = "El número de control es obligatorio")]
        public string NumControl
        {
            get { return _NumControl; }
            set { _NumControl = value; }
        }

        private string _Observaciones;
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        [Display(Name = "observaciones")]
        [StringLength(1000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private int _IDTipoCelular;

        public int IDTipoCelular
        {
            get { return _IDTipoCelular; }
            set { _IDTipoCelular = value; }
        }

        private string _Token;

        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
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