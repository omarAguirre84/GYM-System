using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int IdSocio { get; set; }
        public int nroTarjetaIdentificacion { get; set; }
        public int idEstado { get; set; }
        public int PersonaId { get; set; }
        public String cuota { get; set; }
        public String saldo { get; set; }
    }
}
