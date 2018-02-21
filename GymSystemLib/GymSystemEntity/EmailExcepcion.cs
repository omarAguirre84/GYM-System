using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class EmailExcepcion : ValidacionExcepcionAbstract
    {
        public EmailExcepcion() : base("El email es inválido.")
        {
        }
    }
}
