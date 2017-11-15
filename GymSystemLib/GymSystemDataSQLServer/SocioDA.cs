using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystemEntity;
using GymSystemData;

namespace GymSystemDataSQLServer
{
    public class SocioDA
    {
        public SocioDA()
        {
        }
        public List<SocioEntity> ListarSocios()
        {
            try
            {
                List<SocioEntity> socios = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandText = "SELECT * FROM Socio ORDER BY idSocio";
                        comando.CommandType = CommandType.Text;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {

                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return socios;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
    }
}
