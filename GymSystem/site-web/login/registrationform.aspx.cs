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
    private PersonaBO personaBo = new PersonaBO();
    private SocioBO socioBO = new SocioBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            Console.Write(RegTypeUser.Value);
            //WebHelper.MostrarMensaje(Page, "error");
            PersonaEntity usuario = personaBo.factoryPersona(Convert.ToChar(RegTypeUser.Value));
            usuario.Nombre = RegName.Value;
            usuario.Apellido = RegApell.Value;
            usuario.Telefono = System.Convert.ToInt32(RegTel.Value);
            usuario.Email = RegEmail.Value;
            usuario.Password = RegPass.Value;
            usuario.Password2 = RegRepetPass.Value;
            usuario.FechaNacimiento = Convert.ToDateTime(RegfechaNac.Value);
            usuario.Sexo = Convert.ToChar( RegGender.Value);
            usuario.tipoPersona = Convert.ToChar(RegTypeUser.Value);
            usuario.dni = RegDni.Value;

            //else 
            if (usuario is SocioEntity)
            {
                socioBO.newSocio(usuario);
                
                WebHelper.MostrarMensaje(Page,"Se registro con exito Usuario" + usuario.Nombre);
                Page.Response.Redirect("~/site-web/login/SuccesCreateUser.aspx");
            }
            //}

           // personaBo.RegistrarPersona(usuario, usuario.Email);

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