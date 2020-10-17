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
    public class MoraBLL
    {
        public class MoraBLL
        {

            public static bool Guardar(Mora moras)
            {
                if (!Existe(moras.MoraId))
                    return Insertar(moras);

                else
                    return Modificar(mora);
            }

            private static bool Insertar(Mora moras)
            {
                bool paso = false;
                Contexto db = new Contexto();

                try
                {
                    if (db.mora.Add(moras) != null)
                    {
                        foreach (var item in moras.MorasDetalles)
                        {
                            db.Prestamoss.Find(item.PrestamoId).Balance += item.Valor;
                        }
                    }

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

            public static bool Modificar(Mora mora)
            {

                bool paso = false;
                Contexto db = new Contexto();

                try
                {
                    Mora mora_anterior = db.mora.Where(e => e.MoraId == mora.MoraId)
                        .Include(d => d.MorasDetalles)
                        .FirstOrDefault();

                    db = new Contexto();

                    foreach (var item in mora_anterior.MorasDetalles)
                    {
                        if (!mora.MorasDetalles.Any(d => d.Id == item.Id))
                        {
                            db.Prestamoss.Find(item.PrestamoId).Balance -= item.Valor;
                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in mora.MorasDetalles)
                    {
                        if (item.Id == 0)
                        {
                            db.Prestamoss.Find(item.PrestamoId).Balance += item.Valor;
                            db.Entry(item).State = EntityState.Added;

                        }
                        else
                        {
                            db.Entry(item).State = EntityState.Modified;

                        }
                    }

                    db.Entry(mora).State = EntityState.Modified;
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
                    Mora moras = db.mora.Where(e => e.MoraId == id).Include(d => d.MorasDetalles).FirstOrDefault();

                    foreach (var item in moras.MorasDetalles)
                    {
                        db.Prestamoss.Find(item.PrestamoId).Balance -= item.Valor;

                    }

                    db.mora.Remove(moras);
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




            public static Mora Buscar(int id)
            {

                Contexto db = new Contexto();
                Mora moras = new Mora();

                try
                {

                    moras = db.mora.Where(o => o.MoraId == id)
                        .Include(o => o.MorasDetalles)
                        .SingleOrDefault();

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }

                return moras;

            }


            public static bool Existe(int id)
            {
                bool encontrado = false;
                Contexto db = new Contexto();


                try
                {

                    encontrado = db.mora.Any(p => p.MoraId == id);


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


            public List<Mora> GetList(Expression<Func<Mora, bool>> expression)
            {


                List<Mora> lista = new List<Mora>();
                Contexto db = new Contexto();


                try
                {
                    lista = db.mora.Where(expression).ToList();
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
