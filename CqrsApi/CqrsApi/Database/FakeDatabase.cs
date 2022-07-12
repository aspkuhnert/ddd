using Cto.Tutorial.CqrsApi.Models;

namespace Cto.Tutorial.CqrsApi.Database
{
   public class FakeDatabase
   {
      private static List<Product> _products;

      public FakeDatabase()
      {
         _products = new List<Product>();

         _products.Add(Product.Create(Guid.NewGuid(), "Laptop 4711"));
         _products.Add(Product.Create(Guid.NewGuid(), "Kopfhörer 0815"));
         _products.Add(Product.Create(Guid.NewGuid(), "T-Shirt XYZ"));
      }

      public async Task AddProduct(Product product)
      {
         _products.Add(product);
         await Task.CompletedTask;
      }

      public async Task<IEnumerable<Product>> GetAllProducts() => 
         await Task.FromResult(_products);

      public async Task<Product> GetProductById(Guid id) =>
         await Task.FromResult(_products.Single(p => p.Id == id));
   }
}
