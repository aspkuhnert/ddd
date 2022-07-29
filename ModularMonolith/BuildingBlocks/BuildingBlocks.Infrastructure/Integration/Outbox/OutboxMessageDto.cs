namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.Integration.Outbox
{
   public class OutboxMessageDto
   {
      public Guid Id { get; set; }

      public string ServiceType { get; set; }

      public string ImplementationType { get; set; }

      public string Data { get; set; }
   }
}