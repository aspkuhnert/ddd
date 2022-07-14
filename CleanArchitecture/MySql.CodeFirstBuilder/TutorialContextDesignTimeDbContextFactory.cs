using Cto.Tutorial.CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.MySql.CodeFirstBuilder
{
   public class TutorialContextDesignTimeDbContextFactory :
      IDesignTimeDbContextFactory<TutorialContext>
   {
      public TutorialContext CreateDbContext(string[] args)
      {
         IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
         var connectionString = config.GetSection("ConnectionStrings")?.GetSection("DefaultConnection")?.Value;
         var serverVersion = ServerVersion.AutoDetect(connectionString);

         var optionsBuilder = new DbContextOptionsBuilder<TutorialContext>()
            .UseMySql(
                connectionString,
                serverVersion,
                options =>
                {
                   options
                     .MigrationsAssembly(typeof(TutorialContext).Assembly.GetName().Name);
                });

         return new TutorialContext(optionsBuilder.Options);
      }
   }
}
