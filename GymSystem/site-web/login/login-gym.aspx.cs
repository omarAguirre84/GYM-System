using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemBusiness;
using GymSystemEntity;
using GymSystemWebUtil;

public partial class login_login_gym : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(username.Value, password.Value));
        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.UsuarioAutenticado.Email, false);
        Page.Response.Redirect("~/site-web/home/HomeSiteWeb.aspx");

    }
}