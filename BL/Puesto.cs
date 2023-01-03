using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Puesto
    {
        public int IdPuesto { get; set; }
        public string DescripcionPuesto { get; set; }
        public List<object> PuestoList { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                using (DL.EIgnacioTelcelEntities context = new DL.EIgnacioTelcelEntities())
                {
                    var query = context.PuestoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Puesto puesto = new Puesto();
                            puesto.IdPuesto = obj.IdPuesto;
                            puesto.DescripcionPuesto = obj.DescripcionPuesto;
                            result.Objects.Add(puesto);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Ex = ex;
            }
            return result;
        }
    }
}
