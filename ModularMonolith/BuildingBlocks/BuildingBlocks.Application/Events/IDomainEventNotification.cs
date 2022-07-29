using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Events
{
   public interface IDomainEventNotification :
      INotification
   {
      Guid Id { get; }
   }
}