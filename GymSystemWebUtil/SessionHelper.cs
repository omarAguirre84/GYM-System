using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GymSystemEntity;

namespace GymSystemWebUtil
{
    public class SessionHelper
    {
        private SessionHelper()
        {
        }

        public static void AlmacenarUsuarioAutenticado(PersonaEntity usuario)
        {
            HttpContext.Current.Session.Add("UsuarioAutenticado", usuario);
        }

        public static PersonaEntity UsuarioAutenticado
        {
            get
            {
                return (PersonaEntity)HttpContext.Current.Session["UsuarioAutenticado"];
            }
        }
    }
}
