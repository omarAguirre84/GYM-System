using GymSystemBusiness;
using GymSystemComun;
using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class ViewSocio : System.Web.UI.Page
{
    private SalaBO salaBO;
    private SalaEntity nuevaSala;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionHelper.PersonaAutenticada == null)
                throw new AutenticacionExcepcionBO();
            if (SessionHelper.PersonaAutenticada.tipoPersona != 'A')
                throw new AccessDeniedExceptionBO();
            salaBO = new SalaBO();

            if (!IsPostBack) //false = primera vez que se carga, true= segunda vez, se cambiaron los datos
            {
                cargarSalaEnVista();
                //loadEditActividad();
                //loadActividadList();
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

    protected void cargarSalaEnVista() {
        PopularView(salaBO.BuscarSala(Int32.Parse(Request.QueryString["id"])));
    }

    protected void PopularView(SalaEntity sala)
    {
        try
        {
            nombre.Attributes.Add("Value", sala.Nombre);
            numero.Attributes.Add("Value", Convert.ToString(sala.Numero));
            capacidad.Attributes.Add("Value", Convert.ToString(sala.Capacidad));
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            salaBO.Actualizar(generarNuevoEntity(salaBO.BuscarSala(Int32.Parse(Request.QueryString["id"]))));
            PopularView(salaBO.BuscarSala(Int32.Parse(Request.QueryString["id"])));
            //Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            WebHelper.MostrarMensaje(Page, "Actualizado con exito");
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ("Error de datos: " + ex));
        }
    }

    protected SalaEntity generarNuevoEntity(SalaEntity anterior)
    {
        SalaEntity nuevaSala = new SalaEntity();
        try
        {
            nuevaSala.IdSala = anterior.IdSala;
            nuevaSala.Nombre = nombre.Value;
            nuevaSala.Numero = Convert.ToInt32(numero.Value);
            nuevaSala.Capacidad = Convert.ToInt32(capacidad.Value);
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            nuevaSala = null;
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            nuevaSala = null;
        }
        return nuevaSala;
    }
    /*
    private void loadEditActividad()
    {
        List<int> listaComboActividad = boActividad.BuscarActividadPersonaPorId(Int32.Parse(Request.QueryString["id"]));
        foreach (ListItem item in actividades.Items)
        {
            item.Selected = (listaComboActividad.Contains(Int32.Parse(item.Value)))?true:false;
        }
    }*/
    /*
    protected void loadActividadList()
    {
        int index = 0;
        foreach (ActividadEntity actividadEntity in listaActividades)
        {
            actividades.Items.Insert(index++, new ListItem(actividadEntity.name, actividadEntity.idActividad.ToString()));
        }
        loadEditActividad();
    }*/

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../salas/ViewSalas.aspx");
    }
}
