using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSystemBusiness
{
    public class VerificacionEmailExcepcionBO : ExcepcionBO
    {
        public VerificacionEmailExcepcionBO() : base("Las direcciones de correo no coinciden.")
        {
        }
    }
}
