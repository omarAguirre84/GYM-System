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
            actividad.name = cursor.GetString(cursor.GetOrdinal("descripcion"));
            actividad.tarifa = (float)cursor.GetDouble(cursor.GetOrdinal("tarifa"));
            actividad.horaInicio = cursor.GetTimeSpan(cursor.GetOrdinal("horarioInicio"));// .Date.ToString("yyyy-MM-dd HH:mm:ss"));
            actividad.horaFin = cursor.GetTimeSpan(cursor.GetOrdinal("horarioFin"));
            actividad.dia = cursor.GetString(cursor.GetOrdinal("dia"));

            return actividad;   
        }
        #endregion Métodos Privados

        #region Métodos Públicos

        public void insertarActividad(ActividadEntity actividad)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadAlta", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Descripcion"].Value = actividad.name;
                        comando.Parameters["@Tarifa"].Value = actividad.tarifa;
                        comando.Parameters["@HorarioInicio"].Value = actividad.horaInicio;
                        comando.Parameters["@HorarioFin"].Value = actividad.horaFin;
                        comando.Parameters["@Dia"].Value = actividad.dia;
                        comando.Parameters["@idSala"].Value = actividad.idSala;
                        comando.ExecuteNonQuery();
                    }
                    
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar la actividad.", ex);
            }
        }

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
                            actividad = new ActividadEntity[cursor.FieldCount-1];

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
