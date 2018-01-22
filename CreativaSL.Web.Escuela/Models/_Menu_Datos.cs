using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace CreativaSL.Web.Escuela.Models
{
    public class Menu_Datos
    {
        public MenuModels ObtenerMenu2(MenuModels Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_V2_get_Menu");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        List<MenuModels> ListaPrinc = new List<MenuModels>();
                        MenuModels Item;
                        DataTableReader DTR = Ds.Tables[0].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[0];
                        while (DTR.Read())
                        {
                            Item = new MenuModels();
                            Item.ListaMenuDetalle = new List<MenuModels>();
                            Item.MenuID = !DTR.IsDBNull(DTR.GetOrdinal("MenuID")) ? DTR.GetInt32(DTR.GetOrdinal("MenuID")) : 0;
                            Item.NombreMenu = !DTR.IsDBNull(DTR.GetOrdinal("NombreMenu")) ? DTR.GetString(DTR.GetOrdinal("NombreMenu")) : string.Empty;
                            Item.OrdenMenu = !DTR.IsDBNull(DTR.GetOrdinal("OrdenMenu")) ? DTR.GetInt32(DTR.GetOrdinal("OrdenMenu")) : 0;
                            Item.IconMenu = !DTR.IsDBNull(DTR.GetOrdinal("Icon")) ? DTR.GetString(DTR.GetOrdinal("Icon")) : string.Empty;
                            Item.UrlMenu = !DTR.IsDBNull(DTR.GetOrdinal("UrlMenu")) ? DTR.GetString(DTR.GetOrdinal("UrlMenu")) : string.Empty;
                            //Item.IDFranquicia = !DTR.IsDBNull(0) ? DTR.GetString(0) : string.Empty;
                            //Item.Descripcion = !DTR.IsDBNull(1) ? DTR.GetString(1) : string.Empty;

                            //string Aux = DTR.GetString(2);
                            string Aux = !DTR.IsDBNull(DTR.GetOrdinal("TablaSubMenu")) ? DTR.GetString(DTR.GetOrdinal("TablaSubMenu")) : string.Empty;
                            Aux = string.Format("<Main>{0}</Main>", Aux);
                            XmlDocument xm = new XmlDocument();
                            xm.LoadXml(Aux);
                            XmlNodeList Registros = xm.GetElementsByTagName("Main");
                            XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("C");
                            List<MenuModels> ListaAux = new List<MenuModels>();
                            MenuModels ItemAux;
                            foreach (XmlElement Nodo in Lista)
                            {
                                ItemAux = new MenuModels();
                                XmlNodeList MenuID = Nodo.GetElementsByTagName("MenuID");
                                XmlNodeList NombreMenu = Nodo.GetElementsByTagName("NombreMenu");
                                XmlNodeList MenuUrl = Nodo.GetElementsByTagName("MenuUrl");
                                XmlNodeList MenuIcon = Nodo.GetElementsByTagName("Icono");
                                ItemAux.MenuID = Convert.ToInt32(MenuID[0].InnerText);
                                ItemAux.NombreMenu = NombreMenu[0].InnerText;
                                ItemAux.UrlMenu = MenuUrl[0].InnerText;
                                ItemAux.IconMenu = MenuIcon[0].InnerText;
                                Item.ListaMenuDetalle.Add(ItemAux);
                            }
                            ListaPrinc.Add(Item);
                        }
                        Datos.ListaMenu = ListaPrinc;
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}