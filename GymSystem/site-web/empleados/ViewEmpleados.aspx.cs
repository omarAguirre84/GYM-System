using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Text;
using GymSystemWebUtil;

public partial class ViewSocios : System.Web.UI.Page
{
    private EmpleadoBO empleadoBO;
    private StringBuilder htmlTable;
    protected List<EmpleadoEntity> listaEmpleados;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionHelper.PersonaAutenticada == null)
                throw new AutenticacionExcepcionBO();
            if (SessionHelper.PersonaAutenticada.tipoPersona != 'A')
                throw new AccessDeniedExceptionBO();
            empleadoBO = new EmpleadoBO();
            listaEmpleados = empleadoBO.GetList();
        }
        catch (AccessDeniedExceptionBO ex)
        {
            Response.Redirect("/site-web/home/HomeSiteWeb.aspx");
        }
        catch (AutenticacionExcepcionBO ex)
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
    }

    protected string filterEmpleado(EmpleadoEntity emp) {
        if (emp.tipoEmpleado == 1)
        {
            return "PROFESOR";
        }
        else if (emp.tipoEmpleado == 2)
        {
            return "ADMINITRADOR";
        }
        return "";
    }
}