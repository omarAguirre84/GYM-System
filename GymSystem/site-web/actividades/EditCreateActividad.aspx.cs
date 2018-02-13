using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditCreateActividad : System.Web.UI.Page
{

    SalaBO salaBO = new SalaBO();
    protected SalaEntity[] listSalas;
    ActividadBO actividadBo;
    protected void Page_Load(object sender, EventArgs e)
    {
        actividadBo = new ActividadBO();
        listSalas = salaBO.GetListSalas();
        loadSalasList();
        loadDayWeek();
        if (Request.UrlReferrer != null) {
        }
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
        int idSala = Int32.Parse(salasListItems.SelectedItem.Value);
        actividadBo.saveActividad(crearActividad());
    }

    private ActividadEntity crearActividad() {
        ActividadEntity actividad = new ActividadEntity();
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