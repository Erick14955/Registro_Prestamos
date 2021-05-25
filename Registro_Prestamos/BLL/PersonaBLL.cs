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
    public class PersonaBLL
    {
        public static bool Guardar(Persona persona)
        {
            if (!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Persona.Any(e => e.PersonaId == id);
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

        private static bool Insertar(Persona persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Persona.Add(persona);
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

        private static bool Modificar(Persona persona)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
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
            Contexto contexto = new Contexto();

            try
            {
                var persona = contexto.Persona.Find(id);

                if (persona != null)
                {
                    contexto.Persona.Remove(persona);
                    paso = contexto.SaveChanges() > 0;
                }
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
        public static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona persona;

            try
            {
                persona = contexto.Persona.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return persona;
        }

        public static List<Persona> GetPersona()
        {
            List<Persona> lista = new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Persona.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> criterio)
        {
            List<Persona> lista = new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Persona.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
