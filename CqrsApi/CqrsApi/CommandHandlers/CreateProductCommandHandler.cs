using Cto.Tutorial.CqrsApi.Commands;
using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Models;
using MediatR;

namespace Cto.Tutorial.CqrsApi.CommandHandlers
{
   public class CreateProductCommandHandler :
      IRequestHandler<CreateProductCommand, Guid>
   {
      private readonly FakeDatabase _database;

      public CreateProductCommandHandler(FakeDatabase database) => _database = database;

      public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
      {
         var product = FromRequest(request.Product);
         await _database.AddProduct(product);

         return product.Id;
      }

      private Product FromRequest(CreateProductRequest request)
      {
         return Product.Create(Guid.NewGuid(), request.Name);
      }
   }
}
