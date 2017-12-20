﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using GymSystemEntity;
using GymSystemData;

namespace GymSystemDataSQLServer
{
    public class SocioDA
    {
        private PersonaDA personaDA;
        public SocioDA()
        {
            personaDA = new PersonaDA();
        }
        public List<SocioEntity> ListarSocios()
        {
            try
            {
                List<SocioEntity> socios = new List<SocioEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SELECT * FROM [socio]", conexion))
                    {
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            while (cursor.Read())
                            {
                                //SocioEntity socEnt = new SocioEntity(
                                //    int.Parse(cursor["idSocio"].ToString()),
                                //    int.Parse(cursor["nroTarjetaIdentificacion"].ToString()),
                                //    int.Parse(cursor["idEstado"].ToString()),
                                //    int.Parse(cursor["PersonaId"].ToString()),
                                //    cursor["cuota"].ToString(),
                                //    cursor["saldo"].ToString());
                                //socios.Add(socEnt);
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

        public SocioEntity InsertarSocio(PersonaEntity socio)
        {
            try
            {
                SqlCommand comando = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (comando = new SqlCommand("SocioInsert", conexion))
                    {
                        comando = personaDA.InsertarPersona(socio, comando, conexion);
                        comando.Parameters["@NroTarjetaIdentificacion"].Value = socio.dni.Trim();
                        comando.Parameters["@idEstado"].Value = 2;
                        comando.ExecuteNonQuery();
                        socio.Id = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);

                    }

                    conexion.Close();
                }
                return (SocioEntity) socio;

            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
    }
}
