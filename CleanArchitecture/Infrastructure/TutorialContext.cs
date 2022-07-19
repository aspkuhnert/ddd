using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure
{
   public class TutorialContext :
      DbContext,
      IUnitOfWork
   {
      private readonly IMediator _mediator;

      private readonly IServiceProvider _provider;

      public TutorialContext([NotNullAttribute] DbContextOptions<TutorialContext> options)
        : base(options)
      {
      }

      public TutorialContext([NotNullAttribute] DbContextOptions<TutorialContext> options, IMediator mediator, IServiceProvider provider)
         : base(options)
      {
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
         _provider = provider ?? throw new ArgumentNullException(nameof(provider));
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

      public async Task<bool> SaveChangesAndDispachEventsAsync(CancellationToken cancellationToken = default)
      {
         // dispatch events with mediator
         await _mediator.DispatchDomainEventsAsync(this, _provider);

         var result = await base.SaveChangesAsync(cancellationToken);

         return true;
      }
   }
}