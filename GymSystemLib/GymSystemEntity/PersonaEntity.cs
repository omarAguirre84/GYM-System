using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public abstract class PersonaEntity
    {

        public PersonaEntity()
        {
            Id = 0;
            Nombre = "";
            Apellido = "";
            Email = "";
            Password = "";
            FechaNacimiento = DateTime.MinValue;
            Sexo = ' ';
            Foto = null;
            FechaRegistracion = DateTime.Now;
            FechaActualizacion = null;
            tipoPersona = '-';
        }

        public PersonaEntity(int id, string nombre, string apellido, string email, string password, DateTime fechaNacimiento, char sexo, string foto, DateTime fechaRegistracion, DateTime? fechaActualizacion, char tipoPersona)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
            Foto = foto;
            FechaRegistracion = fechaRegistracion;
            FechaActualizacion = fechaActualizacion;
            this.tipoPersona = tipoPersona;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string Foto { get; set; }
        public DateTime FechaRegistracion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public char tipoPersona { get; set; }
        public void ValidarDatos()
        {
            if (Nombre.Trim() == "" ||
                Apellido.Trim() == "" ||
                Email.Trim() == "" ||
                Password.Trim() == "" ||
                FechaNacimiento == DateTime.MinValue ||
                Sexo == ' ' ||
                EsProfesor ==' '
                )
            {
                throw new DatosObligatoriosExcepcion();
            }

            if (!Util.EsEmail(Email))
            {
                throw new EmailExcepcion();
            }

            if (FechaNacimiento > DateTime.Today)
            {
                throw new FechaNacimientoExcepcion();
            }
        }
    }
}
