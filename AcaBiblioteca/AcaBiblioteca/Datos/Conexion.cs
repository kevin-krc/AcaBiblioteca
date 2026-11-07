using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
namespace AcaBiblioteca.Datos
{
    public class Conexion
    {
        private string cadenaConexion = "Server=KEVIN;Database=AcaBiblioteca;Integrated Security=true;TrustServerCertificate=true;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

    }

}