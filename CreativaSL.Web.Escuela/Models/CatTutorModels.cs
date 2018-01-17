using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatTutorModels
    {
        private string _IDPersona;

        public string IDPersona
        {
            get { return _IDPersona; }
            set { _IDPersona = value; }
        }

        private string _Observaciones;
        [Required(ErrorMessage = "Observaciones es obligatorio")]
        [Display(Name = "Observaciones")]
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

        private string _Nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(120, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _ApPaterno;
        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [Display(Name = "Apellido Paterno")]
        [StringLength(120, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string ApPaterno
        {
            get { return _ApPaterno; }
            set { _ApPaterno = value; }
        }

        private string _ApMaterno;
        
        public string ApMaterno
        {
            get { return _ApMaterno; }
            set { _ApMaterno = value; }
        }

        private string _Correo;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[_A-Za-z0-9-.\\+]+(\\.[_A-Za-z0-9-.]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        [StringLength(300, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private int _IDTipoPersona;

        public int IDTipoPersona
        {
            get { return _IDTipoPersona; }
            set { _IDTipoPersona = value; }
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