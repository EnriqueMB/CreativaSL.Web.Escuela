using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatTutorXAlumno_Datos
    {
        public CatTutorXalumnoModels ObtenerCatTutorXAlumno(CatTutorXalumnoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_CatTutorXAlumno", datos.IDAlumno);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaTutor = ds.Tables[0];
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

        public void abcTutorXAlumno(CatTutorXalumnoModels datos)
        {
            try
            {
                string[] id_tutores;
                if (!string.IsNullOrEmpty(datos.IDTutor))
                {
                    if (datos.IDTutor.Contains(","))
                    {
                        id_tutores = datos.IDTutor.Split(',');
                    }
                    else
                    {
                        id_tutores = new string[] { datos.IDTutor };
                    }
                }
                else
                {
                    id_tutores = new string[] { string.Empty };
                }

                foreach (string id_tutor in id_tutores)
                {
                    object[] parametros =
                    {
                    datos.opcion, datos.IDAlumno, id_tutor, datos.user
                    };
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatTutorXalumno", parametros);
                    datos.IDAlumno = aux.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatTutorXalumnoModels AbcCatTutorXAlumnoModiBorr(CatTutorXalumnoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDAlumno, datos.IDTutor, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatTutorXalumno", parametros);
                datos.IDAlumno = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CatTutorModels> obtenerComboCatTutorXalumno(CatTutorXalumnoModels datos)
        {
            try
            {
                List<CatTutorModels> lista = new List<CatTutorModels>();
                CatTutorModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatTutor", datos.IDAlumno);
                while (dr.Read())
                {
                    item = new CatTutorModels();
                    item.IDPersona = dr["id_persona"].ToString();
                    item.Nombre = dr["nombreCompleto"].ToString();
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