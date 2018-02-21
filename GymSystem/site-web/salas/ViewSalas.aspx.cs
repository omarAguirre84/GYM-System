using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public partial class ViewSocios : System.Web.UI.Page
{
    protected SalaBO salaBO;
    protected List<SalaEntity> listaSalas;

    protected void Page_Load(object sender, EventArgs e)
    {
        salaBO = new SalaBO();
        listaSalas = salaBO.GetListSalas();
        
        switch (Request.QueryString["accion"])
        {
            case "actualizar":
                //actualizar(Int32.Parse(Request.QueryString["id"]), Int32.Parse(Request.QueryString["estadoActual"]));
                break;
            case "eliminar":
                //elmininarSocio(Int32.Parse(Request.QueryString["id"]));
                break;
            default:
                listaSalas = salaBO.GetListSalas();
                break;
        }

    }

}

