using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedSocialBusiness;
using RedSocialEntity;
using RedSocialComun;
using RedSocialWebUtil;

public partial class Registracion : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
        }
    }

    protected void btnRegistrate_Click(object sender, EventArgs e)
    {
     
    }
}