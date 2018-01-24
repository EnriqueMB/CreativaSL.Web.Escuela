using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAdministrativoModels
    {
        private int _numeroMenu;

        public int numeroMenu
        {
            get { return _numeroMenu; }
            set { _numeroMenu = value; }
        }

        private string _id_administrativo;

        public string id_administrativo
        {
            get { return _id_administrativo; }
            set {  _id_administrativo = value; }
        }

        private string _nombre;
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apPaterno;
        [Required(ErrorMessage = "El Apellido Paterno es obligatorio")]
        [Display(Name = "Apellido Parteno")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string apPaterno
        {
            get { return _apPaterno; }
            set { _apPaterno = value; }
        }

        private string _apMaterno;
        [Required(ErrorMessage = "El Apellido Materno es obligatorio")]
        [Display(Name = "Apellido Materno")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string apMaterno
        {
            get { return _apMaterno; }
            set { _apMaterno = value; }
        }

        private string _correo;
        [Display(Name = "Correo")]
        [RegularExpression(@"^[_A-Za-z0-9-.\\+]+(\\.[_A-Za-z0-9-.]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        [StringLength(300, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        //[Remote("CheckEmailAvailability", "Account", ErrorMessage = "Este email esta ocupado")]
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private string _telefono;
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo números")] 
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _direccion;
        [Display(Name = "Dirección")]
        [StringLength(250, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _password;
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _cuenta;
        [Display(Name = "Usuario")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 1)]
        [Remote("CheckUserAvailability", "Account", ErrorMessage = "Este usuario esta ocupado")]
        public string cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public int id_tipoPersona { get; set; }
        public int id_tipoUser { get; set; }
        public string clvUser { get; set; }
        public string passUser { get; set; }
        private DateTime _fecBloqueo;

        public DateTime fecBloqueo
        {
            get { return _fecBloqueo; }
            set { _fecBloqueo = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }


        private DateTime _fecCaducidad;

        public DateTime fecCaducidad
        {
            get { return _fecCaducidad; }
            set { _fecCaducidad = value; }
        }

        private DataTable _tablaAdministracion;

        public DataTable tablaAdministracion
        {
            get { return _tablaAdministracion; }
            set { _tablaAdministracion = value; }
        }

        private DataTable _TablaPermisos;

        public DataTable TablaPermisos
        {
            get { return _TablaPermisos; }
            set { _TablaPermisos = value; }
        }


        private List<CatAdministrativoModels> _ListaPermisos;

        public List<CatAdministrativoModels> ListaPermisos
        {
            get { return _ListaPermisos; }
            set { _ListaPermisos = value; }
        }

        private List<CatAdministrativoModels> _ListaPermisosDetalle;

        public List<CatAdministrativoModels> ListaPermisosDetalle
        {
            get { return _ListaPermisosDetalle; }
            set { _ListaPermisosDetalle = value; }
        }

        private string _IDPermiso;

        public string IDPermiso
        {
            get { return _IDPermiso; }
            set { _IDPermiso = value; }
        }

        private int _IDMenu;

        public int IDMenu
        {
            get { return _IDMenu; }
            set { _IDMenu = value; }
        }

        private bool _Ver;

        public bool ver
        {
            get { return _Ver; }
            set { _Ver = value; }
        }

        private string _NombreMenu;

        public string NombreMenu
        {
            get { return _NombreMenu; }
            set { _NombreMenu = value; }
        }

        private string _NombreUrl;

        public string NombreUrl
        {
            get { return _NombreUrl; }
            set { _NombreUrl = value; }
        }

        private List<string> _ListaPermiso;

        public List<string> ListaPermiso
        {
            get { return _ListaPermiso; }
            set { _ListaPermiso = value; }
        }


        public AdministrativoPermisoJson GetAdminJson()
        {
            try
            {
                AdministrativoPermisoJson _customerJson = new AdministrativoPermisoJson
                {
                    NombreURl = _ListaPermiso
                };
                return _customerJson;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Datos de control
        public bool RememberMe { get; set; }
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion

       
    }
}