using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class Asignatura
    {
        private string _IDAsignatura;

        public string IDAsignatura
        {
            get { return _IDAsignatura; }
            set { _IDAsignatura = value; }
        }

        private string _IDCiclo;

        public string IDCiclo
        {
            get { return _IDCiclo; }
            set { _IDCiclo = value; }
        }

        private string _IDMateria;

        public string IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        private string _IDHorario;

        public string IDHorario
        {
            get { return _IDHorario; }
            set { _IDHorario = value; }
        }

        private string _IDProfesor;

        public string IDProfesor
        {
            get { return _IDProfesor; }
            set { _IDProfesor = value; }
        }

        private string _IDAula;

        public string IDAula
        {
            get { return _IDAula; }
            set { _IDAula = value; }
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