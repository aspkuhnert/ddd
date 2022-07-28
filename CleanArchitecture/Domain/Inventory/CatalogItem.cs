using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Inventory
{
   public class CatalogItem :
      EntityBase,
      IAggregateRoot
   {
      public Guid Id { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public decimal Price { get; set; }

      public List<IdentificationValue> IdentificationValues { get; set; }

      private CatalogItem()
      {
         Id = Guid.NewGuid();
         IdentificationValues = new List<IdentificationValue>();
      }

      public CatalogItem Create()
      {
         var item = new CatalogItem();

         return item;
      }

      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}