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
            const string databaseName = "Template";
            const string databaseUser = "root";
            const string databasePass = "root";

            return $"Server=192.168.99.100;" +
                    $"database={databaseName};" +
                    $"uid={databaseUser};" +
                    $"pwd={databasePass};" +
                    $"pooling=true;";
        }
    }
}
