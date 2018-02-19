using System;

namespace GymSystemData
{
    public class ExcepcionDA : Exception
    {
        public ExcepcionDA(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }
    }
}
