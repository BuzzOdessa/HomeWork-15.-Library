using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Подключение всех сервисов инфраструктуры  к медиатору.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //services.AddScoped<ILibraryRepository, LibraryRepository>();
//            services.AddScoped<IUnitOfWork, UnitOfWork>();
/*            services.AddScoped<ILibraryRepository, LibraryEFCoreRepository>();
            services.AddScoped<IOwnersRepository, OwnersRepository>();
*/        }
    }
}
