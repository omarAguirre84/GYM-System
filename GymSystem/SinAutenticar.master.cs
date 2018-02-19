using System;
using GymSystemBusiness;
using GymSystemWebUtil;

public partial class SinAutenticar : System.Web.UI.MasterPage
{
    private PersonaBO boUsuario = new PersonaBO();
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        try
        {
            SessionHelper.AlmacenarPersonaAutenticada(boUsuario.Autenticar(txtEmail.Text, txtPassword.Text));
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.PersonaAutenticada.Email, false);
            Response.Redirect("Biografia.aspx", true);
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}
