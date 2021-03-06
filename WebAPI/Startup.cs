﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccesLayer;
using NSwag.AspNetCore;
using System.Reflection;
using WebAPI.Infreaestructure;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;
using BusinessLayer.Implementations;
using DataAccesLayer.DALs.Interfaces;
using DataAccesLayer.DALs.Implementatios;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ===== Add our DbContext ========
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(GetConnectionString()));

            // ===== Add Identity ========
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });

            // ===== Add MVC ========
            services.AddMvc();

            // Add swagger
            services.AddSwaggerDocumentation();

            // Agregamos las interfaces de la capa de acceso a datos.
            services.AddTransient<IDAL_Personas, DAL_Personas_EFCore>();

            // Agregamos las interfaces de la capa de negocios.
            services.AddTransient<IBL_Personas, BL_Personas>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ApplicationDbContext dbContext,
            ILoggerFactory loggerFactory
        )
        {
            loggerFactory.AddFile("Loggs/apiLogg-{Date}.txt");
            loggerFactory.AddConsole();            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwaggerDocumentation();
            }
            app.UseSwaggerDocumentation();

            app.UseAuthentication();

            app.UseMvc();

            // Colocamos un delay de 10 s. para que le de tiempo a levantar 
            // el container de la base de datos.
            Task.Delay(10000).Wait();

            // ===== Create tables ======
            //dbContext.Database.EnsureCreated();
            //if (!env.IsDevelopment())
                dbContext.Database.Migrate();
        }

        private static string GetConnectionString()
        {
            const string databaseHost = "192.168.99.100";
            const string databaseName = "webapi";
            const string databaseUser = "root";
            const string databasePass = "root";

            return $"Server={databaseHost};" +
                    $"database={databaseName};" +
                    $"uid={databaseUser};" +
                    $"pwd={databasePass};" +
                    $"pooling=true;";
        }
    }
}
