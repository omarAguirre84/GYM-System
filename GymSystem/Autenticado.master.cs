using System;
using System.Security.Permissions;

[PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
public partial class Autenticado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
