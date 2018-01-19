using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatAlumno_Datos
    {
        public CatAlumnoModels AbcCatAlumnos(CatAlumnoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDPersona,datos.NumControl,datos.Observaciones,datos.nombre,datos.apPaterno,datos.apMaterno,datos.correo,datos.telefono,datos.direccion,datos.id_tipoPersona,datos.clvUser,datos.passUser,datos.user
                };
                
                if (datos.opcion == 1)
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_abc_CatAlumnos", parametros);
                    while (dr.Read())
                    {
                        datos.IDPersona = dr.GetString(dr.GetOrdinal("IDPersona"));
                        datos.clvUser = dr.GetString(dr.GetOrdinal("ClaveUser"));
                        datos.passUser = dr.GetString(dr.GetOrdinal("Contraseña"));
                        datos.Completado = true;
                    }
                }
                else if (datos.opcion == 2 || datos.opcion == 3)
                {
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatAlumnos", parametros);
                    datos.IDPersona = aux.ToString();
                    if (!string.IsNullOrEmpty(datos.IDPersona))
                    {
                        datos.Completado = true;
                    }
                    else
                    {
                        datos.Completado = false;
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatAlumnoModels ObtenerCatAlumno(CatAlumnoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatAlumnosActivo");
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
        public CatAlumnoModels ObtenerCatAlumnoBaja(CatAlumnoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatAlumnosBaja");
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
        public CatAlumnoModels ObtenerCatAlumnoGraduados(CatAlumnoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatAlumnosGraduados");
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

        public CatAlumnoModels ObtenerDetalleCatAlumno(CatAlumnoModels datos)
        {
            try
            {
                object[] parametros = { datos.IDPersona };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatAlumnoXID", parametros);
                while (dr.Read())
                {
                    datos.IDPersona = dr["id_persona"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.apPaterno = dr["apPaterno"].ToString();
                    datos.apMaterno = dr["apMaterno"].ToString();
                    datos.correo = dr["correo"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.direccion = dr["direccion"].ToString();
                    datos.NumControl = dr["numControl"].ToString();
                    datos.id_tipoPersona = Convert.ToInt32(dr["TipoPersona"].ToString());
                    datos.Observaciones = dr["observaciones"].ToString();

                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatTipoPersonaModels> obtenerComboCatTipoPersona(CatAlumnoModels datos)
        {
            try
            {
                List<CatTipoPersonaModels> lista = new List<CatTipoPersonaModels>();
                CatTipoPersonaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatTipoPersona");
                while (dr.Read())
                {
                    item = new CatTipoPersonaModels();
                    item.id_tipoPersona = Convert.ToInt32(dr["IDPersona"].ToString());
                    item.descripcion = dr["TipoPersona"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CatAlumnoModels DarBaja(CatAlumnoModels datos)
        {
            try
            {
                object[] parametros =
                {
                   datos.IDPersona,datos.id_estatus,datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_baja_Alumno", parametros);
                datos.IDPersona = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDPersona))
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