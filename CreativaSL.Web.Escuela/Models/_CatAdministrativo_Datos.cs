using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Security.Cryptography;
using System.Xml;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAdministrativo_Datos
    {

        public CatAdministrativoModels ObtenerCatAdministrativo(CatAdministrativoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_CatAdministrativo");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaAdministracion = ds.Tables[0];
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CatAdministrativoModels ObtenerDetalleCatAdministrativoxID(CatAdministrativoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_administrativo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatAdministrativoXID", parametros);
                while (dr.Read())
                {
                    datos.id_administrativo = dr["id_persona"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.apPaterno = dr["apPaterno"].ToString();
                    datos.apMaterno = dr["apMaterno"].ToString();
                    datos.correo = dr["correo"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.direccion = dr["direccion"].ToString();
                    datos.Observaciones = dr["observaciones"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CatAdministrativoModels AbcCatAdministrativo(CatAdministrativoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_administrativo, datos.nombre, datos.apPaterno,
                    datos.apMaterno, datos.correo, datos.telefono, datos.direccion, datos.Observaciones, datos.clvUser, datos.passUser, 
                    datos.user
                    };
                if (datos.opcion == 1)
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_abc_CatAdministrativo", parametros);
                    while (dr.Read())
                    {
                        datos.id_administrativo = dr.GetString(dr.GetOrdinal("id_administrativo"));
                        datos.clvUser = dr.GetString(dr.GetOrdinal("usuario"));
                        datos.passUser = dr.GetString(dr.GetOrdinal("contraseña"));
                    }
                }
                else if (datos.opcion == 2 || datos.opcion == 3)
                {
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatAdministrativo", parametros);
                    if (aux != null)
                        datos.id_administrativo = aux.ToString();
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string ObtenerTipoUsuarioByUserName(CatAdministrativoModels datos)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_get_TipoUsuarioByUserName", datos.cuenta);
                return aux.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public CatAdministrativoModels PermisosXUsuario(CatAdministrativoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_PermisosXID", Datos.id_administrativo);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            Datos.TablaPermisos = ds.Tables[0];
                        }
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatAdministrativoModels ObtenerPermisoUsuario(CatAdministrativoModels Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_PermisosXID", Datos.id_administrativo);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        List<CatAdministrativoModels> ListaPrinc = new List<CatAdministrativoModels>();
                        CatAdministrativoModels Item;
                        DataTableReader DTR = Ds.Tables[0].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[0];
                        while (DTR.Read())
                        {
                            Item = new CatAdministrativoModels();
                            Item.ListaPermisosDetalle = new List<CatAdministrativoModels>();
                            Item.IDPermiso = !DTR.IsDBNull(DTR.GetOrdinal("IDPermiso")) ? DTR.GetString(DTR.GetOrdinal("IDPermiso")) : string.Empty;
                            Item.IDMenu = !DTR.IsDBNull(DTR.GetOrdinal("MenuID")) ? DTR.GetInt32(DTR.GetOrdinal("MenuID")) : 0;
                            Item.NombreMenu = !DTR.IsDBNull(DTR.GetOrdinal("NombreMenu")) ? DTR.GetString(DTR.GetOrdinal("NombreMenu")) : string.Empty;
                            Item.ver = DTR.GetBoolean(DTR.GetOrdinal("ver"));
                            //string Aux = DTR.GetString(2);
                            string Aux = !DTR.IsDBNull(DTR.GetOrdinal("TablaPermiso")) ? DTR.GetString(DTR.GetOrdinal("TablaPermiso")) : string.Empty;
                            Aux = string.Format("<Main>{0}</Main>", Aux);
                            XmlDocument xm = new XmlDocument();
                            xm.LoadXml(Aux);
                            XmlNodeList Registros = xm.GetElementsByTagName("Main");
                            XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("C");
                            List<CatAdministrativoModels> ListaAux = new List<CatAdministrativoModels>();
                            CatAdministrativoModels ItemAux;
                            foreach (XmlElement Nodo in Lista)
                            {
                                ItemAux = new CatAdministrativoModels();
                                XmlNodeList MenuID = Nodo.GetElementsByTagName("MenuID");
                                XmlNodeList NombreMenu = Nodo.GetElementsByTagName("NombreMenu");
                                XmlNodeList ver = Nodo.GetElementsByTagName("ver");
                                XmlNodeList IDPermiso = Nodo.GetElementsByTagName("IDPermiso");
                                ItemAux.IDMenu = Convert.ToInt32(MenuID[0].InnerText);
                                ItemAux.NombreMenu = NombreMenu[0].InnerText;
                                int Visto = 0;
                                int.TryParse(ver[0].InnerText, out Visto);
                                if (Visto == 1)
                                {
                                    ItemAux.ver = true;
                                }
                                else
                                {
                                    Item.ver = false;
                                }
                                ItemAux.IDPermiso = IDPermiso[0].InnerText;
                                Item.ListaPermisosDetalle.Add(ItemAux);
                            }
                            ListaPrinc.Add(Item);
                        }
                        Datos.ListaPermisos = ListaPrinc;
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GuardarPermisos(CatAdministrativoModels datos)
        {
            try
            {
                DataSet dt = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_ActualizarPermiso",
                new SqlParameter("@IDPersona", datos.id_administrativo),
                new SqlParameter("@Permisos", datos.TablaPermisos),
                new SqlParameter("@usuario", datos.user));
                return Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
