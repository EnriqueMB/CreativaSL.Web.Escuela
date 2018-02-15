using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class ReportesModels
    {
        private string _id_profesor;

        public string id_profesor
        {
            get { return _id_profesor; }
            set { _id_profesor = value; }
        }

        private List<CatCatedraticoModels> _listaCatedraticos;

        public List<CatCatedraticoModels> listaCatedraticos
        {
            get { return _listaCatedraticos; }
            set { _listaCatedraticos = value; }
        }
        private List<CatGrupoModels> _listaGrupo;

        public List<CatGrupoModels> listaGrupo
        {
            get { return _listaGrupo; }
            set { _listaGrupo = value; }
        }
        private List<CatTipoNotificacionModels> _listaTipoNotificacion;

        public List<CatTipoNotificacionModels> listaTipoNotificacion
        {
            get { return _listaTipoNotificacion; }
            set { _listaTipoNotificacion = value; }
        }
        private List<CatMateriaModels> _listaMateria;

        public List<CatMateriaModels> listaMateria
        {
            get { return _listaMateria; }
            set { _listaMateria = value; }
        }
        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
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