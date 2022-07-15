using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Events
{
   public interface IDomainEventNotification :
      INotification
   {
      Guid Id { get; }
   }
}