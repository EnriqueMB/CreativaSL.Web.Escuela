using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class Asignatura_Datos
    {
        public AsignaturaModels AbcAsignatura(AsignaturaModels datos)
        {
            try
            {
                object[] parametros =
                {
                datos.opcion, datos.IDAsignatura, datos.IDCiclo, datos.IDGrupo, datos.IDMateria, datos.IDHorario, datos.IDProfesor, datos.IDAula, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_Asignatura", parametros);
                datos.IDAsignatura = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDAsignatura))
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

        public AsignaturaModels ObtenerAsignatura(AsignaturaModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_Asignatura");
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

        public AsignaturaModels ObtenerDetalleAsignatura(AsignaturaModels datos)
        {
            try
            {
                object[] parametros = { datos.IDAsignatura };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_AsignaturaXID", parametros);
                while (dr.Read())
                {
                    datos.IDAsignatura = dr.GetString(dr.GetOrdinal("IDAsignatura"));
                    datos.IDCiclo = dr.GetString(dr.GetOrdinal("IDCiclo"));
                    datos.IDGrupo = dr.GetString(dr.GetOrdinal("IDGrupo"));
                    datos.IDMateria = dr.GetString(dr.GetOrdinal("IDMateria"));
                    datos.IDHorario = dr.GetString(dr.GetOrdinal("IDHorario"));
                    datos.IDProfesor = dr.GetString(dr.GetOrdinal("IDProfesor"));
                    datos.IDAula = dr.GetString(dr.GetOrdinal("IDAula"));
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(AsignaturaModels datos)
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

        public List<CatGrupoModels> ObtenerComboCatGrupo(AsignaturaModels datos)
        {
            try
            {
                List<CatGrupoModels> lista = new List<CatGrupoModels>();
                CatGrupoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatGrupo");
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

        public List<CatMateriaModels> ObtenerComboCatMaterias(AsignaturaModels datos)
        {
            try
            {
                List<CatMateriaModels> lista = new List<CatMateriaModels>();
                CatMateriaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatMateria");
                while (dr.Read())
                {
                    item = new CatMateriaModels();
                    item.id_materia = dr["IDMateria"].ToString();
                    item.nombre = dr["NombreMateria"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatHorarioModels> ObtenerComboCatHorario(AsignaturaModels datos)
        {
            try
            {
                List<CatHorarioModels> lista = new List<CatHorarioModels>();
                CatHorarioModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatHorario");
                while (dr.Read())
                {
                    item = new CatHorarioModels();
                    item.IDHorario = dr["IDHorario"].ToString();
                    item.Descripcion = dr["Horarios"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatCatedraticoModels> ObtenerComboCatProfesor(AsignaturaModels datos)
        {
            try
            {
                List<CatCatedraticoModels> lista = new List<CatCatedraticoModels>();
                CatCatedraticoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatProfesor");
                while (dr.Read())
                {
                    item = new CatCatedraticoModels();
                    item.id_persona = dr["IDProfesor"].ToString();
                    item.Descripcion = dr["NombreProfesor"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatAulaModels> ObtenerComboCatAula(AsignaturaModels datos)
        {
            try
            {
                List<CatAulaModels> lista = new List<CatAulaModels>();
                CatAulaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatAula");
                while (dr.Read())
                {
                    item = new CatAulaModels();
                    item.IDAula = dr["IDAula"].ToString();
                    item.Descripcion = dr["NombreAula"].ToString();
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