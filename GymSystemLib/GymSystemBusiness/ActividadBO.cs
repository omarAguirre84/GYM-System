using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class ActividadBO {  
        private ActividadDA daActividad;

        public ActividadBO()
        {
            daActividad = new ActividadDA();
        }

        public void Registrar(EmpleadoEntity empleado, string emailVerificacion)
        {
            try
            {
                empleado.ValidarDatos();

                if (daActividad.ExisteEmail(empleado.Email))
                    throw new EmailExisteExcepcionBO();

                if (empleado.Email != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                daActividad.Insertar(empleado);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public ActividadEntity[] GetList()
        {
            try
            {
                return daActividad.ListarActividades(); ;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }

        public ActividadEntity BuscarActividad(int idPersona)
        {
            try
            {
                return daActividad.BuscarActividad(idPersona);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }

        public void ActualizarEmpleado(EmpleadoEntity empleado)
        {
            try
            {
                //daActividad.ActualizarEmpleado(empleado);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }
    }
}
