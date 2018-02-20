using System.Collections.Generic;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class SocioBO : PersonaBO
    {
        private SocioDA daSocio;
        private PersonaDA personaDa;

        public SocioBO()
        {
            daSocio = new SocioDA();
            personaDa = new PersonaDA();
        }

        public PersonaEntity newSocio(PersonaEntity personaSocio) {
            try
            {
                personaSocio.ValidarDatos();
                if (daSocio.ExisteEmail(personaSocio.Email))
                    throw new EmailExisteExcepcionBO();
                return daSocio.InsertarSocio(personaSocio);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
            
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

        public List<SocioEntity> GetList()
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

        public List<SocioEntity> GetListSocioPorActividadId(int idActividad)
        {
            try
            {
                return daSocio.GetListSocioPorActividadId(idActividad); ;
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

        public void ActualizarEstadoSocio(int idSocio, int estadoNuevo) {
            try
            {
                daSocio.ActualizarEstadoSocio(idSocio, estadoNuevo);
            }
            catch {

            }
            
        }
    }
}
