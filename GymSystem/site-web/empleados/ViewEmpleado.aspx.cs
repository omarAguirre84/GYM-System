﻿using GymSystemBusiness;
using GymSystemComun;
using GymSystemEntity;
using GymSystemWebUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewEmpleado : System.Web.UI.Page
{
    private EmpleadoBO boEmpleado;
    private EmpleadoEntity nuevoEmpleado;
    private ActividadBO boActividad;
    protected List<ActividadEntity> actividadesArr;
    private string[] diasArr;


    protected void Page_Load(object sender, EventArgs e)
    {
        boEmpleado = new EmpleadoBO();
        boActividad = new ActividadBO();

        if (!IsPostBack) //false = primera vez que se carga, true= segunda vez, se cambiaron los datos
        {
            //boActividad = new ActividadBO();
            actividadesArr = boActividad.GetList();
            loadActividadList();
            cargarDatoscargarDatosEmpleadoEnVista();
        }
    }

    protected void cargarDatoscargarDatosEmpleadoEnVista() {
        PopularView(boEmpleado.BuscarEmpleado(Int32.Parse(Request.QueryString["id"])), false);
    }

     protected void PopularView(EmpleadoEntity empleado, Boolean origen)
     { 
         try
         {
            nombre.Attributes.Add("Value", empleado.Nombre);
            apellido.Attributes.Add("Value", empleado.Apellido);
            dni.Attributes.Add("Value", Convert.ToString(empleado.dni));
            email.Attributes.Add("Value", empleado.Email);
            telefono.Attributes.Add("Value", Convert.ToString(empleado.Telefono));

            string[] fechaArr = empleado.FechaNacimiento.ToString("dd'/'MM'/'yyyy").Split('/');
            fechaNacimiento.Attributes.Add("value", (fechaArr[2] + "-" + fechaArr[1] + "-" + fechaArr[0]));

            string[] fechaIng = empleado.fechaIngreso.ToString("dd'/'MM'/'yyyy").Split('/');
            fechaIngreso.Attributes.Add("value", (fechaIng[2] + "-" + fechaIng[1] + "-" + fechaIng[0]));

            if (empleado.Sexo == 'm' || empleado.Sexo == 'M')
            {
                 
            }
            if (empleado.Sexo == 'f' || empleado.Sexo == 'F')
            {
                 
            }
            llenarViewActividadesConDatosEmpleado(empleado);
//            llenarDiasConDatosEmpleado(empleado);
         }
         catch (AutenticacionExcepcionBO ex)
         {
             WebHelper.MostrarMensaje(Page, ex.Message);
         }
         catch (Exception ex)
         {
             WebHelper.MostrarMensaje(Page, ex.Message);
         }
     }
     protected void Btn_cancelar(object sender, EventArgs e)
     {
         Response.Redirect("../empleados/ViewEmpleados.aspx");
     }

     protected void Btn_actualizar(object sender, EventArgs e)
     {
         try
         {
             boEmpleado.ActualizarEmpleado(nuevoEntity(boEmpleado.BuscarEmpleado(Int32.Parse(Request.QueryString["id"]))));
             PopularView(boEmpleado.BuscarEmpleado(Int32.Parse(Request.QueryString["id"])), true);
            //Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            cargarDatoscargarDatosEmpleadoEnVista();
             WebHelper.MostrarMensaje(Page, "Actualizado con exito");
         }
         catch (Exception ex)
         {
             WebHelper.MostrarMensaje(Page, ("Error de datos: " + ex));
         }
     }

    protected void loadActividadList()
    {
        int index = 0;
        //actividades.Items.Insert(index++, new ListItem("Seleccione Actividad", "0"));
        foreach (ActividadEntity ActEnt in actividadesArr)
        {
            actividades.Items.Insert(index++, new ListItem(ActEnt.name, ActEnt.idActividad.ToString()));
        };
        loadEditActividad();
    }

    private void loadEditActividad()
    {
        List<int> listSelectActividad = boActividad.BuscarActividadEmpleadoPorId(Int32.Parse(Request.QueryString["id"]));

        foreach (ListItem item in actividades.Items)
        {

            if (listSelectActividad.Contains(Int32.Parse(item.Value)))
            {

                item.Selected = true;

            }
            else {
                item.Selected = false;
            }

        }
    }

        protected EmpleadoEntity nuevoEntity(EmpleadoEntity anterior)
     {
         EmpleadoEntity nuevoEntity = new EmpleadoEntity(
             anterior.tipoEmpleado, anterior.fechaIngreso, anterior.fechaEgreso
             );
         try
         {
             nuevoEntity.Id = anterior.Id;
             nuevoEntity.tipoPersona = anterior.tipoPersona;
             nuevoEntity.Nombre = nombre.Text;
             nuevoEntity.Telefono = System.Convert.ToInt32(telefono.Text);
             nuevoEntity.Apellido = apellido.Text;
             nuevoEntity.dni = dni.Text;
             nuevoEntity.Email = email.Text;
             nuevoEntity.Password = (passw1.Text.Equals(passw2.Text) & !passw1.Text.Equals("********")) ? passw1.Text : anterior.Password;

             string[] fechaNacArr = fechaNacimiento.Value.Split('-');
             nuevoEntity.FechaNacimiento = Util.ObtenerFecha(
                 int.Parse(fechaNacArr[0]),
                 int.Parse(fechaNacArr[1]),
                 int.Parse(fechaNacArr[2]));

            string[] fechaIngrArr = fechaNacimiento.Value.Split('-');
            nuevoEntity.FechaNacimiento = Util.ObtenerFecha(
                int.Parse(fechaIngrArr[0]),
                int.Parse(fechaIngrArr[1]),
                int.Parse(fechaIngrArr[2]));

            char gen;
             if (sexos.SelectedValue.Equals("masculino"))
             {
                 gen = 'M';
                //masculino.Attributes.Add("checked", "checked");
                //femenino.Attributes.Remove("checked");
            }
            else
             {
                 gen = 'F';
                //femenino.Attributes.Add("checked", "checked");
                //masculino.Attributes.Remove("checked");
            }
            nuevoEntity.Sexo = gen;
             nuevoEntity.Foto = null;
             nuevoEntity.FechaRegistracion = anterior.FechaRegistracion;
             nuevoEntity.FechaActualizacion = DateTime.Now;
            foreach (ListItem item in actividades.Items)
            {

                if (item.Selected)
                {
                    nuevoEntity.actividad = string.Concat(nuevoEntity.actividad, item.Value + ",");
                    Console.WriteLine(item.Text);

                }

            }
        }
         catch (AutenticacionExcepcionBO ex)
         {
             WebHelper.MostrarMensaje(Page, ex.Message);
             nuevoEntity = null;
         }
         catch (Exception ex)
         {
             WebHelper.MostrarMensaje(Page, ex.Message);
             nuevoEntity = null;
         }
         return nuevoEntity;
    }

    public void llenarViewActividadesConDatosEmpleado(EmpleadoEntity empleado)
    {
        ListItem li = new ListItem();
        li = new ListItem();
        li.Text = empleado.actividad;
        li.Value = empleado.actividad;
        li.Selected = true;
        //actividades.Items.Add(li);
        /*foreach (ActividadEntity act in actividadesArr)
        {
            if (act != null)
            {
                li = new ListItem();
                li.Text = act.descripcion;
                li.Value = act.descripcion;
                actividades.Items.Add(li);
            }
        }*/
    }

    
}