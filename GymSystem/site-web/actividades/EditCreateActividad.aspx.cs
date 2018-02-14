using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymSystemWebUtil;

public partial class EditCreateActividad : System.Web.UI.Page
{

    SalaBO salaBO = new SalaBO();
    protected SalaEntity[] listSalas;
    ActividadBO actividadBo;
    ActividadEntity actividadEnt;
    protected void Page_Load(object sender, EventArgs e)
    {
        actividadBo = new ActividadBO();
        if (!IsPostBack)
        {
            listSalas = salaBO.GetListSalas();
            loadSalasList();
            loadDayWeek();
            if (Request.QueryString["action"] == "delete")
            {
                loadEditActividad();
            }
            if (Request.QueryString["action"] == "edit")
            {
                loadEditActividad();
            }
            if (Request.UrlReferrer != null)
            {
            }
        }
    }

    private void loadEditActividad() {
        actividadEnt = actividadBo.BuscarActividadPorId(Int32.Parse(Request.QueryString["id"]));

        foreach(ListItem item in salasListItems.Items)
        {

            if (actividadEnt.idSala == Int32.Parse(item.Value))
            {

                item.Selected = true;

            }

        }
        descripcion.Value = actividadEnt.name;
        //salasListItems.SelectedItem.Value = actividadEnt.idSala.ToString();
        datein.Value = actividadEnt.horaInicio.ToString();
        dateout.Value = actividadEnt.horaFin.ToString();
        tarifa.Value = actividadEnt.tarifa.ToString().Replace(',', '.');
        diaSelectList.SelectedItem.Text =  actividadEnt.dia;
    }

    protected void loadSalasList() {
        int index = 0;
        salasListItems.Items.Insert(index++, new ListItem("Seleccione Sala", "0"));
        foreach ( SalaEntity salEnt in listSalas){
            salasListItems.Items.Insert(index++, new ListItem(salEnt.Nombre, salEnt.IdSala.ToString()));
        };
    }

    protected void btnReturnListActiv(object sender, EventArgs e)
    {
        Response.Redirect("ViewActividades.aspx");
    }

    protected void btnConfirmSaveActividad(object sender, EventArgs e)
    {
        Console.WriteLine();
        if (actividadBo.getValidateActividad(diaSelectList.SelectedItem.Text, Int32.Parse(Request.QueryString["id"])))
        {
            if (Request.QueryString["action"] != "edit")
            {
                actividadBo.saveActividad(crearActividad());
                
            }
            else {
                actividadBo.ActualizarActividad(crearActividad());
                
            }
            Response.Redirect("ViewActividades.aspx");
        }
        else {
            WebHelper.MostrarMensaje(Page, "No es posible guardar la actividad. Ya  hay una actividad asignado a tal día");
        }
         
    }

    private ActividadEntity crearActividad() {
        ActividadEntity actividad = new ActividadEntity();
        if (Request.QueryString["id"] != null) {
            actividad.idActividad = Int32.Parse(Request.QueryString["id"]);
        }
        actividad.name = descripcion.Value;
        actividad.idSala = Int32.Parse(salasListItems.SelectedItem.Value);
        actividad.horaInicio = TimeSpan.Parse(datein.Value);
        actividad.horaFin = TimeSpan.Parse(dateout.Value);
        actividad.tarifa = float.Parse(tarifa.Value.Replace('.', ',')); ;
        actividad.dia = diaSelectList.SelectedItem.Text;
        return actividad;
    }

    public void loadDayWeek()
    {
        ListItem li = new ListItem();
        diaSelectList.Items.Add(new ListItem("Seleccione día", null));
        diaSelectList.Items.Add(new ListItem("Lunes", "0"));
        diaSelectList.Items.Add(new ListItem("Martes", "1"));
        diaSelectList.Items.Add(new ListItem("Miercoles", "2"));
        diaSelectList.Items.Add(new ListItem("Jueves", "3"));
        diaSelectList.Items.Add(new ListItem("Viernes", "4"));
        diaSelectList.Items.Add(new ListItem("Sabado", "5"));
        diaSelectList.Items.Add(new ListItem("Domingo", "6"));
                
    }

    private void selectDay() {
        var names = new List<string>(new string[] { "4", "6" });

        foreach (ListItem item in diaSelectList.Items)
        {

            if (names.Contains(item.Value))
            {

                item.Selected = true;

            }

        }
    }
}