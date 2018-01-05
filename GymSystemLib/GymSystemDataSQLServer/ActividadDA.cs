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
    public class ActividadDA : PersonaDA
    {
        public ActividadDA()
        {
        }

        #region Métodos Privados
        private ActividadEntity CrearActividad(SqlDataReader cursor)
        {

            ActividadEntity actividad = new ActividadEntity();
            
            actividad.idActividad = cursor.GetInt32(cursor.GetOrdinal("idActividad"));
            actividad.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            actividad.tarifa = cursor.GetInt32(cursor.GetOrdinal("tarifa"));
            actividad.horaInicio = cursor.GetDateTime(cursor.GetOrdinal("horarioInicio"));// .Date.ToString("yyyy-MM-dd HH:mm:ss"));
            actividad.horaFin = cursor.GetDateTime(cursor.GetOrdinal("horarioFin"));
            
             return actividad;   
        }
        #endregion Métodos Privados

        #region Métodos Públicos

        /*public void Insertar(ActividadEntity actividad)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EmpleadoInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Dni"].Value = empleado.Dni;
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
        }*/

       /* public void Actualizar(ActividadEntity actividad, int idActividad)
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
        }*/
        /*
        public bool Existe(int idActividad)
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
        */
        public ActividadEntity[] ListarActividades()
        {
            try
            {
                ActividadEntity[] actividad = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            int i = 0;
                            actividad = new ActividadEntity[cursor.FieldCount];

                            while (cursor.Read())
                            {
                                actividad[i] = CrearActividad(cursor);
                                i++;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return actividad;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        
        public ActividadEntity BuscarActividad(int idActividad)
        {
            try
            {
                ActividadEntity actividad = null;
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadSalaBuscarPorIdActividad", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idActividad"].Value = idActividad;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                actividad = CrearActividad(cursor);
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                return actividad;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por ID.", ex);
            }
            }
            #endregion Métodos Públicos
        }
}
