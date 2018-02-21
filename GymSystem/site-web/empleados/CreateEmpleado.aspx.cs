using GymSystemBusiness;
using GymSystemComun;
using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateEmpleado : System.Web.UI.Page
{
    private EmpleadoBO boEmpleado;
    private ActividadBO boActividad;
    protected List<ActividadEntity> ListaActividades;
    protected EmpleadoEntity empleadoEntity = new EmpleadoEntity();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionHelper.PersonaAutenticada == null)
                throw new AutenticacionExcepcionBO();
            if (SessionHelper.PersonaAutenticada.tipoPersona != 'A')
                throw new AccessDeniedExceptionBO();
            boEmpleado = new EmpleadoBO();
            if (!Page.IsPostBack)
            {
                empleadoEntity.tipoEmpleado = 1;
                boActividad = new ActividadBO();
               ListaActividades = boActividad.GetList();
               llenarViewActividades();
            }
        }
        catch (AccessDeniedExceptionBO ex)
        {
            Response.Redirect("/site-web/home/HomeSiteWeb.aspx");
        }
        catch (AutenticacionExcepcionBO ex)
        {
            Response.Redirect("/site-web/login/loginform.aspx");
        }
    }

    protected void TypeEmpladoChanged(object sender, EventArgs e) {
        Console.WriteLine();
        //string text = ((TextBox)sender).Text;
        string text = ((DropDownList)sender).SelectedItem.Value;
        if (((DropDownList)sender).SelectedItem.Value.Equals("1"))
        {
            groupActividad.Visible = true;
            empleadoEntity.tipoEmpleado = 1;
        }
        else if(((DropDownList)sender).SelectedItem.Value.Equals("2")){
            groupActividad.Visible = false;
            empleadoEntity.tipoEmpleado = 2;
        } else {
            groupActividad.Visible = true;
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            EmpleadoEntity entityEmpleado = new EmpleadoEntity(empleadoEntity.tipoEmpleado, DateTime.Today, DateTime.MinValue);
            if (groupActividad.Visible)
            {
                foreach (ListItem item in actividades.Items)
                {
                    if (item.Selected)
                    {
                        entityEmpleado.actividad = string.Concat(entityEmpleado.actividad, item.Value + ",");
                    }
                }
                entityEmpleado.tipoEmpleado = 1;
            }
            else {
                entityEmpleado.actividad = "";
                entityEmpleado.tipoEmpleado = 2;
            }
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
            entityPersona.tipoPersona = 'P';
            entityPersona.Telefono = System.Convert.ToInt32(telefono.Value);
            entityPersona.Nombre = nombre.Value;
            entityPersona.Apellido = apellido.Value;
            entityPersona.dni = dni.Value;
            entityPersona.Email = email.Value;
            //entityPersona.Password = (passw1.Value.Equals(passw2.Value)) ? passw1.Value : null;
            entityPersona.Password = passw1.Value;
            entityPersona.Password2 = passw2.Value;
            string[] fechaArr = fechaNacimiento.Value.Split('-');
            entityPersona.FechaNacimiento = Util.ObtenerFecha(
                int.Parse(fechaArr[0]),
                int.Parse(fechaArr[1]),
                int.Parse(fechaArr[2]));

            char gen;
            if (masculino.Checked)
            {
                gen = 'M';
            }
            else
            {
                gen = 'F';
            }
            entityPersona.Sexo = gen;
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