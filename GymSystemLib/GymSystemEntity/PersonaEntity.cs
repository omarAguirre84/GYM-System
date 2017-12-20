using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class PersonaEntity
    {
        public int idPersona { get; set; }
        public char tipoPersona { get; set; }
        public int Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string Foto { get; set; }
        public DateTime FechaRegistracion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public PersonaEntity()
        {
            tipoPersona = ' ';
            Telefono = 0;
            Nombre = "";
            Apellido = "";
            Dni = 0;
            Email = "";
            Password = "";
            FechaNacimiento = DateTime.MinValue;
            Sexo = ' ';
            Foto = null;
            FechaRegistracion = DateTime.Now;
            FechaActualizacion = DateTime.MinValue;
        }
        

        public PersonaEntity(char tipoPersona, int telefono, string nombre, string apellido, int dni, string email, 
            string password, DateTime fechaNacimiento, char sexo, string foto, DateTime fechaRegistracion, DateTime fechaActualizacion)
        {
            this.tipoPersona = tipoPersona;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Email = email;
            this.Password = password;
            this.FechaNacimiento = fechaNacimiento;
            this.Sexo = sexo;
            this.Foto = foto;
            this.FechaRegistracion = fechaRegistracion;
            this.FechaActualizacion = fechaActualizacion;            
        }

        public void ValidarDatos()
        {
            if (tipoPersona == ' ' ||
                Telefono == 0 ||
                Nombre.Trim() == "" ||
                Apellido.Trim() == "" ||
                Dni == 0 ||
                Email.Trim() == "" ||
                Password.Trim() == "" ||
                FechaNacimiento == DateTime.MinValue ||
                Sexo == ' '
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
