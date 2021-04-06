using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class CarreraDAL
    {
        //Declaramos una lista de la clase carrera para guardar en memoria
        public static List<Carrera> lstCarreras = new List<Carrera>();

        //Constructor de la clase
        public CarreraDAL(){}

        public int insertarCarrera(Carrera carrera)
        {
            try
            {
                // Si el listado tiene elementos entonces se genera el ID.
                if (lstCarreras.Count > 0)
                {
                    carrera.id = lstCarreras.Last().id + 1;
                }
                else
                {
                    // Si el listado esta vacio entonces el id será por default 1
                    carrera.id = 1;
                }
                lstCarreras.Add(carrera);
                return carrera.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarCarrera(int id, Carrera carrera)
        {
            try
            {
                // Buscando el indice en la lista
                lstCarreras[lstCarreras.FindIndex(temp => temp.id == id)] = carrera;
                return carrera.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool eliminarCarrera(int id)
        {
            try
            {
                lstCarreras.RemoveAt(lstCarreras.FindIndex(aux => aux.id == id));
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Carrera> obtenerTodos()
        {
            return lstCarreras;
        }

        // para encontrar una carrera por ID
        public Carrera obtenerPorID(int id)
        {
            try
            {
                var elementos = lstCarreras.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}