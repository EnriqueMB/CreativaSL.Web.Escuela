using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatCurso_Datos
    {
        public CatCursoModels AbcCatCurso(CatCursoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDCurso, datos.IDEspecialidad, datos.Descripcion, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatCursos", parametros);
                datos.IDCurso = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDCurso))
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
        public CatCursoModels ObtenerCatCurso(CatCursoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatCurso");
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
        public CatCursoModels ObtenerDetalleCatEspecialidad(CatCursoModels datos)
        {
            try
            {
                object[] parametros = { datos.IDCurso };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatCursoXID", parametros);
                while (dr.Read())
                {
                    datos.IDCurso = dr["id_especialidad"].ToString();
                    datos.IDEspecialidad = dr["id_especialidad"].ToString();
                    datos.Descripcion = dr["Descripcion"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatEspecialidadModels> obtenerComboCatCurso(CatCursoModels datos)
        {
            try
            {
                List<CatEspecialidadModels> lista = new List<CatEspecialidadModels>();
                CatEspecialidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatEspecialidad");
                while (dr.Read())
                {
                    item = new CatEspecialidadModels();
                    item.id_especialidad = dr["IDEspecialidad"].ToString();
                    item.descripcion = dr["Especialidad"].ToString();
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