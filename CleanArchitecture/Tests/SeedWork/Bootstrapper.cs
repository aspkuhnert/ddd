using Cto.Tutorial.CleanArchitecture.Infrastructure;
using Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks;
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
         Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

         var services = new ServiceCollection();

         services.AddLogging(loggingBuilder =>
         {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
         });

         var connectionString = Configuration.GetConnectionString("DefaultConnection");
         var serverVersion = ServerVersion.AutoDetect(connectionString);

         services
            .AddDbContext<TutorialContext>(options =>
            {
               options.UseMySql(connectionString, serverVersion);
               options.EnableDetailedErrors();
            });

         var library = new DomainNotificationsLibrary();
         services.AddSingleton<IDomainNotificationsLibrary>(library);

         return services
            .BuildServiceProvider(false);
      }
   }
}
