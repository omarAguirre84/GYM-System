using GymSystemBusiness;
using GymSystemComun;
using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSocio : System.Web.UI.Page
{
    private SocioBO boSocio;
    SocioEntity nuevoSocio;

    protected void Page_Load(object sender, EventArgs e)
    {
        boSocio = new SocioBO();

        if (!IsPostBack) //false = primera vez que se carga, true= segunda vez, se cambiaron los datos
        {
            cargarDatosSocioEnVista();
        }
    }

    protected void cargarDatosSocioEnVista() {
        PopularView(boSocio.BuscarSocio(Int32.Parse(Request.QueryString["id"])), false);
    }

    protected void PopularView(SocioEntity socio, Boolean origen)
    {
        try
        {
            nombre.Attributes.Add("Value", socio.Nombre);
            apellido.Attributes.Add("Value", socio.Apellido);
            dni.Attributes.Add("Value", Convert.ToString(socio.dni));
            email.Attributes.Add("Value", socio.Email);
            telefono.Attributes.Add("Value", Convert.ToString(socio.Telefono));

            string[] fechaArr = socio.FechaNacimiento.ToString("dd'/'MM'/'yyyy").Split('/');
            fechaNacimiento.Attributes.Add("value", (fechaArr[2] + "-" + fechaArr[1] + "-" + fechaArr[0]));


            if (socio.Sexo == 'm' || socio.Sexo == 'M')
            {
                masculinoLbl.Attributes.Remove("class");
                masculinoLbl.Attributes.Add("class", "btn btn-default active");
                masculino.Attributes.Add("checked", "checked");

                femeninoLbl.Attributes.Remove("class");
                femenino.Attributes.Remove("checked");
                femeninoLbl.Attributes.Add("class", "btn btn-default");
            }
            if (socio.Sexo == 'f' || socio.Sexo == 'F')
            {
                femeninoLbl.Attributes.Remove("class");
                femeninoLbl.Attributes.Add("class", "btn btn-default active");
                femenino.Attributes.Add("checked", "checked");

                masculinoLbl.Attributes.Remove("class");
                masculino.Attributes.Remove("checked");
                masculinoLbl.Attributes.Add("class", "btn btn-default");
            }
            

            if (socio.IdEstado == 1)
            {
                activoLbl.Attributes.Remove("class");
                activoLbl.Attributes.Add("class", "btn btn-default active");
                activo.Attributes.Add("checked", "checked");

                inactivoLbl.Attributes.Remove("class");
                inactivo.Attributes.Remove("checked");
                inactivoLbl.Attributes.Add("class", "btn btn-default");
            }
            if (socio.IdEstado == 2)
            {
                inactivoLbl.Attributes.Remove("class");
                inactivoLbl.Attributes.Add("class", "btn btn-default active");
                inactivo.Attributes.Add("checked", "checked");

                activoLbl.Attributes.Remove("class");
                activo.Attributes.Remove("checked");
                activoLbl.Attributes.Add("class", "btn btn-default");
            }
            
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
    protected void Btn_cancelar(object sender, EventArgs e) {
        Response.Redirect("../socios/ViewSocios.aspx");
    }

    protected void Btn_actualizar(object sender, EventArgs e)
    {
        try
        {
            boSocio.ActualizarSocio(generarNuevoEntity(boSocio.BuscarSocio(Int32.Parse(Request.QueryString["id"]))));
            PopularView(boSocio.BuscarSocio(Int32.Parse(Request.QueryString["id"])), true);
            //Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            cargarDatosSocioEnVista();
            WebHelper.MostrarMensaje(Page, "Actualizado con exito");
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ("Error de datos: " + ex));
        }
    }

    protected SocioEntity generarNuevoEntity(SocioEntity anterior)
    {
        int estado = (activo.Checked) ? 1 : 2 ;
        SocioEntity nuevoEntity = new SocioEntity(
            anterior.NroTarjetaIdentificacion, estado
            );
        try
        {
            nuevoEntity.Id = anterior.Id;
            nuevoEntity.tipoPersona = anterior.tipoPersona;
            nuevoEntity.Nombre = nombre.Text;
            nuevoEntity.Telefono = System.Convert.ToInt32(telefono.Text);
            nuevoEntity.Apellido = apellido.Text;
            nuevoEntity.dni = dni.Text;
            nuevoEntity.Email = email.Text;
            nuevoEntity.Password = (passw1.Text.Equals(passw2.Text) & !passw1.Text.Equals("********")) ? passw1.Text: anterior.Password;

            string[] fechaArr = fechaNacimiento.Value.Split('-');
            nuevoEntity.FechaNacimiento = Util.ObtenerFecha(
                int.Parse(fechaArr[0]),
                int.Parse(fechaArr[1]),
                int.Parse(fechaArr[2]));

            char gen;
            if (masculino.Checked)
            {
                gen = 'M';
            }
            else {
                gen = 'F';
            }

            nuevoEntity.Sexo = gen;
            nuevoEntity.Foto = null;
            nuevoEntity.FechaRegistracion = anterior.FechaRegistracion;
            nuevoEntity.FechaActualizacion = DateTime.Now;
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            nuevoEntity = null;
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            nuevoEntity = null;
        }
        return nuevoEntity;
    }

    
}