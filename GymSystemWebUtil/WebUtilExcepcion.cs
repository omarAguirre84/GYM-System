using System;
using GymSystemComun;

namespace GymSystemWebUtil
{
    public class WebUtilExcepcion : ValidacionExcepcionAbstract
    {
        public WebUtilExcepcion(string mensaje) : base(mensaje)
        {
        }

        public WebUtilExcepcion(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }
    }
}
