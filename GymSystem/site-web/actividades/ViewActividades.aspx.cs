﻿using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemWebUtil;

public partial class ViewActividades : System.Web.UI.Page
{
    protected ActividadBO activBo = new ActividadBO();
    protected List<ActividadEntity> listActiv;
    protected SalaBO salaBO = new SalaBO();
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
            deleteActividad(Int32.Parse(Request.QueryString["id"]));
        }
    }

    protected void deleteActividad(int idActividad)
    {
        Console.WriteLine("Se Eliminar Actividad");
        if (activBo.DeleteActividad(idActividad))
        {
            Response.Redirect("ViewActividades.aspx");
        }
        else {
            WebHelper.MostrarMensaje(Page, "No es posible eliminar la actividad. Intente nuevamente");
        }
        
    }
}