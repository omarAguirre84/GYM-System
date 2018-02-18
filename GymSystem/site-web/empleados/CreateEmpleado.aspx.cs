using GymSystemBusiness;
using GymSystemComun;
using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateEmpleado : System.Web.UI.Page
{
    private EmpleadoBO boEmpleado;
    private ActividadBO boActividad;
    protected List<ActividadEntity> ListaActividades;


    protected void Page_Load(object sender, EventArgs e)
    {
        boEmpleado = new EmpleadoBO();
        if (!Page.IsPostBack)
        {
           boActividad = new ActividadBO();
           ListaActividades = boActividad.GetList();
           llenarViewActividades();
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            EmpleadoEntity entityEmpleado = new EmpleadoEntity(1, DateTime.Today, DateTime.MinValue);
            foreach (ListItem item in actividades.Items)
            {
                if (item.Selected)
                {
                    entityEmpleado.actividad = string.Concat(entityEmpleado.actividad, item.Value + ",");
                    Console.WriteLine(item.Text);
                }
            }
            //entityEmpleado.actividad = entityEmpleado.actividad == null ? null : entityEmpleado.actividad.Trim(',');
            entityEmpleado = (EmpleadoEntity)popularEntity(entityEmpleado);

            boEmpleado.Registrar(entityEmpleado, entityEmpleado.Email.Trim());
            WebHelper.MostrarMensaje(Page, ("Empleado " + entityEmpleado.Nombre + " " + entityEmpleado.Apellido + " creado con exito."));
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
        catch (FormatException ex)
        {
            WebHelper.MostrarMensaje(Page, ("Error en ingreso de datos: " + ex));
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ("Error en ingreso de datos: " + ex));
        }
    }

    protected EmpleadoEntity popularEntity(EmpleadoEntity entityPersona)
    {
        try
        {
            entityPersona.tipoPersona = 'S';
            entityPersona.Telefono = System.Convert.ToInt32(telefono.Value);
            entityPersona.Nombre = nombre.Value;
            entityPersona.Apellido = apellido.Value;
            entityPersona.dni = dni.Value;
            entityPersona.Email = email.Value;
            entityPersona.Password = (passw1.Value.Equals(passw2.Value)) ? passw1.Value : null;

            string[] fechaArr = fechaNacimiento.Value.Split('-');
            entityPersona.FechaNacimiento = Util.ObtenerFecha(
                int.Parse(fechaArr[0]),
                int.Parse(fechaArr[1]),
                int.Parse(fechaArr[2]));
            entityPersona.Sexo = System.Convert.ToChar(sexos.SelectedValue);
            entityPersona.Foto = null;
            entityPersona.FechaRegistracion = DateTime.Now;
            entityPersona.FechaActualizacion = DateTime.Now;

            
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            entityPersona = null;
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
            entityPersona = null;
        }
        return entityPersona;
    }

    public void llenarViewActividades() {
        ListItem li = new ListItem();
        actividades.Items.Clear();
        foreach (ActividadEntity act in ListaActividades) {
            if (act != null) { 
                li = new ListItem();
                li.Text = act.descripcion;
                li.Value = act.descripcion;
                actividades.Items.Add(new ListItem(act.name, act.idActividad.ToString()));
            }
        }
    }
    
    protected void BtnCancelar_click(object sender, EventArgs e)
    {
        Response.Redirect("../empleados/ViewEmpleados.aspx");
    }
}