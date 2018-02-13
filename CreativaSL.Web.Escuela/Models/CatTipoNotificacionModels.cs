using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatTipoNotificacionModels
    {
        private int _id_tipoNotificacion;

        public int id_tipoNotificacion
        {
            get { return _id_tipoNotificacion; }
            set { _id_tipoNotificacion = value; }
        }
        private string  _descripcion;

        public string  descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }
}