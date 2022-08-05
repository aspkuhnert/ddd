using MediatR;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain
{
   public interface IDomainEvent :
      INotification
   {
      Guid Id { get; }

      DateTime OccurredOn { get; }
   }
}