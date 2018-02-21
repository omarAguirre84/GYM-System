using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSystemData
{
    public class ExcepcionDA : Exception
    {
        public ExcepcionDA(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }
    }
}
