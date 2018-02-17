using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemEntity;
using GymSystemWebUtil;
using GymSystemBusiness;

public partial class site_web_profile_Profile : System.Web.UI.Page
{
    protected PersonaEntity persona;
    protected List<ActividadEntity> listActiv;
    protected List<ActividadEntity> listActivSelect;
    protected ActividadBO activBo = new ActividadBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionHelper.PersonaAutenticada != null)
        {
            persona = SessionHelper.PersonaAutenticada;
            listActiv = activBo.GetList();
            listActivSelect = activBo.ListActividadPersonaPorId(persona.Id);
        }
        else
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
    }
}