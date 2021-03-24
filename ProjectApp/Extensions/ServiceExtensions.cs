using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using References;
using Repository;

namespace ProjectApp.Extensions
{
    /// <summary>
    /// Все сервисы
    /// </summary>
    public static class ServiceExtensions
    {
        //подключения механизма CORS
        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
                  builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
          });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        //сервис логгирования
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
       
        //сервис подключения бд
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<CarServiceContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("CarServiceContext")));
        
        //сервис репозитория-менеджера
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
