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
    protected void Page_Load(object sender, EventArgs e)
    {
        persona = SessionHelper.PersonaAutenticada;
        actividadesUser = actividadBo.ActividadPorPersonaId(persona.Id);
    }
}