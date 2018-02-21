using GymSystemBusiness;
using GymSystemComun;
using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class CreateSala : System.Web.UI.Page
{
    private SalaBO salaBO;
    protected List<SalaEntity> listaActividades;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionHelper.PersonaAutenticada == null)
                throw new AutenticacionExcepcionBO();
            if (SessionHelper.PersonaAutenticada.tipoPersona != 'A')
                throw new AccessDeniedExceptionBO();
            salaBO = new SalaBO();
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

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            SalaEntity SalaEntity = new SalaEntity();
            salaBO.RegistrarSala(popularEntity());
            WebHelper.MostrarMensaje(Page, ("Sala " + SalaEntity.Nombre + " " + " creada con exito."));
            Response.Redirect("../salas/ViewSalas.aspx");
        }
        catch (SalaExisteExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
        catch (FormatException ex)
        {
            WebHelper.MostrarMensaje(Page, ("Error en ingreso de datos: " + ex));
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ("Error en ingreso de datos: " + ex));
        }
    }
    
    protected SalaEntity popularEntity()
    {
        SalaEntity salaEntity = new SalaEntity();
        try
        {
            salaEntity.Nombre = nombre.Value;
            salaEntity.Numero = System.Convert.ToInt32(numero.Value);
            salaEntity.Capacidad = System.Convert.ToInt32(capacidad.Value);
        }
        catch (AutenticacionExcepcionBO ex)
        {
            salaEntity = null;
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
        catch (Exception ex)
        {
            salaEntity = null;
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
        return salaEntity;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../salas/ViewSalas.aspx");
    }
}
