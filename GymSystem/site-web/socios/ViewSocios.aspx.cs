using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSocios : System.Web.UI.Page
{
    SocioBO s;
    StringBuilder htmlTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        s = new SocioBO();
        GenerarTabla(htmlTable);
    }

    private void GenerarTabla(StringBuilder htmlTable)
    {
        htmlTable = new StringBuilder();
        foreach (SocioEntity socio in s.GetList())
        {
            if(socio != null)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + socio.Nombre + "</td>");
                htmlTable.Append("<td>" + socio.Apellido + "</td>");
                htmlTable.Append("<td>" + socio.Email+ "</td>");
                htmlTable.Append("<td>" + socio.Telefono + "</td>");
                htmlTable.Append("<td>" + socio.FechaNacimiento.ToString("dd'/'MM'/'yyyy")+ "</td>");
                htmlTable.Append("<td>" + socio.NroTarjetaIdentificacion + "</td>");
                htmlTable.Append("<td>");
                htmlTable.Append(SetBtnEstado(socio.IdEstado));
                htmlTable.Append("</td>");
                htmlTable.Append("<td>");
                htmlTable.Append("<a href=\"../socios/ViewSocio.aspx?id="+ socio.Id + "\"class=\"btn btn-primary btn-xs\" ><i class=\"fa fa-eye\" ></i> Ver / Editar </a>");
                //htmlTable.Append("<a href=\"#\" class=\"btn btn-info btn-xs\" ><i class=\"fa fa-pencil\" ></i> Editar </a>");
                htmlTable.Append("</td>");
                htmlTable.Append("</tr>");
            }
        }
        TablaPlaceHolder.Controls.Add(new Literal{
            Text = htmlTable.ToString()
        });
    }

    private string SetBtnEstado(int estado) {
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
        cadena.Append("<a href = \"#\" class=\"btn btn-");
        cadena.Append(btn);
        cadena.Append("btn-xs\"><i class=\"fa fa-thumbs-o-");
        cadena.Append(thumb);
        cadena.Append("\"></i>");
        cadena.Append(texto);
        cadena.Append("</a>");

        return cadena.ToString();
    }

       
}

