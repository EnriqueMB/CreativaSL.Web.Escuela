using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatEspecialidadModels
    {
        private string _id_especialidad;

        public string id_especialidad 
        {
            get { return _id_especialidad; }
            set { _id_especialidad = value; }
        }

        private string _id_modalidad;

        public string id_modalidad
        {
            get { return _id_modalidad; }
            set { _id_modalidad = value; }
        }


        private List<CatModalidadModels> _tablaModalidadCmb;
        [Required(ErrorMessage = "Modalidad es un campo requerido")]
        [Display(Name = "Modalidad")]
        public List<CatModalidadModels> tablaModalidadCmb
        {
            get { return _tablaModalidadCmb; }
            set { _tablaModalidadCmb = value; }
        }



        private string _descripcion;
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        [StringLength(180, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private string _abreviatura;
        [Required(ErrorMessage = "La abreviatura es obligatoria")]
        [Display(Name = "nombre")]
        [StringLength(5, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\-\s]*$", ErrorMessage = "Solo Letras y guión")]
        public string abreviatura
        {
            get { return _abreviatura; }
            set { _abreviatura = value; }
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