using System;
using System.Data;
using System.Data.SqlClient;
using GymSystemEntity;
using GymSystemData;

namespace GymSystemDataSQLServer
{
    public class SalaDA
    {
        //private SalaDA salaDA;
        public SalaDA()
        {
            //salaDA = new SalaDA();
        }

        #region Métodos Privados


        private SalaEntity CrearSala(SqlDataReader cursor)
        {
            SalaEntity sala = new SalaEntity();
            sala.IdSala = cursor.GetInt32(cursor.GetOrdinal("IdSala"));
            sala.Nombre = cursor.GetString(cursor.GetOrdinal("nombre"));
            sala.Numero = Int32.Parse((cursor.GetString(cursor.GetOrdinal("numero"))));
            sala.Capacidad = cursor.GetInt32(cursor.GetOrdinal("capacidad"));
            return sala;
        }
        #endregion Métodos Privados

        public SalaEntity[] ListarSalas()
        {
            try
            {
                SalaEntity[] salas = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SalaTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            int i = 0;
                            salas = new SalaEntity[cursor.FieldCount];

                            while (cursor.Read())
                            {
                                salas[i] = CrearSala(cursor);
                                i++;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }

                return salas;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
    }
}