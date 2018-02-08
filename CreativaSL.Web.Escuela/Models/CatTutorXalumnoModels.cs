using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatTutorXalumnoModels
    {
        private string _IDAlumno;

        public string IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private string _IDTutor;

        public string IDTutor
        {
            get { return _IDTutor; }
            set { _IDTutor = value; }
        }

        private DataTable _TablaTutor;

        public DataTable TablaTutor
        {
            get { return _TablaTutor; }
            set { _TablaTutor = value; }
        }

        private List<CatTutorModels> _TablaTutorCmb;
        [Required(ErrorMessage = "Tutor es obligatorio")]
        [Display(Name = "Tutor")]
        public List<CatTutorModels> TablaTurorCmb
        {
            get { return _TablaTutorCmb; }
            set { _TablaTutorCmb = value; }
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