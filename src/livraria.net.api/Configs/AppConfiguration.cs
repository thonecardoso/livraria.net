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

namespace livraria.net.api.Configs
{
    public static class AppConfiguration
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Api-StringBd-Postgres"), o =>
                {
                    o.EnableRetryOnFailure();
                });

                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.ResoveDependencyInjection(configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers();

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

            return app;
        }
    }
}
