using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADSProject.Controllers
{
    public class CarrerasController : Controller
    {
        public ServiceCarrera servicioCarrera = new ServiceCarrera();

        public CarrerasController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var Carrera = servicioCarrera.obtenerTodos();
            return View(Carrera);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var carrera = new Carrera();

            if (id.HasValue)
            {
                carrera = servicioCarrera.obtenerPorID(id.Value);
            }
            ViewData["Operacion"] = operacion;

            return View(carrera);
        }

        [HttpPost]
        public ActionResult Form(Carrera carrera)
        {
            try
            {
                if (carrera.id == 0)
                {
                    servicioCarrera.insertar(carrera);
                }
                else
                {
                    servicioCarrera.modificar(carrera.id, carrera);
                }
                return RedirectToAction("Index");
            }
            catch ( Exception e)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                servicioCarrera.eliminar(id);
                return RedirectToAction("Index");
            }
            catch ( Exception e)
            {
                throw;
            }
        }
    }
}