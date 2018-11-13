using DataAccesLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Personas_Contactos>(entity =>
        //    {
        //    entity.HasOne(d => d.Persona)
        //        .WithMany(p => p.)
        //            .HasForeignKey(d => d.);
        //    });
        //}

        internal DbSet<Personas> Personas { get; set; }
        internal DbSet<Personas_Contactos> Personas_Contactos { get; set; }
    }
}
