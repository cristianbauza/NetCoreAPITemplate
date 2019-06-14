using DataAccesLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Personas_Contactos> Personas_Contactos { get; set; }
        public DbSet<Personas_Contactos_Tipos> Personas_Contactos_Tipos { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<TipoDeSeguro> TiposDeSeguros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
