using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemBusiness;
using GymSystemEntity;
using GymSystemWebUtil;


public partial class DetalleActividadesDelProfesor : System.Web.UI.Page
{

    protected SocioBO socioBo = new SocioBO();
    protected ActividadBO actividadBo = new ActividadBO();
    protected List<SocioEntity> listsocios = new List<SocioEntity>();
    protected ActividadEntity actividad = new ActividadEntity();
    protected PersonaEntity persona;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionHelper.PersonaAutenticada == null)
                throw new AutenticacionExcepcionBO();
            if (SessionHelper.PersonaAutenticada.tipoPersona != 'P')
                throw new AccessDeniedExceptionBO();
            if (Request.QueryString["id"] == null)
                throw new Exception();
            persona = SessionHelper.PersonaAutenticada;
            actividad = actividadBo.BuscarActividadPorId(Int32.Parse(Request.QueryString["id"]));
            listsocios = socioBo.GetListSocioPorActividadId(Int32.Parse(Request.QueryString["id"]));

        }
        catch (AccessDeniedExceptionBO ex)
        {
            Response.Redirect("/site-web/home/HomeSiteWeb.aspx");
        }
        catch (AutenticacionExcepcionBO ex)
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
        catch (Exception ex) {
            Response.Redirect("/site-web/actividades/ListaActividadesDelProfesor.aspx");
        }

    }
}