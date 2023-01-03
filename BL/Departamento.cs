using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }
        public List<object> DepartamentoList { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DL.EIgnacioTelcelEntities context= new DL.EIgnacioTelcelEntities())
                {
                    var query = context.DepartamentoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Departamento departamento = new Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.DescripcionDepartamento = obj.DescripcionDepartamento;
                            result.Objects.Add(departamento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
            }

            return result;
        }
    }
}
