using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatedraticoModels
    {
        private string _id_persona;

        public string id_persona
        {
            get { return _id_persona; }
            set { _id_persona = value; }
        }
        private string  _id_gradoEstudio;

        public string  id_gradoEstudio
        {
            get { return _id_gradoEstudio; }
            set { _id_gradoEstudio = value; }
        }
        private string _clave;
        [Required(ErrorMessage = "La Clave es obligatoria")]
        [Display(Name = "Clave")]
        [StringLength(20, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        private string _curriculum;
        [Required(ErrorMessage = "La currículum es obligatoria")]
        [Display(Name = "Currículum")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string curriculum
        {
            get { return _curriculum; }
            set { _curriculum = value; }
        }
        private int _id_tipoPersona;
        //CAT TIPO PERSONA  
        public int id_tipoPersona
        {
            get { return _id_tipoPersona; }
            set { _id_tipoPersona = value; }
        }
        private string _descripcion;
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "descripción")]
        [StringLength(80, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        //CUENTA USER
        private string _id_personaCU;

        public string id_personaCU
        {
            get { return _id_personaCU; }
            set { _id_personaCU = value; }
        }
        private string _clvUser;
        [Required(ErrorMessage = "La Clave es obligatoria")]
        [Display(Name = "clave")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string clvUser
        {
            get { return _clvUser; }
            set { _clvUser = value; }
        }
        private bool  _validado;
        private string _passUser;

        public string passUser
        {
            get { return _passUser; }
            set { _passUser = value; }
        }

        public bool  validado
        {
            get { return _validado; }
            set { _validado = value; }
        }

        private DateTime _fecBloqueo;

        public DateTime fecBloqueo
        {
            get { return _fecBloqueo; }
            set { _fecBloqueo = value; }
        }
        private DateTime _fecCaducidad;

        public DateTime fecCaducidad
        {
            get { return _fecCaducidad; }
            set { _fecCaducidad = value; }
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