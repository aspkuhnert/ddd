using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;

namespace Cto.Tutorial.CleanArchitecture.Domain.Inventory
{
   public class IdentificationType :
      Enumeration
   {
      public IdentificationType(int id, string name)
         : base(id, name)
      {
      }

      public static IdentificationType Sku = new IdentificationType(1, nameof(Sku).ToLowerInvariant());

      public static IdentificationType EanGtin = new IdentificationType(2, nameof(EanGtin).ToLowerInvariant());

      public static IdentificationType Asin = new IdentificationType(3, nameof(Asin).ToLowerInvariant());

      public static IdentificationType ManufacturerIdNo = new IdentificationType(4, nameof(ManufacturerIdNo).ToLowerInvariant());

      public static IEnumerable<IdentificationType> List() =>
         new[] { Sku, EanGtin, Asin, ManufacturerIdNo };
   }
}