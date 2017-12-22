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

    protected List<SocioEntity> socios = new List<SocioEntity>();


    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void modificarSocio(object sender, EventArgs e)
    {
        

    }
    protected void alterEstadoSocio(object sender, EventArgs e)
    {


    }
}