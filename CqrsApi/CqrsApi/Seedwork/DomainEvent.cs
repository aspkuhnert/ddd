namespace Cto.Tutorial.CqrsApi.Seedwork
{
   public class DomainEvent
   {
      public Guid Id { get; }

      public DateTime OccurredOn { get; }

      public string EventName { get; }

      public string Data { get; }

      public DomainEvent(string eventName, string data)
      {
         Id = Guid.NewGuid();
         OccurredOn = DateTime.UtcNow;
         EventName = eventName;
         Data = data;
      }
   }
}
