using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;
using System.Collections.Generic;

namespace GymSystemBusiness
{
    public class SalaBO
    {
        private SalaDA salaDa;

        public SalaBO()
        {
            salaDa = new SalaDA();
        }

        public List<SalaEntity> GetListSalas()
        {
            List<SalaEntity> listsala = null;
            try
            {
                listsala = salaDa.ListarSalas();
                return listsala;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo listar las salas.", ex);
            }
        }

        public void RegistrarSala(SalaEntity salaEntity)
        {
            try
            {
                if (salaDa.BuscarSala(salaEntity.Nombre) != null)
                {
                    throw new SalaExisteExcepcionBO();
                }
                else
                {
                    salaDa.InsertSala(salaEntity);
                }
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración de la sala.", ex);
            }
        }

        public void Actualizar(SalaEntity salaEntity)
        {
            try
            {
                salaDa.ActualizarSala(salaEntity);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }

        public SalaEntity BuscarSala(int idSala)
        {
            SalaEntity salaEntity = null;
            try
            {
                salaEntity = salaDa.BuscarSala(idSala);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
            return salaEntity;
        }
    }
}
