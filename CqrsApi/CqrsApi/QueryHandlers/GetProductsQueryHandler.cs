using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Models;
using Cto.Tutorial.CqrsApi.Queries;
using MediatR;
using System.Linq;

namespace Cto.Tutorial.CqrsApi.QueryHandlers
{
   public class GetProductsQueryHandler :
      IRequestHandler<GetProductsQuery, IEnumerable<ProductView>>
   {
      private readonly FakeDatabase _database;

      public GetProductsQueryHandler(FakeDatabase database) => _database = database;

      public async Task<IEnumerable<ProductView>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
      {
         return _database.GetAllProducts().Result.Select(x => FromProduct(x));
      }

      private ProductView FromProduct(Product product)
      {
         return new ProductView() { Id = Guid.NewGuid(), Name = product.Name };
      }
   }
}
