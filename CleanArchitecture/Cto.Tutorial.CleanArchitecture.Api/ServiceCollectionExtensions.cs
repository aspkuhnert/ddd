using Cto.Tutorial.CleanArchitecture.Application.BuildingBlocks.Persistence;
using Cto.Tutorial.CleanArchitecture.Application.Services;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Cto.Tutorial.CleanArchitecture.Infrastructure;
using Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks.DomainNotifications;
using Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks.Persistence;
using Cto.Tutorial.CleanArchitecture.Infrastructure.Domain.Sales;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cto.Tutorial.CleanArchitecture.Api
{
   internal static class ServiceCollectionExtensions
   {
      public static IServiceCollection AddMediator(this IServiceCollection services)
      {
         services.AddMediatR(
            typeof(IApplicationService).Assembly,
            typeof(ISalesOrderRepository).Assembly,
            typeof(TutorialContext).Assembly);

         return services;
      }

      public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
      {
         var connectionString = configuration.GetConnectionString("DefaultConnection");
         var serverVersion = ServerVersion.AutoDetect(connectionString);

         services.AddDbContext<TutorialContext>(options => options.UseMySql(connectionString, serverVersion));

         services.AddScoped<ISqlConnectionFactory>(service => new SqlConnectionFactory(connectionString));

         return services;
      }

      public static IServiceCollection AddDomainEventNotificationLibrary(this IServiceCollection services)
      {
         var library = new DomainNotificationsLibrary();

         // Sales
         //library.AddNotification(typeof(IDomainEventNotification<SalesOrderStartedDomainEvent>), typeof(SalesOrderDraftCreatedNotification));

         // Customers

         services.AddSingleton<IDomainNotificationsLibrary>(library);

         return services;
      }

      public static IServiceCollection AddServices(this IServiceCollection services)
      {
         services.AddTransient<ISalesOrderRepository, SalesOrderRepository>();

         services.AddTransient<IApplicationService, ApplicationService>();

         return services;
      }
   }
}
