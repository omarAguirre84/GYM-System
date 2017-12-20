using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemEntity;
using GymSystemWebUtil;

public partial class HomeSiteWeb : System.Web.UI.Page
{
    protected PersonaEntity persona;
    protected void Page_Load(object sender, EventArgs e)
    {
        persona = SessionHelper.UsuarioAutenticado;
    }
    
}