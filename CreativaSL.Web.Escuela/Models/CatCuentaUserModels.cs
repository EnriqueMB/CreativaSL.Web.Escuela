using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatCuentaUserModels
    {
        private string _id_cuenta;

        public string id_cuenta
        {
            get { return _id_cuenta; }
            set { _id_cuenta = value; }
        }

        private bool _validado;

        public bool validado
        {
            get { return _validado; }
            set { _validado = value; }
        }

        private int _IDTipoPersona;

        public int IDTipoPersona
        {
            get { return _IDTipoPersona; }
            set { _IDTipoPersona = value; }
        }

        private string _id_tipoPersona;

        public string id_tipoPersona
        {
            get { return _id_tipoPersona; }
            set { _id_tipoPersona = value; }
        }


        private string _clvUser;

        public string clvUser
        {
            get { return _clvUser; }
            set { _clvUser = value; }
        }

        private string _passUser;
        [Required(ErrorMessage = "La Contraseña Vieja es Obligatoria")]
        [Display(Name = "Contraseña vieja")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        public string passUser
        {
            get { return _passUser; }
            set { _passUser = value; }
        }

        [Required(ErrorMessage = "La Contraseña Actual es Obligatoria")]
        [Display(Name = "Contraseña Actual")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}", MinimumLength = 1)]
        public string passActualizado { get; set; }

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

        private DataTable _tablaUsuarioCuenta;

        public DataTable tablaUsuarioCuenta
        {
            get { return _tablaUsuarioCuenta; }
            set { _tablaUsuarioCuenta = value; }
        }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}