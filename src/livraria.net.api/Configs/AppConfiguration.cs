using FluentValidation.AspNetCore;
using livraria.net.infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json.Serialization;

namespace livraria.net.api.Configs
{
    public static class AppConfiguration
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            var server = configuration.GetSection("Variables:DbServer").Value ?? "localhost";
            //server = "localhost,1430";
            var user = configuration.GetSection("Variables:DbUser").Value ?? "SA"; // Warning do not use the SA account
            var password = configuration.GetSection("Variables:Password").Value ?? "numsey#2021";
            var database = configuration.GetSection("Variables:Database").Value ?? "livrarianet";
            var connectionString = $"Server={server};Initial Catalog={database};User ID={user};Password={password}";
            services.AddDbContext<ApiDbContext>(options => {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddControllersWithViews().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                o.JsonSerializerOptions.MaxDepth = 0;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.ResoveDependencyInjection(configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers().AddNewtonsoftJson(); 

            //services.AddControllers()
            //    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StartupApiTests>());

            services.AddSwaggerConfiguration();

            return services;
        }

        public static IApplicationBuilder UseAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseConfiguracaoSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           //DatabaseManagementService.MigrationInitialisation(app);

            return app;
        }

        public static class DatabaseManagementService
        {
            // Getting the scope of our database context
            public static void MigrationInitialisation(IApplicationBuilder app)
            {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    // Takes all of our migrations files and apply them against the database in case they are not implemented
                    serviceScope.ServiceProvider.GetService<ApiDbContext>().Database.Migrate();
                }
            }
        }
    }
}
