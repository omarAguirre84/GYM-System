using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
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
            
            if (ColumExist(cursor, "nombre")) {
                actividad.sala.Nombre = cursor.GetString(cursor.GetOrdinal("nombre"));
            }

            if (ColumExist(cursor, "idSala")) {
                actividad.idSala = cursor.GetInt32(cursor.GetOrdinal("idSala"));
            }
            return actividad;   
        }
        #endregion Métodos Privados

        private Boolean ColumExist(SqlDataReader cursor, string columnName) {
            for (int i = 0; i < cursor.FieldCount; i++)
            {

                if (cursor.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

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

        public void ActualizarActividad(ActividadEntity actividad)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadActualizar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idActividad"].Value = actividad.idActividad;
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
                throw new ExcepcionDA("Se produjo un error al actualizar la Actividad.", ex);
            }
        }
        
        public List<ActividadEntity> ListarActividades()
        {
            try
            {
                List<ActividadEntity> actividad = new List<ActividadEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadTraerTodos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                                while (cursor.Read())
                                {
                                    actividad.Add(CrearActividad(cursor));
                                    
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

        public List<int> BuscarActividadPersonaPorId(int idPersona)
        {
            try
            {
                List<int> empleadoActividad = new List<int>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("[ActividadPersonaGetList]", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idPersona"].Value = idPersona;
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {


                            while (cursor.Read())
                            {
                                empleadoActividad.Add(cursor.GetInt32(cursor.GetOrdinal("idActividad")));

                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return empleadoActividad;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public List<ActividadEntity> ActividadPorPersonaId(int idPersona)
        {
            try
            {
                List<ActividadEntity> actividades = new List<ActividadEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("[ActividadPorPersonaId]", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idPersona"].Value = idPersona;
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {


                            while (cursor.Read())
                            {
                                ActividadEntity auxActi = CrearActividad(cursor);
                                auxActi.listPersonas = PersonaPorActividadId(auxActi.idActividad);
                                actividades.Add(auxActi);

                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return actividades;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public List<PersonaEntity> PersonaPorActividadId(int idActividad)
        {
            try
            {
                List<PersonaEntity> profesores = new List<PersonaEntity>();
                PersonaDA personaDA = new PersonaDA();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("[PersonaPorActividadId]", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idActividad"].Value = idActividad;
                        comando.Parameters["@TipoPersona"].Value = 'P';
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {


                            while (cursor.Read())
                            {
                                profesores.Add(personaDA.CrearPersona(cursor));

                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return profesores;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public List<ActividadEntity> ListActividadPersonaPorId(int idPersona)
        {
            try
            {
                List<ActividadEntity> empleadoActividad = new List<ActividadEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("[ActividadPersonaGetList]", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);
                        comando.Parameters["@idPersona"].Value = idPersona;
                        comando.Parameters["@valueAll"].Value = 1;
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {


                            while (cursor.Read())
                            {
                                empleadoActividad.Add(CrearActividad(cursor));

                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return empleadoActividad;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public Boolean deleteActividad(int idActividad)
        {
            try
            {
                Boolean isDelete = false;
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadBaja", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idActividad"].Value = idActividad;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.RecordsAffected > 0)
                            {
                                isDelete = true;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return isDelete;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public Boolean ValidadDiaHoraActividad(string dia, int? idActividad)
        {
            try
            {                
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    Boolean isOkDia = false;
                    using (SqlCommand comando = new SqlCommand("ActividadValidaDia&Horario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Dia"].Value = dia;
                        comando.Parameters["@idActividad"].Value = idActividad == null ? 0 : idActividad;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                isOkDia = cursor.GetInt32(cursor.GetOrdinal("isfree")) == 1 ? false : true;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                    return isOkDia;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por ID.", ex);
            }
        }

        public Boolean ActividadValidaNombre(string nombre, int id)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    Boolean isOkDia = false;
                    using (SqlCommand comando = new SqlCommand("ActividadValidaNombre", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@Nombre"].Value = nombre;
                        comando.Parameters["@idActividad"].Value = id;
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                isOkDia = cursor.GetInt32(cursor.GetOrdinal("isfree")) == 1 ? false : true;
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                    return isOkDia;
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por ID.", ex);
            }
        }

        public ActividadEntity BuscarActividad(int idActividad)
        {
            try
            {
                ActividadEntity actividad = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActividadBuscarPorId", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idActividad"].Value = idActividad;
                        int i = 0;
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                actividad = CrearActividad(cursor);
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
                throw new ExcepcionDA("Se produjo un error al buscar por ID.", ex);
            }
        }
            #endregion Métodos Públicos
    }
}
