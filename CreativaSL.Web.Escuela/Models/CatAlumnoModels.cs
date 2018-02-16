using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAlumnoModels
    {
        private string _IDPersona;

        public string IDPersona
        {
            get { return _IDPersona; }
            set { _IDPersona = value; }
        }

        private string _NumControl;
        [Required(ErrorMessage = "El número de control es obligatorio")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\s]*$", ErrorMessage = "Solo Letras y números")]
        public string NumControl
        {
            get { return _NumControl; }
            set { _NumControl = value; }
        }

        private string _Observaciones;
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        [Display(Name = "observaciones")]
        [StringLength(1000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private int _IDTipoCelular;

        public int IDTipoCelular
        {
            get { return _IDTipoCelular; }
            set { _IDTipoCelular = value; }
        }

        private string _Token;

        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }
        private int _id_estatus;

        public int id_estatus
        {
            get { return _id_estatus; }
            set { _id_estatus = value; }
        }


        //CATALOGO PERSONA
        private string _nombre;
        [Required(ErrorMessage = "El nombre es obligatoria")]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apPaterno;
        [Required(ErrorMessage = "El Apellido Paterno es obligatorio")]
        [Display(Name = "Apellido")]
        [StringLength(80, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]

        public string apPaterno
        {
            get { return _apPaterno; }
            set { _apPaterno = value; }
        }
        private string _apMaterno;

        [Display(Name = "Apellido")]
        [StringLength(80, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]

        public string apMaterno
        {
            get { return _apMaterno; }
            set { _apMaterno = value; }
        }
        private string _correo;
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        [StringLength(300, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        private string _telefono;
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [Display(Name = "Telefono")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[0-9\s\-\(\)\+]*$", ErrorMessage = "Solo numeros")]
        public string telefono
        {
           
            get { return _telefono; }
            set { _telefono = value; }
        }
        private string _direccion;
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [Display(Name = "Direccion")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9#,.\s]*$", ErrorMessage = "Solo Letras y Números")]
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _clvUser;

        [Display(Name = "clave")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\s]*$", ErrorMessage = "Solo Letras y Números")]
        public string clvUser
        {
            get { return _clvUser; }
            set { _clvUser = value; }
        }
        private bool _validado;
        private string _passUser;

        [Display(Name = "contraseña")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string passUser
        {
            get { return _passUser; }
            set { _passUser = value; }
        }

        private int _id_tipoPersona;

        public int id_tipoPersona
        {
            get { return _id_tipoPersona; }
            set { _id_tipoPersona = value; }
        }
        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private List<CatTipoPersonaModels> _TablaTipoPersonaCmb;
        [Required(ErrorMessage = "El tipo de persona es obligatorio")]
        [Display(Name = "Plan de Estudio")]
        public List<CatTipoPersonaModels> TablaTipoPersonaCmb
        {
            get { return _TablaTipoPersonaCmb; }
            set { _TablaTipoPersonaCmb = value; }
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