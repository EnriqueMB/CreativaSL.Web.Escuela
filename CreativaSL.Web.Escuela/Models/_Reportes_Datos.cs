using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class _Reportes_Datos
    {
        public List<CatCatedraticoModels> ObtenerComboProfesor(ReportesModels datos)
        {
            try
            {
                List<CatCatedraticoModels> lista = new List<CatCatedraticoModels>();
                CatCatedraticoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatProfesorReporte");
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
        public List<CatMateriaModels> ObtenerComboCatMaterias(ReportesModels datos)
        {
            try
            {
                List<CatMateriaModels> lista = new List<CatMateriaModels>();
                CatMateriaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatMateriaReporte",datos.id_profesor);
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
        public List<CatGrupoModels> ObtenerComboCatGrupo(ReportesModels datos)
        {
            try
            {
                List<CatGrupoModels> lista = new List<CatGrupoModels>();
                CatGrupoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatMateriaReporte", datos.id_profesor);
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

    }
}