using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CreativaSL.Web.Escuela.Models
{
    public class MenuModels
    {
        private int _MenuID;

        public int MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }

        private string _NombreMenu;

        public string NombreMenu
        {
            get { return _NombreMenu; }
            set { _NombreMenu = value; }
        }

        private int _IDSubMenu;

        public int IDSubMenu
        {
            get { return _IDSubMenu; }
            set { _IDSubMenu = value; }
        }

        private int _OrdenMenu;

        public int OrdenMenu
        {
            get { return _OrdenMenu; }
            set { _OrdenMenu = value; }
        }

        private string _UrlMenu;

        public string UrlMenu
        {
            get { return _UrlMenu; }
            set { _UrlMenu = value; }
        }

        private string _IconMenu;

        public string IconMenu
        {
            get { return _IconMenu; }
            set { _IconMenu = value; }
        }

        public string Conexion { get; set; }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private List<MenuModels> _ListaMenu;

        public List<MenuModels> ListaMenu
        {
            get { return _ListaMenu; }
            set { _ListaMenu = value; }
        }

        private List<MenuModels> _ListaMenuDetalle;

        public List<MenuModels> ListaMenuDetalle
        {
            get { return _ListaMenuDetalle; }
            set { _ListaMenuDetalle = value; }
        }

    }
}