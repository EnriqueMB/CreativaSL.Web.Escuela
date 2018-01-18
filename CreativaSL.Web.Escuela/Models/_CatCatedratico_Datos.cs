using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatCatedratico_Datos
    {
        public CatCatedraticoModels AbcCatCatedratico(CatCatedraticoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion,datos.id_persona,datos.nombre,datos.apPaterno,datos.apMaterno,datos.correo,
                    datos.telefono,datos.direccion,datos.id_tipoPersona,datos.id_gradoEstudio,datos.clave,datos.curriculum,
                    datos.clvUser,datos.passUser,datos.user
                };
                if (datos.opcion == 1)
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_abc_CatCatedraticos", parametros);
                    while (dr.Read())
                    {
                        datos.id_persona = dr.GetString(dr.GetOrdinal("IDPersona"));
                        datos.clvUser = dr.GetString(dr.GetOrdinal("ClaveUser"));
                        datos.passUser = dr.GetString(dr.GetOrdinal("Contraseña"));
                    }
                }
                else if (datos.opcion == 2 || datos.opcion == 3)
                {
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatCatedraticos", parametros);
                    datos.id_persona = aux.ToString();
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatCatedraticoModels ObtenerCatCatedratico(CatCatedraticoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatCatedraticos");
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
        public CatCatedraticoModels ObtenerDetalleCatCatedratico(CatCatedraticoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_persona };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatCatedraticoXID", parametros);
                while (dr.Read())
                {
                    datos.id_persona = dr["id_persona"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.apPaterno = dr["apPaterno"].ToString();
                    datos.apMaterno= dr["apMaterno"].ToString();
                    datos.correo = dr["correo"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.direccion = dr["direccion"].ToString();
                    datos.clave = dr["matricula"].ToString();
                    datos.id_tipoPersona =Convert.ToInt32( dr["TipoPersona"].ToString());
                    datos.id_gradoEstudio = dr["gradoEstudio"].ToString();
                    datos.curriculum= dr["curriculum"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatGradoEstudioProfesorModels> obtenerComboCatGradoEstudio(CatCatedraticoModels datos)
        {
            try
            {
                List<CatGradoEstudioProfesorModels> lista = new List<CatGradoEstudioProfesorModels>();
                CatGradoEstudioProfesorModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatGradoEstudio");
                while (dr.Read())
                {
                    item = new CatGradoEstudioProfesorModels();
                    item.IDGradoEstudio =dr["IDGradoEstudio"].ToString();
                    item.Descripcion = dr["GradoEstudio"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatTipoPersonaModels> obtenerComboCatTipoPersona(CatCatedraticoModels datos)
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

    }
}