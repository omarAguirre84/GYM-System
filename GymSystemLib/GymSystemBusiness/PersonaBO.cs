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
        private PersonaDA personaDa;
        public PersonaEntity factoryPersona(Char type) {
            PersonaEntity person=null;
            switch (type) {
                case 'S':
                    person = new SocioEntity();
                    break;
                case 'P':
                    //person = new ProfesorEntity();
                    break;
                case 'E':
                    //person = new EmpleadoEntity();
                    break;
            }
            return person;
        }
        public PersonaBO()
        {
            personaDa = new PersonaDA();

        }

        public PersonaEntity Autenticar(string email, string password)
        {
            try
            {
                PersonaEntity persona = personaDa.BuscarPersona(email, password);

                if (persona == null)
                    throw new AutenticacionExcepcionBO();
                    //throw new ValidacionExcepcionAbstract();
                return persona;
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

                if (personaDa.ExisteEmail(persona.Email))
                    throw new EmailExisteExcepcionBO();

                if (persona.Email != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                personaDa.Insertar(persona);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public void RegistrarPersona(PersonaEntity usuario, string emailVerificacion)
        {
            try
            {
                usuario.ValidarDatos();

                if (personaDa.ExisteEmail(usuario.Email))

                    throw new EmailExisteExcepcionBO();

                if (usuario.Email != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                personaDa.Insertar(usuario);
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
                personaDa.Actualizar(id, nombreArchivo, archivoFoto);

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

                //personaDa.ListarUsuarios();

                //return listPerson;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

    }
}
