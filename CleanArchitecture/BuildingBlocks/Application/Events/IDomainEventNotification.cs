using MediatR;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Events
{
   public interface IDomainEventNotification :
      INotification
   {
      Guid Id { get; }
   }
}