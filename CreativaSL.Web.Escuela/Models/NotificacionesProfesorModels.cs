using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class NotificacionesProfesorModels
    {

        private bool _tutores;

        public bool tutores
        {
            get { return _tutores; }
            set { _tutores = value; }
        }
        private string _id_registro;

        public string id_registro
        {
            get { return _id_registro; }
            set { _id_registro = value; }
        }


        private string _IDNotificacionGeneral;

        public string IDNotificacionGeneral
        {
            get { return _IDNotificacionGeneral; }
            set { _IDNotificacionGeneral = value; }
        }
        private int _IDTipoNotificacion;

        public int IDTipoNotificacion
        {
            get { return _IDTipoNotificacion; }
            set { _IDTipoNotificacion = value; }
        }
        private int _numAlumnos;

        public int numAlumnos
        {
            get { return _numAlumnos; }
            set { _numAlumnos = value; }
        }

        private string _ciclo;

        public string ciclo
        {
            get { return _ciclo; }
            set { _ciclo = value; }
        }
        private int _idplanEstudio;

        public int idplanEstudio
        {
            get { return _idplanEstudio; }
            set { _idplanEstudio = value; }
        }
        private string _IDModalidad;

        public string IDModalidad
        {
            get { return _IDModalidad; }
            set { _IDModalidad = value; }
        }
        private string _IDEspecialidad;

        public string IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }
        private string _id_profesor;

        public string id_profesor
        {
            get { return _id_profesor; }
            set { _id_profesor = value; }
        }

        private string _curso;

        public string curso
        {
            get { return _curso; }
            set { _curso = value; }
        }
        private string _grupo;

        public string grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        private DataTable _TablaAlumnos;

        public DataTable TablaAlumnos
        {
            get { return _TablaAlumnos; }
            set { _TablaAlumnos = value; }
        }
        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
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
        private List<CatCicloEscolarModels> _TablaCicloEscolarCmb;
        [Required(ErrorMessage = "El Ciclo es obligatorio")]
        [Display(Name = "Ciclo")]
        public List<CatCicloEscolarModels> TablaCicloEscolarCmb
        {
            get { return _TablaCicloEscolarCmb; }
            set { _TablaCicloEscolarCmb = value; }
        }
        private List<CatTipoNotificacionModels> _TablaTipoNotificacionCmb;
        [Required(ErrorMessage = "El tipo de notificación es obligatorio")]
        [Display(Name = "Tipo de notificación")]
        public List<CatTipoNotificacionModels> TablaTipoNotificacionCmb
        {
            get { return _TablaTipoNotificacionCmb; }
            set { _TablaTipoNotificacionCmb = value; }
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
        private List<CatGrupoModels> _TablaGrupoCmb;
        [Required(ErrorMessage = "El Grupo es obligatorio")]
        [Display(Name = "Grupo")]
        public List<CatGrupoModels> TablaGrupoCmb
        {
            get { return _TablaGrupoCmb; }
            set { _TablaGrupoCmb = value; }
        }
        private List<CatCatedraticoModels> _TablaProfesorCmb;
        [Required(ErrorMessage = "El Grupo es obligatorio")]
        [Display(Name = "Grupo")]
        public List<CatCatedraticoModels> TablaProfesorCmb
        {
            get { return _TablaProfesorCmb; }
            set { _TablaProfesorCmb = value; }
        }


        private List<CatAlumnoModels> _TablaAlumnosXGrupo;
        [Required(ErrorMessage = "El Alumno es obligatorio")]
        [Display(Name = "Alumno")]
        public List<CatAlumnoModels> TablaAlumnosXGrupo
        {
            get { return _TablaAlumnosXGrupo; }
            set { _TablaAlumnosXGrupo = value; }
        }

        private string _titulo;
        [Required(ErrorMessage = "El título de la notificación es obligatorio ")]
        [Display(Name = "Título")]
        [StringLength(80, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        private string _texto;
        [Required(ErrorMessage = "La descripción  de la notificación es obligatoria ")]
        [Display(Name = "Descripción")]
        [StringLength(1000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }


        private string _resumen;
        [Required(ErrorMessage = "El resumen  de la notificación es obligatorio ")]
        [Display(Name = "resumen")]
        [StringLength(140, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        public string resumen
        {
            get { return _resumen; }
            set { _resumen = value; }
        }


        private DataTable _TablaNotificacionXTipo;

        public DataTable TablaNotificacionXTipo
        {
            get { return _TablaNotificacionXTipo; }
            set { _TablaNotificacionXTipo = value; }
        }

        //datos de la notificacion 
        private string _nombreAlumno;

        public string nombreAlumno
        {
            get { return _nombreAlumno; }
            set { _nombreAlumno = value; }
        }
        private DateTime _fechaEvento;

        public DateTime fechaEvento
        {
            get { return _fechaEvento; }
            set { _fechaEvento = value; }
        }
        private string _nombreEvento;

        public string nombreEvento
        {
            get { return _nombreEvento; }
            set { _nombreEvento = value; }
        }
        private string _notificacionFinal;

        public string notificacionFinal
        {
            get { return _notificacionFinal; }
            set { _notificacionFinal = value; }
        }
        private string _notificacionPlantilla;

        public string notificacionPlantilla
        {
            get { return _notificacionPlantilla; }
            set { _notificacionPlantilla = value; }
        }
        private float _calificacion;

        public float calificacion
        {
            get { return _calificacion; }
            set { _calificacion = value; }
        }
        private string _materia;

        public string materia
        {
            get { return _materia; }
            set { _materia = value; }
        }

        private string _nombreTarea;

        public string nombreTarea
        {
            get { return _nombreTarea; }
            set { _nombreTarea = value; }
        }
        private DateTime _fechaTarea;

        public DateTime fechaTarea
        {
            get { return _fechaTarea; }
            set { _fechaTarea = value; }
        }
        //lista filtros


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