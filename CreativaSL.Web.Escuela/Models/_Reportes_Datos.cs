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
    public class _Reportes_Datos
    {
        public void actualizarDetalleNotificacion(ReportesModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_NotificacionDetalleActualizar",
                    new SqlParameter("@TablaNotificacion", datos.TablaNotificacionXTipo)
                     );

                if (dr != null)
                {
                    if (dr.Tables.Count == 1)
                    {


                        DataTableReader DTR = dr.Tables[0].CreateDataReader();
                        DataTable Tbl1 = dr.Tables[0];
                        while (DTR.Read())
                        {
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void insertarNotificacion(ReportesModels datos)
        {

            try
            {
                datos.Completado = false;
                //int Resultado = 0;
                DataSet dr = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_V2_set_NotificacionReportes",
                  
                     new SqlParameter("@id_registro", datos.id_registro),
                     new SqlParameter("@IDGrupo", datos.id_grupo),
                     new SqlParameter("@IDCurso", datos.id_curso),
                     new SqlParameter("@id_alumno",datos.id_alumno),
                     new SqlParameter("@IDTipoNotificacion", datos.id_tipo_notificacion),
                    
                     //new SqlParameter("@titulo", datos.titulo),
                     //new SqlParameter("@resumen", datos.resumen),
                     //new SqlParameter("@texto", datos.texto),
                    
                    
                     new SqlParameter("@IDUsuario", datos.user)

                     );

                if (dr != null)
                {
                    if (dr.Tables.Count == 2)
                    {
                        datos.TablaAlumnos = dr.Tables[0];

                        DataTableReader DTR = dr.Tables[1].CreateDataReader();
                        DataTable Tbl1 = dr.Tables[1];
                        while (DTR.Read())
                        {
                            datos.Resultado = !DTR.IsDBNull(DTR.GetOrdinal("resultado")) ? DTR.GetInt32(DTR.GetOrdinal("resultado")) : 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ReportesModels ObtenerReporteDetalle(ReportesModels Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.conexion, "spCSLDB_V2_get_Reporte", Datos.fechaReporte, Datos.id_grupo,Datos.id_curso);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        List<ReportesModels> ListaPrinc = new List<ReportesModels>();
                       
                        ReportesModels Item;
                        DataTableReader DTR = Ds.Tables[0].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[0];
                        while (DTR.Read())
                        {
                            Item = new ReportesModels();
                            Item.ListaReportes = new List<ReportesModels>();
                            Item.ListEventos = new List<ReportesModels>();
                            Item.ListTareas= new List<ReportesModels>();
                            Item.ListAsistencia = new List<ReportesModels>();
                            Item.ListExamen = new List<ReportesModels>();
                            Item.resultado = !DTR.IsDBNull(DTR.GetOrdinal("Resultado")) ? DTR.GetInt32(DTR.GetOrdinal("Resultado")) : 0;
                            Item.NombreMateria = !DTR.IsDBNull(DTR.GetOrdinal("NombreMateria")) ? DTR.GetString(DTR.GetOrdinal("NombreMateria")) : string.Empty;
                            Item.NombreMaestro = !DTR.IsDBNull(DTR.GetOrdinal("NombreMaestro")) ? DTR.GetString(DTR.GetOrdinal("NombreMaestro")) : string.Empty;
                            Item.NombreLista = !DTR.IsDBNull(DTR.GetOrdinal("NombreLista")) ? DTR.GetString(DTR.GetOrdinal("NombreLista")) : string.Empty;
                           // Item.UrlMenu = !DTR.IsDBNull(DTR.GetOrdinal("UrlMenu")) ? DTR.GetString(DTR.GetOrdinal("UrlMenu")) : string.Empty;
                            //Item.IDFranquicia = !DTR.IsDBNull(0) ? DTR.GetString(0) : string.Empty;
                            //Item.Descripcion = !DTR.IsDBNull(1) ? DTR.GetString(1) : string.Empty;

                            //string Aux = DTR.GetString(2);
                            string Aux = !DTR.IsDBNull(DTR.GetOrdinal("TablaDetalle")) ? DTR.GetString(DTR.GetOrdinal("TablaDetalle")) : string.Empty;
                            Aux = string.Format("<Main>{0}</Main>", Aux);
                            XmlDocument xm = new XmlDocument();
                            xm.LoadXml(Aux);
                            XmlNodeList Registros = xm.GetElementsByTagName("Main");
                            XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("C");
                            List<ReportesModels> ListaAux = new List<ReportesModels>();
                            ReportesModels ItemAux;
                            foreach (XmlElement Nodo in Lista)
                            {
                                if (Item.resultado == 111) {
                                    ItemAux = new ReportesModels();
                                    XmlNodeList id_examen = Nodo.GetElementsByTagName("id_examen");
                                    XmlNodeList id_alumno = Nodo.GetElementsByTagName("id_alumno");
                                    XmlNodeList NumControl = Nodo.GetElementsByTagName("NumControl");
                                    XmlNodeList NombreAlumno = Nodo.GetElementsByTagName("NombreAlumno");
                                    XmlNodeList calificacion = Nodo.GetElementsByTagName("calificacion");
                                    float Ca = 0;
                                    float.TryParse(calificacion[0].InnerText, out Ca);
                                    ItemAux.calificacion = Ca;
                                    ItemAux.NumControl = NumControl[0].InnerText;
                                    ItemAux.NombreAlumno = NombreAlumno[0].InnerText;
                                    ItemAux.id_examen = id_examen[0].InnerText;
                                    ItemAux.id_alumno = id_alumno[0].InnerText;
                                    Item.ListExamen.Add(ItemAux);
                                }
                                else if (Item.resultado == 110)
                                {
                                    ItemAux = new ReportesModels();
                                    XmlNodeList id_evento = Nodo.GetElementsByTagName("id_evento");
                                    XmlNodeList id_alumno = Nodo.GetElementsByTagName("id_alumno");
                                    XmlNodeList NumControl = Nodo.GetElementsByTagName("NumControl");
                                    XmlNodeList NombreAlumno = Nodo.GetElementsByTagName("NombreAlumno");
                                    XmlNodeList calificacion = Nodo.GetElementsByTagName("calificacion");
                                    float Ca = 0;
                                    float.TryParse(calificacion[0].InnerText, out Ca);
                                    ItemAux.calificacion = Ca;
                                    ItemAux.NumControl = NumControl[0].InnerText;
                                    ItemAux.NombreAlumno = NombreAlumno[0].InnerText;
                                    ItemAux.id_evento = id_evento[0].InnerText;
                                    ItemAux.id_alumno = id_alumno[0].InnerText;
                                    Item.ListEventos.Add(ItemAux);
                                }
                                else if (Item.resultado == 112)
                                {
                                    ItemAux = new ReportesModels();
                                    XmlNodeList id_tarea = Nodo.GetElementsByTagName("id_tarea");
                                    XmlNodeList id_alumno = Nodo.GetElementsByTagName("id_alumno");
                                    XmlNodeList NumControl = Nodo.GetElementsByTagName("NumControl");
                                    XmlNodeList NombreAlumno = Nodo.GetElementsByTagName("NombreAlumno");
                                    XmlNodeList calificacion = Nodo.GetElementsByTagName("calificacion");
                                    float Ca = 0;
                                    float.TryParse(calificacion[0].InnerText, out Ca);
                                    ItemAux.calificacion = Ca;
                                    ItemAux.NumControl = NumControl[0].InnerText;
                                    ItemAux.NombreAlumno = NombreAlumno[0].InnerText;
                                    ItemAux.id_tarea = id_tarea[0].InnerText;
                                    ItemAux.id_alumno = id_alumno[0].InnerText;
                                    Item.ListTareas.Add(ItemAux);
                                }
                               else if (Item.resultado == 113)
                                {
                                    ItemAux = new ReportesModels();
                                    XmlNodeList id_lista = Nodo.GetElementsByTagName("id_lista");
                                    XmlNodeList id_alumno = Nodo.GetElementsByTagName("id_alumno");
                                    XmlNodeList NumControl = Nodo.GetElementsByTagName("NumControl");
                                    XmlNodeList NombreAlumno = Nodo.GetElementsByTagName("NombreAlumno");
                                    
                                    ItemAux.id_lista = id_lista[0].InnerText;
                                    ItemAux.NumControl = NumControl[0].InnerText;
                                    ItemAux.NombreAlumno = NombreAlumno[0].InnerText;
                                   
                                    ItemAux.id_alumno = id_alumno[0].InnerText;
                                    Item.ListAsistencia.Add(ItemAux);
                                    
                                }

                            }
                                
                            //AGREGAR AQUI LOS ELEMENTOS DE LOS ITEMS
                            ListaPrinc.Add(Item);
                            
                        }
                        Datos.resultado110 = ListaPrinc.FindAll(x => x.resultado == 110);
                        Datos.resultado111 = ListaPrinc.FindAll(x => x.resultado == 111);
                        Datos.resultado112 = ListaPrinc.FindAll(x => x.resultado == 112);
                        Datos.resultado113 = ListaPrinc.FindAll(x => x.resultado == 113);
                        Datos.ListaMenu = ListaPrinc;
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public List<CatGrupoModels> ObtenerComboCatGrupoMaterias(ReportesModels datos)
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
        public List<CatGrupoModels> ObtenerComboCatGrupo(ReportesModels datos)
        {
            try
            {
                List<CatGrupoModels> lista = new List<CatGrupoModels>();
                CatGrupoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatGrupoXID", datos.ciclo, datos.IDEspecialidad, datos.curso);
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
        public List<CatEspecialidadModels> ObtenerComboCatEspecialidad(ReportesModels datos)
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
        public List<CatCursoModels> ObtenerComboCatCursos(ReportesModels datos)
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
        public List<CatModalidadModels> ObtenerComboCatModalidad(ReportesModels datos)
        {
            try
            {
                List<CatModalidadModels> lista = new List<CatModalidadModels>();
                CatModalidadModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_V2_get_ComboCatModalidadXID", datos.idplanEstudio);//enviar 1 por default
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
        public List<CatPlanEstudioModels> ObtenerComboCatPlanEstudio(ReportesModels datos)
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
        public List<CatCicloEscolarModels> ObtenerComboCatCicloEscolar(ReportesModels datos)
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

    }
}