using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using GymSystemEntity;
using GymSystemData;

namespace GymSystemDataSQLServer
{
    public class EmpleadoDA
    {
        public EmpleadoDA()
        {
        }

        #region Métodos Privados
        private EmpleadoEntity CrearUsuario(SqlDataReader cursor)
        {
            EmpleadoEntity empleado = new EmpleadoEntity();
            empleado.Id = cursor.GetInt32(cursor.GetOrdinal("PersonaID"));
            empleado.Nombre = cursor.GetString(cursor.GetOrdinal("PersonaNombre"));
            empleado.Apellido = cursor.GetString(cursor.GetOrdinal("PersonaApellido"));
            empleado.Email = cursor.GetString(cursor.GetOrdinal("PersonaEmail"));
            empleado.Password = cursor.GetString(cursor.GetOrdinal("PersonaPassword"));
            empleado.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("PersonaFechaNacimiento"));
            empleado.Sexo = cursor.GetString(cursor.GetOrdinal("PersonaSexo"))[0];
            empleado.EsProfesor = cursor.GetString(cursor.GetOrdinal("PersonaProfesor"))[0];
            if (!cursor.IsDBNull(cursor.GetOrdinal("PersonaFoto")))
                empleado.Foto = cursor.GetString(cursor.GetOrdinal("PersonaFoto"));

            empleado.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("PersonaFechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("PersonaFechaActualizacion")))
                empleado.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("PersonaFechaActualizacion"));

            return empleado;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(EmpleadoEntity usuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@PersonaNombre"].Value = usuario.Nombre.Trim();
                        comando.Parameters["@PersonaApellido"].Value = usuario.Apellido.Trim();
                        comando.Parameters["@PersonaEmail"].Value = usuario.Email.Trim();
                        comando.Parameters["@PersonaPassword"].Value = usuario.Password.Trim();
                        comando.Parameters["@PersonaFechaNacimiento"].Value = usuario.FechaNacimiento;
                        comando.Parameters["@PersonaSexo"].Value = usuario.Sexo;
                        comando.Parameters["@PersonaProfesor"].Value = usuario.EsProfesor;
                        comando.Parameters["@PersonaFechaRegistracion"].Value = usuario.FechaRegistracion;
                        comando.ExecuteNonQuery();
                        usuario.Id = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);
                    }
                    
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }

        public void Actualizar(int id, string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                FileInfo infoArchivo = new FileInfo(nombreArchivo);
                
                string rutaFotos = ConfigurationManager.AppSettings["RutaFotos"];
                string nuevoNombreArchivo = id.ToString() + infoArchivo.Extension;

                using (FileStream archivo = File.Create(rutaFotos + nuevoNombreArchivo))
                {
                    archivo.Write(archivoFoto, 0, archivoFoto.Length);
                    archivo.Close();
                }
                
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaActualizarFoto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@PersonaID"].Value = id;
                        comando.Parameters["@PersonaFoto"].Value = nuevoNombreArchivo;
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar la foto.", ex);
            }
        }

        public bool ExisteEmail(string email)
        {
            try
            {
                bool existeEmail;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaBuscarEmail", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@PersonaEmail"].Value = email.Trim();
                        existeEmail = Convert.ToBoolean(comando.ExecuteScalar());
                    }

                    conexion.Close();
                }

                return existeEmail;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email.", ex);
            }
        }

        public EmpleadoEntity BuscarUsuario(string email, string password)
        {
            try
            {
                EmpleadoEntity usuario = null;
                
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@PersonaEmail"].Value = email.Trim();
                        comando.Parameters["@PersonaPassword"].Value = password.Trim();
                        
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                usuario = CrearUsuario(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public EmpleadoEntity ListarUsuarios()
        {
            try
            {
                EmpleadoEntity usuario = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandText = "SELECT * FROM Personas ORDER BY PersonaId";
                        comando.CommandType = CommandType.Text;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                usuario = CrearUsuario(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
