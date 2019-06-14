﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;

namespace WebAPI.Infreaestructure
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = ".NET Core API Template With MySQL - v1.0", Version = "v1.0" });

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, IConfiguration conf)
        {
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "help";
                s.SwaggerEndpoint(conf["SwaggerPath"] + "/swagger/v1.0/swagger.json", "NETCoreAPI");
                s.InjectStylesheet(conf["SwaggerPath"] + "/swagger/swagger-ui.css");
                s.DocumentTitle = ".NET Core API Template With MySQL - v1.0";
                s.DocExpansion(DocExpansion.None);
            });


            return app;
        }
    }
}
