using System.Data.SqlClient;
using System.Configuration;

namespace GymSystemDataSQLServer
{
    internal class ConexionDA
    {
        private ConexionDA()
        {
        }

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CONECTION_DB_GYM"].ConnectionString);
            conexion.Open();

            return conexion;
        }
    }
}
