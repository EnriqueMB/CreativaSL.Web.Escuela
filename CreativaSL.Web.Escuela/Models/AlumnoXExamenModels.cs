﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CreativaSL.Web.Escuela.Models
{
    public class AlumnoXExamenModels
    {
        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private string _IDExamen;

        public string IDExamen
        {
            get { return _IDExamen; }
            set { _IDExamen = value; }
        }

        private string _IDAlumno;

        public string IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private float _Calificacion;
        [Required(ErrorMessage = "Calificacion")]
        [Display(Name = "Calificacion")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Solo números")]
        //^[0-9]+(\.[0-9]{1,2})?$
        public float Calificacion
        {
            get { return _Calificacion; }
            set { _Calificacion = value; }
        }

        private DataTable  _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private DataTable _TablaCalificacionExamen;

        public DataTable TablaCalificacionExamen
        {
            get { return _TablaCalificacionExamen; }
            set { _TablaCalificacionExamen = value; }
        }

        private DataTable _TablaNotificacion;

        public DataTable TablaNotificacion
        {
            get { return _TablaNotificacion; }
            set { _TablaNotificacion = value; }
        }

        private int _NumeroAlumnos;

        public int NumeroAlumnos
        {
            get { return _NumeroAlumnos; }
            set { _NumeroAlumnos = value; }
        }

        private string _NombreExamen;

        public string NombreExamen
        {
            get { return _NombreExamen; }
            set { _NombreExamen = value; }
        }

        private DateTime _FechaExamen;

        public DateTime FechaExamen
        {
            get { return _FechaExamen; }
            set { _FechaExamen = value; }
        }

        private string _NombreMateria;

        public string NombreMateria
        {
            get { return _NombreMateria; }
            set { _NombreMateria = value; }
        }

        private string _Resumen;

        public string Resumen
        {
            get { return _Resumen; }
            set { _Resumen = value; }
        }

        private string _NombreProfesor;

        public string NombreProfesor
        {
            get { return _NombreProfesor; }
            set { _NombreProfesor = value; }
        }

        private bool _EnviarTarea;

        public bool EnviarTarea
        {
            get { return _EnviarTarea; }
            set { _EnviarTarea = value; }
        }

        private string _Cadena;

        public string Cadena
        {
            get { return _Cadena; }
            set { _Cadena = value; }
        }

        private string _CadenaFinal;

        public string CadenaFinal
        {
            get { return _CadenaFinal; }
            set { _CadenaFinal = value; }
        }

        private string _IDNofificacionDetalle;

        public string IDNotificacionDetalle
        {
            get { return _IDNofificacionDetalle; }
            set { _IDNofificacionDetalle = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private DataTable _TablaCadenaNotificacion;

        public DataTable TablaCadenaNotificacion
        {
            get { return _TablaCadenaNotificacion; }
            set { _TablaCadenaNotificacion = value; }
        }
        

        #region Datos de control
        public int Resultado { get; set; }
        public bool Completado { get; set; }
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}