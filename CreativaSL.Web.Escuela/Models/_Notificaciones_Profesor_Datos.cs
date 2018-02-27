using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _Notificaciones_Profesor_Datos
    {
        public NotificacionesProfesorModels obtenerCatNotificacionProfesor(NotificacionesProfesorModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatNotificacionesDefinidas",Datos.grupo,Datos.id_profesor);
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
        public NotificacionesProfesorModels obtenerCatNotificacionProfesorEnviadas(NotificacionesProfesorModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatNotificacionesDefinidasEnviadas", Datos.grupo, Datos.id_profesor);
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
        public void insertarNotificacion(NotificacionesProfesorModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_NotificacionGeneral",
                    new SqlParameter("@opcion", datos.opcion),
                     new SqlParameter("@id_notificacion", datos.IDNotificacionGeneral),
                     new SqlParameter("@IDPlanEstudios", datos.idplanEstudio),
                     new SqlParameter("@IDModalidad", datos.IDModalidad),
                     new SqlParameter("@IDEspecialidad", datos.IDEspecialidad),
                     new SqlParameter("@IDCurso", datos.curso),
                     new SqlParameter("@IDCiclo", datos.ciclo),
                     new SqlParameter("@IDGrupo", datos.grupo),
                     new SqlParameter("@IDTipoNotificacion", datos.IDTipoNotificacion),
                     new SqlParameter("@titulo", datos.titulo),
                     new SqlParameter("@resumen", datos.resumen),
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
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void actualizarDetalleNotificacion(NotificacionesProfesorModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_NotificacionDetalleActualizar",
                    new SqlParameter("@TablaNotificacion", datos.TablaNotificacionXTipo)
                     );

                if (dr != null)
                {
                    if (dr.Tables.Count == 1)
                    {
                        

                        DataTableReader DTR = dr.Tables[0].CreateDataReader();
                        DataTable Tbl1 = dr.Tables[0];
                        while (DTR.Read())
                        {
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public NotificacionesProfesorModels obtenerDetalleCatNotificacionGeneralXID(NotificacionesProfesorModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatNotificacionesGeneralesDetaleXID", Datos.IDNotificacionGeneral);
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
        public void ReenviarNotificacion(NotificacionesProfesorModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_get_ReenviarTipoNotificacionXID",
                    new SqlParameter("@id_notificacion", datos.IDNotificacionGeneral),
                    new SqlParameter("@id_registro", datos.id_registro),
                    new SqlParameter("@tipo_notificacion", datos.IDTipoNotificacion),
                    new SqlParameter("@idusuario",datos.user)
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
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //obtener combos
        public List<CatCatedraticoModels> obtenerComboCatCatedraticos(NotificacionesProfesorModels datos)
        {
            try
            {
                List<CatCatedraticoModels> lista = new List<CatCatedraticoModels>();
                CatCatedraticoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatProfesorXGrupo", datos.grupo);
                while (dr.Read())
                {
                    item = new CatCatedraticoModels();
                    item.id_persona = dr["IDProfesor"].ToString();
                    item.nombre = dr["NombreProfesor"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(NotificacionesProfesorModels datos)
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
        public List<CatGrupoModels> ObtenerComboCatGrupo(NotificacionesProfesorModels datos)
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
        public List<CatEspecialidadModels> ObtenerComboCatEspecialidad(NotificacionesProfesorModels datos)
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
        public List<CatCursoModels> ObtenerComboCatCursos(NotificacionesProfesorModels datos)
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
        public List<CatModalidadModels> ObtenerComboCatModalidad(NotificacionesProfesorModels datos)
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
        public List<CatPlanEstudioModels> ObtenerComboCatPlanEstudio(NotificacionesProfesorModels datos)
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
    }
}