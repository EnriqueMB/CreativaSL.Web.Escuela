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
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatCatedraticos", parametros);
                datos.id_persona = aux.ToString();
                if (!string.IsNullOrEmpty(datos.id_persona))
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
        public List<CatGradoEstudioModels> obtenerComboCatGradoEstudio(CatCatedraticoModels datos)
        {
            try
            {
                List<CatGradoEstudioModels> lista = new List<CatGradoEstudioModels>();
                CatGradoEstudioModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatGradoEstudio");
                while (dr.Read())
                {
                    item = new CatGradoEstudioModels();
                    item.id_gradoEstudio =dr["IDGradoEstudio"].ToString();
                    item.descripcion = dr["GradoEstudio"].ToString();
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