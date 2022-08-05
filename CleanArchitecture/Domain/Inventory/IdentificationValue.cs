using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;

namespace Cto.Tutorial.CleanArchitecture.Domain.Inventory
{
   public class IdentificationValue :
      EntityBase
   {
      public IdentificationType Type { get; private set; }

      public int IdentificationTypeId { get; private set; }

      public CatalogItem CatalogItem { get; private set; }

      public Guid CatalogItemId { get; private set; }

      public string Value { get; private set; }

      private IdentificationValue()
      {
      }

      private IdentificationValue(CatalogItem catalogItem, IdentificationType type, string value)
      {
         CatalogItemId = catalogItem.Id;
         IdentificationTypeId = type.Id;
         Value = value;
      }

      public static IdentificationValue CreateSku(CatalogItem catalogItem, string value)
      {
         return new IdentificationValue(catalogItem, IdentificationType.Sku, value);
      }

      public static IdentificationValue CreateEanGtin(CatalogItem catalogItem, string value)
      {
         return new IdentificationValue(catalogItem, IdentificationType.EanGtin, value);
      }

      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}