using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class SocioEntity : PersonaEntity
    {
        public int nroTarjetaIdentificacion { get; set; }
        public int idEstado { get; set; }
        public string Estado { get; set; }

        public SocioEntity(int nroTarjetaIdentificacion, int idEstado)
        {
            this.nroTarjetaIdentificacion = nroTarjetaIdentificacion;
            this.idEstado = idEstado;
        }
    }
}
