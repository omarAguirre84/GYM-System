using System;
using System.Collections.Generic;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class GenericBO
    {
        private GenericDA genericDa;

        public GenericBO()
        {
            genericDa = new GenericDA();
        }

        public GenericEntity GetListParaAdmin()
        {
            try
            {
                return genericDa.GetListParaAdmin(); ;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar GetListParaAdmin.", ex);
            }
        }
    }

      
}
