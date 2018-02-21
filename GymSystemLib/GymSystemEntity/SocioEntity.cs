using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class SocioEntity : PersonaEntity
    {
        private int nroTarjetaIdentificacion;
        private int idEstado;

        public SocioEntity() : base ()
        {
        }

        public SocioEntity(int nroTarjetaIdentificacion, int idEstado)
        {
            this.nroTarjetaIdentificacion = nroTarjetaIdentificacion;
            this.idEstado = idEstado;
        }

        public int NroTarjetaIdentificacion { get { return nroTarjetaIdentificacion; } set { nroTarjetaIdentificacion = value; } }
        public int IdEstado { get { return idEstado; } set { idEstado = value; } }

    }
}
