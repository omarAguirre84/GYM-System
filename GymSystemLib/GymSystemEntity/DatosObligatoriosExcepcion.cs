using GymSystemComun;

namespace GymSystemEntity
{
    public class DatosObligatoriosExcepcion : ValidacionExcepcionAbstract 
    {
        public DatosObligatoriosExcepcion() : base("Todos los datos son obligatorios.")
        {
        }
    }
}
