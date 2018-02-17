using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class ActividadEntity 
    {
        public int idActividad { get; set; }
        public string descripcion{ get; set; }
        public float tarifa { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public string dia { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public int idSala { get; set; }
        public SalaEntity sala { get; set; }

        public ActividadEntity()
        {
            sala = new SalaEntity();
        }
    }
}
