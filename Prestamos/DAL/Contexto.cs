using Microsoft.EntityFrameworkCore;
using Prestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.DAL
{

        public class Contexto : DbContext
        {
          
            public DbSet<Personas> Personas { get; set; }
            public DbSet<Prestamoss> Prestamoss { get; set; }
            public DbSet<Mora> mora { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(@"Data Source=Data\PrestamoDB1.db");
            }

        }
    
}
