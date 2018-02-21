using GymSystemEntity;
using GymSystemBusiness;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;

public partial class HomeSiteWeb : System.Web.UI.Page
{
    protected PersonaEntity persona;
    protected ActividadBO actividadBo = new ActividadBO();
    protected List<ActividadEntity> actividadesUser = new List<ActividadEntity>();
    protected GenericEntity listAdmin = new GenericEntity();
    protected GenericBO genericBO = new GenericBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        persona = SessionHelper.PersonaAutenticada;
        if (SessionHelper.PersonaAutenticada != null)
        {
            actividadesUser = actividadBo.ActividadPorPersonaId(persona.Id);
            listAdmin = genericBO.GetListParaAdmin();
        }
        else
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
    }
}