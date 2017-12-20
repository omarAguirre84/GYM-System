using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class SocioBO
    {
        private SocioDA daSocio;
        private PersonaDA personaDa;

        public SocioBO()
        {
            daSocio = new SocioDA();
            personaDa = new PersonaDA();
        }

        public PersonaEntity newSocio(PersonaEntity personaSocio) {
            return daSocio.InsertarSocio(personaSocio);
        }

        public List<SocioEntity> getListSocio()
        {
            try
            {
                SocioEntity se = new SocioEntity();
                //daUsuario.Insertar(usuariko);
                return daSocio.ListarSocios();
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar socios.", ex);
            }
        }
    }
}
