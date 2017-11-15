using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemBusiness;
using GymSystemEntity;

public partial class ABMSocio : System.Web.UI.Page
{
    private SocioBO boSocio = new SocioBO();
    private UsuarioEntity persona;


    protected void Page_Load(object sender, EventArgs e)
    {
        boSocio.getListSocio();

    }
}