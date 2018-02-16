using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _CatPlantillaTipoNotificacion_Datos
    {

        public CatPlantillaTipoNotificacionModels AbcPlatillaTipoNotificacion(CatPlantillaTipoNotificacionModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_plantilla, datos.titulo,datos.resumen, datos.texto, datos.id_tipoNotificacion, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatPlantillaTipoNotificacion", parametros);
                datos.id_plantilla = aux.ToString();
                if (!string.IsNullOrEmpty(datos.id_plantilla))
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
        public CatPlantillaTipoNotificacionModels obtenerCatPlantillaTipoNotificacion(CatPlantillaTipoNotificacionModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatPlantillaTipoNotificacion");
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
        public CatPlantillaTipoNotificacionModels ObtenerDetallePlantillaNotificacion(CatPlantillaTipoNotificacionModels datos)
        {
            try
            {
                object[] parametros = { datos.id_plantilla};
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatPlantillaNotificacionXID", parametros);
                while (dr.Read())
                {
                    datos.id_plantilla = dr["id_plantilla"].ToString();
                    datos.titulo = dr["titulo"].ToString();
                    datos.resumen = dr["resumen"].ToString();
                    datos.texto = dr["texto"].ToString();
                    datos.id_tipoNotificacion =Convert.ToInt32( dr["id_tipoNotificacion"].ToString());
          
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatVariablesNotificacionModels> ObtenerCatVariablesNotificacion(CatPlantillaTipoNotificacionModels datos)
        {
            try
            {
                  List<CatVariablesNotificacionModels> lista = new List<CatVariablesNotificacionModels>();
                CatVariablesNotificacionModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_VariablesNotificacion", datos.id_tipoNotificacion);//enviar 1 por default
                while (dr.Read())
                {
                    item = new CatVariablesNotificacionModels();
                    item.clave = dr["clave"].ToString();
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CatTipoNotificacionModels> obtenerListaTipoNotificacion(CatPlantillaTipoNotificacionModels datos) {
            try
            {
                List<CatTipoNotificacionModels> lista = new List<CatTipoNotificacionModels>();
                CatTipoNotificacionModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatTipoNotificacion");
                while (dr.Read())
                {
                    item = new CatTipoNotificacionModels();
                    item.id_tipoNotificacion = Convert.ToInt32(dr["id_tipoNotificacion"].ToString());
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }
    }
}