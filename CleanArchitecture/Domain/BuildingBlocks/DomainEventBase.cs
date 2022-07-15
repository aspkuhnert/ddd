namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public class DomainEventBase :
      IDomainEvent
   {
      public Guid Id { get; }

      public DateTime OccurredOn { get; }

      public DomainEventBase()
      {
         Id = Guid.NewGuid();
         OccurredOn = DateTime.UtcNow;
      }
   }
}