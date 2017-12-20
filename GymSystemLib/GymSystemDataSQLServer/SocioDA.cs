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
using System.Diagnostics;

namespace GymSystemDataSQLServer
{
    public class SocioDA : PersonaDA
    {
        public SocioDA()
        {
        }

        #region Métodos Privados

        
        private SocioEntity CrearSocio(SqlDataReader cursor)
        {
            SocioEntity socio = new SocioEntity(
                cursor.GetInt32(cursor.GetOrdinal("nroTarjetaIdentificacion")), 
                cursor.GetInt32(cursor.GetOrdinal("idEstado")));
            socio.Estado = cursor.GetString(cursor.GetOrdinal("Descripcion"));

            socio.idPersona = cursor.GetInt32(cursor.GetOrdinal("idPersona"));
            socio.tipoPersona = cursor.GetString(cursor.GetOrdinal("TipoPersona"))[0];
            socio.Telefono = cursor.GetInt32(cursor.GetOrdinal("Telefono"));
            socio.Nombre = cursor.GetString(cursor.GetOrdinal("Nombre"));
            socio.Apellido = cursor.GetString(cursor.GetOrdinal("Apellido"));
            socio.Dni = System.Convert.ToInt32(cursor.GetString(cursor.GetOrdinal("Dni")));
            socio.Email = cursor.GetString(cursor.GetOrdinal("Email"));
            socio.Password = cursor.GetString(cursor.GetOrdinal("Password"));
            socio.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("FechaNacimiento"));
            socio.Sexo = cursor.GetString(cursor.GetOrdinal("Sexo"))[0];
            if (!cursor.IsDBNull(cursor.GetOrdinal("Foto"))) {
                socio.Foto = cursor.GetString(cursor.GetOrdinal("Foto"));
            }
            socio.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("FechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("FechaActualizacion"))) {
                socio.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("FechaActualizacion"));
            }

            return socio;   
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(SocioEntity socio)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SocioInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Dni"].Value = socio.Dni;
                        comando.Parameters["@Nombre"].Value = socio.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = socio.Apellido.Trim();
                        comando.Parameters["@Telefono"].Value = socio.Telefono;
                        comando.Parameters["@Email"].Value = socio.Email.Trim();
                        comando.Parameters["@Password"].Value = socio.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = socio.FechaNacimiento;
                        comando.Parameters["@Sexo"].Value = socio.Sexo;
                        comando.Parameters["@TipoPersona"].Value = socio.tipoPersona;
                        comando.Parameters["@FechaRegistracion"].Value = socio.FechaRegistracion;
                        comando.Parameters["@FechaActualizacion"].Value = socio.FechaActualizacion;
                        comando.Parameters["@NroTarjetaIdentificacion"].Value = socio.nroTarjetaIdentificacion;
                        comando.Parameters["@idEstado"].Value = socio.idEstado;
                        comando.Parameters["@Estado"].Value = socio.Estado;
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }

        public void ActualizarFoto(int id, string nombreArchivo, byte[] archivoFoto)
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
                    using (SqlCommand comando = new SqlCommand("ActualizarFoto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idpersona"].Value = id;
                        comando.Parameters["@Foto"].Value = nuevoNombreArchivo;
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

                        comando.Parameters["@Email"].Value = email.Trim();
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

        public SocioEntity BuscarSocio(string email, string password)
        {
            try
            {
                SocioEntity socio = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SocioBuscarPorMailPassword", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Email"].Value = email.Trim();
                        comando.Parameters["@Password"].Value = password.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                socio = CrearSocio(cursor);
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return socio;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public SocioEntity[] ListarSocios()
        {
            try
            {
                SocioEntity[] socios = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SocioTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            int i = 0;
                            socios = new SocioEntity[cursor.FieldCount];

                            while (cursor.Read())
                            {
                                socios[i] = CrearSocio(cursor);
                                i++;
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

        public void ActualizarSocio(SocioEntity socio)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SocioActualizarTodo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idPersona"].Value = socio.idPersona;
                        comando.Parameters["@Dni"].Value = socio.Dni;
                        comando.Parameters["@Nombre"].Value = socio.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = socio.Apellido.Trim();
                        comando.Parameters["@Telefono"].Value = socio.Telefono;
                        comando.Parameters["@Email"].Value = socio.Email.Trim();
                        comando.Parameters["@Password"].Value = socio.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = socio.FechaNacimiento.Date.ToString("yyyy-MM-dd");
                        comando.Parameters["@Sexo"].Value = socio.Sexo;
                        comando.Parameters["@TipoPersona"].Value = socio.tipoPersona;
                        comando.Parameters["@FechaActualizacion"].Value = socio.FechaActualizacion.Date.ToString("yyyy-MM-dd HH:mm:ss");
                        comando.Parameters["@NroTarjetaIdentificacion"].Value = socio.nroTarjetaIdentificacion;
                        comando.Parameters["@idEstado"].Value = socio.idEstado;
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

        public SocioEntity BuscarSocio(int idPersona) {
            try
            {
                SocioEntity socio = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SocioBuscarId", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idPersona"].Value = idPersona;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                socio = CrearSocio(cursor);
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return socio;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por ID.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
