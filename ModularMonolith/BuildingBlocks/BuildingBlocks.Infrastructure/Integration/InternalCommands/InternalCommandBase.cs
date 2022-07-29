namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.Integration.InternalCommands
{
   public abstract class InternalCommandBase
   {
      public Guid Id { get; }

      public DateTime OccurredOn { get; }

      public string ServiceType { get; }

      public string ImplementationType { get; }

      public string Data { get; }

      public DateTime? ProcessedOn { get; }

      public string Error { get; }

      protected InternalCommandBase(Guid id, DateTime occurredOn, string serviceType, string implementationType, string data)
      {
         Id = id;
         OccurredOn = occurredOn;
         ServiceType = serviceType;
         ImplementationType = implementationType;
         Data = data;
      }

      protected InternalCommandBase()
      {
      }
   }
}