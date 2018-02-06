using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatAlumnoXGrupo_Datos
    {
        #region Datos Profesor

        public CatAlumnosXGrupoModels ObtenerCatAlumnoXGrupoPROF(CatAlumnosXGrupoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_ListaDAlumnoXasignatura", datos.IDAsignatura, datos.IDProfesor, datos.IDMateria);
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

        #endregion
    }
}