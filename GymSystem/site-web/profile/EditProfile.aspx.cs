using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemEntity;
using GymSystemWebUtil;
using GymSystemBusiness;
using System.Globalization;


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

        persona.Nombre = nombre.Value;
        persona.Apellido =  apellido.Value;
        persona.dni = dni.Value;
        persona.FechaNacimiento = DateTime.Parse(fechanacimiento.Attributes["value"]);
        persona.Password = contrasenia.Attributes["value"];
        if (genderM.Checked)
        {
            persona.Sexo = 'M';
        }
        else
        {
            persona.Sexo = 'F';
        }

        personaBo.saveProfile(persona);
        Response.Redirect("Profile.aspx");
    }

    
}