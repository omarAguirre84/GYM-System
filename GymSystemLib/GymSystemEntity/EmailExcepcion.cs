using GymSystemComun;

namespace GymSystemEntity
{
    public class EmailExcepcion : ValidacionExcepcionAbstract
    {
        public EmailExcepcion() : base("El email es inválido.")
        {
        }
    }
}
