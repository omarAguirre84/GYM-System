using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class SocioBO : PersonaBO
    {
        private SocioDA daSocio;

        public SocioBO()
        {
            daSocio = new SocioDA();
        }

        public void Registrar(SocioEntity socio, string emailVerificacion)
        {
            try
            {
                socio.ValidarDatos();

                if (daSocio.ExisteEmail(socio.Email))
                    throw new EmailExisteExcepcionBO();

                if (socio.Email != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                daSocio.Insertar(socio);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public SocioEntity[] GetList()
        {
            try
            {
                return daSocio.ListarSocios(); ;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar socios.", ex);
            }
        }

        public SocioEntity BuscarSocio(string email, string password)
        {
            try
            {
                return daSocio.BuscarSocio(email, password);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar socios.", ex);
            }
        }

        public SocioEntity BuscarSocio(int idPersona)
        {
            try
            {
                return daSocio.BuscarSocio(idPersona);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar socios.", ex);
            }
        }

        public void ActualizarSocio(SocioEntity socio)
        {
            try
            {
                daSocio.ActualizarSocio(socio);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar socios.", ex);
            }
        }
    }
}
