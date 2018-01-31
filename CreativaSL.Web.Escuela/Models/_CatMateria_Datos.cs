using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatMateria_Datos
    {
        public CatMateriaModels AbcCatMateria(CatMateriaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_materia,datos.id_curso,datos.id_tipoMateria, datos.clave, datos.nombre,datos.horaSemana, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatMateria", parametros);
                datos.id_materia = aux.ToString();
                if (!string.IsNullOrEmpty(datos.id_materia))
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

        public CatMateriaModels ObtenerCatMateria(CatMateriaModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatMateria");
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
        public CatMateriaModels ObtenerDetalleCatMateria(CatMateriaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_materia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatMateriaXID", parametros);
                while (dr.Read())
                {
                    datos.id_materia = dr["id_materia"].ToString();
                    datos.id_curso = dr["id_modalidad"].ToString();
                    datos.id_tipoMateria = dr.GetInt32(dr.GetOrdinal("id_tipoMateria"));
                    datos.clave = dr["clave"].ToString();
                    datos.nombre = dr["Nombre"].ToString();
                    datos.horaSemana = dr.GetInt32(dr.GetOrdinal("horaSemana"));
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatCursoModels> obtenerComboCatCurso(CatMateriaModels datos)
        {
            try
            {
                List<CatCursoModels> lista = new List<CatCursoModels>();
                CatCursoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidad");
                while (dr.Read())
                {
                    item = new CatCursoModels();
                    item.IDCurso = dr["IDModalidad"].ToString();
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
        public List<CatTipoMateriaModels> obtenerComboCatTipoMaterias(CatMateriaModels datos)
        {
            try
            {
                List<CatTipoMateriaModels> lista = new List<CatTipoMateriaModels>();
                CatTipoMateriaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatTipoMaterias");
                while (dr.Read())
                {
                    item = new CatTipoMateriaModels();
                    item.descripcion = dr["TipoMateria"].ToString();
                    item.id_tipoMateria = dr.GetInt32(dr.GetOrdinal("IDTipoMateria")); ;
                    
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