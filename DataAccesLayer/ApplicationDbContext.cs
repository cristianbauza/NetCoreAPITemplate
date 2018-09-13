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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString());
        }

        internal DbSet<Personas> Personas { get; set; }

        private static string GetConnectionString()
        {
            const string databaseName = "webapi";
            const string databaseUser = "webapi";
            const string databasePass = "webapi";

            return $"Server=db;" +
                    $"database={databaseName};" +
                    $"uid={databaseUser};" +
                    $"pwd={databasePass};" +
                    $"pooling=true;";
        }
    }
}
