using System;
using GymSystemBusiness;

public partial class site_web_template_master_LoginRegister : System.Web.UI.MasterPage
{
    private PersonaBO boPersona = new PersonaBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {

        Console.Write("One ");
    }
}
