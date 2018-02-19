using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;

namespace GymSystemBusiness
{
    public class EmpleadoBO
    {
        private EmpleadoDA daEmpleado;

        public EmpleadoBO()
        {
            daEmpleado = new EmpleadoDA();
        }

        public void Registrar(EmpleadoEntity empleado, string emailVerificacion)
        {
            try
            {
                empleado.ValidarDatos();
                           
                if (daEmpleado.ExisteEmail(empleado.Email))
                    throw new EmailExisteExcepcionBO();

                if (empleado.Email != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                daEmpleado.Insertar(empleado);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }

        public EmpleadoEntity[] GetList()
        {
            try
            {
                return daEmpleado.ListarEmpleados(); ;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }

        public EmpleadoEntity BuscarEmpleado(int idPersona)
        {
            try
            {
                return daEmpleado.BuscarEmpleado(idPersona);
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
                daEmpleado.ActualizarEmpleado(empleado);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }
    }
}
