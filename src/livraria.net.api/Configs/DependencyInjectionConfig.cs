using livraria.net.core.Contracts;
using livraria.net.core.Notificator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace livraria.net.api.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResoveDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<INotificator, NotificatorHandler>();

            return services;
        }
    }
}
