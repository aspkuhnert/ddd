using Cto.Tutorial.CqrsApi.Seedwork;
using MediatR;

namespace Cto.Tutorial.CqrsApi.Queries
{
   public record GetDomainEventsQuery :
      IRequest<IEnumerable<DomainEvent>>;
}
