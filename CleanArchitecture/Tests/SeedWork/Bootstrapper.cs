using Cto.Tutorial.CleanArchitecture.Application.BuildingBlocks.Persistence;
using Cto.Tutorial.CleanArchitecture.Application.Services;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Cto.Tutorial.CleanArchitecture.Infrastructure;
using Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks.DomainNotifications;
using Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks.Persistence;
using Cto.Tutorial.CleanArchitecture.Infrastructure.Domain.Sales;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Tests.SeedWork
{
   internal class Bootstrapper
   {
      public IConfigurationRoot Configuration => GetConfiguration();

      public IServiceProvider Services => GetServices();

      private IConfigurationRoot GetConfiguration()
      {
         IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

         return configuration;
      }

      private IServiceProvider GetServices()
      {
         var services = new ServiceCollection();

         // logging
         Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

         services.AddLogging(loggingBuilder =>
         {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
         });

         // mediator
         services.AddMediatR(
            typeof(IApplicationService).Assembly,
            typeof(ISalesOrderRepository).Assembly,
            typeof(TutorialContext).Assembly);

         // database
         var connectionString = Configuration.GetConnectionString("DefaultConnection");
         var serverVersion = ServerVersion.AutoDetect(connectionString);

         services
            .AddDbContext<TutorialContext>(options =>
            {
               options.UseMySql(connectionString, serverVersion);
               options.EnableDetailedErrors();
            });

         services.AddScoped<ISqlConnectionFactory>(service => new SqlConnectionFactory(connectionString));

         // domain notifications
         var library = new DomainNotificationsLibrary();
         services.AddSingleton<IDomainNotificationsLibrary>(library);

         // services
         services.AddTransient<ISalesOrderRepository, SalesOrderRepository>();

         services.AddTransient<IApplicationService, ApplicationService>();

         return services
            .BuildServiceProvider(false);
      }
   }
}
