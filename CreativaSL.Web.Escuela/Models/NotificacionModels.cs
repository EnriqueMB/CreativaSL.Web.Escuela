using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class NotificacionModels
    {
        private string _IDNotificacion;

        public string IDNotificacion
        {
            get { return _IDNotificacion; }
            set { _IDNotificacion = value; }
        }

        private string _cadena;
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "descripción")]
        [StringLength(350, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\[\]\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string cadena
        {
            get { return _cadena; }
            set { _cadena = value; }
        }
        private string _materia;

        public string Materia
        {
            get { return _materia; }
            set { _materia = value; }
        }

        private List<ParejaPalabra> _listListValues;

        public List<ParejaPalabra> ListValues
        {
            get { return _listListValues; }
            set { _listListValues = value; }
        }


        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private string _textoFinal;

        public string textoFinal
        {
            get { return _textoFinal; }
            set { _textoFinal = value; }
        }
        private DateTime _fecha = DateTime.Now ;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "nombre")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\-\s]*$", ErrorMessage = "Solo Letras y guión")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
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