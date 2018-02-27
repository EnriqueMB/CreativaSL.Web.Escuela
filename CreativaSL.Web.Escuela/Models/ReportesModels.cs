using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class ReportesModels
    {
        private List<ReportesModels> _resultado110;

        public List<ReportesModels> resultado110
        {
            get { return _resultado110; }
            set { _resultado110 = value; }
        }
        private List<ReportesModels> _resultado111;

        public List<ReportesModels> resultado111
        {
            get { return _resultado111; }
            set { _resultado111 = value; }
        }
        private List<ReportesModels> _resultado112;

        public List<ReportesModels> resultado112
        {
            get { return _resultado112; }
            set { _resultado112 = value; }
        }
        private List<ReportesModels> _resultado113;

        public List<ReportesModels> resultado113
        {
            get { return _resultado113; }
            set { _resultado113 = value; }
        }

        private string _NumControl;

        public string NumControl
        {
            get { return _NumControl; }
            set { _NumControl = value; }
        }
        private string _id_evento;

        public string id_evento
        {
            get { return _id_evento; }
            set { _id_evento = value; }
        }
        private string _NombreAlumno;

        public string NombreAlumno
        {
            get { return _NombreAlumno; }
            set { _NombreAlumno = value; }
        }
        private float _calificacion;

        public float calificacion
        {
            get { return _calificacion; }
            set { _calificacion = value; }
        }
        private List<ReportesModels> _ListaMenu;

        public List<ReportesModels> ListaMenu
        {
            get { return _ListaMenu; }
            set { _ListaMenu = value; }
        }
        private List<ReportesModels> _ListEventos;

        public List<ReportesModels> ListEventos
        {
            get { return _ListEventos; }
            set { _ListEventos = value; }
        }

        private List<ReportesModels> _ListExamen;

        public List<ReportesModels> ListExamen
        {
            get { return _ListExamen; }
            set { _ListExamen = value; }
        }

        private List<ReportesModels> _ListTareas;

        public List<ReportesModels> ListTareas  
        {
            get { return _ListTareas; }
            set { _ListTareas = value; }
        }
        private List<ReportesModels> _ListAsistencia;

        public List<ReportesModels> ListAsistencia
        {
            get { return _ListAsistencia; }
            set { _ListAsistencia = value; }
        }
        private string   _asistencia;

        public string asistencia
        {
            get { return _asistencia; }
            set { _asistencia = value; }
        }
        private string _id_tarea;

        public string id_tarea
        {
            get { return _id_tarea; }
            set { _id_tarea = value; }
        }
        private string _id_examen;
        private string _id_lista;

        public string id_lista
        {
            get { return _id_lista; }
            set { _id_lista = value; }
        }

        public string id_examen
        {
            get { return _id_examen; }
            set { _id_examen = value; }
        }

        private int _resultado;

        public int resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }
        private string _NombreMateria;

        public string NombreMateria
        {
            get { return _NombreMateria; }
            set { _NombreMateria = value; }
        }
        private string _NombreMaestro;

        public string NombreMaestro
        {
            get { return _NombreMaestro; }
            set { _NombreMaestro = value; }
        }
        private string _NombreLista;

        public string NombreLista
        {
            get { return _NombreLista; }
            set { _NombreLista = value; }
        }
        private List<ReportesModels> _ListaReportes;

        public List<ReportesModels> ListaReportes
        {
            get { return _ListaReportes; }
            set { _ListaReportes = value; }
        }
        private string _id_curso;

        public string id_curso
        {
            get { return _id_curso; }
            set { _id_curso = value; }
        }
        private string _id_grupo;

        public string id_grupo
        {
            get { return _id_grupo; }
            set { _id_grupo = value; }
        }
        private DateTime _fechaReporte;

        public DateTime fechaReporte
        {
            get { return _fechaReporte; }
            set { _fechaReporte = value; }
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
        private string _ciclo;

        public string ciclo
        {
            get { return _ciclo; }
            set { _ciclo = value; }
        }
        private string _curso;

        public string curso
        {
            get { return _curso; }
            set { _curso = value; }
        }
        private string _id_profesor;

        public string id_profesor
        {
            get { return _id_profesor; }
            set { _id_profesor = value; }
        }

        private List<CatCatedraticoModels> _listaCatedraticos;

        public List<CatCatedraticoModels> listaCatedraticos
        {
            get { return _listaCatedraticos; }
            set { _listaCatedraticos = value; }
        }
        private List<CatGrupoModels> _listaGrupo;

        public List<CatGrupoModels> listaGrupo
        {
            get { return _listaGrupo; }
            set { _listaGrupo = value; }
        }
        private List<CatTipoNotificacionModels> _listaTipoNotificacion;

        public List<CatTipoNotificacionModels> listaTipoNotificacion
        {
            get { return _listaTipoNotificacion; }
            set { _listaTipoNotificacion = value; }
        }
        private List<CatMateriaModels> _listaMateria;

        public List<CatMateriaModels> listaMateria
        {
            get { return _listaMateria; }
            set { _listaMateria = value; }
        }
        private List<CatPlanEstudioModels> _listaPlanEstudio;
        [Required(ErrorMessage = "El Plan de estudio es obligatorio")]
        [Display(Name = "Plan de Estudio")]
        public List<CatPlanEstudioModels> listaPlanEstudio
        {
            get { return _listaPlanEstudio; }
            set { _listaPlanEstudio = value; }
        }
        private List<CatCicloEscolarModels> _listaCicloEscolar;
        [Required(ErrorMessage = "El ciclo escolar es obligatorio")]
        [Display(Name = "Ciclo Escolar")]
        public List<CatCicloEscolarModels> listaCicloEscolar
        {
            get { return _listaCicloEscolar; }
            set { _listaCicloEscolar = value; }
        }
        private List<CatCursoModels> _listaCursos;
        [Required(ErrorMessage = "El Curso es obligatorio")]
        [Display(Name = "Curso")]
        public List<CatCursoModels> listaCursos
        {
            get { return _listaCursos; }
            set { _listaCursos = value; }
        }
        private List<CatModalidadModels> _listaModalidad;
        [Required(ErrorMessage = "La Modalidad es obligatorio")]
        [Display(Name = "Modalidad")]
        public List<CatModalidadModels> listaModalidad
        {
            get { return _listaModalidad; }
            set { _listaModalidad = value; }
        }
        private List<CatEspecialidadModels> _listaEspecialidad;
        [Required(ErrorMessage = "La modalidad es obligatorio")]
        [Display(Name = "Modalidad")]
        public List<CatEspecialidadModels> listaEspecialidad
        {
            get { return _listaEspecialidad; }
            set { _listaEspecialidad = value; }
        }
        private List<CatGrupoModels> _listaGrupos;
        [Required(ErrorMessage = "El Grupo es obligatorio")]
        [Display(Name = "Grupo")]
        public List<CatGrupoModels> listaGrupos
        {
            get { return _listaGrupos; }
            set { _listaGrupos = value; }
        }
        private string _id_alumno;

        public string id_alumno
        {
            get { return _id_alumno; }
            set { _id_alumno = value; }
        }

        private string _id_registro;

        public string id_registro
        {
            get { return _id_registro; }
            set { _id_registro = value; }
        }
        private int _id_tipo_notificacion;

        public int id_tipo_notificacion
        {
            get { return _id_tipo_notificacion; }
            set { _id_tipo_notificacion = value; }
        }

        private DateTime _fecha = DateTime.Now;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
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
        private DataTable _TablaNotificacionXTipo;

        public DataTable TablaNotificacionXTipo
        {
            get { return _TablaNotificacionXTipo; }
            set { _TablaNotificacionXTipo = value; }
        }

        //NOTIFICACION 

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
        
        private string _materia;

        public string materia
        {
            get { return _materia; }
            set { _materia = value; }
        }
        private string _profesor;

        public string profesor
        {
            get { return _profesor; }
            set { _profesor = value; }
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
        private string  _resumen;

        public string  resumen
        {
            get { return _resumen; }
            set { _resumen = value; }
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