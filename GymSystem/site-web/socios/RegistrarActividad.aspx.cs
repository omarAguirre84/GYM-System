using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemEntity;
using GymSystemWebUtil;
using GymSystemBusiness;
using System.Diagnostics;

public partial class site_web_template_master_Default : System.Web.UI.Page
{
    protected List<int> listSelectActividad = new List<int>();
    protected List<ActividadEntity> listActividad = new List<ActividadEntity>();
    protected ActividadBO actividadBo = new ActividadBO();
    protected PersonaEntity persona;
    protected void Page_Load(object sender, EventArgs e)
    {
            try
            {
                if (SessionHelper.PersonaAutenticada == null)
                    throw new AutenticacionExcepcionBO();
                if (SessionHelper.PersonaAutenticada.tipoPersona != 'S')
                    throw new AccessDeniedExceptionBO();
                persona = SessionHelper.PersonaAutenticada;
                    if (Request.QueryString["action"] == "alta")
                    {
                        actividadBo.GetCapacidadActividad(Int32.Parse(Request.QueryString["id"]));
                        darDeAltaActividad(Int32.Parse(Request.QueryString["id"]));
                    }
                    else if (Request.QueryString["action"] == "baja")
                    {
                        darDeBajaActividad(Int32.Parse(Request.QueryString["id"]));
                    }
                    else if (Request.QueryString["action"] == "error")
                    {
                        WebHelper.MostrarMensaje(Page, "Actividad sin cupos");
                        listSelectActividad = actividadBo.BuscarActividadPersonaPorId(persona.Id);
                        listActividad = actividadBo.ActividadGetAll();
                }
                else
                    {
                        listSelectActividad = actividadBo.BuscarActividadPersonaPorId(persona.Id);
                        listActividad = actividadBo.ActividadGetAll();
                    }
                
            }
            catch (AccessDeniedExceptionBO ex)
            {
                Response.Redirect("/site-web/home/HomeSiteWeb.aspx");
            }
            catch (AutenticacionExcepcionBO ex)
            {
                Response.Redirect("/site-web/login/loginform.aspx");
            }
            catch(ActividadSinLugarExceptionBO ex)
            {
                Response.Redirect("RegistrarActividad.aspx?action=error");
            }
    }

    private void darDeBajaActividad(int idActividad)
    {
        actividadBo.borrarActividadPersona(idActividad, persona.Id);
        Response.Redirect("RegistrarActividad.aspx");
    }

    private void darDeAltaActividad(int idActividad)
    {
        actividadBo.insertarActividadPersona(idActividad, persona.Id);
        Response.Redirect("RegistrarActividad.aspx");
    }

    protected Boolean isRegistrado(int idActividad) {

        if (listSelectActividad.Contains(idActividad)) 
        return false;

        return true;
    }

    protected void btn(object sender, EventArgs e)
    {
        int areaId = Convert.ToInt32((sender as Button).CommandArgument.ToString());
        string id = "txtReplyArea" + areaId;
    }
}