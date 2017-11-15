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

        public SocioBO()
        {
            daSocio = new SocioDA();
        }

        public List<SocioEntity> getListSocio()
        {
            try
            {
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
