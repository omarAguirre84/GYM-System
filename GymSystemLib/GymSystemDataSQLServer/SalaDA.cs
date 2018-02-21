using System;
using System.Data;
using System.Data.SqlClient;
using GymSystemEntity;
using GymSystemData;
using System.Collections.Generic;

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

        public List<SalaEntity> ListarSalas()
        {
            try
            {
                List<SalaEntity> salas = new List<SalaEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SalaTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            while (cursor.Read())
                            {
                                salas.Add(CrearSala(cursor));
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

        public SalaEntity BuscarSala(String nombre)
        {
            SalaEntity salaEntity = null;
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SalaBuscarPorNombre", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@nombre"].Value = nombre.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                if (salaEntity == null)
                                {
                                    salaEntity = new SalaEntity();
                                }
                                salaEntity = CrearSala(cursor);
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar sala por nombre.", ex);
            }
            return salaEntity;
        }

        public SalaEntity BuscarSala(int idSala)
        {
            SalaEntity salaEntity = null;
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SalaBuscarPorId", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idSala"].Value = idSala;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                if (salaEntity == null)
                                {
                                    salaEntity = new SalaEntity();
                                }
                                salaEntity = CrearSala(cursor);
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar sala por nombre.", ex);
            }
            return salaEntity;
        }

        public void InsertSala(SalaEntity salaEntity)
        {
            try
            {
                SqlCommand comando = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (comando = new SqlCommand("SalaInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@nombre"].Value = salaEntity.Nombre.Trim();
                        comando.Parameters["@numero"].Value = salaEntity.Numero;
                        comando.Parameters["@capacidad"].Value = salaEntity.Capacidad;
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al crear sala.", ex);
            }
        }

        public void ActualizarSala(SalaEntity salaEntity)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SalaActualizarTodo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idSala"].Value = salaEntity.IdSala;
                        comando.Parameters["@nombre"].Value = salaEntity.Nombre.Trim();
                        comando.Parameters["@numero"].Value = salaEntity.Numero;
                        comando.Parameters["@capacidad"].Value = salaEntity.Capacidad;
                        
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar el sala.", ex);
            }
        }
    }
}