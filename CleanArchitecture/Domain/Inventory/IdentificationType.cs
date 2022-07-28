using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Inventory
{
   public class IdentificationType :
      Enumeration
   {
      public IdentificationType(int id, string name)
         : base(id, name)
      {
         //IdentificationValues = new List<IdentificationValue>();
      }

      public static IdentificationType Sku = new IdentificationType(1, nameof(Sku).ToLowerInvariant());

      public static IdentificationType EanGtin = new IdentificationType(2, nameof(EanGtin).ToLowerInvariant());

      public static IdentificationType Asin = new IdentificationType(3, nameof(Asin).ToLowerInvariant());

      public static IdentificationType ManufacturerIdNo = new IdentificationType(4, nameof(ManufacturerIdNo).ToLowerInvariant());

      public static IEnumerable<IdentificationType> List() =>
         new[] { Sku, EanGtin, Asin, ManufacturerIdNo };

      //public List<IdentificationValue> IdentificationValues { get; set; }
   }
}
