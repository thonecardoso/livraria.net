using livraria.net.core.Contracts;
using livraria.net.core.Notificator;
using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Services;
using livraria.net.infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace livraria.net.api.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResoveDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<INotificator, NotificatorHandler>();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<AuthorService>();
            services.AddScoped<BookService>();
            services.AddScoped<PublisherService>();
            services.AddScoped<UserService>();

            return services;
        }
    }
}
