using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemBusiness
{
    public class ExcepcionBO : ValidacionExcepcionAbstract
    {
        public ExcepcionBO(string mensaje) : base(mensaje)
        {
        }
        
        public ExcepcionBO(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }
    }
}
