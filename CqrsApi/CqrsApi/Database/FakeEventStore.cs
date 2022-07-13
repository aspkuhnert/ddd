using Cto.Tutorial.CqrsApi.Seedwork;

namespace Cto.Tutorial.CqrsApi.Database
{
   public class FakeEventStore
   {
      private static List<DomainEvent> _events;

      public FakeEventStore()
      {
         _events = new List<DomainEvent>();
      }

      public async Task AddEvent(DomainEvent domainEvent)
      {
         _events.Add(domainEvent);
         await Task.CompletedTask;
      }

      public async Task<IEnumerable<DomainEvent>> GetEvents() =>
         await Task.FromResult(_events);
   }
}
