using Microsoft.EntityFrameworkCore;
using Registro_Prestamos.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Prestamos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/DatosPrestamos");
        }
    }
}
