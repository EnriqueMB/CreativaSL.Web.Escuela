using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatCatedraticoModels
    {
        //cat profesor
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
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\s]*$", ErrorMessage = "Solo Letras")]
        public string curriculum
        {
            get { return _curriculum; }
            set { _curriculum = value; }
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
        private string  _telefono;
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [Display(Name = "Telefono")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[0-9\s\,\.\;\:\-\(\)\+]*$", ErrorMessage = "Solo numeros")]
        public string  telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private string _direccion;

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private int _id_tipoPersona;
        
        public int id_tipoPersona
        {
            get { return _id_tipoPersona; }
            set { _id_tipoPersona = value; }
        }
      
       //CUENTA USER
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
        private List<CatGradoEstudioProfesorModels> _TablaGradoEstudioCmb;
        [Required(ErrorMessage = "El Grado de estudio es obligatorio")]
        [Display(Name = "Plan de Estudio")]
        public List<CatGradoEstudioProfesorModels> TablaGradoEstudioCmb
        {
            get { return _TablaGradoEstudioCmb; }
            set { _TablaGradoEstudioCmb = value; }
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