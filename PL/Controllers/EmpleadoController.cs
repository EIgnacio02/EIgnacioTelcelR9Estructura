using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.Empleado empleado = new BL.Empleado();
            BL.Result result = BL.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                empleado.EmpleadoList = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(empleado);

        }

        [HttpPost]
        public ActionResult GetAll(BL.Empleado empleado)
        {
            BL.Result result = BL.Empleado.GetAll(empleado);
            //empleado = new BL.Empleado();
            if (result.Correct)
            {
                empleado.EmpleadoList = result.Objects;
                return View(empleado);

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpleado)
        {
            BL.Empleado empleado = new BL.Empleado();

            BL.Result resultPuesto =  BL.Puesto.GetAll();
            BL.Result resultDepartamento =  BL.Departamento.GetAll();

            empleado.Puesto= new BL.Puesto();
            empleado.Departamento = new BL.Departamento();

            if (IdEmpleado == null)
            {
                empleado.Puesto.PuestoList = resultPuesto.Objects;
                empleado.Departamento.DepartamentoList = resultDepartamento.Objects;

                return View(empleado);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(BL.Empleado empleado)
        {
            BL.Result result = new BL.Result();

            if (empleado.IdEmpleado==0)
            {
                result = BL.Empleado.Add(empleado);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocrrio un error";
                }
            }
            return PartialView("Modal");

        }

        [HttpGet]
        public ActionResult Delete(int? IdEmpleado)
        {
            if (IdEmpleado>=1)
            {
                BL.Result result = BL.Empleado.Delete(IdEmpleado.Value);
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Ocurrio un errror";
            }
            return PartialView("Modal");
        }
    }
}