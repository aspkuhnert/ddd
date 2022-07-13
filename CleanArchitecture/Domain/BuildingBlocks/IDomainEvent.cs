using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public interface IDomainEvent :
      INotification
   {
      Guid Id { get; }

      string ModelId { get; }

      DateTime OccurredOn { get; }

      int Version { get; }
   }
}