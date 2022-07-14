using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure
{
   public class TutorialContext :
      DbContext,
      IUnitOfWork
   {
      public TutorialContext([NotNullAttribute] DbContextOptions<TutorialContext> options)
        : base(options)
      {
      }

      public DbSet<SalesOrder> SalesOrders { get; set; }

      public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

      public DbSet<SalesOrderStatus> SalesOrderInternStatus { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(TutorialContext).Assembly);
         modelBuilder.Seed();

         base.OnModelCreating(modelBuilder);
      }

      public Task<bool> SaveChangesAndDispachEventsAsync(CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
