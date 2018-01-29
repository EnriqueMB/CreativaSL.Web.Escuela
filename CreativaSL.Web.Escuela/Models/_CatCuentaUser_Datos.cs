using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSL.Web.Escuela.Models
{
    public class CatCuentaUser_Datos
    {
        public CatCuentaUserModels AbcCambiarContraseña(CatCuentaUserModels datos)
        {
            try
            {

                object[] parametros =
                {
                    datos.id_cuenta, datos.passUser, datos.passActualizado,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_V2_set_CatCuentaUser", parametros);
                datos.id_cuenta = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatCuentaUserModels ValidadCuenta(CatCuentaUserModels datos)
        {
            try
            {
                object[] parametros = { datos.id_cuenta, datos.validado, datos.user };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatValidarCuenta", parametros);
                datos.id_cuenta = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}