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

public partial class site_web_login_registrationform : System.Web.UI.Page
{
    private PersonaBO boUsuario = new PersonaBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            Console.Write(RegTypeUser.Value);
            WebHelper.MostrarMensaje(Page, "error");
            PersonaEntity usuario = boUsuario.factoryPersona(Convert.ToChar(RegTypeUser.Value));
            usuario.Nombre = RegName.Value;
            usuario.Apellido = RegApell.Value;
            usuario.Email = RegEmail.Value;
            usuario.Password = RegPass.Value;
            usuario.FechaNacimiento = Convert.ToDateTime(RegfechaNac.Value);
            usuario.Sexo = Convert.ToChar( RegGender.Value);
            usuario.tipoPersona = Convert.ToChar(RegTypeUser.Value);

            boUsuario.Registrar(usuario, usuario.Email);

            Server.Transfer("\\Biografia.aspx");
            //Page.Response.Redirect("~/site-web/login/registrationform.aspx#signup"); 
         } catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }

    }

    protected void TextValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (args.Value.Length >= 8);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Console.Write("One ");
    }
}