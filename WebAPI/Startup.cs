using System;
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
            SetupDependencies();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ===== Add our DbContext ========
            services.AddDbContext<ApplicationDbContext>();

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }

            app.UseAuthentication();

            // Swagger
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    NJsonSchema.PropertyNameHandling.CamelCase;

            });

            app.UseMvc();

            // ===== Create tables ======
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }

        private static void SetupDependencies()
        {
            //Program.blPersonas = new BusinessLayer.Implementations.BL_Personas(new DataAccesLayer.DALs.Implementatios.DAL_Personas_EFCore());
        }
    }
}
