using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Text;

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
                if (empleado.tipoEmpleado == 1)
                {
                    htmlTable.Append("<td>" + "Profesor" + "</td>");
                }
                else {
                    htmlTable.Append("<td>" + "Otro Empleado" + "</td>");
                }
                
            
                htmlTable.Append("<td>");
                htmlTable.Append("<a href=\"../empleados/ViewEmpleado.aspx?id=" + empleado.Id + "\"class=\"btn btn-primary btn-xs\" ><i class=\"fa fa-eye\" ></i> Ver / Editar </a>");
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