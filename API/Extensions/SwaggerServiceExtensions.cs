using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Genesis ERP API",
                    Version = "v1",
                    Description = "API for Testing Purpose Only.",
                    TermsOfService = new Uri("https://genesis-system.net/"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Genesis System",
                        Email = "info@@genesis-system.net",
                        Url = new Uri("https://genesis-system.net/")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Genesis System",
                        Url = new Uri("https://genesis-system.net/")
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTR Logistic API v1"));

            return app;
        }
    }
}
