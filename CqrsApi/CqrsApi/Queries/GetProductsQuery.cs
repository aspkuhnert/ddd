using Cto.Tutorial.CqrsApi.Models;
using MediatR;

namespace Cto.Tutorial.CqrsApi.Queries
{
   public record GetProductsQuery :
      IRequest<IEnumerable<ProductView>>;
}
