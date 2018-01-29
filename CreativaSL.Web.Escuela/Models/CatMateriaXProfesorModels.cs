using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatMateriaXProfesorModels
    {
        private string _IDProfesor;

        public string IDProfesor
        {
            get { return _IDProfesor; }
            set { _IDProfesor = value; }
        }

        private string _IDModalidad;

        public string IDModalidad
        {
            get { return _IDModalidad; }
            set { _IDModalidad = value; }
        }


        private string _IDMateria;

        public string IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }
        private List<CatModalidadModels> _tablaModalidadCmb;
        [Required(ErrorMessage = "Modalidad es un campo requerido")]
        [Display(Name = "Modalidad")]
        public List<CatModalidadModels> tablaModalidadCmb
        {
            get { return _tablaModalidadCmb; }
            set { _tablaModalidadCmb = value; }
        }
        private List<CatMateriaXProfesorModels> _TablaMateriaCmb;
        [Required(ErrorMessage = "Materia es un campo requerido")]
        [Display(Name = "Materia")]
        public List<CatMateriaXProfesorModels> TablaMateriaCmb
        {
            get { return _TablaMateriaCmb; }
            set { _TablaMateriaCmb = value; }
        }

        private string _NombreM;

        public string NombreM
        {
            get { return _NombreM; }
            set { _NombreM = value; }
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
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}