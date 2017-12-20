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

        public SocioEntity()
        {
        }

        public SocioEntity(int id, string nombre, string apellido, string email, string password, DateTime fechaNacimiento, char sexo, string foto, DateTime fechaRegistracion, DateTime? fechaActualizacion, char tipoPersona, int nroTarjetaIdentificacion, int idEstado) : base(id, nombre, apellido, email, password, fechaNacimiento, sexo, foto, fechaRegistracion, fechaActualizacion, tipoPersona)
        {
            this.nroTarjetaIdentificacion = nroTarjetaIdentificacion;
            this.idEstado = idEstado;
        }

        public int NroTarjetaIdentificacion { get { return nroTarjetaIdentificacion; } set{ this.nroTarjetaIdentificacion = value;} }
        public int IdEstado { get { return idEstado; } set { this.idEstado = value; } }
    }
}
