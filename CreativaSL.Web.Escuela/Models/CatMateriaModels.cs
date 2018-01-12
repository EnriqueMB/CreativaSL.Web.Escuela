using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatMateriaModels
    {
        private string _id_materia;

        public string id_materia
        {
            get { return _id_materia; }
            set { _id_materia = value; }
        }
        private int _id_tipoMateria;

        public int id_tipoMateria
        {
            get { return _id_tipoMateria; }
            set { _id_tipoMateria = value; }
        }
        private string _id_curso;

        public string id_curso
        {
            get { return _id_curso; }
            set { _id_curso = value; }
        }
        private string _clave;
        [Required(ErrorMessage = "La clave es obligatoria")]
        [Display(Name = "clave")]
        [StringLength(20, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        private string _nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private int _horaSemana;

        public int horaSemana
        {
            get { return _horaSemana; }
            set { _horaSemana = value; }
        }

        private List<CatCursoModels> _tablaCursoCmb;
        [Required(ErrorMessage = "La especialidad es un campo requerido")]
        [Display(Name = "Especialidad")]
        public List<CatCursoModels> tablaCursoCmb
        {
            get { return _tablaCursoCmb; }
            set { _tablaCursoCmb = value; }
        }


        private List<CatTipoMateriaModels> _tablaTipoMateriaCmb;
        [Required(ErrorMessage = "La especialidad es un campo requerido")]
        [Display(Name = "Especialidad")]
        public List<CatTipoMateriaModels> tablaTipoMateriaCmb
        {
            get { return _tablaTipoMateriaCmb; }
            set { _tablaTipoMateriaCmb = value; }
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