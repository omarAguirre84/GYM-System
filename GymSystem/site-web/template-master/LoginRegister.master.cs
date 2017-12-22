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


    protected void btnRegister_Click(object sender, EventArgs e)
    {

        Console.Write("One ");
    }
}
