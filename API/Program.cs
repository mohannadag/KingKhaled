using API.Extensions;
using API.Middleware;
using API.ViewModels.Nationality;
using Data.Context;
using Data.DataSeed;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                            })
                            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddSwaggerDocumentation();

            builder.Services.AddCors(options => 
            {
                options.AddPolicy("AllowAll", policy => policy
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowAnyOrigin());
            });

            //===================End Services======================

            var app = builder.Build();

            //builder.ConfigureWebHostDefaults(b => b.Configure(app => { }));

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.MapControllers();

            //================End Builder==========================

            //var hostUrl = builder.Configuration["HostUrl"]; // add this line
            //if (string.IsNullOrEmpty(hostUrl)) // add this line
            //    hostUrl = "http://0.0.0.0:5001"; // add this line

            //var host = new WebHostBuilder()
            //.UseKestrel()
            //.UseUrls(hostUrl)   // // add this line
            //.UseContentRoot(Directory.GetCurrentDirectory())
            //.UseIISIntegration()
            //.UseStartup<Program>()
            //.UseConfiguration(builder.Configuration)
            //.Build();

            //host.Run();

            // Data Seed
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();

                await context.Database.MigrateAsync();

                await Seed.SeedBanks(context);
                await Seed.SeedNationality(context);

                await Seed.SeedGrades(context);
                await Seed.SeedLevels(context);

                await Seed.SeedQualifications(context);
                await Seed.SeedJobVisa(context);

                await Seed.SeedJobGroupAndSubGroups(context);
                await Seed.SeedDepartmentAndBranchs(context);
                
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Error Occured During Migration");
            }

            await app.RunAsync();
        }
    }
}