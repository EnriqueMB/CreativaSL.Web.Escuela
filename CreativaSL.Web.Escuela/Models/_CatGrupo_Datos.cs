using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatGrupo_Datos
    {
        public CatGrupoModels AbcCatGrupo(CatGrupoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.IDGrupo, datos.Clave, datos.Nombre, datos.IDCiclo, datos.IDEspecialidad, datos.IDCurso,
                    datos.IDModalidad, datos.IDPlanEstudio, datos.ExtraEscolar, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_abc_CatGrupo", parametros);
                datos.IDGrupo = aux.ToString();
                if (!string.IsNullOrEmpty(datos.IDGrupo))
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

        public CatGrupoModels ObtenerCatGrupo(CatGrupoModels Datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatGrupo");
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

        public CatGrupoModels ObtenerDetalleCatGrupo(CatGrupoModels datos)
        {
            try
            {
                object[] parametros = { datos.IDGrupo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_CatGrupoXID", parametros);
                while (dr.Read())
                {

                    datos.IDGrupo = dr.GetString(dr.GetOrdinal("IDGrupo"));
                    datos.Clave = dr.GetString(dr.GetOrdinal("Clave"));
                    datos.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                    datos.IDCiclo = dr.GetString(dr.GetOrdinal("IDCiclo"));
                    datos.IDEspecialidad = dr.GetString(dr.GetOrdinal("IDEspecialidad"));
                    datos.IDCurso = dr.GetString(dr.GetOrdinal("IDCurso"));
                    datos.IDModalidad = dr.GetString(dr.GetOrdinal("IDModalidad"));
                    datos.IDPlanEstudio = dr.GetInt32(dr.GetOrdinal("IDPlanEstudio"));
                    datos.ExtraEscolar = dr.GetBoolean(dr.GetOrdinal("ExtraEscolar"));
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(CatGrupoModels datos)
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

        public List<CatPlanEstudioModels> ObtenerComboCatPlanEstudio(CatGrupoModels datos)
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

        public List<CatModalidadModels> ObtenerComboCatModalidad(CatGrupoModels datos)
        {
            try
            {
                List<CatModalidadModels> lista = new List<CatModalidadModels>();
                CatModalidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidadXID", datos.IDPlanEstudio);
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

        public List<CatEspecialidadModels> ObtenerComboCatEspecialidad(CatGrupoModels datos)
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

        public List<CatCursoModels> ObtenerComboCatCursos(CatGrupoModels datos)
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

        public CatGrupoModels ObtenerListAlumnos(CatGrupoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_V2_get_AlumnosXGrupo", datos.IDGrupo);
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

        public List<CatAlumnoModels> ObtenerComboAlumnosInscripcion(CatAlumnosXGrupoModels datos)
        {
            try
            {
                List<CatAlumnoModels> Lista = new List<CatAlumnoModels>();
                CatAlumnoModels Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_comboAlumnosInscripcion");
                while (dr.Read())
                {
                    Item = new CatAlumnoModels();
                    Item.IDPersona = dr.GetString(dr.GetOrdinal("IDAlumno"));
                    Item.nombre = dr.GetString(dr.GetOrdinal("NombreAlumno"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatGrupoModels ObtenerMateriaPRofesr(CatGrupoModels Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_CatAsignarMateriaYProfesor", Datos.IDGrupo, Datos.IDCurso);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        List<CatGrupoModels> ListaPrinc = new List<CatGrupoModels>();
                        CatGrupoModels Item;
                        DataTableReader DTR = Ds.Tables[0].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[0];
                        while (DTR.Read())
                        {
                            Item = new CatGrupoModels();
                            Item.ListaGrupoDetalle = new List<CatGrupoModels>();
                            Item.IDAsignacion = !DTR.IsDBNull(DTR.GetOrdinal("IDAsignatura")) ? DTR.GetString(DTR.GetOrdinal("IDAsignatura")) : string.Empty;
                            Item.IDMateria = !DTR.IsDBNull(DTR.GetOrdinal("IDMateria")) ? DTR.GetString(DTR.GetOrdinal("IDMateria")) : string.Empty;
                            Item.NombreMateria = !DTR.IsDBNull(DTR.GetOrdinal("NombreMateria")) ? DTR.GetString(DTR.GetOrdinal("NombreMateria")) : string.Empty;
                            //string Aux = DTR.GetString(2);
                            string Aux = !DTR.IsDBNull(DTR.GetOrdinal("TablaProfesores")) ? DTR.GetString(DTR.GetOrdinal("TablaProfesores")) : string.Empty;
                            Aux = string.Format("<Main>{0}</Main>", Aux);
                            XmlDocument xm = new XmlDocument();
                            xm.LoadXml(Aux);
                            XmlNodeList Registros = xm.GetElementsByTagName("Main");
                            XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("AB");
                            List<CatGrupoModels> ListaAux = new List<CatGrupoModels>();
                            CatGrupoModels ItemAux;
                            foreach (XmlElement Nodo in Lista)
                            {
                                ItemAux = new CatGrupoModels();
                                XmlNodeList IDProfesor = Nodo.GetElementsByTagName("IDProfesor");
                                XmlNodeList IDProfesorR = Nodo.GetElementsByTagName("IDProfesorR");
                                XmlNodeList NombreProfesor = Nodo.GetElementsByTagName("NombreProfesor");
                                ItemAux.IDProfesor = IDProfesor[0].InnerText;
                                ItemAux.IDProfesorR = IDProfesorR[0].InnerText;
                                ItemAux.NombreProfesor = NombreProfesor[0].InnerText;
                                Item.ListaGrupoDetalle.Add(ItemAux);
                            }
                            ListaPrinc.Add(Item);
                        }
                        Datos.ListaGrupoMateria = ListaPrinc;
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AMateriaPorProfesor(CatGrupoModels Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_abc_Asignatura",
                     new SqlParameter("@IDGrupo", Datos.IDGrupo),
                     new SqlParameter("@MateriaProfe", Datos.TablaMateria),
                     new SqlParameter("@usuario", Datos.user)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    else
                    {
                        Datos.Completado = false;
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}