using Cto.Tutorial.CqrsApi.Commands;
using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Models;
using MediatR;

namespace Cto.Tutorial.CqrsApi.CommandHandlers
{
   public class CreateProductCommandHandler :
      IRequestHandler<CreateProductCommand, ProductView>
   {
      private readonly FakeDatabase _database;

      public CreateProductCommandHandler(FakeDatabase database) => _database = database;

      public async Task<ProductView> Handle(CreateProductCommand request, CancellationToken cancellationToken)
      {
         var product = FromRequest(request.Product);
         await _database.AddProduct(product);

         return ViewFromRequest(request.Product);
      }

      private Product FromRequest(CreateProductRequest request)
      {
         return Product.Create(Guid.NewGuid(), request.Name);
      }

      private ProductView ViewFromRequest(CreateProductRequest request)
      {
         return new ProductView() { Id = Guid.NewGuid(), Name = request.Name };
      }
   }
}
