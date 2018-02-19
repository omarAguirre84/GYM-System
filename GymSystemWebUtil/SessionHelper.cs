using System.Web;
using GymSystemEntity;

namespace GymSystemWebUtil
{
    public class SessionHelper
    {
        private SessionHelper()
        {
        }

        public static void AlmacenarPersonaAutenticada(PersonaEntity persona)
        {
            HttpContext.Current.Session.Add("PersonaAutenticada", persona);
        }

        public static PersonaEntity PersonaAutenticada
        {
            get
            {
                PersonaEntity p = (PersonaEntity)HttpContext.Current.Session["PersonaAutenticada"]; ;
                return p;
            }
        }
    }
}
