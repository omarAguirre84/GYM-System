using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

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
                PersonaEntity usuario = personaDa.BuscarUsuario(email, password);

                if (usuario == null)
                    throw new AutenticacionExcepcionBO();

                return usuario;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public void Registrar(PersonaEntity usuario, string emailVerificacion)
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

        public void getListUsers()
        {
            //private Array<UsuarioEntity> listPerson = new UsuarioEntity()[];
            try
            {
                //daUsuario.Insertar(usuariko);
                personaDa.ListarUsuarios();
                //return listPerson;
    }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }
    }
}
