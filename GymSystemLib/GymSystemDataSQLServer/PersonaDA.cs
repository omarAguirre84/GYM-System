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
    public class PersonaDA
    {
        public PersonaDA()
        {
        }

        #region Métodos Privados
        public PersonaEntity CrearPersona(SqlDataReader cursor)
        {
            PersonaEntity persona;

            int tipoPersonaOrdinal = cursor.GetOrdinal("TipoPersona");
            string tipoPersona = cursor.GetString(tipoPersonaOrdinal).ToUpper();

            switch (tipoPersona[0]) {
                case 'S':
                    persona = new SocioEntity();
                    break;
                default:
                    persona = new EmpleadoEntity();
                    break;
            }
            
            // si  el cursor no contiene el campo especificado (lo tiene en NULL), lanza excepcion

            persona.Id = cursor.GetInt32(cursor.GetOrdinal("idPersona"));
            persona.tipoPersona = cursor.GetString(cursor.GetOrdinal("TipoPersona"))[0];
            persona.Telefono = cursor.GetInt32(cursor.GetOrdinal("Telefono"));
            persona.Nombre = cursor.GetString(cursor.GetOrdinal("Nombre"));
            persona.Apellido = cursor.GetString(cursor.GetOrdinal("Apellido"));
            persona.dni = cursor.GetString(cursor.GetOrdinal("Dni"));
            persona.Email = cursor.GetString(cursor.GetOrdinal("Email"));
            persona.Password = cursor.GetString(cursor.GetOrdinal("Password"));
            persona.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("FechaNacimiento"));
            persona.Sexo = cursor.GetString(cursor.GetOrdinal("Sexo"))[0];
            if (!cursor.IsDBNull(cursor.GetOrdinal("Foto"))) { 
                persona.Foto = cursor.GetString(cursor.GetOrdinal("Foto"));
            }
            persona.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("FechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("FechaActualizacion"))) {
                persona.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("FechaActualizacion"));
            }
            return (PersonaEntity) persona;   
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(PersonaEntity persona)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Nombre"].Value = persona.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = persona.Apellido.Trim();
                        comando.Parameters["@Email"].Value = persona.Email.Trim();
                        comando.Parameters["@Password"].Value = persona.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = persona.FechaNacimiento;
                        comando.Parameters["@Sexo"].Value = persona.Sexo;
                        comando.Parameters["@Profesor"].Value = persona.tipoPersona;
                        comando.Parameters["@FechaRegistracion"].Value = persona.FechaRegistracion;
                        comando.Parameters["@Telefono"].Value = persona.Telefono;
                        comando.ExecuteNonQuery();
                        //persona.Id = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);
                    }
                    
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }

        public void saveProfile(PersonaEntity persona)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActualizarProfilePersona", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idPersona"].Value = persona.Id;
                        comando.Parameters["@Nombre"].Value = persona.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = persona.Apellido.Trim();
                        comando.Parameters["@Dni"].Value = persona.dni;
                        comando.Parameters["@Password"].Value = persona.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = persona.FechaNacimiento;
                        comando.Parameters["@Sexo"].Value = persona.Sexo;
                       
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al gaurdar el profile.", ex);
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
                //comando.Parameters["@FechaRegistracion"].Value = DateTime.Today;
                comando.Parameters["@Dni"].Value = usuario.dni;
                comando.Parameters["@Telefono"].Value = usuario.Telefono;
                //comando.Parameters["@FechaActualizacion"].Value = DateTime.Today;
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
                    using (SqlCommand comando = new SqlCommand("PersonaActualizarFoto", conexion))
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
                    using (SqlCommand comando = new SqlCommand("PersonaExisteEmail", conexion))
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

        public PersonaEntity BuscarPersona(string email, string password)
        {
            try
            {
                PersonaEntity persona = null;
                
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
                                persona = CrearPersona(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return persona;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public PersonaEntity[] ListarPersonas()
        {
            try
            {
                PersonaEntity [] personas = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("PersonaTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader()){

                            personas = new PersonaEntity[cursor.Depth];
                            int i = 0;
                            while (cursor.Read())
                            {
                                personas[i] = CrearPersona(cursor);
                                i++;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }

                return personas;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
