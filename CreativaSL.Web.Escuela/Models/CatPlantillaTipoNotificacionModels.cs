using System;
using System.Collections.Generic;
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

        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        private string _texto;

        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
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