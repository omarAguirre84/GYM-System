using GymSystemEntity;
using GymSystemWebUtil;
using System;

public partial class HomePrincipal : System.Web.UI.MasterPage
{
    protected PersonaEntity persona;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionHelper.PersonaAutenticada != null)
        {
            persona = SessionHelper.PersonaAutenticada;
        }
        else {
            Response.Redirect("/site-web/login/loginform.aspx");
        }

        
  
    }
}
