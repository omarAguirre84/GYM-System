using System;
using GymSystemEntity;
using GymSystemWebUtil;
using GymSystemBusiness;


public partial class site_web_profile_EditProfile : System.Web.UI.Page
{
    protected PersonaEntity persona;
    protected PersonaBO personaBo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionHelper.PersonaAutenticada != null)
        {
            personaBo = new PersonaBO();
            persona = SessionHelper.PersonaAutenticada;
            if (!IsPostBack) { 
            
            loadDataPersona();
            }
        }
        else
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
    }

    private void loadDataPersona() {
        nombre.Value = persona.Nombre;
        apellido.Value = persona.Apellido;
        dni.Value = persona.dni;
        fechanacimiento.Attributes["value"] = persona.FechaNacimiento.ToString("yyyy-MM-dd");
        contrasenia.Attributes["value"] = persona.Password;
        confirmcontrasenia.Attributes["value"] = persona.Password;
        if (persona.Sexo == 'M') {
            genderM.Checked = true;
        } else {
            genderF.Checked = true;
        }
        Console.WriteLine(genderM);
        //Console.WriteLine(genderF);
    }

    protected void btn_returnProfile(object sender, EventArgs e) {
        Response.Redirect("Profile.aspx");
    }

    protected void rbtn_CheckedChanged(object sender, EventArgs e) {
        if (genderM.Checked)
        {
            genderM.Checked = true;
            genderF.Checked = false;
        }
        else
        {
            genderM.Checked = false;
            genderF.Checked = true;
        }
    }

    protected void btn_saveProfile(object sender, EventArgs e)
    {
        PersonaEntity personaSend;
        if (persona.tipoPersona == 'S') {
            personaSend = new SocioEntity();
        } else {
            personaSend = new EmpleadoEntity();
        }
        personaSend.Id = persona.Id;
        personaSend.Nombre = nombre.Value;
        personaSend.Apellido =  apellido.Value;
        personaSend.dni = dni.Value;
        personaSend.FechaNacimiento = DateTime.Parse(fechanacimiento.Attributes["value"]);
        personaSend.Password = contrasenia.Attributes["value"];
        if (genderM.Checked)
        {
            personaSend.Sexo = 'M';
        }
        else
        {
            personaSend.Sexo = 'F';
        }

        personaBo.saveProfile(personaSend);
        SessionHelper.AlmacenarPersonaAutenticada(personaBo.Autenticar(persona.Email, personaSend.Password));
        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.PersonaAutenticada.Email, false);
        Response.Redirect("Profile.aspx");
    }

    
}