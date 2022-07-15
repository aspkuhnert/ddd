using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure
{
   internal static class MediatorExtension
   {
      public static async Task DispatchDomainEventsAsync(
         this IMediator mediator,
         TutorialContext context)
      {
         var domainEntities = context.ChangeTracker
             .Entries<EntityBase>()
             .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

         var domainEvents = domainEntities
             .SelectMany(x => x.Entity.DomainEvents)
             .ToList();

         domainEntities
            .ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

         foreach (var domainEvent in domainEvents)
         {
            await mediator.Publish(domainEvent);
         }
      }
   }
}
