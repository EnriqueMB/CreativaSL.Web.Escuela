using System;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Collections.Generic;

namespace CreativaSL.Web.Escuela.Models
{
    public class LoginDatos
    {

        //public CatAdministrativoModels ValidarUsuario(CatAdministrativoModels datos)
        //{
        //    try
        //    {                
        //        object[] parametros = { datos.user, datos.password };
        //        SqlDataReader dr = null;
        //        dr = SqlHelper.ExecuteReader(datos.conexion, "V2_Login_sp", parametros);
        //        while (dr.Read())
        //        {
        //            datos.opcion = Convert.ToInt32(dr[0].ToString());
        //            if(datos.opcion == 1)
        //            {
        //                datos.id_administrativo = dr["Id_U"].ToString();
        //                datos.nombre = dr["U_Nombre"].ToString();
        //                datos.apPaterno = dr["U_Apellidop"].ToString();
        //                datos.apMaterno = dr["U_Apellidom"].ToString();
        //                datos.user = dr["Cu_User"].ToString();
        //                datos.password = dr["Cu_Pass"].ToString();
        //            }
        //        }
        //        return datos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public CatAdministrativoModels ValidarUsuario(CatAdministrativoModels Datos)
        {
            try
            {
                object[] parametros = { Datos.user, Datos.password };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.conexion, "V2_Login_sp2", parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 3)
                    {
                        DataTableReader DTRD = Ds.Tables[0].CreateDataReader();
                        while (DTRD.Read())
                        {
                            Datos.opcion = Convert.ToInt32(DTRD["id"].ToString());
                        }
                        if (Datos.opcion == 1)
                        {
                            DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                            while (Dr.Read())
                            {
                                Datos.id_administrativo = Dr["Id_U"].ToString();
                                Datos.nombre = Dr["U_Nombre"].ToString();
                                Datos.apPaterno = Dr["U_Apellidop"].ToString();
                                Datos.apMaterno = Dr["U_Apellidom"].ToString();
                                Datos.user = Dr["Cu_User"].ToString();
                                Datos.password = Dr["Cu_Pass"].ToString();
                            }
                            List<CatAdministrativoModels> ListaPrinc = new List<CatAdministrativoModels>();
                            CatAdministrativoModels Item;
                            DataTableReader DTR = Ds.Tables[2].CreateDataReader();
                            DataTable Tbl1 = Ds.Tables[1];
                            while (DTR.Read())
                            {
                                Item = new CatAdministrativoModels();
                                Item.NombreUrl = !DTR.IsDBNull(DTR.GetOrdinal("NombreUrl")) ? DTR.GetString(DTR.GetOrdinal("NombreUrl")) : string.Empty;
                                ListaPrinc.Add(Item);
                            }
                            Datos.ListaPermisos = ListaPrinc;
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

        public CatAdministrativoModels ObtenerPermisos(CatAdministrativoModels datos)
        {
            try
            {
                List<CatAdministrativoModels> lista = new List<CatAdministrativoModels>();
                CatAdministrativoModels item;
                object[] parametros = { datos.cuenta };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatPermisoPorUsuario", parametros);
                while (dr.Read())
                {
                    item = new CatAdministrativoModels();
                    item.NombreUrl = !dr.IsDBNull(dr.GetOrdinal("NombreUrl")) ? dr.GetString(dr.GetOrdinal("NombreUrl")) : string.Empty;
                    lista.Add(item);
                }
                datos.ListaPermisos = lista;
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
