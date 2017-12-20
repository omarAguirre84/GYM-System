using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;
using GymSystemComun;

namespace GymSystemBusiness
{
    public class PersonaBO
    {
        private PersonaDA daPersona;

        public PersonaBO()
        {
            daPersona = new PersonaDA();
        }

        public PersonaEntity Autenticar(string email, string password)
        {
            try
            {
                PersonaEntity usuario = daPersona.BuscarPersona(email, password);

                if (usuario == null)
                    throw new AutenticacionExcepcionBO();
                    //throw new ValidacionExcepcionAbstract();
                return usuario;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public void Registrar(PersonaEntity persona, string emailVerificacion)
        {
            try
            {
                persona.ValidarDatos();

                if (daPersona.ExisteEmail(persona.Email))
                    throw new EmailExisteExcepcionBO();

                if (persona.Email != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                daPersona.Insertar(persona);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public void ActualizarFoto(int id, string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                daPersona.Actualizar(id, nombreArchivo, archivoFoto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo actualizar la foto.", ex);
            }
        }

        public void GetListUsers()
        {
            //private Array<UsuarioEntity> listPerson = new UsuarioEntity()[];
            try
            {
                //daUsuario.Insertar(usuariko);
                daPersona.ListarPersonas();
                //return listPerson;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

    }
}
