using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _NotificacionesGenerales_Datos
    {
        public void insertarNotificacion(NotificacionesGeneralesModels datos) {
           
            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_NotificacionGeneral",
                    
                     new SqlParameter("@IDPlanEstudios", datos.idplanEstudio),
                     new SqlParameter("@IDModalidad", datos.IDModalidad),
                     new SqlParameter("@IDEspecialidad", datos.IDEspecialidad),
                     new SqlParameter("@IDCurso", datos.curso),
                     new SqlParameter("@IDCiclo", datos.ciclo),
                     new SqlParameter("@IDGrupo", datos.grupo),
                     new SqlParameter("@IDTipoNotificacion", datos.IDTipoNotificacion),
                     new SqlParameter("@titulo", datos.titulo),
                     new SqlParameter("@texto", datos.texto),
                     new SqlParameter("@Tutores", datos.tutores),
                     new SqlParameter("@TablaAlumnos", datos.TablaAlumnos),
                     new SqlParameter("@IDUsuario", datos.user)
                     
                     );
                   
                if (dr != null)
                {
                    if (dr.Tables.Count == 2)
                    {
                        datos.TablaAlumnos = dr.Tables[0];

                        DataTableReader DTR = dr.Tables[1].CreateDataReader();
                        DataTable Tbl1 = dr.Tables[1];
                        while (DTR.Read())
                        {
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) :0;
                        }
                    }
                }

                    }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<CatAlumnoModels> ObtenertablaCatAlumnoXGrupo(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatAlumnoModels> lista = new List<CatAlumnoModels>();
                CatAlumnoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatAlumnosXGrupoNotificacionGeneral", datos.grupo);
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
        public List<CatGrupoModels> ObtenerComboCatGrupo(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatGrupoModels> lista = new List<CatGrupoModels>();
                CatGrupoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatGrupoXIDNotificacionGeneral", datos.ciclo, datos.IDEspecialidad, datos.curso);
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
        public List<CatEspecialidadModels> ObtenerComboCatEspecialidad(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatEspecialidadModels> lista = new List<CatEspecialidadModels>();
                CatEspecialidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatEspecialidadXIDNotificacionGeneral", datos.IDModalidad);
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
        public List<CatCursoModels> ObtenerComboCatCursos(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatCursoModels> lista = new List<CatCursoModels>();
                CatCursoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatCursoXIDNotificacionGeneral", datos.IDEspecialidad);
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
        public List<CatModalidadModels> ObtenerComboCatModalidad(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatModalidadModels> lista = new List<CatModalidadModels>();
                CatModalidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidadXIDNotificacionGeneral", datos.idplanEstudio);//enviar 1 por default
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
        public List<CatPlanEstudioModels> ObtenerComboCatPlanEstudio(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatPlanEstudioModels> lista = new List<CatPlanEstudioModels>();
                CatPlanEstudioModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatPlanEstudioNotificacionGeneral");
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
        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(NotificacionesGeneralesModels datos)
        {
            try
            {
                List<CatCicloEscolarModels> lista = new List<CatCicloEscolarModels>();
                CatCicloEscolarModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatCicloEscolarNotificacionGeneral");
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