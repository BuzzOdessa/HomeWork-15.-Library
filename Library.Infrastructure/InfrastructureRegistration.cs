using System.Reflection;
using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Common;
using Library.Infrastructure.Application.Domain.Books.Checkers;
using Library.Infrastructure.Common;
using Library.Infrastructure.Core.Domain.Authors;
using Library.Infrastructure.Core.Domain.Books;
using Library.Infrastructure.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Подключение всех сервисов инфраструктуры  к медиатору.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IBookRepository, BooksEFCoreRepository>();
            services.AddScoped<IAuthorRepository, AuthorsEFCoreRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISerialNumUniqueChecker, SerialNumUniqueChecker>();

            services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
            services.AddSingleton<IExceptionToResponseDeveloperMapper, ExceptionToResponseDeveloperMapper>();
            /*services.AddTransient<ExceptionHandlerDeveloperMiddleware>();
            services.AddTransient<ExceptionHandlerMiddleware>();*/
        }
    }
}
