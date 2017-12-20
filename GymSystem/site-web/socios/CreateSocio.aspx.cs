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

public partial class CreateSocio : System.Web.UI.Page
{
    private SocioBO boSocio;

    protected void Page_Load(object sender, EventArgs e)
    {
        boSocio = new SocioBO();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            SocioEntity entitySocio = new SocioEntity(new Random().Next(1, 99999), 1);
            entitySocio = (SocioEntity)popularEntity(entitySocio);

            boSocio.Registrar(entitySocio, entitySocio.Email.Trim());
            WebHelper.MostrarMensaje(Page, ("Socio "+entitySocio.Nombre +" "+ entitySocio.Apellido + " creado con exito."));
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
        catch (FormatException ex)
        {
            //WebHelper.MostrarMensaje(Page, ex.Message);
            WebHelper.MostrarMensaje(Page, ("Error en ingreso de datos: " + ex));
        }
        catch (Exception ex)
        {
            //WebHelper.MostrarMensaje(Page, ex.Message);
            WebHelper.MostrarMensaje(Page, ("Error en ingreso de datos: " + ex));
        }
    }

    protected PersonaEntity popularEntity(PersonaEntity entityPersona)
    {
        try
        {
            entityPersona.tipoPersona = 'S';
            entityPersona.Telefono = System.Convert.ToInt32(telefono.Value);
            entityPersona.Nombre = nombre.Value;
            entityPersona.Apellido = apellido.Value;
            entityPersona.Dni = Int32.Parse(dni.Value);
            entityPersona.Email = email.Value;
            entityPersona.Password = (passw1.Value.Equals(passw2.Value)) ? passw1.Value : null;
            
            string[] fechaArr = fechaNacimiento.Value.Split('-');
            entityPersona.FechaNacimiento = Util.ObtenerFecha(
                int.Parse(fechaArr[0]),
                int.Parse(fechaArr[1]),
                int.Parse(fechaArr[2]));
            entityPersona.Sexo = System.Convert.ToChar(sexos.SelectedValue);
            entityPersona.Foto = null;
            entityPersona.FechaRegistracion = DateTime.Now;
            entityPersona.FechaActualizacion = DateTime.Now;
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            entityPersona = null;
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            entityPersona = null;
        }
        return entityPersona;
    }

}