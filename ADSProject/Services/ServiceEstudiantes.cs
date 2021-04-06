using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceEstudiantes
    {
        // Instancia para acceder a todos los metodos de la DAL
        public EstudianteDAL estudianteDal = new EstudianteDAL();

        // Para insertar estudiante
        public int insertar(Estudiante estudiante)
        {
            try
            {
                return estudianteDal.insertarEstudiante(estudiante);
            }catch(Exception ex)
            {
                throw;
            }
        }

        // Para modificar un estudiante
        public int modificar( int id, Estudiante estudiante)
        {
            try
            {
                return estudianteDal.modificarEstudiante(id, estudiante);
            }catch(Exception ex)
            {
                throw;
            }
        }

        // Para eliminar

        public bool eliminar( int id)
        {
            try
            {
                return estudianteDal.eliminarEstudiante(id);
            }catch(Exception ex)
            {
                throw;
            }
        }

        // Para obtener todos los estudiantes.
        public List<Estudiante> obtenerTodos()
        {
            return estudianteDal.obtenerTodos();
        }

        // Para obtener por ID.
        public Estudiante obtenerPorID( int id)
        {
            try
            {
                return estudianteDal.obtenerPorID(id);
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}