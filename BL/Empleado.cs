using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public int IdPuesto { get; set; }
        public int IdDepartamento { get; set; }
        public List<object> EmpleadoList { get; set; }
        public Departamento Departamento { get; set; }
        public Puesto Puesto { get; set; }

        public static Result GetAll(Empleado empleado)
        {
            Result result = new Result();
            //if (empleado.Nombre == null)
            //{
            //    empleado.Nombre = "";
            //}
            try
            {
                using (DL.EIgnacioTelcelEntities context= new DL.EIgnacioTelcelEntities())
                {
                    empleado.Nombre = ((empleado.Nombre == null) ? "" : empleado.Nombre);
                    var query = context.EmpleadoGetAll(empleado.Nombre).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            Empleado empleadoBuscar = new Empleado();

                            empleadoBuscar.IdEmpleado = obj.IdEmpleado;
                            empleadoBuscar.Nombre = obj.Nombre;

                            empleadoBuscar.Puesto = new Puesto();
                            empleadoBuscar.Puesto.IdPuesto = (int)obj.IdPuesto;
                            empleadoBuscar.Puesto.DescripcionPuesto = obj.DescripcionPuesto;

                            empleadoBuscar.Departamento = new Departamento();
                            empleadoBuscar.Departamento.IdDepartamento = (int)obj.IdDepartamento;
                            empleadoBuscar.Departamento.DescripcionDepartamento= obj.DescripcionDepartamento;

                            result.Objects.Add(empleadoBuscar);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
            }

            return result;
        }

        public static Result Add(Empleado empleado)
        {
            Result result = new Result();

            try
            {
                using (DL.EIgnacioTelcelEntities context = new DL.EIgnacioTelcelEntities())
                {
                    var query = context.EmpleadoAdd(empleado.Nombre,empleado.Puesto.IdPuesto,empleado.Departamento.IdDepartamento);
                    if (query>0)
                    {
                        result.Message = "Se agregaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un error ";
                result.Ex = ex;
            }
            return result;
        }

        public static Result Delete(int IdEmpleado)
        {
            Result result = new Result();

            try
            {
                using (DL.EIgnacioTelcelEntities context = new DL.EIgnacioTelcelEntities())
                {
                    var query = context.EmpleadoDelete(IdEmpleado);
                    if (query>0)
                    {
                        result.Message = "Se elimino correctamente ";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un problema";
                result.Ex = ex;
            }

            return result;
        }
    }
}
