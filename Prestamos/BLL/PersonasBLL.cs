using Microsoft.EntityFrameworkCore;
using Prestamos.DAL;
using Prestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prestamos.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.PersonaId))

                return Insertar(personas);
            else
                return Modificar(personas);

        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Personas.Any(d => d.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Personas.Add(personas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(personas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var persona = db.Personas.Find(id);

                if (persona != null)
                {
                    db.Personas.Remove(persona);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas personas;

            try
            {
                personas = contexto.Personas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return personas;

        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> lista = new List<Personas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Personas.Where(persona).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
