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
    public class EstudiantesController : Controller
    {
        // instancia del servicio encargado de proveer los metodos
        public ServiceEstudiantes servicio = new ServiceEstudiantes();

        public EstudiantesController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var estudiante = servicio.obtenerTodos();
            return View(estudiante);
        }

        [HttpGet]
       public ActionResult Form(int? id, Operacion operacion)
        {
            var estudiante = new Estudiante();
            // Si el id tiene un valor; entonces se procede  a buscar un estudiante
            if ( id.HasValue)
            {
                estudiante = servicio.obtenerPorID(id.Value);
            }
            // Indica la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operacion;
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Form(Estudiante estudiante)
        {
            try
            {
                // Si el ID es 0; entonces se esta insertando
                if ( estudiante.id == 0)
                {
                    servicio.insertar(estudiante);
                } else
                {
                    // Si el ID es distinto de cero entonces estamos modificando
                    servicio.modificar(estudiante.id, estudiante);
                }
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                // Eliminar un estudiante
                servicio.eliminar(id);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}