using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class FechaNacimientoExcepcion : ValidacionExcepcionAbstract
    {
        public FechaNacimientoExcepcion() : base("La fecha de nacimiento debe ser menor al día de la fecha.")
        {
        }
    }
}
