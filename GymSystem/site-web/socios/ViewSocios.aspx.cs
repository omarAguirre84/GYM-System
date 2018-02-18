using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

public partial class ViewSocios : System.Web.UI.Page
{
    protected SocioBO socioBO;
    protected StringBuilder htmlTable;
    protected List<SocioEntity> listaSocios;

    protected void Page_Load(object sender, EventArgs e)
    {
        socioBO = new SocioBO();

        if ((Request.QueryString["accion"] == "actualizar"))
        {
            actualizarEstado(Int32.Parse(Request.QueryString["id"]), Int32.Parse(Request.QueryString["estadoActual"]));
        }
        else {
            listaSocios = socioBO.GetList();
        }
    }

    protected string SetBtnEstado(int estado, int id) {
        StringBuilder cadena = new StringBuilder();
        string btn;
        string thumb;
        string texto;

        switch (estado)
        {
            case 1:
                btn = "success ";
                thumb = "up";
                texto = "Activo";
                break;
            case 2:
            default:
                btn = "danger ";
                thumb = "down";
                texto = "Inactivo";
                break;
        }
        
        //< a href = "#" class="btn btn-success btn-xs"><i class="fa fa-thumbs-o-up"></i> activo</a>
        cadena.Append("<a href=\"../socios/ViewSocios.aspx?id="+id+"&accion=actualizar&estadoActual="+estado + "\" class=\"btn btn-");
        cadena.Append(btn);
        cadena.Append("btn-xs\"><i class=\"fa fa-thumbs-o-");
        cadena.Append(thumb);
        cadena.Append("\"></i>");
        cadena.Append(texto);
        cadena.Append("</a>");

        return cadena.ToString();
    }

    protected void actualizarEstado(int id, int estadoActual) {
        int estadoNuevo = (estadoActual == 2) ? 1 : 2;
        socioBO.ActualizarEstadoSocio(id, estadoNuevo);
        Response.Redirect("ViewSocios.aspx");
    }
}

