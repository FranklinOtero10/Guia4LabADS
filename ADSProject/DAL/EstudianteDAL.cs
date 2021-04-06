using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class EstudianteDAL
    {
        // Listado de estudiantes, a nivel de memoria del proyecto
        public static List<Estudiante> lstEstudiantes = new List<Estudiante>();

        public EstudianteDAL() { }

        public int insertarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Si el listado tiene elementos entonces se genera el ID.
                if ( lstEstudiantes.Count > 0)
                {
                    estudiante.id = lstEstudiantes.Last().id + 1;
                } else
                {
                    // Si el listado esta vacio entonces el id será por default 1
                    estudiante.id = 1;
                }
                lstEstudiantes.Add(estudiante);
                return estudiante.id;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public int modificarEstudiante( int id, Estudiante estudiante)
        {
            try
            {
                // Buscando el indice en la lista
                lstEstudiantes[lstEstudiantes.FindIndex(temp => temp.id == id)] = estudiante;
                return estudiante.id;
            }catch(Exception ex)
            {
                throw;
            }
        }

        // Para eliminar un estudiante del listado
        public bool eliminarEstudiante( int id)
        {
            try
            {
                lstEstudiantes.RemoveAt(lstEstudiantes.FindIndex(aux => aux.id == id));
                return true;
            }catch(Exception ex)
            {
                throw;
            }
        }

        // Para listar todos los estudiantes
        public List<Estudiante> obtenerTodos()
        {
            return lstEstudiantes;
        }

        // para encontrar un estudiante por ID
        public Estudiante obtenerPorID(int id)
        {
            try
            {
                var elementos = lstEstudiantes.Find(temp => temp.id == id);
                return elementos;
            }catch(Exception ex)
            {
                throw;
            }
        }

    }
}