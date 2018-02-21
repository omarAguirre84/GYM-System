using System.Collections.Generic;
using GymSystemEntity;
using GymSystemData;
using GymSystemDataSQLServer;
using System;

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

        public List<EmpleadoEntity> GetList()
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

        public Boolean EliminarEmpleado(int idEmpleado)
        {
            Boolean res = false;
            try
            {
                daEmpleado.EliminarEmpleado(idEmpleado);
                res = true;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo eliminar Empleado.", ex);
            }
            return res;
        }
    }
}
