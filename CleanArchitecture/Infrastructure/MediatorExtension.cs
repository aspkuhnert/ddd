using Cto.Tutorial.CleanArchitecture.Application.Events;
using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks.DomainNotifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
         TutorialContext context,
         IServiceProvider provider
         )
      {
         var notificationLibrary = provider.GetService<IDomainNotificationsLibrary>();

         var domainEntities = context.ChangeTracker
             .Entries<EntityBase>()
             .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

         var domainEvents = domainEntities
             .SelectMany(x => x.Entity.DomainEvents)
             .ToList();

         var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();

         foreach (var domainEvent in domainEvents)
         {
            Type domainEvenNotificationType = typeof(IDomainEventNotification<>);
            Type domainNotificationWithGenericType = domainEvenNotificationType.MakeGenericType(domainEvent.GetType());

            try
            {
               var domainNotificationImplementationType = notificationLibrary.GetImplementationType(domainNotificationWithGenericType);

               if (domainNotificationImplementationType != null)
               {
                  var domainNotificationInstance = ActivatorUtilities.CreateInstance(provider, domainNotificationImplementationType, domainEvent, domainEvent.Id);

                  if (domainNotificationInstance != null)
                  {
                     domainEventNotifications.Add(domainNotificationInstance as IDomainEventNotification<IDomainEvent>);
                  }
               }
            }
            catch (Exception ex)
            {
               var x = ex;
            }
         }


         domainEntities
            .ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

         foreach (var domainEvent in domainEvents)
         {
            await mediator.Publish(domainEvent);
         }

         foreach (var domainEventNotification in domainEventNotifications)
         {
            await mediator.Publish(domainEventNotification);
         }
      }
   }
}
