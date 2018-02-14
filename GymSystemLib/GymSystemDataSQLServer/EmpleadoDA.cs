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
    public class EmpleadoDA : PersonaDA
    {
        public EmpleadoDA()
        {
        }


        #region Métodos Públicos
        
        private EmpleadoEntity CrearEmpleado(SqlDataReader cursor)
        {
            EmpleadoEntity empleado = new EmpleadoEntity(
                cursor.GetInt32(cursor.GetOrdinal("tipoEmpleado")),
                cursor.GetDateTime(cursor.GetOrdinal("fechaDeIngreso")),
                cursor.GetDateTime(cursor.GetOrdinal("fechaDeEgreso"))
                );
                
            empleado.Id = cursor.GetInt32(cursor.GetOrdinal("idPersona"));
            empleado.tipoPersona = cursor.GetString(cursor.GetOrdinal("TipoPersona"))[0];
            empleado.Telefono = cursor.GetInt32(cursor.GetOrdinal("Telefono"));
            empleado.Nombre = cursor.GetString(cursor.GetOrdinal("Nombre"));
            empleado.Apellido = cursor.GetString(cursor.GetOrdinal("Apellido"));
            empleado.dni = cursor.GetString(cursor.GetOrdinal("Dni"));
            empleado.Email = cursor.GetString(cursor.GetOrdinal("Email"));
            empleado.Password = cursor.GetString(cursor.GetOrdinal("Password"));
            empleado.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("FechaNacimiento"));
            empleado.Sexo = cursor.GetString(cursor.GetOrdinal("Sexo"))[0];
            if (!cursor.IsDBNull(cursor.GetOrdinal("Foto")))
            {
                empleado.Foto = cursor.GetString(cursor.GetOrdinal("Foto"));
            }
            empleado.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("FechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("FechaActualizacion")))
            {
                empleado.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("FechaActualizacion"));
            }
            
            //empleado.actividad = cursor.GetString(cursor.GetOrdinal("descripcion"));
            //empleado.dia = cursor.GetString(cursor.GetOrdinal("dia"));

            
            return empleado;
        }

        public void Insertar(EmpleadoEntity empleado)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EmpleadoInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Dni"].Value = empleado.dni;
                        comando.Parameters["@Nombre"].Value = empleado.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = empleado.Apellido.Trim();
                        comando.Parameters["@Telefono"].Value = empleado.Telefono;
                        comando.Parameters["@Email"].Value = empleado.Email.Trim();
                        comando.Parameters["@Password"].Value = empleado.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = empleado.FechaNacimiento;
                        comando.Parameters["@Sexo"].Value = empleado.Sexo;
                        comando.Parameters["@TipoPersona"].Value = empleado.tipoPersona;
                        comando.Parameters["@FechaRegistracion"].Value = empleado.FechaRegistracion;
                        comando.Parameters["@FechaActualizacion"].Value = empleado.FechaActualizacion;
                        comando.Parameters["@TipoEmpleado"].Value = empleado.tipoEmpleado;
                        comando.Parameters["@fechaDeIngreso"].Value = empleado.fechaIngreso;
                        comando.Parameters["@fechaDeEgreso"].Value = empleado.fechaEgreso;
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

        public EmpleadoEntity[] ListarEmpleados()
        {
            try
            {
                EmpleadoEntity[] empleados = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EmpleadoTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            int i = 0;
                            empleados = new EmpleadoEntity[cursor.FieldCount];

                            while (cursor.Read())
                            {
                                empleados[i] = CrearEmpleado(cursor);
                                i++;
                            }
                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return empleados;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public void ActualizarEmpleado(EmpleadoEntity empleado)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EmpleadoActualizarTodo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idPersona"].Value = empleado.Id;
                        comando.Parameters["@Dni"].Value = empleado.dni;
                        comando.Parameters["@Nombre"].Value = empleado.Nombre.Trim();
                        comando.Parameters["@Apellido"].Value = empleado.Apellido.Trim();
                        comando.Parameters["@Telefono"].Value = empleado.Telefono;
                        comando.Parameters["@Email"].Value = empleado.Email.Trim();
                        comando.Parameters["@Password"].Value = empleado.Password.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = empleado.FechaNacimiento.Date.ToString("yyyy-MM-dd");
                        comando.Parameters["@Sexo"].Value = empleado.Sexo;
                        comando.Parameters["@TipoPersona"].Value = empleado.tipoPersona;
                        //comando.Parameters["@FechaActualizacion"].Value = empleado.FechaActualizacion.Date.ToString("yyyy-MM-dd HH:mm:ss");
                        comando.Parameters["@fechaDeIngreso"].Value = empleado.fechaIngreso.Date.ToString("yyyy-MM-dd");
                        comando.Parameters["@fechaDeEgreso"].Value = empleado.fechaEgreso.Date.ToString("yyyy-MM-dd");
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

        public EmpleadoEntity BuscarEmpleado(int idPersona)
        {
            try
            {
                EmpleadoEntity empleado = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EmpleadoBuscarPorId", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idPersona"].Value = idPersona;
                        int i = 0;
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                empleado = CrearEmpleado(cursor);
                                i++;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return empleado;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por ID.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
