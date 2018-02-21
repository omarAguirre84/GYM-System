using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using GymSystemWebUtil;

public partial class ViewActividades : System.Web.UI.Page
{
    protected ActividadBO activBo = new ActividadBO();
    protected List<ActividadEntity> listaActividades;
    protected SalaBO salaBO = new SalaBO();
    protected List<SalaEntity> listaSalas;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionHelper.PersonaAutenticada == null)
                throw new AutenticacionExcepcionBO();
            if (SessionHelper.PersonaAutenticada.tipoPersona != 'A')
                throw new AccessDeniedExceptionBO();
            if (!IsPostBack)
            {
                listaActividades = activBo.GetList();
                listaSalas = salaBO.GetListSalas();
            }

            if (Request.QueryString["action"] == "delete")
            {
                deleteActividad(Int32.Parse(Request.QueryString["id"]));
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
    }

    protected void deleteActividad(int idActividad)
    {
        if (activBo.DeleteActividad(idActividad))
        {
            Response.Redirect("ViewActividades.aspx");
        }
        else {
            WebHelper.MostrarMensaje(Page, "No es posible eliminar la actividad. Intente nuevamente");
        }
    }
}