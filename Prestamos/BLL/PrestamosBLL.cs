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
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamoss prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }

        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Personas.Any(e => e.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Prestamoss prestamos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Prestamoss.Add(prestamos);
                paso = db.SaveChanges() > 0;
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

        public static bool Modificar(Prestamoss prestamos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(prestamos).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var prestamos = db.Prestamoss.Find(id);

                if (prestamos != null)
                {
                    db.Prestamoss.Remove(prestamos);
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

        public static Prestamoss Buscar(int id)
        {
            Contexto db = new Contexto();
            Prestamoss prestamos;

            try
            {
                prestamos = db.Prestamoss.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return prestamos;
        }

        public static List<Prestamoss> GetList(Expression<Func<Prestamoss, bool>> criterio)
        {
            List<Prestamoss> lista = new List<Prestamoss>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Prestamoss.Where(criterio).ToList();
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

        public static void LlenarBalance(int Id, decimal BalancePrestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();
            var persona = db.Personas.Find(Id);

            if (persona != null)
            {
                persona.Balance = GuardarInscripcion(persona.Balance, BalancePrestamo);
                paso = (db.SaveChanges() > 0);
            }

        }
        public static decimal GuardarInscripcion(decimal BalancePersona, decimal NuevoBalance)
        {
            Contexto db = new Contexto();

            try
            {
                BalancePersona += NuevoBalance;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return NuevoBalance;
        }

        public static void RemoverPrestamo(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var persona = db.Personas.Find(Id);
                persona.Balance = 0;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
