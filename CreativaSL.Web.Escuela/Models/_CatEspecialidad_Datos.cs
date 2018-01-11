using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatEspecialidad_Datos
    {
        public CatEspecialidadModels AbcCatEspecialidad(CatEspecialidadModels datos) {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_especialidad, datos.id_modalidad, datos.descripcion, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatEspecialidad", parametros);
                datos.id_especialidad = aux.ToString();
                if (!string.IsNullOrEmpty(datos.id_especialidad))
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
        public CatEspecialidadModels ObtenerCatEspecialidad(CatEspecialidadModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatEspecialidad");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            Datos.TablaDatos = ds.Tables[0];
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
        public CatEspecialidadModels ObtenerDetalleCatEspecialidad(CatEspecialidadModels datos)
        {
            try
            {
                object[] parametros = { datos.id_especialidad };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatEspecialidadXID", parametros);
                while (dr.Read())
                {
                    datos.id_especialidad = dr["id_especialidad"].ToString();
                    datos.id_modalidad = dr["id_modalidad"].ToString();
                    datos.descripcion = dr["Descripcion"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatModalidadModels> obtenerComboCatModalidad(CatEspecialidadModels datos)
        {
            try
            {
                List<CatModalidadModels> lista = new List<CatModalidadModels>();
                CatModalidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidad");
                while (dr.Read())
                {
                    item = new CatModalidadModels();
                    item.IDModalidad = dr["IDModalidad"].ToString();
                    item.Descripcion = dr["Modalidad"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}