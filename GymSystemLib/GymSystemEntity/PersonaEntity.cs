using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public abstract class PersonaEntity
    {
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
        public string dni { get; set; }
        public int Telefono { get; set; }
        public string actividad { get; set; }
        public List<ActividadEntity> actividades { get; set; }
        public string Password2 { get; set; }

        public PersonaEntity()
        {
            tipoPersona = ' ';
            Telefono = 0;
            Nombre = "";
            Apellido = "";
            dni = "";
            Email = "";
            Password = "";
            FechaNacimiento = DateTime.MinValue;
            Sexo = ' ';
            Foto = null;
            FechaRegistracion = DateTime.Now;
            FechaActualizacion = DateTime.MinValue;
            actividad = "";
            actividades = new List<ActividadEntity>();
        }


        public PersonaEntity(char tipoPersona, int telefono, string nombre, string apellido, string dni, string email, 
            string password, DateTime fechaNacimiento, char sexo, string foto, DateTime fechaRegistracion, DateTime fechaActualizacion)
        {
            this.tipoPersona = tipoPersona;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.dni = dni;
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
                dni == "" ||
                Email.Trim() == "" ||
                Password.Trim() == "" ||
                FechaNacimiento == DateTime.MinValue ||
                Sexo == ' '
                )


            {
                throw new DatosObligatoriosExcepcion();
            }
            if (Password.Trim().Equals(Password2.Trim()) == false)
                throw new ExceptionMuestraMensaje("Las contraseñas no coinciden");

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
