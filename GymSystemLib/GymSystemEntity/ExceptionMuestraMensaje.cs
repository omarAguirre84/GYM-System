using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class ExceptionMuestraMensaje : ValidacionExcepcionAbstract 
    {
        public ExceptionMuestraMensaje(string mensaje) : base(mensaje)
        {
        }
    }
}
