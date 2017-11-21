using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
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
                List<SocioEntity> socios = new List<SocioEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SELECT * FROM [persona]", conexion))
                    {
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            while (cursor.Read())
                            {
                                SocioEntity socEnt = new SocioEntity(
                                    int.Parse(cursor["idSocio"].ToString()),
                                    int.Parse(cursor["nroTarjetaIdentificacion"].ToString()),
                                    int.Parse(cursor["idEstado"].ToString()),
                                    int.Parse(cursor["PersonaId"].ToString()),
                                    cursor["cuota"].ToString(),
                                    cursor["saldo"].ToString());
                                socios.Add(socEnt);
                                Console.WriteLine(cursor.GetString(0));
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
