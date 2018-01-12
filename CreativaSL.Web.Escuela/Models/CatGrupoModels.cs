using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatGrupoModels
    {

        private string _IDGrupo;

        public string IDGrupo
        {
            get { return _IDGrupo; }
            set { _IDGrupo = value; }
        }

        private string _Clave;

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "nombre")]
        [StringLength(180, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _IDCiclo;

        public string IDCiclo
        {
            get { return _IDCiclo; }
            set { _IDCiclo = value; }
        }

        private string _IDEspecialidad;

        public string IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }

        private string _IDCurso;

        public string IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private int _IDPlanEstudio;

        public int IDPlanEstudio
        {
            get { return _IDPlanEstudio; }
            set { _IDPlanEstudio = value; }
        }

        private string _IDModalidad;

        public string IDModalidad
        {
            get { return _IDModalidad; }
            set { _IDModalidad = value; }
        }


        private List<CatCicloEscolarModels> _TablaCicloEscolarCmb;
        [Required(ErrorMessage = "El ciclo escolar es obligatorio")]
        [Display(Name = "Ciclo Escolar")]
        public List<CatCicloEscolarModels> TablaCicloEscolarCmb
        {
            get { return _TablaCicloEscolarCmb; }
            set { _TablaCicloEscolarCmb = value; }
        }

        private List<CatEspecialidadModels> _TablaEspecialidadCmb;
        [Required(ErrorMessage = "La especialidad es obligatorio")]
        [Display(Name = "Especialidad")]
        public List<CatEspecialidadModels> TablaEspecialidadCmb
        {
            get { return _TablaEspecialidadCmb; }
            set { _TablaEspecialidadCmb = value; }
        }

        private List<CatCursoModels> _TablaCursosCmb;
        [Required(ErrorMessage = "El curso es obligatorio")]
        [Display(Name = "Curso")]
        public List<CatCursoModels> TablaCursosCmb
        {
            get { return _TablaCursosCmb; }
            set { _TablaCursosCmb = value; }
        }

        private List<CatPlanEstudioModels> _TablaPlanEstudioCmb;
        [Required(ErrorMessage = "El plan de estudio es obligatorio")]
        [Display(Name = "Plan Estudio")]
        public List<CatPlanEstudioModels> TablaPlanEstudioCmb
        {
            get { return _TablaPlanEstudioCmb; }
            set { _TablaPlanEstudioCmb = value; }
        }

        private List<CatModalidadModels> _TablaModalidadCmb;
        [Required(ErrorMessage = "La modalidad es obligatorio")]
        [Display(Name = "Modalidad")]
        public List<CatModalidadModels> TablaModalidadCmb
        {
            get { return _TablaModalidadCmb; }
            set { _TablaModalidadCmb = value; }
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