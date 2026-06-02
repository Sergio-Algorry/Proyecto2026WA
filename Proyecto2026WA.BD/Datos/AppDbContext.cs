using Microsoft.EntityFrameworkCore;
using Proyecto2026WA.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2026WA.BD.Datos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domiclio> Domicilios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaDomicilio> PersonasDomicilios { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }
    }
}
