using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAlumnosXGrupoModels
    {
        private string _IDGrupo;

        public string IDGrupo
        {
            get { return _IDGrupo; }
            set { _IDGrupo = value; }
        }

        private string _IDAlumno;

        public string IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private List<CatAlumnoModels> _tablaAlumnos;
        [Required(ErrorMessage = "Seleccione el alumno a inscribir")]
        [Display(Name = "Alumno")]
        public List<CatAlumnoModels> tablaAlumnos
        {
            get { return _tablaAlumnos; }
            set { _tablaAlumnos = value; }
        }
        
        #region Datos de control
        public int Resultado { get; set; }
        public bool Completado { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}