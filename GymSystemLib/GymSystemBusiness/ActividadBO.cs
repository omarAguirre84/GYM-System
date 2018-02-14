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

        public void saveActividad(ActividadEntity actividad) {
            try
            {
                daActividad.insertarActividad(actividad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo guardar la actividad.", ex);
            }
        }

        public Boolean getValidateActividad(string dia, int idActividad)
        {
            try
            {
                return daActividad.ValidadDiaHoraActividad(dia, idActividad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No es posible guardar la actividad. Ya  hay una actividad asignado a tal día", ex);
            }
        }

        public List<ActividadEntity> GetList()
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

        public ActividadEntity BuscarActividadPorId(int idActividad)
        {
            try
            {
                return daActividad.BuscarActividad(idActividad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }

        public Boolean DeleteActividad(int idActividad)
        {
            try
            {
                return daActividad.deleteActividad(idActividad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }

        public void ActualizarActividad(ActividadEntity actividad)
        {
            try
            {
               daActividad.ActualizarActividad(actividad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar listar Empleados.", ex);
            }
        }
    }
}
