using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class EspecialidadModels
    {
        private string _id_especialidad;

        public string id_especialidad 
        {
            get { return _id_especialidad; }
            set { _id_especialidad = value; }
        }
        public string id_modalidad { get; set; }
      
        private string _descripcion;
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        [StringLength(180, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
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