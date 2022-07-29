using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain
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