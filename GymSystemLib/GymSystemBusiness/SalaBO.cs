using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class SalaBO
    {
        private SalaDA salaDa;
        public SalaBO()
        {
            salaDa = new SalaDA();

        }

        public SalaEntity[] GetListSalas()
        {
            SalaEntity[] listsala = null;
            try
            {
                //daUsuario.Insertar(usuariko);

                listsala = salaDa.ListarSalas();

                return listsala;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

    }
}
