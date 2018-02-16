using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatPlantillaTipoNotificacionModels
    {
        private string _id_plantilla;

        public string id_plantilla
        {
            get { return _id_plantilla; }
            set { _id_plantilla = value; }
        }
        private string _titulo;
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        [Display(Name = "Observaciones")]
        [StringLength(80, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
       // [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        private string _texto;
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        [Display(Name = "Observaciones")]
        [StringLength(1000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }
        private string _resumen;
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        [Display(Name = "Observaciones")]
        [StringLength(140, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        public string resumen
        {
            get { return _resumen; }
            set { _resumen = value; }
        }

        private int _id_tipoNotificacion;

        public int id_tipoNotificacion
        {
            get { return _id_tipoNotificacion; }
            set { _id_tipoNotificacion = value; }
        }
        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private List<CatTipoNotificacionModels> _listaTipoNotificacion;

        public List<CatTipoNotificacionModels> listaTipoNotificacion
        {
            get { return _listaTipoNotificacion; }
            set { _listaTipoNotificacion = value; }
        }
        private List<CatVariablesNotificacionModels> _listaVariableNotificacion;

        public List<CatVariablesNotificacionModels> listaVariableNotificacion
        {
            get { return _listaVariableNotificacion; }
            set { _listaVariableNotificacion = value; }
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