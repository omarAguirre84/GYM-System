﻿using System;
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
    public class PersonaDA
    {
        public PersonaDA()
        {
        }

        #region Métodos Privados
        private PersonaEntity CrearUsuario(SqlDataReader cursor)
        {
            PersonaEntity usuario = new SocioEntity();
            usuario.Id = cursor.GetInt32(cursor.GetOrdinal("idpersona"));
            usuario.Nombre = cursor.GetString(cursor.GetOrdinal("Nombre"));
            usuario.Apellido = cursor.GetString(cursor.GetOrdinal("Apellido"));
            usuario.Email = cursor.GetString(cursor.GetOrdinal("Email"));
            usuario.Password = cursor.GetString(cursor.GetOrdinal("Password"));
            usuario.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("FechaNacimiento"));
            usuario.Sexo = cursor.GetString(cursor.GetOrdinal("Sexo"))[0];
            usuario.tipoPersona = cursor.GetString(cursor.GetOrdinal("TipoPersona"))[0];
            if (!cursor.IsDBNull(cursor.GetOrdinal("Foto")))
                usuario.Foto = cursor.GetString(cursor.GetOrdinal("Foto"));

            usuario.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("FechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("FechaActualizacion")))
                usuario.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("FechaActualizacion"));

            return usuario;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(PersonaEntity usuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Nombre"].Value = usuario.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = usuario.Apellido.Trim();
                        comando.Parameters["@Email"].Value = usuario.Email.Trim();
                        comando.Parameters["@Password"].Value = usuario.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = usuario.FechaNacimiento;
                        comando.Parameters["@Sexo"].Value = usuario.Sexo;
                        comando.Parameters["@Profesor"].Value = usuario.tipoPersona;
                        comando.Parameters["@FechaRegistracion"].Value = usuario.FechaRegistracion;
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

        public SqlCommand InsertarPersona(PersonaEntity usuario, SqlCommand comando, SqlConnection conexion)
        {
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(comando);

                comando.Parameters["@Nombre"].Value = usuario.Nombre.Trim();
                comando.Parameters["@Apellido"].Value = usuario.Apellido.Trim();
                comando.Parameters["@Email"].Value = usuario.Email.Trim();
                comando.Parameters["@Password"].Value = usuario.Password.Trim();
                comando.Parameters["@FechaNacimiento"].Value = usuario.FechaNacimiento;
                comando.Parameters["@Sexo"].Value = usuario.Sexo;
                comando.Parameters["@TipoPersona"].Value = usuario.tipoPersona;
                comando.Parameters["@FechaRegistracion"].Value = DateTime.Today;
                comando.Parameters["@Dni"].Value = usuario.dni;
                comando.Parameters["@Telefono"].Value = " ";
                comando.Parameters["@FechaActualizacion"].Value = DateTime.Today;
                return comando;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al InsertarPersona.", ex);
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

        public PersonaEntity BuscarUsuario(string email, string password)
        {
            try
            {
                PersonaEntity usuario = null;
                
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Email"].Value = email.Trim();
                        comando.Parameters["@Password"].Value = password.Trim();
                        
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

        public PersonaEntity ListarUsuarios()
        {
            try
            {
                PersonaEntity usuario = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandText = "SELECT * FROM Personas ORDER BY idpersona";
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
