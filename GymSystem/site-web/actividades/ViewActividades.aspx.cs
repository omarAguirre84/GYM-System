using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewActividades : System.Web.UI.Page
{
    ActividadBO activBo = new ActividadBO();
    protected ActividadEntity[] listActiv;
    SalaBO salaBO = new SalaBO();
    protected SalaEntity[] listSalas;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listActiv = activBo.GetList();
            listSalas = salaBO.GetListSalas();
            Console.WriteLine(listActiv);
        }

        if (Request.QueryString["action"] == "delete")
        {
            this.deleteActividad();
        }
    }

    protected void deleteActividad()
    {
        Console.WriteLine("Se Eliminar Actividad");
        Response.Redirect("ViewActividades.aspx");
    }
}