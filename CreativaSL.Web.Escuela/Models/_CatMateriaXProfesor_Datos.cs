using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatMateriaXProfesor_Datos
    {
        public CatMateriaXProfesorModels ObtenerListMaterias(CatMateriaXProfesorModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_ProfesorXMateria", datos.IDProfesor);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaDatos = ds.Tables[0];
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

        public List<CatMateriaXProfesorModels> obtenerComboCatMateriaPorProfesor(CatMateriaXProfesorModels datos)
        {
            try
            {
                List<CatMateriaXProfesorModels> lista = new List<CatMateriaXProfesorModels>();
                CatMateriaXProfesorModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatMateriaXProfesor", datos.IDProfesor);
                while (dr.Read())
                {
                    item = new CatMateriaXProfesorModels();
                    item.IDMateria = dr["IDMateria"].ToString();
                    item.NombreM = dr["NombreMateria"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatMateriaXProfesorModels AbcCatMateriaXProfesor(CatMateriaXProfesorModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDProfesor,datos.IDMateria, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatProfesorXMateria", parametros);
                datos.IDProfesor = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDProfesor))
                {
                    datos.Completado = true;
                }
                else
                {
                    datos.Completado = false;
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}