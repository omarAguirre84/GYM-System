using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemBusiness;
using GymSystemEntity;
using GymSystemWebUtil;
using GymSystemDataSQLServer;
using System.Diagnostics;

public partial class site_web_template_master_LoginRegister : System.Web.UI.MasterPage
{
    private PersonaBO boPersona = new PersonaBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SessionHelper.AlmacenarPersonaAutenticada(boPersona.Autenticar(username.Value, password.Value));
        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.PersonaAutenticada.Email, false);

        Page.Response.Redirect("~/site-web/home/HomeSiteWeb.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        Console.Write("One ");
    }
}
