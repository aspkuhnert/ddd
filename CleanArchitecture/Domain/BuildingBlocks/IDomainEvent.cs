using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public interface IDomainEvent :
      INotification
   {
      Guid Id { get; }

      DateTime OccurredOn { get; }
   }
}