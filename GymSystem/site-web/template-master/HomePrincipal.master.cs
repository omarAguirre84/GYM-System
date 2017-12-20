using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemEntity;
using GymSystemWebUtil;

public partial class HomePrincipal : System.Web.UI.MasterPage
{
    protected PersonaEntity persona;
    protected void Page_Load(object sender, EventArgs e)
    {
        persona = SessionHelper.UsuarioAutenticado;

    }

    protected string viewUser() {
        return persona.Apellido + "," + persona.Nombre;
    }
}
