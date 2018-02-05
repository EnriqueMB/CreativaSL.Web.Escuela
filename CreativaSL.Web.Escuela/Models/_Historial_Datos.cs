using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _Historial_Datos
    {
        public HistorialModels ObtenerListaMateriasCursadas(HistorialModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_DetalleMateriaCursadaXAlumno", datos.id_alumno);
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
        public HistorialModels ObtenerListaCursoCursados(HistorialModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_CursosCursadosXAlumno",datos.id_alumno);
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
        public List<CatAlumnoModels> ObtenertablaCatAlumnoXGrupo(HistorialModels datos)
        {
            try
            {
                List<CatAlumnoModels> lista = new List<CatAlumnoModels>();
                CatAlumnoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatAlumnosXGrupo", datos.grupo);
                while (dr.Read())
                {
                    item = new CatAlumnoModels();
                    item.IDPersona = dr["id_alumno"].ToString();
                    item.nombre = dr["nombreCompleto"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatGrupoModels> ObtenerComboCatGrupo(HistorialModels datos)
        {
            try
            {
                List<CatGrupoModels> lista = new List<CatGrupoModels>();
                CatGrupoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatGrupoXID", datos.ciclo, datos.IDEspecialidad, datos.curso);
                while (dr.Read())
                {
                    item = new CatGrupoModels();
                    item.IDGrupo = dr["IDGrupo"].ToString();
                    item.Nombre = dr["NombreGrupo"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatEspecialidadModels> ObtenerComboCatEspecialidad(HistorialModels datos)
        {
            try
            {
                List<CatEspecialidadModels> lista = new List<CatEspecialidadModels>();
                CatEspecialidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatEspecialidadXID", datos.IDModalidad);
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
        public List<CatCursoModels> ObtenerComboCatCursos(HistorialModels datos)
        {
            try
            {
                List<CatCursoModels> lista = new List<CatCursoModels>();
                CatCursoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatCursoXID", datos.IDEspecialidad);
                while (dr.Read())
                {
                    item = new CatCursoModels();
                    item.IDCurso = dr["IDCurso"].ToString();
                    item.Descripcion = dr["Curso"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatModalidadModels> ObtenerComboCatModalidad(HistorialModels datos)
        {
            try
            {
                List<CatModalidadModels> lista = new List<CatModalidadModels>();
                CatModalidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidadXID", datos.idplanEstudio);//enviar 1 por default
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
        public List<CatPlanEstudioModels> ObtenerComboCatPlanEstudio(HistorialModels datos)
        {
            try
            {
                List<CatPlanEstudioModels> lista = new List<CatPlanEstudioModels>();
                CatPlanEstudioModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatPlanEstudio");
                while (dr.Read())
                {
                    item = new CatPlanEstudioModels();
                    item.IDPlanEstudio = dr.GetInt32(dr.GetOrdinal("IDPlanEstudio"));
                    item.Descripcion = dr["PlanEstudio"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(HistorialModels datos)
        {
            try
            {
                List<CatCicloEscolarModels> lista = new List<CatCicloEscolarModels>();
                CatCicloEscolarModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatCicloEscolar");
                while (dr.Read())
                {
                    item = new CatCicloEscolarModels();
                    item.IDCiclo = dr["IDCiclo"].ToString();
                    item.Nombre = dr["NombreCiclo"].ToString();
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