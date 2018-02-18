using System;

namespace GymSystemEntity
{
    public class EmpleadoEntity : PersonaEntity
    {
        public int tipoEmpleado { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaEgreso { get; set; }
        public string actividad { get; set; }
        

        public EmpleadoEntity() { }

        public EmpleadoEntity(int tipoEmpleado, DateTime fechaIngreso, DateTime fechaEgreso)
        {
            this.tipoEmpleado = tipoEmpleado;
            this.fechaIngreso = fechaIngreso;
            this.fechaEgreso = fechaEgreso;
        }
     
    }
}
