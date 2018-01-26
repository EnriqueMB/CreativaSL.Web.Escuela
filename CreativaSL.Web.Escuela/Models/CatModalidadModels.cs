using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatModalidadModels
    {
        private string _IDModalidad;

        public string IDModalidad
        {
            get { return _IDModalidad; }
            set { _IDModalidad = value; }
        }

        private int _IDPlanEstudio;

        public int IDPlanEstudio
        {
            get { return _IDPlanEstudio; }
            set { _IDPlanEstudio = value; }
        }

        private string _Descripcion;
        [Required(ErrorMessage = "La descripción es obligatorio")]
        [Display(Name = "descripción")]
        [StringLength(180, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private List<CatPlanEstudioModels> _TablaPlanEstudioCmb;
        [Required(ErrorMessage = "El plan de estudio es obligatorio")]
        [Display(Name = "Plan de Estudio")]
        public List<CatPlanEstudioModels> TablaPlanEstudioCmb
        {
            get { return _TablaPlanEstudioCmb; }
            set { _TablaPlanEstudioCmb = value; }
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