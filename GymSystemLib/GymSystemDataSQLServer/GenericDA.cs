using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using GymSystemEntity;
using GymSystemData;

namespace GymSystemDataSQLServer
{
    public class GenericDA
    {
        public GenericDA()
        {
        }

        public GenericEntity GetListParaAdmin()
        {
            try
            {
               
                GenericEntity generic = new GenericEntity();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("[ListaTotalParaAdmin]", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            while (cursor.Read())
                            {
                                generic.Salas = cursor.GetInt32(cursor.GetOrdinal("Salas"));
                                generic.Profesores = cursor.GetInt32(cursor.GetOrdinal("Profesores")); ;
                                generic.Actividades = cursor.GetInt32(cursor.GetOrdinal("Actividades")); ;
                                generic.Socios = cursor.GetInt32(cursor.GetOrdinal("Socios")); ;
                                generic.Adminitradores = cursor.GetInt32(cursor.GetOrdinal("Administradores")); ;
                                // actividad.Add(CrearActividad(cursor));

                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return generic;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al ListaTotalParaAdmin", ex);
            }
        }

    }
}
