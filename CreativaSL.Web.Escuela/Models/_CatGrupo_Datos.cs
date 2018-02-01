using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatGrupo_Datos
    {
        public CatGrupoModels AbcCatGrupo(CatGrupoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDGrupo, datos.Clave, datos.Nombre, datos.IDCiclo, datos.IDEspecialidad, datos.IDCurso,
                    datos.IDModalidad, datos.IDPlanEstudio, datos.ExtraEscolar, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatGrupo", parametros);
                datos.IDGrupo = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDGrupo))
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

        public CatGrupoModels ObtenerCatGrupo(CatGrupoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatGrupo");
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

        public CatGrupoModels ObtenerDetalleCatGrupo(CatGrupoModels datos)
        {
            try
            {
                object[] parametros = { datos.IDGrupo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatGrupoXID", parametros);
                while (dr.Read())
                {

                    datos.IDGrupo = dr.GetString(dr.GetOrdinal("IDGrupo"));
                    datos.Clave = dr.GetString(dr.GetOrdinal("Clave"));
                    datos.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                    datos.IDCiclo = dr.GetString(dr.GetOrdinal("IDCiclo"));
                    datos.IDEspecialidad = dr.GetString(dr.GetOrdinal("IDEspecialidad"));
                    datos.IDCurso = dr.GetString(dr.GetOrdinal("IDCurso"));
                    datos.IDModalidad = dr.GetString(dr.GetOrdinal("IDModalidad"));
                    datos.IDPlanEstudio = dr.GetInt32(dr.GetOrdinal("IDPlanEstudio"));
                    datos.ExtraEscolar = dr.GetBoolean(dr.GetOrdinal("ExtraEscolar"));
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(CatGrupoModels datos)
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

        public List<CatPlanEstudioModels> ObtenerComboCatPlanEstudio(CatGrupoModels datos)
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

        public List<CatModalidadModels> ObtenerComboCatModalidad(CatGrupoModels datos)
        {
            try
            {
                List<CatModalidadModels> lista = new List<CatModalidadModels>();
                CatModalidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidadXID", datos.IDPlanEstudio);
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

        public List<CatEspecialidadModels> ObtenerComboCatEspecialidad(CatGrupoModels datos)
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

        public List<CatCursoModels> ObtenerComboCatCursos(CatGrupoModels datos)
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

        public CatGrupoModels ObtenerListAlumnos(CatGrupoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_AlumnosXGrupo", datos.IDGrupo);
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

        public List<CatAlumnoModels> ObtenerComboAlumnosInscripcion(CatAlumnosXGrupoModels datos)
        {
            try
            {
                List<CatAlumnoModels> Lista = new List<CatAlumnoModels>();
                CatAlumnoModels Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_comboAlumnosInscripcion");
                while(dr.Read())
                {
                    Item = new CatAlumnoModels();
                    Item.IDPersona = dr.GetString(dr.GetOrdinal("IDAlumno"));
                    Item.nombre = dr.GetString(dr.GetOrdinal("NombreAlumno"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}