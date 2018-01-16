using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CreativaSL.Web.Escuela.Models
{
    public class AsignaturaModels
    {
        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private string _IDCiclo;

        public string IDCiclo
        {
            get { return _IDCiclo; }
            set { _IDCiclo = value; }
        }

        private string _IDMateria;

        public string IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        private string _IDHorario;

        public string IDHorario
        {
            get { return _IDHorario; }
            set { _IDHorario = value; }
        }

        private string _IDProfesor;

        public string IDProfesor
        {
            get { return _IDProfesor; }
            set { _IDProfesor = value; }
        }

        private string _IDAula;

        public string IDAula
        {
            get { return _IDAula; }
            set { _IDAula = value; }
        }
        private string _IDGrupo;

        public string IDGrupo
        {
            get { return _IDGrupo; }
            set { _IDGrupo = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private List<CatCicloEscolarModels> _TablaCicloEscolarCmb;
        [Required(ErrorMessage = "El ciclo escolar es obligatorio")]
        [Display(Name = "Ciclo Escolar")]
        public List<CatCicloEscolarModels> TablaCicloEscolarCmb
        {
            get { return _TablaCicloEscolarCmb; }
            set { _TablaCicloEscolarCmb = value; }
        }

        private List<CatGrupoModels> _TablaGrupoCmb;
        [Required(ErrorMessage = "El grupo es obligatorio")]
        [Display(Name = "Grupo Escolar")]
        public List<CatGrupoModels> TablaGrupoCmb
        {
            get { return _TablaGrupoCmb; }
            set { _TablaGrupoCmb = value; }
        }

        private List<CatMateriaModels> _TablaMateriaCmb;
        [Required(ErrorMessage = "La materia es obligatorio")]
        [Display(Name = "Materia")]
        public List<CatMateriaModels> TablaMateriaCmb
        {
            get { return _TablaMateriaCmb; }
            set { _TablaMateriaCmb = value; }
        }

        private List<CatHorarioModels> _TablaHorarioCmb;
        [Required(ErrorMessage = "El Horario es obligatorio")]
        [Display(Name = "Horario")]
        public List<CatHorarioModels> TablaHorarioCmb
        {
            get { return _TablaHorarioCmb; }
            set { _TablaHorarioCmb = value; }
        }

        private List<CatAulaModels> _TablaAulaCmb;
        [Required(ErrorMessage = "El Aula es obligatorio")]
        [Display(Name = "Aula")]
        public List<CatAulaModels> TablaAulaCmb
        {
            get { return _TablaAulaCmb; }
            set { _TablaAulaCmb = value; }
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