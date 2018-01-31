using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatMateriaXCurso_Datos
    {
        public CatMateriaXCursoModels ObtenerListMaterias(CatMateriaXCursoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_MateriaXCurso", datos.IDCurso);
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
        public List<CatModalidadModels> obtenerComboCatModalidad(CatMateriaXCursoModels datos)
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
        public CatMateriaXCursoModels AbcCatMateriaXProfesor(CatMateriaXCursoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDCurso,datos.IDMateria, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatMateriaXCurso", parametros);
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
        public List<CatMateriaXCursoModels> obtenerComboCatMateriaPorCurso(CatMateriaXCursoModels datos)
        {
            try
            {
                List<CatMateriaXCursoModels> lista = new List<CatMateriaXCursoModels>();
                CatMateriaXCursoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatMateriaXCurso", datos.IDCurso,datos.IDModalidad);
                while (dr.Read())
                {
                    item = new CatMateriaXCursoModels();
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
    }
}