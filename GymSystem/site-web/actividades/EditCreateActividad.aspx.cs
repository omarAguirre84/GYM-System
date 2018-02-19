using GymSystemBusiness;
using GymSystemEntity;
using System;
using System.Collections.Generic;
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
                loadEditActividad("delete");
            }
            if (Request.QueryString["action"] == "edit")
            {
                loadEditActividad("edit");
            }
            if (Request.UrlReferrer != null)
            {
            }
        }
    }

    private void loadEditActividad(String action)
    {
        actividadEnt = actividadBo.BuscarActividadPorId(Int32.Parse(Request.QueryString["id"]));

        foreach (ListItem item in salasListItems.Items)
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
        diaSelectList.SelectedItem.Text = actividadEnt.dia;
    }

    protected void loadSalasList()
    {
        int index = 0;
        salasListItems.Items.Insert(index++, new ListItem("Seleccione Sala", "0"));
        foreach (SalaEntity salEnt in listSalas)
        {
            salasListItems.Items.Insert(index++, new ListItem(salEnt.Nombre, salEnt.IdSala.ToString()));
        };
    }

    protected void btnReturnListActiv(object sender, EventArgs e)
    {
        Response.Redirect("ViewActividades.aspx");
    }

    protected void btnConfirmSaveActividad(object sender, EventArgs e)
    {
        try
        {
            if (hayCamposVacios())
            {
                WebHelper.MostrarMensaje(Page, "No es posible guardar la actividad. Se deben completar todos los campos.");
            }
            else if (!esHorarioValido())
            {
                WebHelper.MostrarMensaje(Page, "No es posible guardar la actividad. La hora de inicio debe ser menor a la de finalización.");
            }
            else
            {
                ActividadEntity actividad = crearActividad();
                if (!actividadBo.getValidateActividadNombre(actividad.name, actividad.idActividad))
                    throw new Exception("No es posible guardar la actividad. Ya  hay una actividad con el mismo nombre.");
                if(!actividadBo.getValidateActividad(actividad.dia, actividad.idActividad))
                    throw new Exception("No es posible guardar la actividad. Ya  hay una actividad asignado a tal día");

                if (Request.QueryString["action"] != "edit")
                {
                    actividadBo.saveActividad(actividad);
                }
                else
                {
                    actividadBo.ActualizarActividad(actividad);

                }
                Response.Redirect("ViewActividades.aspx");
            }
        }
        catch (Exception ex){
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    private bool hayCamposVacios()
    {
        bool hayVacios = false;

        Console.WriteLine(diaSelectList.SelectedItem.Text.Trim());
        Console.WriteLine(salasListItems.SelectedItem.Text.Trim());
        Console.WriteLine(datein.Value.Trim());

        if (descripcion.Value.Trim().Equals("")
            || tarifa.Value.Trim().Equals("")
            || datein.Value.Trim().Equals("")
            || dateout.Value.Trim().Equals("")
            || diaSelectList.SelectedItem.Text.Trim().Equals("")
            || diaSelectList.SelectedItem.Text.Trim().Equals("Seleccione día")
            || salasListItems.SelectedItem.Text.Trim().Equals("")
            || salasListItems.SelectedItem.Text.Trim().Equals("Seleccione Sala")
                )
        {
            hayVacios = true;
        }
        return hayVacios;
    }

    private bool esHorarioValido()
    {
        return TimeSpan.Parse(dateout.Value) > TimeSpan.Parse(datein.Value);
    }

    private ActividadEntity crearActividad()
    {
        ActividadEntity actividad = new ActividadEntity();
        if (Request.QueryString["id"] != null)
        {
            actividad.idActividad = Int32.Parse(Request.QueryString["id"]);
        }
        actividad.name = descripcion.Value;
        actividad.idSala = Int32.Parse(salasListItems.SelectedItem.Value);
        actividad.horaInicio = datein.Value.Equals("") ? TimeSpan.MinValue : TimeSpan.Parse(datein.Value);
        actividad.horaFin = dateout.Value.Equals("") ? TimeSpan.MinValue : TimeSpan.Parse(dateout.Value);
        actividad.tarifa = tarifa.Value.Equals("") ? -1 : float.Parse(tarifa.Value.Replace('.', ',')); ;
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

    private void selectDay()
    {
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