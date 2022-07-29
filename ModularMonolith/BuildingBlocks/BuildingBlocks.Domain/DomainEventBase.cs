namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain
{
   public class DomainEventBase :
      IDomainEvent
   {
      public Guid Id { get; }

      public DateTime OccurredOn { get; }

      public string ModelId { get; protected set; }

      public int Version { get; protected set; }

      public DomainEventBase()
      {
         Id = Guid.NewGuid();
         OccurredOn = DateTime.UtcNow;
         Version = 1;
      }
   }
}