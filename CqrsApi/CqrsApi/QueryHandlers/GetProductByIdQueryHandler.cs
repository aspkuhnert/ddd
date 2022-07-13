using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Models;
using Cto.Tutorial.CqrsApi.Queries;
using MediatR;

namespace Cto.Tutorial.CqrsApi.QueryHandlers
{
   public class GetProductByIdQueryHandler :
      IRequestHandler<GetProductByIdQuery, ProductView>
   {
      private readonly FakeDatabase _database;

   public GetProductByIdQueryHandler(FakeDatabase database) => _database = database;

   public async Task<ProductView> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
   {
      return FromProduct(_database.GetProductById(request.id).Result);
   }

   private ProductView FromProduct(Product product)
   {
      return new ProductView() { Id = Guid.NewGuid(), Name = product.Name };
   }
}
}
