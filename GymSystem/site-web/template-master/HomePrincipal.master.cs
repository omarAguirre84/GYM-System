using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePrincipal : System.Web.UI.MasterPage
{
    public PersonaEntity p { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string tipoPersona { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        p = SessionHelper.PersonaAutenticada;
        nombre = p.Nombre;
        apellido = p.Apellido;
        switch (p.tipoPersona) {
            case 's':
            case 'S':
                tipoPersona = "Socio";
                break;

            case 'P':
            case 'p':
                tipoPersona = "Profesor";
                break;

            case 'E':
            case 'e':
                tipoPersona = "Empleado";
                break;

            default:
                tipoPersona = "Desconocido";
                break;
        }   
    }
}
