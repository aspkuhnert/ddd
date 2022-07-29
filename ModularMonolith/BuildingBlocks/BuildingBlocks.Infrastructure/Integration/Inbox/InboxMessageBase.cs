namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.Integration.Inbox
{
   public abstract class InboxMessageBase
   {
      public Guid Id { get; }

      public DateTime OccurredOn { get; }

      public string ServiceType { get; }

      public string ImplementationType { get; }

      public string Data { get; }

      public DateTime? ProcessedOn { get; }

      protected InboxMessageBase(Guid id, DateTime occurredOn, string serviceType, string implementationType, string data)
      {
         Id = id;
         OccurredOn = occurredOn;
         ServiceType = serviceType;
         ImplementationType = implementationType;
         Data = data;
      }

      protected InboxMessageBase()
      {
      }
   }
}