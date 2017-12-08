using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemBusiness;
using GymSystemEntity;
using GymSystemComun;
using GymSystemWebUtil;

public partial class Registracion : System.Web.UI.Page
{
    private PersonaBO boUsuario = new PersonaBO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//una página envía datos a un servidor hace un post. Cuando el servidor responde con datos es un post back
        {
            for (int i = 1; i < 32; i++)
            {
                ddlDia.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = DateTime.Now.Year; i > 1904; i--)
            {
                ddlAnio.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }

    protected void btnRegistrate_Click(object sender, EventArgs e)
    {
        try
        {
            PersonaEntity usuario = new PersonaEntity();
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Email = txtEmail.Text;
            usuario.Password = txtPassword.Text;
            usuario.FechaNacimiento = Util.ObtenerFecha(
                int.Parse(ddlAnio.SelectedValue),
                int.Parse(ddlMes.SelectedValue),
                int.Parse(ddlDia.SelectedValue));
            usuario.Sexo = (ControlsHelper.RadioSeleccionado("Debe seleccionar el sexo.", radMujer, radHombre) == radMujer ? 'F' : 'M');
            usuario.EsProfesor = (ControlsHelper.RadioSeleccionado("Debe seleccionar si es profesor o cliente.", radProfesor, radCliente) == radProfesor ? 'P' : 'C');
       
            boUsuario.Registrar(usuario, txtEmailVerificacion.Text);

            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(txtEmail.Text, txtPassword.Text));
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.UsuarioAutenticado.Email, false);
            Server.Transfer("\\Biografia.aspx");
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}