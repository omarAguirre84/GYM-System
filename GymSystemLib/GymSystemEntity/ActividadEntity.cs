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
        public int tarifa { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public string dia { get; set; }

        public ActividadEntity()
        {
            
        }
    }
}
