using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Queries;
using Cto.Tutorial.CqrsApi.Seedwork;
using MediatR;

namespace Cto.Tutorial.CqrsApi.QueryHandlers
{
   public class GetDomainEventsQueryHandler :
      IRequestHandler<GetDomainEventsQuery, IEnumerable<DomainEvent>>
   {
      private readonly FakeEventStore _eventStore;

      public GetDomainEventsQueryHandler(FakeEventStore eventStore) =>
         _eventStore = eventStore;

      public async Task<IEnumerable<DomainEvent>> Handle(GetDomainEventsQuery request, CancellationToken cancellationToken)
      {
         return await _eventStore.GetEvents(); 
      }
   }
}
