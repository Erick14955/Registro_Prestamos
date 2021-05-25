using Microsoft.EntityFrameworkCore;
using Registro_Prestamos.DAL;
using Registro_Prestamos.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Registro_Prestamos.BLL
{
    public class PrestamoBLL
    {
        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Prestamo.Any(p => p.PrestamoId == id);
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

        public static bool Insertar(Prestamo Prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Prestamo.Add(Prestamo);
                paso = db.SaveChanges() > 0;
                AfectarBalance(Prestamo);
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

        public static bool Modificar(Prestamo Prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(Prestamo).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
                AfectarBalance(Prestamo);
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

        public static bool Guardar(Prestamo Prestamo)
        {
            if (!Existe(Prestamo.PrestamoId))
                return Insertar(Prestamo);
            else
                return Modificar(Prestamo);
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var prestamo = db.Prestamo.Find(id);

                if (prestamo != null)
                {
                    db.Prestamo.Remove(prestamo);
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

        public static Prestamo Buscar(int id)
        {
            Contexto db = new Contexto();
            Prestamo Prestamo;

            try
            {
                Prestamo = db.Prestamo.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Prestamo;
        }

        private static bool AfectarBalance(Prestamo prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;

                db.Persona.Find(prestamo.PersonaId).Balance = prestamo.Balance;
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

        public static List<Prestamo> GetPrestamo()
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Prestamo.ToList();
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

        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> criterio)
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Prestamo.Where(criterio).ToList();
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
