using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemComun;

namespace GymSystemEntity
{
    public class SocioEntity
    {
        public SocioEntity()
        {
            IdSocio = 0;
            nroTarjetaIdentificacion = 0;
            idEstado = 0;
            PersonaId = 0;
            cuota = "";
            saldo = "";
        }


        public SocioEntity(int IdSocio, int nroTarjetaIdentificacion, int idEstado, int PersonaId, string cuota, string saldo)
        {
            this.IdSocio = IdSocio;
            this.nroTarjetaIdentificacion = nroTarjetaIdentificacion;
            this.idEstado = idEstado;
            this.PersonaId = PersonaId;
            this.cuota = cuota;
            this.saldo = saldo;
        }

        public int IdSocio { get; set; }
        public int nroTarjetaIdentificacion { get; set; }
        public int idEstado { get; set; }
        public int PersonaId { get; set; }
        public string cuota { get; set; }
        public string saldo { get; set; }
    }
}
