using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatCursoModels
    {
        private string _IDCurso;

        public string IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private string _IDEspecialidad;

        public string IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }
        private List<CatEspecialidadModels> _tablaEspecialidadCmb;
        [Required(ErrorMessage = "La especialidad es un campo requerido")]
        [Display(Name = "Especialidad")]
        public List<CatEspecialidadModels> tablaEspecialidadCmb
        {
            get { return _tablaEspecialidadCmb; }
            set { _tablaEspecialidadCmb = value; }
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