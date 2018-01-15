using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatGradoEstudioProfesor_Datos
    {
        public CatGradoEstudioProfesorModels ObtenerCatGradoEstudioProfesor(CatGradoEstudioProfesorModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_CatGradoEstudioProfesor");
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
        public CatGradoEstudioProfesorModels ObtenerDetalleCatGradoEstudioProfesorXID(CatGradoEstudioProfesorModels datos)
        {
            try
            {
                object[] parametros = { datos.IDGradoEstudio };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatGradoEstudioProfesorXID", parametros);
                while (dr.Read())
                {
                    datos.IDGradoEstudio = dr["id_gradoEstudio"].ToString();
                    datos.Descripcion = dr["descripcion"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CatGradoEstudioProfesorModels AbcCatGradoEstudioProfesor(CatGradoEstudioProfesorModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDGradoEstudio, datos.Descripcion,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatGradoEstudioProfesor", parametros);
                datos.IDGradoEstudio = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDGradoEstudio))
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