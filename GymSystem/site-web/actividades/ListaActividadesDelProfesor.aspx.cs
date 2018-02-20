using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemBusiness;
using GymSystemEntity;
using GymSystemWebUtil;

public partial class ListaActividadesDelProfesor : System.Web.UI.Page
{

    protected ActividadBO actividadBo =  new ActividadBO();
    protected List<ActividadEntity> listActividad = new List<ActividadEntity>();
    protected List<int> listSelectActividad = new List<int>();
    protected PersonaEntity persona;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionHelper.PersonaAutenticada != null)
        {
            persona = SessionHelper.PersonaAutenticada;
            if (Request.QueryString["action"] == "alta")
            {
                darDeAltaActividad(Int32.Parse(Request.QueryString["id"]));
            }
            else if (Request.QueryString["action"] == "baja")
            {
                darDeBajaActividad(Int32.Parse(Request.QueryString["id"]));
            }
            else
            {
                listSelectActividad = actividadBo.BuscarActividadPersonaPorId(persona.Id);
                listActividad = actividadBo.ActividadGetAll();
            }
            
        }
        else
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
    }
    private void darDeBajaActividad(int idActividad)
    {
        actividadBo.borrarActividadPersona(idActividad, persona.Id);
        Response.Redirect("ListaActividadesDelProfesor.aspx");
    }

    private void darDeAltaActividad(int idActividad)
    {
        actividadBo.insertarActividadPersona(idActividad, persona.Id);
        Response.Redirect("ListaActividadesDelProfesor.aspx");
    }

    protected Boolean isRegistrado(int idActividad)
    {

        if (listSelectActividad.Contains(idActividad))
            return false;

        return true;
    }

    protected string calcularSiHayLugar(ActividadEntity activ)
    {

        return "Capacidad Total: "+ activ.sala.Capacidad + " de "+ activ.cantSocios;
    }

    protected string calcularPorcentaje(ActividadEntity activ)
    {
        int porcentaje = 0;
        if (activ.cantSocios != 0)
            porcentaje = activ.cantSocios * 100 / activ.sala.Capacidad;

        return porcentaje.ToString();
    }

}