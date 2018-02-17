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
    EmpleadoBO e;
    StringBuilder htmlTable;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        this.e = new EmpleadoBO();
        GenerarTabla(htmlTable);
    }

    private void GenerarTabla(StringBuilder htmlTable)
    {
        htmlTable = new StringBuilder();
        foreach (EmpleadoEntity empleado in e.GetList())
        {
            if (empleado != null)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + empleado.Nombre + "</td>");
                htmlTable.Append("<td>" + empleado.Apellido + "</td>");
                htmlTable.Append("<td>" + empleado.Email + "</td>");
                htmlTable.Append("<td>" + empleado.Telefono + "</td>");
                htmlTable.Append("<td>" + empleado.actividad + "</td>");
                htmlTable.Append("<td>" + empleado.dia + "</td>");
                htmlTable.Append("<td>");
                htmlTable.Append("<a href=\"../empleados/ViewEmpleado.aspx?id=" + empleado.Id + "\"class=\"btn btn-primary btn-xs\" ><i class=\"fa fa-eye\" ></i> Ver / Editar </a>");
                //htmlTable.Append("<a href=\"#\" class=\"btn btn-info btn-xs\" ><i class=\"fa fa-pencil\" ></i> Editar </a>");
                htmlTable.Append("</td>");
                htmlTable.Append("</tr>");
            }
        }
        TablaPlaceHolder.Controls.Add(new Literal
        {
            Text = htmlTable.ToString()
        });
    }
}