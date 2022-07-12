namespace Cto.Tutorial.CqrsApi.Models
{
   public class Product
   {
      public Guid Id { get; private set; }

      public string Name { get; private set; }

      private Product()
      {
         Id = Guid.NewGuid(); 
      }

      private Product(Guid id, string name)
      {
         Id = id;
         Name = name;
      }

      public static Product Create()
      {
         return new Product();
      }

      public static Product Create(Guid id, string name) 
      { 
         return new Product(id, name); 
      }
   }
}
