// See https://aka.ms/new-console-template for more information
using Cto.Tutorial.CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

var host = CreateHostBuilder(args).Build();

BuildDatabase(host.Services, "scope 1");

await host.RunAsync();

static void BuildDatabase(IServiceProvider services, string scope)
{
   using IServiceScope serviceScope = services.CreateScope();
   IServiceProvider provider = serviceScope.ServiceProvider;

   var context = provider.GetRequiredService<TutorialContext>();

   try
   {
      context.Database.EnsureCreated();
      context.Database.Migrate();
      Console.WriteLine("Migrated!");
   }
   catch (Exception ex)
   {
      Console.WriteLine(ex.Message);
      return;
   }
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
           services.AddLogging();

           IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

           string connectionString = configuration.GetConnectionString("DefaultConnection");
           var serverVersion = ServerVersion.AutoDetect(connectionString);

           services.AddDbContext<TutorialContext>(options =>
           {
              options.UseMySql(
                 connectionString,
                 serverVersion,
                 options =>
                 {
                    options.MigrationsAssembly(typeof(TutorialContext).Assembly.GetName().Name);
                 });
           }, ServiceLifetime.Scoped);
        })
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
           var env = hostingContext.HostingEnvironment;

           config.AddEnvironmentVariables();
           config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        });